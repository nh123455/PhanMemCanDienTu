using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using DevExpress.XtraSplashScreen;
using System.Data.SqlClient;
using Can.BUS;
using Can.GUI.CustomUserControl;
using Can.GUI.MauIn;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Data.SQLite;
using Can.DTO;
using System.Linq;
using ImageMagick;

namespace Can.GUI
{
    public partial class frmMain : Form
    {
        private SerialPort serialPort;

        #region Khai báo lớp BUS
        PhieuCanBUS pcBUS = new PhieuCanBUS();
        baseBUS baseBUS = new baseBUS();
        LoaiHangBUS lhBUS = new LoaiHangBUS();
        NguoiDungBUS ndBUS = new NguoiDungBUS();
        DiemCanBUS dcBUS = new DiemCanBUS();
        #endregion
        #region Khai báo Rstp Camera
        string rtsp1;
        string rtsp2;
        string rtsp3;
        bool statusInsert;
        #endregion
        #region Khai báo cổng COM
        string portName;
        Int32 baudRate;
        Int32 dataBits;
        #endregion
        #region Khai báo lớp DTO
        PhieuCanDTO pcDTO = new PhieuCanDTO();
        baseDTO baseDTO = new baseDTO();
        TaiKhoanDTO tkDTO = new TaiKhoanDTO();
        #endregion

        private char char_0 = '+';
        string string_2, string_3;
        decimal decimal_0;
        string scaleType;
        int quality = 0;
        public frmMain()
        {
            InitializeComponent();
            if (Properties.Settings.Default.scaleType == true)
            {
                scaleType = "Cân Online";
            }
            else scaleType = "Cân Offline";
            this.Text = "Phần mềm cân" + $" - {Properties.Settings.Default.NhanVien}" + $" - {scaleType}";
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm("Đang tải phần mềm", "Loading... ");
                timer1.Start();
                #region Menu Click
                menuThongKeDuLieu.Click += MenuThongKeDuLieu_Click;
                menuCongTy.Click += MenuCongTy_Click;
                menuTaiKhoan.Click += MenuTaiKhoan_Click;
                menuCOM.Click += MenuCOM_Click;
                menuCamera.Click += MenuCamera_Click;
                menuMachine.Click += MenuMachine_Click;
                menuConnect.Click += MenuConnect_Click;
                menuLoaiHang.Click += MenuLoaiHang_Click;
                menuDuLieuOffline.Click += MenuDuLieuOffline_Click;
                menuDanhSachDiemCan.Click += MenuDanhSachDiemCan_Click;
                //menuInternet.Click += MenuInternet_Click;
                #endregion
                #region Sự kiện check kiểu cân
                ckNhap.CheckedChanged += CkNhap_CheckedChanged;
                ckXuat.CheckedChanged += CkXuat_CheckedChanged;
                ckDichVu.CheckedChanged += CkDichVu_CheckedChanged;
                #endregion

                #region Vẽ số thứ tự Gridview
                gvPhieuCan1.CustomDrawRowIndicator += GvPhieuCan1_CustomDrawRowIndicator;
                gvPhieuCan2.CustomDrawRowIndicator += GvPhieuCan2_CustomDrawRowIndicator;
                #endregion
                #region Gridview cân doubleclick
                gvPhieuCan1.DoubleClick += GvPhieuCan1_DoubleClick;
                gvPhieuCan2.DoubleClick += GvPhieuCan2_DoubleClick;
                #endregion
                #region Button cân click
                btnCanLan1.Click += BtnCanLan1_Click;
                btnCanLan2.Click += BtnCanLan2_Click;
                btnLapPhieu.Click += BtnLapPhieu_Click;
                btnInPhieu.Click += BtnInPhieu_Click;
                #endregion            

                ctCanLan2.Click += CtCanLan2_Click;
                ctInPhieuCan1.Click += CtInPhieuCan1_Click;
                ctInPhieu.Click += CtInPhieu_Click;
                ctChiTietPhieu.Click += CtChiTietPhieu_Click;

                tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
                glkMaHang.EditValueChanged += GlkMaHang_EditValueChanged;
                this.FormClosing += FrmMain_FormClosing;

                
                if (Properties.Settings.Default.scaleType == true)
                {
                    LoadPhieuCanLan1();
                    GetThongTinCan();
                }
                else
                {
                    LoadPhieuCanLan1();
                    GetThongTinCanOffline();
                }
                LoadThongTinDiemCan();
                #region Kiểm tra quyền của User --> hiện menu chức năng
                if (baseBUS.LoadQuyenUser() == false)
                {
                    menuCongTy.Visible = false;
                    menuTaiKhoan.Visible = false;
                    menuMachine.Visible = false;
                    menuLoaiHang.Visible = false;

                    menuCOM.Visible = false;
                    menuCamera.Visible = false;
                    menuConnect.Visible = false;
                    menuDanhSachDiemCan.Visible = false;
                }
                #endregion

                LoadRstp();
                LoadCom();
                SetCom();
                Camera1();
                Camera2();
                Camera3();
                SplashScreenManager.CloseDefaultWaitForm();
                OpenComPort();

                
            }
            catch(Exception ex)
            {
                SplashScreenManager.CloseDefaultWaitForm();
                MessageBox.Show(ex.ToString());
            }
            
        }
        #region Show Form ds điểm cân
        private void MenuDanhSachDiemCan_Click(object sender, EventArgs e)
        {
            DanhSachDiemCanForm frm = new DanhSachDiemCanForm();
            frm.ShowDialog();
        }
        #endregion

