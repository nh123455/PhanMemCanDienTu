using Can.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Can.GUI
{
    public partial class DangNhapForm : Form
    {
        baseBUS bBUS = new baseBUS();
        NguoiDungBUS ndBUS = new NguoiDungBUS();
        TaiKhoanDTO tkDTO = new TaiKhoanDTO();
        public DangNhapForm()
        {
            InitializeComponent(); 
            this.Load += DangNhapForm_Load;
            Properties.Settings.Default.connectString = bBUS.LoadThongTinKetNoi();
            Properties.Settings.Default.Save();
            
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            btnDangNhap.Click += BtnDangNhap_Click;
            btnThoat.Click += BtnThoat_Click;
            txtPass.KeyDown += TxtPass_KeyDown;
            //if (bBUS.IsInternetAvailable())
            //{
            //    Properties.Settings.Default.isConnect = true;
            //    Properties.Settings.Default.Save();
            //}
            //else
            //{
            //    Properties.Settings.Default.isConnect = false;
            //    Properties.Settings.Default.Save();
            //    MessageBox.Show("Không có kết nối Internet","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //}
            LoadUserPass();
            LoadScaleType();
        }
        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "admin" & txtPass.Text.Trim() == "sa1001")
            {
                rdOnline.Enabled = true;
                rdOffline.Enabled = true;
            }
            else
            {
                MessageBox.Show("Tài khoản không đủ quyền để thay đổi kiểu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
        void LoadUserPass()
        {
            txtUser.Text = Properties.Settings.Default.user;
            txtPass.Text = Properties.Settings.Default.pass;
            if (Properties.Settings.Default.isRemember == true) ckRememberPass.Checked = true;
        }
        void LoadScaleType()
        {
            if (Properties.Settings.Default.scaleType == true)
                rdOnline.Checked = true;
            else
                rdOffline.Checked = true;
        }
        void RememberPass()
        {
            if (ckRememberPass.Checked == true)
            {
                Properties.Settings.Default.user = txtUser.Text.Trim();
                Properties.Settings.Default.pass = txtPass.Text.Trim();
                Properties.Settings.Default.isRemember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.user = "";
                Properties.Settings.Default.pass = "";
                Properties.Settings.Default.isRemember = false;
                Properties.Settings.Default.Save();
            }
        }
        public bool RememberScaleType()
        {
            if(rdOnline.Checked == true)
            {
                if (bBUS.IsInternetAvailable())
                {
                    Properties.Settings.Default.scaleType = true;
                    Properties.Settings.Default.Save();
                    return true;
                }   
                else
                {
                    MessageBox.Show("Kết nối Internet không ổn định, vui lòng chọn kiểu chạy Offline", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }    
                
            } 
            else
            {
                Properties.Settings.Default.scaleType = false;
                Properties.Settings.Default.Save();
                return true;
            }    
        }
        bool VerifyUser(string user)
        {
            
            if (txtUser.Text.Trim()=="admin" & txtPass.Text.Trim()=="sa1001")
            {
                Properties.Settings.Default.admin = true;
                Properties.Settings.Default.NhanVien = "Admin";
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                Properties.Settings.Default.admin = false;
                Properties.Settings.Default.Save();
            }  
            if(txtUser.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            tkDTO = ndBUS.GetPassByUser(user);
            if (tkDTO.Password != txtPass.Text.Trim())
            {
                MessageBox.Show("Tài khoản không chính xác, kiểm tra lại thông tin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                Properties.Settings.Default.NhanVien = tkDTO.HoTen;
                Properties.Settings.Default.LoginName = txtUser.Text.Trim();
                Properties.Settings.Default.Save();
                return true;
            } 
        }
        void DangNhap()
        {
            RememberPass();
            if (VerifyUser(txtUser.Text.Trim()) && RememberScaleType())
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
        }
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
    }
}
