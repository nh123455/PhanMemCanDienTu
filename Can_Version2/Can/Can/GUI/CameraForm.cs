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
    public partial class CameraForm : Form
    {
        public CameraForm()
        {
            InitializeComponent();
            this.Load += CameraForm_Load;
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            LoadThongTin();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");
                par.AddSetting("CAMERA", "RTSP1", txtRstp1.Text.Trim());
                par.AddSetting("CAMERA", "RTSP2", txtRstp2.Text.Trim());
                par.AddSetting("CAMERA", "RTSP3", txtRstp3.Text.Trim());

                par.SaveSettings();
                MessageBox.Show("Lưu kết nối thành công, phần mềm sẽ tự động tắt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        public void LoadThongTin()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("CAMERA", "RTSP1").Split(',');
                txtRstp1.Text = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("CAMERA", "RTSP2").Split(',');
                txtRstp2.Text = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("CAMERA", "RTSP3").Split(',');
                txtRstp3.Text = Convert.ToString(a[0].Replace(" ", ""));
            }
        }
    }
}
