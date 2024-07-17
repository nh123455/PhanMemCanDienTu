using Can.BUS;
using Can.GUI.MauIn;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Can.GUI
{
    public partial class PhieuCanChiTietForm : Form
    {
        private readonly frmMain frmck;
        PhieuCanBUS pcBUS = new PhieuCanBUS();
        PhieuCanDTO pcDTO = new PhieuCanDTO();
        LoaiHangBUS lhBUS = new LoaiHangBUS();
        baseDTO baseDTO = new baseDTO();
        baseBUS baseBUS = new baseBUS();
        public PhieuCanChiTietForm(frmMain frm, PhieuCanDTO item)
        {
            InitializeComponent();
            frmck = frm;
            pcDTO = item;

            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnInPhieu.Click += BtnInPhieu_Click;
            btnCanLan2.Click += BtnCanLan2_Click;

            btnDongBo.Click += BtnDongBo_Click;

            ckXuat.CheckedChanged += CkXuat_CheckedChanged;
            ckNhap.CheckedChanged += CkNhap_CheckedChanged;
            ckDichVu.CheckedChanged += CkDichVu_CheckedChanged;
            this.Load += PhieuCanChiTietForm_Load;
            
            if(baseBUS.LoadQuyenUser() == false)
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }    
            if(pcDTO.LanCan == 1)
            {
                btnCanLan2.Enabled = true;
                txtKhoiLuongCan2.Enabled = false;
                dteTGCan2.Enabled = false;
                txtNVC2.Enabled = false;
            }
            if (Properties.Settings.Default.scaleType == false)
            {
                btnDongBo.Enabled = true;
                
                if(pcDTO.sync == "True")
                {
                    this.Text = this.Text + " - Kiểu cân Offline - Đã đồng bộ";
                    btnDongBo.Enabled = false;
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                }    
                else
                {
                    this.Text = this.Text + " - Kiểu cân Offline - Chưa đồng bộ";
                    btnDongBo.Enabled = true;
                }    
                    
            }
        }

        private void BtnDongBo_Click(object sender, EventArgs e)
        {
            if(pcDTO.sync == "True")
            {
                MessageBox.Show("Phiếu đã đồng bộ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (pcBUS.DongBo1Phieu(pcDTO.SoPhieu) == true)
                {
                    pcBUS.UpdateStatusSyncSoPhieu(pcDTO.SoPhieu);
                    this.Text = "Phiếu cân chi tiết" + " - Kiểu cân Offline - Đã đồng bộ";
                    btnDongBo.Enabled = false;
                    if (frmck != null)
                    {
                        frmck.LoadPhieuCanLan2();
                        frmck.LoadPhieuCanLan1();
                    }
                    MessageBox.Show("Đồng bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }    
        }

        private void BtnCanLan2_Click(object sender, EventArgs e)
        {
            if(frmck != null)
            {
                frmck.CanLan2(pcDTO);
                this.Close();
            }    
        }

        private void CkDichVu_CheckedChanged(object sender, EventArgs e)
        {
            if(ckDichVu.Checked == true)
            {
                ckXuat.Checked = false;
                ckNhap.Checked = false;
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

        private void CkXuat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckXuat.Checked == true)
            {
                ckDichVu.Checked = false;
                ckNhap.Checked = false;
            }
        }

        private void BtnInPhieu_Click(object sender, EventArgs e)
        {
            PhieuCanXe report = new PhieuCanXe(txtSoPhieu.Text.Trim(), pcDTO.LanCan);
            ViewReportForm frm = new ViewReportForm(report);
            //frm.Show();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xóa phiếu này cả 2 lần cân?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information)== DialogResult.Yes)
            {
                if(Properties.Settings.Default.scaleType == true)
                {
                    if (pcBUS.DeletePhieuCan(Properties.Settings.Default.connectString, pcDTO) == true && pcBUS.DeletePhieuCanOff(pcDTO) == true)
                    {
                        MessageBox.Show("Xóa phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (frmck != null)
                        {
                            frmck.LoadPhieuCanLan2();
                            frmck.LoadPhieuCanLan1();
                        }
                        this.Close();
                    }
                    else
                        MessageBox.Show("Xóa phiếu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                else
                {
                    if (pcBUS.DeletePhieuCanOffSync(pcDTO) == true)
                    {
                        MessageBox.Show("Xóa phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (frmck != null)
                        {
                            frmck.LoadPhieuCanLan2();
                            frmck.LoadPhieuCanLan1();
                        }
                        this.Close();
                    }
                    else
                        MessageBox.Show("Xóa phiếu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            }    
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtKhoiLuongCan1.Text) || !String.IsNullOrEmpty(txtKhoiLuongCan1.Text))
                {
                    if (Convert.ToInt32(txtKhoiLuongCan1.Text) <= 0 && pcDTO.LanCan == 1)
                    {
                        MessageBox.Show("Khối lượng cân lần 1 phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(pcDTO.LanCan == 2)
                    {
                        if(Convert.ToInt32(txtKhoiLuongCan1.Text) <= 0)
                        {
                            MessageBox.Show("Khối lượng cân lần 1 phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }    
                        if(Convert.ToInt32(txtKhoiLuongCan2.Text) <= 0)
                        {
                            MessageBox.Show("Khối lượng cân lần 2 phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }    
                    }    
                }
                else
                {
                    MessageBox.Show("Khối lượng cân không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ckNhap.Checked == false && ckXuat.Checked == false && ckDichVu.Checked == false)
                {
                    MessageBox.Show("Chưa chọn kiểu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (ckNhap.Checked == true) pcDTO.KieuCan = baseDTO.Nhap;
                    else if (ckXuat.Checked == true) pcDTO.KieuCan = baseDTO.Xuat;
                    else if (ckDichVu.Checked == true) pcDTO.KieuCan = baseDTO.DichVu;
                }

                pcDTO.BienSoXe = txtBienSo.Text.Trim();
                pcDTO.NguoiBan = txtNguoiBan.Text.Trim();
                pcDTO.NguoiMua = txtNguoiMua.Text.Trim();
                pcDTO.LaiXe = txtLaiXe.Text.Trim();
                pcDTO.MaHang = glkMaHang.Text.Trim();
                pcDTO.TenHang = txtTenHang.Text.Trim();
                pcDTO.KhoHang = txtKhoHang.Text.Trim();
                pcDTO.GhiChu = txtGhiChu.Text.Trim();
                pcDTO.ThoiGianCan1 = dteTGCan1.Value;
                pcDTO.ThoiGianCan2 = dteTGCan2.Value;
                pcDTO.NhanVienCanLan1 = txtNVC1.Text.Trim();
                pcDTO.NhanVienCanLan2 = txtNVC2.Text.Trim();
                pcDTO.KhoiLuongCan1 = Convert.ToInt32(txtKhoiLuongCan1.Text.Trim());
                pcDTO.KhoiLuongCan2 = Convert.ToInt32(txtKhoiLuongCan2.Text.Trim());

                if (Properties.Settings.Default.scaleType == true)
                {
                    if (pcDTO.LanCan == 1)
                    {
                        if (pcBUS.UpdatePhieuCan1(Properties.Settings.Default.connectString, pcDTO) == true && pcBUS.UpdatePhieuCan1Off(pcDTO) == true)
                        {
                            if (frmck != null)
                            {
                                frmck.LoadPhieuCanLan1();
                            }
                            MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (pcBUS.UpdatePhieuCan1(Properties.Settings.Default.connectString, pcDTO) == true && pcBUS.UpdatePhieuCan1Off(pcDTO) == true)
                    {
                        if (pcBUS.UpdatePhieuCan2(Properties.Settings.Default.connectString, pcDTO) == true && pcBUS.UpdatePhieuCan2Off(pcDTO) == true)
                        {
                            MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1&2 thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (frmck != null)
                            {
                                frmck.LoadPhieuCanLan2();
                            }
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                else
                {
                    if (pcDTO.LanCan == 1)
                    {
                        if (pcBUS.UpdatePhieuCan1Off(pcDTO) == true)
                        {
                            MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (pcBUS.UpdatePhieuCan1Off(pcDTO) == true)
                    {
                        if (pcBUS.UpdatePhieuCan2Off(pcDTO) == true)
                        {
                            MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1&2 thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (frmck != null)
                            {
                                frmck.LoadPhieuCanLan2();
                            }
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                //if (pcDTO.LanCan == 1)
                //{
                //    if (pcBUS.UpdatePhieuCan1(Properties.Settings.Default.connectString, pcDTO) == true)
                //    {
                //        MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
                //else if (pcBUS.UpdatePhieuCan1(Properties.Settings.Default.connectString, pcDTO) == true)
                //{
                //    if (pcBUS.UpdatePhieuCan2(Properties.Settings.Default.connectString, pcDTO) == true)
                //    {
                //        MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1&2 thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        if (frmck != null)
                //        {
                //            frmck.LoadPhieuCanLan2();
                //        }
                //        this.Close();
                //    }
                //}
                //else
                //    MessageBox.Show($"Update phiếu: {pcDTO.SoPhieu} cân lần 1 không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void PhieuCanChiTietForm_Load(object sender, EventArgs e)
        {
            GetMaHang();
            glkMaHang.EditValueChanged += GlkMaHang_EditValueChanged;
            txtSoPhieu.Text = pcDTO.SoPhieu;
            txtBienSo.Text = pcDTO.BienSoXe;
            txtNguoiBan.Text = pcDTO.NguoiBan;
            txtNguoiMua.Text = pcDTO.NguoiMua;
            txtLaiXe.Text = pcDTO.LaiXe;
            glkMaHang.SelectedText = pcDTO.MaHang;
            txtTenHang.Text = pcDTO.TenHang;
            txtKhoHang.Text = pcDTO.KhoHang;
            txtGhiChu.Text = pcDTO.GhiChu;
            txtNVC1.Text = pcDTO.NhanVienCanLan1;
            txtNVC2.Text = pcDTO.NhanVienCanLan2;

            if (pcDTO.KieuCan == "Nhập") ckNhap.Checked = true;
            else if (pcDTO.KieuCan == "Xuất") ckXuat.Checked = true;
            else ckDichVu.Checked = true;

            if (pcDTO.KhoiLuongCan1 != null) txtKhoiLuongCan1.Text = pcDTO.KhoiLuongCan1.ToString();
            if (pcDTO.KhoiLuongCan2 != null) txtKhoiLuongCan2.Text = pcDTO.KhoiLuongCan2.ToString();
            if (pcDTO.ThoiGianCan1 != null) dteTGCan1.Value =Convert.ToDateTime(pcDTO.ThoiGianCan1);
            if (pcDTO.ThoiGianCan2 != null) dteTGCan2.Value =Convert.ToDateTime(pcDTO.ThoiGianCan2);   
        }

        private void GlkMaHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTenHang.Text = glkMaHang.EditValue.ToString();
            }
            catch
            {
                txtTenHang.Text = "";
            }
        }

        public void GetMaHang()
        {
            MaHangBindingSource.DataSource = lhBUS.GetLoaiHang(Properties.Settings.Default.connectString);
            glkMaHang.Properties.TextEditStyle = TextEditStyles.Standard;
        }
    }
}
