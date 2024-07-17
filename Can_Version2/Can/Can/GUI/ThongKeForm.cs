using Can.BUS;
using Can.DTO;
using Can.GUI.CustomUserControl;
using Can.GUI.MauIn;
using DevExpress.XtraSplashScreen;
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
    public partial class ThongKeForm : Form
    {
        PhieuCanBUS pcBUS = new PhieuCanBUS();
        baseBUS bBUS = new baseBUS();
        DiemCanBUS dcBUS = new DiemCanBUS();
        public ThongKeForm()
        {
            InitializeComponent();
            this.Load += ThongKeForm_Load;
        }

        private void ThongKeForm_Load(object sender, EventArgs e)
        {
            btnXuatExcel.Click += BtnXuatExcel_Click;            
            gvThongKeDuLieu.DoubleClick += GvThongKeDuLieu_DoubleClick;
            btnTimKiem.Click += BtnTimKiem_Click;
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            //dteTo.DateTime = DateTime.Now;

            gvThongKeDuLieu.CustomDrawRowIndicator += GvThongKeDuLieu_CustomDrawRowIndicator;
            //LoadData();
        }

        private void GvThongKeDuLieu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridViewHelper.GridView_CustomDrawRowIndicator(sender, e, gcThongKeDuLieu, gvThongKeDuLieu);
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Đang tải dữ liệu", "Loading... ");
            if (Properties.Settings.Default.scaleType == true)
            {
                if (bBUS.IsInternetAvailable())
                {
                    DiemCanDTO item = new DiemCanDTO();
                    item = dcBUS.GetThongTinDiemCan(Properties.Settings.Default.connectString, bBUS.GetMac());
                    BaoCaoPhieuCanBindingSource.DataSource = pcBUS.GetPhieuCanByDate(Properties.Settings.Default.connectString, dateTimePicker1.Value, dateTimePicker2.Value, item.SoMay);
                }
                else
                    MessageBox.Show("Đang ở kiểu cân Online nhưng kết nối không ổn định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            else
            {
                BaoCaoPhieuCanBindingSource.DataSource = pcBUS.GetPhieuCanByDateOff(dateTimePicker1.Value, dateTimePicker2.Value);
            }    
            
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void GvThongKeDuLieu_DoubleClick(object sender, EventArgs e)
        {
            PhieuCanDTO item =gvThongKeDuLieu.GetFocusedRow() as PhieuCanDTO;
            if(item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            if(MessageBox.Show($"Bạn có muốn in phiếu cân: {item.SoPhieu}?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                PhieuCanXe report = new PhieuCanXe(item.SoPhieu, item.LanCan);
                ViewReportForm frm = new ViewReportForm(report);
                //frm.Show();
            }         
        }
        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            //PhieuCanXe report = new PhieuCanXe();
            //ViewReportForm frm = new ViewReportForm(report);
            //frm.Show();
        }

        void LoadData()
        {
            SplashScreenManager.ShowDefaultWaitForm("Đang tải dữ liệu", "Loading... ");
            BaoCaoPhieuCanBindingSource.DataSource = pcBUS.GetPhieuCan(Properties.Settings.Default.connectString);
            SplashScreenManager.CloseDefaultWaitForm();
        }
        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                BUS.baseBUS.ExportGridViewToExcel(gvThongKeDuLieu, DateTime.Now, "BaoCaoPhieuCan");
            }
            catch
            {
                MessageBox.Show("Xuất file báo cáo không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
