using Can.BUS;
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
    public partial class NguoiDungForm : Form
    {
        NguoiDungBUS ndBUS = new NguoiDungBUS();
        public NguoiDungForm()
        {
            InitializeComponent();
            this.Load += NguoiDungForm_Load;
        }

        private void NguoiDungForm_Load(object sender, EventArgs e)
        {
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            LoadData();
            LoadQuyenUser();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO item = NguoiDungBindingSource.Current as TaiKhoanDTO;
            if (item == null) return;

            if(ndBUS.DeleteUserByUserName(item) !=0)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }    
            else
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void LoadQuyenUser()
        {
            if(Properties.Settings.Default.admin == false)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }    
        }
        public void LoadData()
        {
            NguoiDungBindingSource.DataSource = ndBUS.GetListNguoiDung();
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO item = new TaiKhoanDTO();
            NguoiDungChiTietForm frm = new NguoiDungChiTietForm(this, item);
            frm.ShowDialog();
        }
    }
}
