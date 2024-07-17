using Can.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Can.GUI
{
    public partial class ConnectForm : Form
    {
        baseBUS bBUS = new baseBUS();
        public ConnectForm()
        {
            InitializeComponent();
            this.Load += ConnectForm_Load;
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            btnKT.Click += BtnKT_Click;
            btnSave.Click += BtnSave_Click;
            LoadThongTin();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");
                par.AddSetting("CONNECT", "SERVER", bBUS.Encrypt(txtServer.Text.Trim()));
                par.AddSetting("CONNECT", "CSDL", bBUS.Encrypt(txtCSDL.Text.Trim()));
                par.AddSetting("CONNECT", "USER", bBUS.Encrypt(txtNguoiDung.Text.Trim()));
                par.AddSetting("CONNECT", "PASS", bBUS.Encrypt(txtPassword.Text.Trim()));

                par.SaveSettings();
                MessageBox.Show("Lưu kết nối thành công, khởi động lại phần mềm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void BtnKT_Click(object sender, EventArgs e)
        {
            string ConnStr = "Data Source = " + txtServer.Text.Trim() + "; User ID = " + txtNguoiDung.Text.Trim() + "; Password = " + txtPassword.Text.Trim() + "; Database = " + txtCSDL.Text.Trim();
            if (bBUS.TestConnect(ConnStr))
            {
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Kết nối không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void LoadThongTin()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("CONNECT", "SERVER").Split(',');
                txtServer.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("CONNECT", "CSDL").Split(',');
                txtCSDL.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("CONNECT", "USER").Split(',');
                txtNguoiDung.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("CONNECT", "PASS").Split(',');
                txtPassword.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));
            }
        }
    }
}
