using Can.BUS;
using Can.GUI.CustomUserControl;
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
    public partial class LoaiHangForm : Form
    {
        private readonly frmMain frmck;
        LoaiHangBUS lhBUS = new LoaiHangBUS();
        baseBUS baseBUS = new baseBUS();
        public LoaiHangForm(frmMain frm)
        {
            InitializeComponent();
            frmck = frm;
            this.Load += LoaiHangForm_Load;
        }

        private void LoaiHangForm_Load(object sender, EventArgs e)
        {
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            gvLoaiHang.CustomDrawRowIndicator += GvLoaiHang_CustomDrawRowIndicator;
            gvLoaiHangoff.CustomDrawRowIndicator += GridView1_CustomDrawRowIndicator;
            this.FormClosing += LoaiHangForm_FormClosing;
            LoadData();
        }

        private void GridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridViewHelper.GridView_CustomDrawRowIndicator(sender, e, gcLoaiHangoff, gvLoaiHangoff);
        }

        private void GvLoaiHang_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            GridViewHelper.GridView_CustomDrawRowIndicator(sender, e, gcLoaiHang, gvLoaiHang);
        }

        private void LoaiHangForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmck != null)
            {
                frmck.GetThongTinCan();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (baseBUS.IsInternetAvailable() == false)
            {
                MessageBox.Show("Edit loại hàng phải đảm bảo có Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoaiHangDTO item = gvLoaiHang.GetFocusedRow() as LoaiHangDTO;
            if (item == null) return;
            if((MessageBox.Show($"Bạn có muốn xóa mã hàng: {item.MaHang}","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes))
            {
                if (lhBUS.DeletLoaiHang(Properties.Settings.Default.connectString, item) == 1 && lhBUS.DeletLoaiHangOff(item) == 1)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }    
                
        } 

        private void BtnThem_Click(object sender, EventArgs e)
        {
            LoaiHangChiTietForm frm = new LoaiHangChiTietForm(this);
            frm.ShowDialog();
        }
        public void LoadData()
        {
            if(baseBUS.IsInternetAvailable())
            {
                LHBindingSource.DataSource = lhBUS.GetLoaiHang(Properties.Settings.Default.connectString);
            }
            LHBindingSourceOffline.DataSource = lhBUS.GetLoaiHangOff();
        }
    }
}
