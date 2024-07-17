using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Can.BUS
{
    public class baseBUS
    {
        string mac;
        public bool IsInternetAvailable()
        {
            try
            {
                // Sử dụng một địa chỉ IP có thể truy cập để kiểm tra kết nối Internet
                Ping ping = new Ping();
                PingReply reply = ping.Send("8.8.8.8"); // Đây là địa chỉ IP của Google DNS

                if (reply.Status == IPStatus.Success)
                {
                    return true;          
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool LoadQuyenUser()
        {
            if (Properties.Settings.Default.admin == true) return true;
            else return false;
        }
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("HOANGMINHNHAT068"); // Thay thế bằng khóa bảo mật của bạn
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("6868686868686868"); // Thay thế bằng IV của bạn
        string sever, csdl, user, pass;
        public string LoadThongTinKetNoi()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("CONNECT", "SERVER").Split(',');
                sever = Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("CONNECT", "CSDL").Split(',');
                csdl = Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("CONNECT", "USER").Split(',');
                user = Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("CONNECT", "PASS").Split(',');
                pass = Decrypt(Convert.ToString(a[0].Replace(" ", "")));
            }

            return $"Data Source ={sever}; User ID ={user} ; Password ={pass}; Database ={csdl}";
        }
        public Int32 LoadLimit()
        {
            try
            {
                int x = 0;
                if (File.Exists(@"Config\Setting.ini"))
                {
                    IniParserBUS par = new IniParserBUS(@"Config\Setting.ini");
                    string[] a = par.GetSetting("PROGRAM", "SETTING").Split(',');
                    x = Convert.ToInt32(Decrypt(a[0].Replace(" ", "")));
                    x = x - 1;
                    par.AddSetting("PROGRAM", "SETTING", Encrypt(x.ToString()));
                    par.SaveSettings();
                    return x;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu cấu hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public string Encrypt(string plaintext)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plaintext);
                            }
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            catch
            {
                return "";
            }

        }
        public string Decrypt(string ciphertext)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(ciphertext)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                return "";
            }

        }
        public bool TestConnect(string connectString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                return false;
            }
        }

        public static void ExportGridViewToExcel(GridView grdView, DateTime Ngay, string fileName)
        {
            SaveFileDialog openFD = new SaveFileDialog();
            openFD.Filter = "Excel 2007->2010|*.xlsx";
            openFD.Title = "Save Microsoft Excel Document";
            openFD.InitialDirectory = "D:\\";
            openFD.FileName = fileName + "_" + Ngay.ToString("ddMMyyyyHHmmss");

            if (openFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    grdView.ExportToXlsx(openFD.FileName);
                    if (MessageBox.Show("Bạn muốn mở File Excel vừa được xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        System.Diagnostics.Process.Start(openFD.FileName);
                }
                catch
                {
                    MessageBox.Show("Có lỗi phát sinh !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        public string GetMac()
        {
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                // Lặp qua từng card mạng để lấy địa chỉ MAC
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    // Kiểm tra xem card mạng có phải là card mạng không ảo không
                    if (!networkInterface.Description.ToLower().Contains("virtual") &&
                        !networkInterface.Description.ToLower().Contains("pseudo"))
                    {
                        // Lấy địa chỉ MAC của card mạng
                        PhysicalAddress macAddress = networkInterface.GetPhysicalAddress();
                        byte[] bytes = macAddress.GetAddressBytes();

                        // In địa chỉ MAC dưới dạng chuỗi hex
                        //Console.WriteLine("Địa chỉ MAC: " + string.Join(":", bytes.Select(b => b.ToString("X2"))));
                        //MessageBox.Show(string.Join(":", bytes.Select(b => b.ToString("X2"))));

                        mac = string.Join(":", bytes.Select(b => b.ToString("X2")));
                        // Chỉ lấy địa chỉ MAC của card mạng đầu tiên không ảo và thoát khỏi vòng lặp
                        break;
                    }
                }
                return mac;
            }
            catch
            {
                return mac;
            }
            
        }
    }
}
