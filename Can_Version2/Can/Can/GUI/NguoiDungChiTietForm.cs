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
    public partial class NguoiDungChiTietForm : Form
    {
        private readonly NguoiDungForm frm1;

        NguoiDungBUS ndBUS = new NguoiDungBUS();
        public NguoiDungChiTietForm(NguoiDungForm frm, TaiKhoanDTO item)
        {
            InitializeComponent();
            frm1 = frm;
            this.Load += NguoiDungChiTietForm_Load;
        }

        private void NguoiDungChiTietForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
        }
        void KiemTra()
        {
            if (txtUser.Text.ToUpper().Trim() == "ADMIN")
            {
                MessageBox.Show("Tài khoản Admin không được đăng kí mới, vui lòng chọn tên đăng nhập khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản đăng nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Họ Tên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Mật Khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtVerifyPass.Text.Trim() == "")
            {
                MessageBox.Show("Xác nhận mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPassword.Text.Trim() != txtVerifyPass.Text.Trim())
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            KiemTra();
            TaiKhoanDTO item = new TaiKhoanDTO();
            if (item == null) return;

            item.TaiKhoan = txtUser.Text.Trim();
            item.HoTen = txtName.Text.Trim();
            item.Email = txtEmail.Text.Trim();
            item.Phone = txtPhone.Text.Trim();
            item.Password = txtPassword.Text.Trim();

            if (ndBUS.InsertUser(item) != 0) 
            {
                frm1.LoadData();
                this.Close();
                MessageBox.Show("Thêm mới tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else 
                MessageBox.Show("Thêm mới tài khoản không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