        #region Load thông tin điểm cân
        public void LoadThongTinDiemCan()
        {
            if(Properties.Settings.Default.scaleType == true)
            {
                DiemCanDTO item = new DiemCanDTO();
                item = dcBUS.GetThongTinDiemCan(Properties.Settings.Default.connectString, baseBUS.GetMac());
                if(item.SoMay == 0)
                {
                    MessageBox.Show("Chưa cài đặt thông tin điểm cân, vui lòng cài đặt trước khi cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } 
                else
                {
                    Properties.Settings.Default.Machine_Name = item.SoMay;
                    Properties.Settings.Default.Save();
                }                 
            } 
            else
            {
                DiemCanDTO item = new DiemCanDTO();
                item = dcBUS.GetThongTinDiemCanOff(baseBUS.GetMac());
                if (item.SoMay == 0)
                {
                    MessageBox.Show("Chưa cài đặt thông tin điểm cân, vui lòng cài đặt trước khi cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Properties.Settings.Default.Machine_Name = item.SoMay;
                    Properties.Settings.Default.Save();
                }
            }    
        }
        #endregion

        #region Sự kiện contextmenuStrip In phiếu cân lần 1
        private void CtInPhieuCan1_Click(object sender, EventArgs e)
        {
            PhieuCanDTO item = gvPhieuCan1.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PhieuCanXe report = new PhieuCanXe(item.SoPhieu, item.LanCan);
            ViewReportForm frm = new ViewReportForm(report);
            //frm.Show();
        }
        #endregion

        #region Sự kiện contextmenuStrip In phiếu
        private void CtInPhieu_Click(object sender, EventArgs e)
        {
            PhieuCanDTO item = gvPhieuCan2.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PhieuCanXe report = new PhieuCanXe(item.SoPhieu, item.LanCan);
            ViewReportForm frm = new ViewReportForm(report);
            //frm.Show();
        }
        #endregion

        #region Sự kiện contextmenuStrip chi tiết phiếu
        private void CtChiTietPhieu_Click(object sender, EventArgs e)
        {
            PhieuCanDTO item = gvPhieuCan2.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PhieuCanChiTietForm frm = new PhieuCanChiTietForm(this, item);
                frm.ShowDialog();
            }
        }
        #endregion

        #region Sự kiện contextmenuStrip cân lần 2
        private void CtCanLan2_Click(object sender, EventArgs e)
        {
            PhieuCanDTO item = gvPhieuCan1.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (item.LanCan == 2)
            {
                MessageBox.Show("Phiếu cân đã cân xong lần cân thứ 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Cân phiếu: {item.SoPhieu} lần 2?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CanLan2(item);
            }
        }
        #endregion

        #region Lấy thông tin cân lần 1 cân tiếp
        public void CanLan2(PhieuCanDTO item)
        {
            try
            {
                ResetControl();
                pcDTO = item;
                txtSoPhieuCan.Text = item.SoPhieu;
                glkBienSoXe.SelectedText = item.BienSoXe;
                glkNguoiBan.SelectedText = item.NguoiBan;
                glkNguoiMua.SelectedText = item.NguoiMua;
                glkLaiXe.SelectedText = item.LaiXe;
                glkMaHang.SelectedText = item.MaHang;
                txtTenHang.Text = item.TenHang;
                glkKhoHang.SelectedText = item.KhoHang;
                txtGhiChu.Text = item.GhiChu;

                if (item.KieuCan == "Nhập") ckNhap.Checked = true;
                else if (item.KieuCan == "Xuất") ckXuat.Checked = true;
                else if (item.KieuCan == "Dịch Vụ") ckDichVu.Checked = true;

                txtKhoiLuongCan1.Text = item.KhoiLuongCan1.ToString();
                txtTGCanLan1.Text = item.ThoiGianCan1.ToString();

                btnCanLan1.Enabled = false;
                btnCanLan2.Enabled = true;
            }
            catch
            {

            }          
        }
        #endregion

        #region Vẽ ảnh từ Panel
        private Image Picture_Cam(PanelControl Cam)
        {
            System.Drawing.Image ret = null;
            try
            {
                // take picture BEFORE saveFileDialog pops up!!
                Bitmap bitmap = new Bitmap(Cam.Width, Cam.Height);
                {
                    Graphics g = Graphics.FromImage(bitmap);
                    {
                        Graphics gg = Cam.CreateGraphics();
                        {
                            //timerTakePicFromVideo.Start();
                            this.BringToFront();
                            g.CopyFromScreen(
                                Cam.PointToScreen(new System.Drawing.Point()).X,
                                Cam.PointToScreen(new System.Drawing.Point()).Y,
                                0, 0,
                                new System.Drawing.Size(Cam.Width, Cam.Height)
                                );
                        }
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ret = System.Drawing.Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return ret;
        }
        #endregion

        #region Chuyển từ kiểu ảnh sang byte
        private byte[] converImgToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Byte[] bytBLOBData = new Byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytBLOBData, 0, Convert.ToInt32(ms.Length));
            return bytBLOBData;
        }
        #endregion

        #region Play camera 1
        void Camera1()
        {
            Cam1.playlist.items.clear();
            Cam1.playlist.add(rtsp1);
            Cam1.playlist.play();

        }
        #endregion

        #region Play camera 2
        void Camera2()
        {
            Cam2.playlist.items.clear();
            Cam2.playlist.add(rtsp2);
            //Cam2.video.aspectRatio = "16:10";
            Cam2.playlist.play();
        }
        #endregion

        #region Play camera 3
        void Camera3()
        {
            Cam3.playlist.items.clear();
            Cam3.playlist.add(rtsp3);
            //Cam2.video.aspectRatio = "16:10";
            Cam3.playlist.play();
        }
        #endregion

        #region Thông tin phiếu cân
        public void GetThongTinCan()
        {
            List<BienSoDTO> bienSoXe = new List<BienSoDTO>();
            List<LaiXeDTO> laiXe = new List<LaiXeDTO>();
            List<NguoiBanDTO> nguoiBan = new List<NguoiBanDTO>();
            List<NguoiMuaDTO> nguoiMua = new List<NguoiMuaDTO>();
            List<KhoHangDTO> khoHang = new List<KhoHangDTO>();
            List<LoaiHangDTO> maHang = new List<LoaiHangDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connectString))
                {
                    connection.Open();
                    string queryBienSo = "select Distinct BienSoXe from E_PhieuCan where BienSoXe != ''";
                    string queryLaiXe = "select Distinct LaiXe from E_PhieuCan where LaiXe != ''";
                    string queryNguoiBan = "select Distinct NguoiBan from E_PhieuCan where NguoiBan != ''";
                    string queryNguoiMua = "select Distinct NguoiMua from E_PhieuCan where NguoiMua != ''";
                    string queryKhoHang = "select Distinct KhoHang from E_PhieuCan where KhoHang != ''";
                    string queryMaHang = "select * from E_LoaiHang ";

                    using (SqlCommand command = new SqlCommand(queryBienSo, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BienSoDTO obj = new BienSoDTO();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                bienSoXe.Add(obj);
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand(queryLaiXe, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LaiXeDTO obj = new LaiXeDTO();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                laiXe.Add(obj);
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand(queryNguoiBan, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NguoiBanDTO obj = new NguoiBanDTO();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                nguoiBan.Add(obj);
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand(queryNguoiMua, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NguoiMuaDTO obj = new NguoiMuaDTO();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                nguoiMua.Add(obj);
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand(queryKhoHang, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KhoHangDTO obj = new KhoHangDTO();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                khoHang.Add(obj);
                            }
                        }
                    }
                    using (SqlCommand command = new SqlCommand(queryMaHang, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoaiHangDTO obj = new LoaiHangDTO();
                                obj.id =Convert.ToInt32((reader["id"]));
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                maHang.Add(obj);
                            }
                        }
                    }
                    BienSoBindingSource.DataSource = bienSoXe;                 
                    NguoiBanBindingSource.DataSource = nguoiBan;
                    NguoiMuaBindingSource.DataSource = nguoiMua;
                    LaiXeBindingSource.DataSource = laiXe;
                    KhoHangBindingSource.DataSource = khoHang;
                    MaHangBindingSource.DataSource = maHang;
                }
            }
            catch (Exception ex)
            {
                new List<BienSoDTO>();          
                new List<NguoiBanDTO>();
                new List<NguoiMuaDTO>();
                new List<LaiXeDTO>();
                new List<KhoHangDTO>();
                new List<LoaiHangDTO>();
            }
        }

        #endregion

        #region Thông tin phiếu cân Sqlite
        public void GetThongTinCanOffline()
        {
            List<BienSoDTO> bienSoXe = new List<BienSoDTO>();
            List<LaiXeDTO> laiXe = new List<LaiXeDTO>();
            List<NguoiBanDTO> nguoiBan = new List<NguoiBanDTO>();
            List<NguoiMuaDTO> nguoiMua = new List<NguoiMuaDTO>();
            List<KhoHangDTO> khoHang = new List<KhoHangDTO>();
            List<LoaiHangDTO> maHang = new List<LoaiHangDTO>();
            try
            {
                string sqliteConnectionString = @"Data source =Config\SAMCO.db";
                using (SQLiteConnection connecttion = new SQLiteConnection(sqliteConnectionString))
                {
                    connecttion.Open();
                    string queryBienSo = "select Distinct BienSoXe from E_PhieuCan where BienSoXe != ''";
                    string queryLaiXe = "select Distinct LaiXe from E_PhieuCan where LaiXe != ''";
                    string queryNguoiBan = "select Distinct NguoiBan from E_PhieuCan where NguoiBan != ''";
                    string queryNguoiMua = "select Distinct NguoiMua from E_PhieuCan where NguoiMua != ''";
                    string queryKhoHang = "select Distinct KhoHang from E_PhieuCan where KhoHang != ''";
                    string queryMaHang = "select * from E_LoaiHang ";

                    using (SQLiteCommand command = new SQLiteCommand(queryBienSo, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BienSoDTO obj = new BienSoDTO();
                                obj.BienSoXe = (reader["BienSoXe"]).ToString();
                                bienSoXe.Add(obj);
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand(queryLaiXe, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LaiXeDTO obj = new LaiXeDTO();
                                obj.LaiXe = (reader["LaiXe"]).ToString();
                                laiXe.Add(obj);
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand(queryNguoiBan, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NguoiBanDTO obj = new NguoiBanDTO();
                                obj.NguoiBan = (reader["NguoiBan"]).ToString();
                                nguoiBan.Add(obj);
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand(queryNguoiMua, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NguoiMuaDTO obj = new NguoiMuaDTO();
                                obj.NguoiMua = (reader["NguoiMua"]).ToString();
                                nguoiMua.Add(obj);
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand(queryKhoHang, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KhoHangDTO obj = new KhoHangDTO();
                                obj.KhoHang = (reader["KhoHang"]).ToString();
                                khoHang.Add(obj);
                            }
                        }
                    }
                    using (SQLiteCommand command = new SQLiteCommand(queryMaHang, connecttion))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LoaiHangDTO obj = new LoaiHangDTO();
                                obj.id = Convert.ToInt32((reader["id"]));
                                obj.MaHang = (reader["MaHang"]).ToString();
                                obj.TenHang = (reader["TenHang"]).ToString();
                                maHang.Add(obj);
                            }
                        }
                    }
                    BienSoBindingSource.DataSource = bienSoXe;
                    NguoiBanBindingSource.DataSource = nguoiBan;
                    NguoiMuaBindingSource.DataSource = nguoiMua;
                    LaiXeBindingSource.DataSource = laiXe;
                    KhoHangBindingSource.DataSource = khoHang;
                    MaHangBindingSource.DataSource = maHang;
                }
            }
            catch (Exception ex)
            {
                new List<BienSoDTO>();
                new List<NguoiBanDTO>();
                new List<NguoiMuaDTO>();
                new List<LaiXeDTO>();
                new List<KhoHangDTO>();
                new List<LoaiHangDTO>();
            }
        }

        #endregion

        #region Cân
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                base.Invoke(new EventHandler(this.method_41));
            }
            catch
            {
            }
        }
        private void method_41(object sender, EventArgs e)
        {
            string_2 = serialPort.ReadExisting();
            try
            {
                if (this.string_2.IndexOf(this.char_0) != -1)
                {
                    this.string_3 = this.string_2.Replace("\r\n", "");
                    this.decimal_0 = Convert.ToDecimal(this.string_3.Substring(2, 6));
                    this.lbcan.Text = this.decimal_0.ToString();
                }
            }
            catch
            {
                this.lbcan.Text = string.Empty;
            }
        }
        #endregion

        #region Chuyển ảnh từ Jpg -> byte[]
        public byte[] CompressImage(byte[] originalImageBytes, int quality)
        {
            using (var image = new MagickImage(originalImageBytes))
            {
                // Thiết lập chất lượng nén (quality)
                image.Quality = quality;

                // Chuyển đổi ảnh về định dạng JPEG để nén (nếu ảnh gốc là PNG chẳng hạn)
                image.Format = MagickFormat.Jpeg;

                // Convert ảnh nén về dạng mảng byte và trả về
                return image.ToByteArray();
            }
        }
        #endregion

        #region Chụp ảnh, lấy hình ảnh từ folder, chuyển thành byte[], xóa hình ảnh
        void GetImage(int anh)
        {
            if (anh == 1)
            {
                Cam1.video.takeSnapshot();
            }
            else if (anh == 2)
            {
                Cam2.video.takeSnapshot();
            }
            else if (anh == 3)
            {
                Cam3.video.takeSnapshot();
            }
            else if (anh == 4)
            {
                Cam1.video.takeSnapshot();
            }
            else if (anh == 5)
            {
                Cam2.video.takeSnapshot();
            }
            else if (anh == 6)
            {
                Cam3.video.takeSnapshot();
            }

            string[] bmpFiles = Directory.GetFiles(Application.StartupPath, "*.bmp");
            if (bmpFiles.Length > 0)
            {
                string firstBmpFilePath = bmpFiles.First(); // Lấy đường dẫn của ảnh BMP đầu tiên trong folder
                byte[] imageBytes = File.ReadAllBytes(firstBmpFilePath);
                if (anh == 1)
                {
                    //pcDTO.Image1_1 = imageBytes;
                    pcDTO.Image1_1 = CompressImage(imageBytes, quality);
                }
                else if (anh == 2)
                {
                    pcDTO.Image1_2 = CompressImage(imageBytes, quality);
                }
                else if (anh == 3)
                {
                    pcDTO.Image1_3 = CompressImage(imageBytes, quality);
                }
                else if (anh == 4)
                {
                    pcDTO.Image2_1 = CompressImage(imageBytes, quality);
                }
                else if (anh == 5)
                {
                    pcDTO.Image2_2 = CompressImage(imageBytes, quality);
                }
                else if (anh == 6)
                {
                    pcDTO.Image2_3 = CompressImage(imageBytes, quality);
                }

                File.Delete(firstBmpFilePath);
            }
        }
        #endregion

        #region Cân lần 1
        private void BtnCanLan1_Click(object sender, EventArgs e)
        {
            try
            {
                pcDTO = new PhieuCanDTO();
                if (CheckKieuCan() == false) return;
                if (KiemTraKhoiLuongCan() == true)
                {
                    txtKhoiLuongCan1.Text = lbcan.Text;
                }
                else return;

                pcDTO.SoPhieu = "PC" + DateTime.Now.ToString("ddMMyyyyHHmmss") + Properties.Settings.Default.Machine_Name + GenerateRandomValue();
                pcDTO.BienSoXe = glkBienSoXe.Text.Trim();
                pcDTO.NguoiBan = glkNguoiBan.Text.Trim();
                pcDTO.NguoiMua = glkNguoiMua.Text.Trim();
                pcDTO.LaiXe = glkLaiXe.Text.Trim();
                pcDTO.MaHang = glkMaHang.Text.Trim();
                pcDTO.TenHang = txtTenHang.Text.Trim();
                pcDTO.KhoHang = glkKhoHang.Text.Trim();
                pcDTO.GhiChu = txtGhiChu.Text.Trim();

                if (ckNhap.Checked == true) pcDTO.KieuCan = baseDTO.Nhap;
                else if (ckXuat.Checked == true) pcDTO.KieuCan = baseDTO.Xuat;
                else if (ckDichVu.Checked == true) pcDTO.KieuCan = baseDTO.DichVu;

                pcDTO.KhoiLuongCan1 = Convert.ToInt32(txtKhoiLuongCan1.Text.Trim());
                pcDTO.KhoiLuongCan2 = 0;
                pcDTO.ThoiGianCan1 = GetDatetimeFormat();
                pcDTO.created_at = DateTime.Now;
                if(Properties.Settings.Default.Machine_Name !=0)
                    pcDTO.SoMay = Properties.Settings.Default.Machine_Name;
                else
                {
                    MessageBox.Show("Chưa cài đặt thông tin điểm cân, vui lòng cài đặt trước khi cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                  
                pcDTO.LanCan = 1;

                if(String.IsNullOrEmpty(Properties.Settings.Default.NhanVien))
                {
                    if (Properties.Settings.Default.admin == true)
                        pcDTO.NhanVienCanLan1 = "Admin";
                    else
                    {
                        tkDTO = ndBUS.GetPassByUser(Properties.Settings.Default.LoginName);
                        Properties.Settings.Default.NhanVien = tkDTO.HoTen;
                        Properties.Settings.Default.Save();

                        pcDTO.NhanVienCanLan1 = Properties.Settings.Default.NhanVien;
                    }    
                }  
                else
                    pcDTO.NhanVienCanLan1 = Properties.Settings.Default.NhanVien;

                pcDTO.status_show = "SHOW";

                //pcDTO.Image1_1 = converImgToByte(Picture_Cam(panel1));
                //pcDTO.Image1_2 = converImgToByte(Picture_Cam(panel2));
                //pcDTO.Image1_3 = converImgToByte(Picture_Cam(panel3));
                GetImage(1);
                GetImage(2);
                GetImage(3);

                if (Properties.Settings.Default.scaleType == true)
                {
                    if (baseBUS.IsInternetAvailable() == false)
                    {
                        MessageBox.Show("Kết nối Internet không ổn định, tắt phần mềm và chuyển qua chạy Offline", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }    
                    statusInsert = pcBUS.InsertPhieuCanLan(Properties.Settings.Default.connectString, pcDTO);
                    if (statusInsert == true)
                    {
                        LoadPhieuCanLan1();
                    }
                }    
                else
                {
                    statusInsert = pcBUS.InsertPhieuCanLanSqlite(pcDTO);
                    if (statusInsert == true)
                    {
                        LoadPhieuCanLan1();
                    }
                }
                //if (baseBUS.IsInternetAvailable() == false)
                //{
                //    statusInsert = pcBUS.InsertPhieuCanLanSqlite(pcDTO);
                //}
                //else
                //{
                //    statusInsert = pcBUS.InsertPhieuCanLan(Properties.Settings.Default.connectString, pcDTO);
                //    if (statusInsert == true)
                //    {
                //        LoadPhieuCanLan1();
                //    }
                //}
                if (statusInsert == true)
                {
                    txtTGCanLan1.Text = pcDTO.ThoiGianCan1.ToString();
                    txtSoPhieuCan.Text = pcDTO.SoPhieu;
                    btnCanLan1.Enabled = false;
                    Properties.Settings.Default.LanCan = 1;
                    Properties.Settings.Default.Save();
                    btnCanLan2.Enabled = true;
                    statusInsert = false;
                    pcDTO.Image1_1 = null;
                    pcDTO.Image1_2 = null;
                    pcDTO.Image1_3 = null;
                    MessageBox.Show("Lưu phiếu cân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtKhoiLuongCan1.ResetText();
                    txtTGCanLan1.ResetText();
                    pcDTO.Image1_1 = null;
                    pcDTO.Image1_2 = null;
                    pcDTO.Image1_3 = null;
                    MessageBox.Show("Lưu phiếu cân không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
                    
            }
            catch (Exception ex)
            {
                pcDTO.Image1_1 = null;
                pcDTO.Image1_2 = null;
                pcDTO.Image1_3 = null;
                MessageBox.Show(ex.ToString(),"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Cân lần 2
        private void BtnCanLan2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckKieuCan() == false) return;
                if (KiemTraKhoiLuongCan() == true)
                {
                    txtKhoiLuongCan2.Text = lbcan.Text;
                }
                else return;

                pcDTO.Image1_1 = null;
                pcDTO.Image1_2 = null;
                pcDTO.Image1_3 = null;

                if (String.IsNullOrEmpty(Properties.Settings.Default.NhanVien))
                {
                    if (Properties.Settings.Default.admin == true)
                        pcDTO.NhanVienCanLan2 = "Admin";
                    else
                    {
                        tkDTO = ndBUS.GetPassByUser(Properties.Settings.Default.LoginName);
                        Properties.Settings.Default.NhanVien = tkDTO.HoTen;
                        Properties.Settings.Default.Save();

                        pcDTO.NhanVienCanLan2 = Properties.Settings.Default.NhanVien;
                    }
                }
                else
                    pcDTO.NhanVienCanLan2 = Properties.Settings.Default.NhanVien;

                pcDTO.LanCan = 2;
                pcDTO.GhiChu = txtGhiChu.Text.Trim();
                pcDTO.KhoiLuongCan2 = Convert.ToInt32(txtKhoiLuongCan2.Text.Trim());

                if (ckNhap.Checked == true) pcDTO.KieuCan = baseDTO.Nhap;
                else if (ckXuat.Checked == true) pcDTO.KieuCan = baseDTO.Xuat;
                else if (ckDichVu.Checked == true) pcDTO.KieuCan = baseDTO.DichVu;

                pcDTO.ThoiGianCan2 = GetDatetimeFormat();
                pcDTO.created_at = DateTime.Now;
                pcDTO.status_show = "SHOW";

                //pcDTO.Image2_1 = converImgToByte(Picture_Cam(panel1));
                //pcDTO.Image2_2 = converImgToByte(Picture_Cam(panel2));
                //pcDTO.Image2_3 = converImgToByte(Picture_Cam(panel3));
                GetImage(4);
                GetImage(5);
                GetImage(6);

                if (Properties.Settings.Default.Machine_Name != 0)
                    pcDTO.SoMay = Properties.Settings.Default.Machine_Name;
                else
                {
                    MessageBox.Show("Chưa cài đặt thông tin điểm cân, vui lòng cài đặt trước khi cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Properties.Settings.Default.scaleType == true)
                {
                    if (baseBUS.IsInternetAvailable() == false)
                    {
                        MessageBox.Show("Kết nối Internet không ổn định, tắt phần mềm và chuyển qua chạy Offline", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (pcBUS.CheckPhieuCanLan1(Properties.Settings.Default.connectString, pcDTO) == true)
                    {
                        statusInsert = pcBUS.InsertPhieuCanLan(Properties.Settings.Default.connectString, pcDTO);
                        if (statusInsert == true)
                        {
                            pcBUS.UpdateStatusPC1(Properties.Settings.Default.connectString, pcDTO);
                            LoadPhieuCanLan1();
                        }
                    }
                    else
                        MessageBox.Show($"Không tìm thấy phiếu cân lần 1 của Phiếu:{pcDTO.SoPhieu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (pcBUS.CheckPhieuCanLan1Sqlite(pcDTO) == true)
                    {
                        statusInsert = pcBUS.InsertPhieuCanLanSqlite(pcDTO);
                        if (statusInsert == true)
                        {
                            pcBUS.UpdateSqliteStatusPC1(pcDTO);
                        }
                    }
                    else
                        MessageBox.Show($"Không tìm thấy phiếu cân lần 1 của Phiếu:{pcDTO.SoPhieu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //if (baseBUS.IsInternetAvailable() == false)
                //{
                //    if (pcBUS.CheckPhieuCanLan1Sqlite(pcDTO) == true)
                //    {
                //        statusInsert = pcBUS.InsertPhieuCanLanSqlite(pcDTO);
                //        if (statusInsert == true)
                //        {
                //            pcBUS.UpdateSqliteStatusPC1(pcDTO);
                //        }
                //    }
                //    else
                //        MessageBox.Show($"Không tìm thấy phiếu cân lần 1 của Phiếu:{pcDTO.SoPhieu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}
                //else
                //{
                //    if (pcBUS.CheckPhieuCanLan1(Properties.Settings.Default.connectString, pcDTO) == true)
                //    {
                //        statusInsert = pcBUS.InsertPhieuCanLan(Properties.Settings.Default.connectString, pcDTO);
                //        if (statusInsert == true)
                //        {
                //            pcBUS.UpdateStatusPC1(Properties.Settings.Default.connectString, pcDTO);
                //            LoadPhieuCanLan1();
                //        }
                //    }
                //    else
                //        MessageBox.Show($"Không tìm thấy phiếu cân lần 1 của Phiếu:{pcDTO.SoPhieu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}

                if (statusInsert == true)
                {

                    txtTGCanLan2.Text = pcDTO.ThoiGianCan2.ToString();
                    txtKhoiLuongHang.Text = Convert.ToString(Math.Abs(Convert.ToInt32(txtKhoiLuongCan1.Text) - Convert.ToInt32(txtKhoiLuongCan2.Text)));
                    btnCanLan2.Enabled = false;
                    Properties.Settings.Default.LanCan = 2;
                    Properties.Settings.Default.Save();
                    pcDTO.Image2_1 = null;
                    pcDTO.Image2_2 = null;
                    pcDTO.Image2_3 = null;
                    MessageBox.Show("Lưu phiếu cân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtKhoiLuongCan2.ResetText();
                    txtTGCanLan2.ResetText();
                    pcDTO.Image2_1 = null;
                    pcDTO.Image2_2 = null;
                    pcDTO.Image2_3 = null;
                    MessageBox.Show("Lưu phiếu cân không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }           
            }
            catch (Exception ex)
            {
                pcDTO.Image2_1 = null;
                pcDTO.Image2_2 = null;
                pcDTO.Image2_3 = null;
                MessageBox.Show(ex.ToString(),"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        #endregion

        #region In phiếu cân
        private void BtnInPhieu_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.scaleType == true)
            {
                if (baseBUS.IsInternetAvailable() == false)
                {
                    MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }    
            if (String.IsNullOrEmpty(txtSoPhieuCan.Text.Trim()))
            {
                MessageBox.Show("In phiếu cân không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PhieuCanXe report = new PhieuCanXe(txtSoPhieuCan.Text.Trim(), pcDTO.LanCan);
            ViewReportForm frm = new ViewReportForm(report);
            //frm.Show();
        }
        #endregion

        #region Lập phiếu mới
        private void BtnLapPhieu_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        #endregion

        #region Load phiếu cân từ DongBoForm
        public void LoadPhieuCanOffline(PhieuCanDTO item)
        {
            try
            {
                ResetControl();
                btnCanLan1.Enabled = false;
                btnCanLan2.Enabled = true;
                txtTenHang.Text = item.SoPhieu;
                glkBienSoXe.SelectedText = item.BienSoXe;
                glkNguoiBan.SelectedText = item.NguoiBan;
                glkNguoiMua.SelectedText = item.NguoiMua;
                glkLaiXe.SelectedText = item.LaiXe;
                glkMaHang.SelectedText = item.MaHang;
                txtSoPhieuCan.Text = item.SoPhieu;
                glkKhoHang.SelectedText = item.KhoHang;
                txtGhiChu.Text = item.GhiChu;

                if (item.KieuCan == baseDTO.Nhap) ckNhap.Checked = true;
                else if (item.KieuCan == baseDTO.Xuat) ckXuat.Checked = true;
                else if (item.KieuCan == baseDTO.DichVu) ckDichVu.Checked = true;

                txtTGCanLan1.Text = item.ThoiGianCan1.ToString();
                txtKhoiLuongCan1.Text = item.KhoiLuongCan1.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Lấy thời gian hệ thống
        private DateTime? GetDatetimeFormat()
        {
            try
            {
                DateTime currentTime = DateTime.Now;

                // Chuyển đổi từ DateTime sang chuỗi với định dạng mong muốn
                string formattedTime = currentTime.ToString("dd/MM/yyyy HH:mm:ss");

                // Chuyển đổi từ chuỗi về DateTime nếu cần
                DateTime parsedTime = DateTime.ParseExact(formattedTime, "dd/MM/yyyy HH:mm:ss", null);
                return parsedTime;
            }
            catch
            {
                return DateTime.Now;
            }
            
        }
        #endregion

        #region Random kí tự ngẫu nhiên của xử lý số phiếu
        static string GenerateRandomValue()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 1001); // Số ngẫu nhiên từ 1 đến 100

            // Chữ cái viết hoa ngẫu nhiên (A-Z)
            char randomChar = (char)('A' + random.Next(26));

            string result = randomNumber.ToString() + randomChar;
            return result;
        }
        #endregion       

        #region Kiểm tra khối lượng cân > 0
        bool KiemTraKhoiLuongCan()
        {
            try
            {
                if (String.IsNullOrEmpty(lbcan.Text))
                {
                    MessageBox.Show("Không nhận được tín hiệu từ cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(lbcan.Text) <= 0)
                {
                    MessageBox.Show("Khối lượng cân phải > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else 
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        #endregion

        #region Kiểm tra kiểu cân bắt buộc phải chọn
        bool CheckKieuCan()
        {
            if (ckNhap.Checked == false & ckXuat.Checked == false & ckDichVu.Checked == false)
            {
                MessageBox.Show("Kiểu cân bắt buộc phải chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else return true;
        }
        #endregion

        #region Load thông tin cổng COM
        public void LoadCom()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("COM", "COMPORT").Split(',');
                portName = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("COM", "BAUDRATE").Split(',');
                baudRate = Convert.ToInt32(a[0].Replace(" ", ""));

                a = par.GetSetting("COM", "DATABITS").Split(',');
                dataBits = Convert.ToInt32(a[0].Replace(" ", ""));
            }
        }
        #endregion

        #region thông tin COM
        public void SetCom()
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName; // Đặt tên cổng COM tương ứng
            serialPort.BaudRate = baudRate; // Đặt tốc độ baud
            serialPort.DataBits = dataBits; // Đặt số bit dữ liệu
            serialPort.Parity = Parity.None; // Đặt kiểm tra chẵn/lẻ
            serialPort.StopBits = StopBits.One; // Đặt số bit dừng
            serialPort.Handshake = Handshake.None; // Đặt kiểm tra tay
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        #endregion

        #region Mở cổng COM
        public void OpenComPort()
        {
            try
            {
                if (serialPort.IsOpen == false)
                {
                    serialPort.Open(); // Mở cổng COM
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở cổng COM: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Thông tin Biển số, lái xe, người bán, người mua, kho hàng
        void GetThongTinPhieuCan()
        {
            ThongTinPhieuCanBindingSource.DataSource = pcBUS.GetListThongTinPhieuCan(Properties.Settings.Default.connectString);
        }
        #endregion

        #region Lấy danh sách mã hàng
        public void GetMaHang()
        {
            MaHangBindingSource.DataSource = lhBUS.GetLoaiHang(Properties.Settings.Default.connectString);
        }
        #endregion

        #region Sự kiện chọn mã hàng --> tên hàng
        private void GlkMaHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTenHang.Text = glkMaHang.EditValue.ToString();
            }
            catch
            {

            }
        }
        #endregion

        #region reset control
        void ResetControl()
        {
            try
            {
                txtTenHang.Text = "";
                glkBienSoXe.Text = "";
                glkNguoiBan.Text = "";
                glkNguoiMua.Text = "";
                glkLaiXe.Text = "";
                glkMaHang.Text = "";
                txtSoPhieuCan.Text = "";
                glkKhoHang.Text = "";
                txtGhiChu.Text = "";
                txtKhoiLuongCan1.Text = "";
                txtKhoiLuongCan2.Text = "";
                txtTGCanLan1.Text = "";
                txtTGCanLan2.Text = "";
                txtKhoiLuongHang.Text = "";
                btnCanLan1.Enabled = true;
                btnCanLan2.Enabled = false;
                ckNhap.Checked = false;
                ckXuat.Checked = false;
                ckDichVu.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region GV2 click sửa, xóa, in phiếu
        private void GvPhieuCan2_DoubleClick(object sender, EventArgs e)
        {
            //if (baseBUS.LoadQuyenUser() == false)
            //{
            //    MessageBox.Show("Chỉ tài khoản Admin mới được quyền sửa phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            PhieuCanDTO item = gvPhieuCan2.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PhieuCanChiTietForm frm = new PhieuCanChiTietForm(this, item);
                frm.ShowDialog();
            }
        }
        #endregion

        #region GV 1 click cân lần 2
        private void GvPhieuCan1_DoubleClick(object sender, EventArgs e)
        {
            //PhieuCanDTO item = gvPhieuCan1.GetFocusedRow() as PhieuCanDTO;
            //if (item == null)
            //{
            //    MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (MessageBox.Show($"Cân phiếu: {item.SoPhieu} lần 2?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        Properties.Settings.Default.LanCan = 1;
            //        Properties.Settings.Default.Save();
            //        ResetControl();
            //        pcDTO = item;
            //        txtSoPhieuCan.Text = item.SoPhieu;
            //        glkBienSoXe.SelectedText = item.BienSoXe;
            //        glkNguoiBan.SelectedText = item.NguoiBan;
            //        glkNguoiMua.SelectedText = item.NguoiMua;
            //        glkLaiXe.SelectedText = item.LaiXe;
            //        glkMaHang.SelectedText = item.MaHang;
            //        txtTenHang.Text = item.TenHang;
            //        glkKhoHang.SelectedText = item.KhoHang;
            //        txtGhiChu.Text = item.GhiChu;

            //        if (item.KieuCan == "Nhập") ckNhap.Checked = true;
            //        else if (item.KieuCan == "Xuất") ckXuat.Checked = true;
            //        else if (item.KieuCan == "Dịch Vụ") ckDichVu.Checked = true;

            //        txtKhoiLuongCan1.Text = item.KhoiLuongCan1.ToString();
            //        txtTGCanLan1.Text = item.ThoiGianCan1.ToString();

            //        btnCanLan1.Enabled = false;
            //        btnCanLan2.Enabled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}

            PhieuCanDTO item = gvPhieuCan1.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PhieuCanChiTietForm frm = new PhieuCanChiTietForm(this, item);
                frm.ShowDialog();
            }
        }

        #endregion

        #region Thêm số thứ tự cho lưới
        private void GvPhieuCan2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridViewHelper.GridView_CustomDrawRowIndicator(sender, e, gcPhieuCan2, gvPhieuCan2);
        }

        private void GvPhieuCan1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridViewHelper.GridView_CustomDrawRowIndicator(sender, e, gcPhieuCan1, gvPhieuCan1);
        }
        #endregion

        #region Tải phiếu cân lần 1&2
        public void LoadPhieuCanLan1()
        {
            if(Properties.Settings.Default.scaleType == true)
            {
                PhieuCanLan1bindingSource.DataSource = pcBUS.GetPhieuCanLan1(Properties.Settings.Default.connectString);
            }  
            else
            {
                PhieuCanLan1bindingSource.DataSource = pcBUS.GetPhieuCanLan1Sqlite();
            }    
            
        }
        public void LoadPhieuCanLan2()
        {
            if(Properties.Settings.Default.scaleType == true)
            {
                PhieuCanLan2bindingSource.DataSource = pcBUS.GetPhieuCanLan2(Properties.Settings.Default.connectString);
            }   
            else
            {
                PhieuCanLan2bindingSource.DataSource = pcBUS.GetPhieuCanLan2Sqlite();
            }    
            
        }
        #endregion

        #region Sự kiện Tab change
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tab hiện tại được chọn
            TabControl tabControl = (TabControl)sender;
            TabPage selectedTab = tabControl.SelectedTab;

            // Thực hiện các hành động dựa trên tab được chọn
            if (selectedTab == Page1)
            {
                SplashScreenManager.ShowDefaultWaitForm("Đang tải dữ liệu", "Loading... ");
                LoadPhieuCanLan1();
                SplashScreenManager.CloseDefaultWaitForm();
            }
            else if (selectedTab == Page2)
            {
                SplashScreenManager.ShowDefaultWaitForm("Đang tải dữ liệu", "Loading... ");
                LoadPhieuCanLan2();
                SplashScreenManager.CloseDefaultWaitForm();
            }
            //else if (selectedTab == Page3)
            //{
            //    SplashScreenManager.ShowDefaultWaitForm("Đang tải dữ liệu", "Loading... ");
            //    PhieuCanAllBindingSource.DataSource = pcBUS.GetPhieuCan(Properties.Settings.Default.connectString);
            //    SplashScreenManager.CloseDefaultWaitForm();
            //}
        }
        #endregion

        #region Menu click
        private void MenuConnect_Click(object sender, EventArgs e)
        {
            ConnectForm frm = new ConnectForm();
            frm.ShowDialog();
        }
        private void MenuMachine_Click(object sender, EventArgs e)
        {
            TenMayForm frm = new TenMayForm(this);
            frm.ShowDialog();
        }

        private void MenuCamera_Click(object sender, EventArgs e)
        {
            CameraForm frm = new CameraForm();
            frm.ShowDialog();
        }

        private void MenuCOM_Click(object sender, EventArgs e)
        {
            COMForm frm = new COMForm(this);
            frm.ShowDialog();
        }

        private void MenuTaiKhoan_Click(object sender, EventArgs e)
        {
            NguoiDungForm frm = new NguoiDungForm();
            frm.ShowDialog();
        }

        private void MenuCongTy_Click(object sender, EventArgs e)
        {
            ThongTinCongTyForm frm = new ThongTinCongTyForm();
            frm.ShowDialog();
        }

        private void MenuThongKeDuLieu_Click(object sender, EventArgs e)
        {
            ThongKeForm frm = new ThongKeForm();
            frm.ShowDialog();
        }
        private void MenuDuLieuOffline_Click(object sender, EventArgs e)
        {
            DongBoForm frm = new DongBoForm(this);
            frm.ShowDialog();
        }

        private void MenuLoaiHang_Click(object sender, EventArgs e)
        {
            LoaiHangForm frm = new LoaiHangForm(this);
            frm.ShowDialog();
        }
        #endregion

        #region Sự kiện check Kiểu cân
        private void CkDichVu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDichVu.Checked == true)
            {
                ckXuat.Checked = false;
                ckNhap.Checked = false;
            }
        }
        private void CkXuat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckXuat.Checked == true)
            {
                ckNhap.Checked = false;
                ckDichVu.Checked = false;
            }
        }
        private void CkNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (ckNhap.Checked == true)
            {
                ckXuat.Checked = false;
                ckDichVu.Checked = false;
            }
        }
        #endregion

        #region Sự kiện đóng form
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string processNameToKill = "Can";
                Process[] processes = Process.GetProcessesByName(processNameToKill);
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        process.Kill();
                    }
                }
                Application.Exit();
            }
            catch
            {
                Application.Exit();
            }
        }
        #endregion

        #region Reload camera
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Cam1.playlist.items.clear();
                Cam1.playlist.add(rtsp1);
                Cam1.playlist.play();

                Cam2.playlist.items.clear();
                Cam2.playlist.add(rtsp1);
                Cam2.playlist.play();

                Cam3.playlist.items.clear();
                Cam3.playlist.add(rtsp1);
                Cam3.playlist.play();
            }
            catch
            {

            }
        }
        #endregion

        #region Load thông tin RSTP Camera
        public void LoadRstp()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("CAMERA", "RTSP1").Split(',');
                rtsp1 = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("CAMERA", "RTSP2").Split(',');
                rtsp2 = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("CAMERA", "RTSP3").Split(',');
                rtsp3 = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("CAMERA", "QUALITY").Split(',');
                quality = Convert.ToInt32(a[0].Replace(" ", ""));
            }
        }
        #endregion             
    }
}
