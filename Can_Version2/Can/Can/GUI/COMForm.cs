using Can.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Can.GUI
{
    public partial class COMForm : Form
    {
        private readonly frmMain frmck;
        public COMForm(frmMain frm)
        {
            InitializeComponent();
            frmck = frm;
            this.Load += COMForm_Load;
        }

        private void COMForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            LoadThongTinCom();
            LoadAvailableComPorts();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");
                par.AddSetting("COM", "COMPORT", cbComPort.Text.Trim());
                par.AddSetting("COM", "BAUDRATE", txtBaudRate.Text.Trim());
                par.AddSetting("COM", "DATABITS", txtDataBits.Text.Trim());

                par.SaveSettings();
                if (frmck != null)
                {
                    frmck.LoadCom();
                    frmck.SetCom();
                    frmck.OpenComPort();
                }
                MessageBox.Show("Lưu kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadAvailableComPorts()
        {
            try
            {
                cbComPort.Properties.Items.Clear();

                // Lấy danh sách các cổng COM có sẵn trong máy tính
                string[] ports = SerialPort.GetPortNames();

                // Thêm danh sách cổng COM vào ComboBoxEdit
                cbComPort.Properties.Items.AddRange(ports);
            }
            catch
            {

            }
        }

        public void LoadThongTinCom()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("COM", "COMPORT").Split(',');
                cbComPort.Text = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("COM", "BAUDRATE").Split(',');
                txtBaudRate.Text = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("COM", "PARITY").Split(',');
                txtParity.Text = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("COM", "DATABITS").Split(',');
                txtDataBits.Text = Convert.ToString(a[0].Replace(" ", ""));

                a = par.GetSetting("COM", "STOPBITS").Split(',');
                txtStopBits.Text = Convert.ToString(a[0].Replace(" ", ""));
            }
        }
    }
}
