using Can.BUS;
using Can.DTO;
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
    public partial class TenMayForm : Form
    {
        private readonly frmMain frmck;
        DiemCanBUS dcBUS = new DiemCanBUS();
        baseBUS bBUS = new baseBUS();
        public TenMayForm(frmMain frm)
        {
            InitializeComponent();
            frmck = frm;
            this.Load += TenMayForm_Load;
        }

        private void TenMayForm_Load(object sender, EventArgs e)
        {   
            btnSave.Click += BtnSave_Click;
            btnSua.Click += BtnSua_Click;
            if(Properties.Settings.Default.admin == true)
            {
                btnSave.Enabled = true;
                btnSua.Enabled = true;
            }
            if (bBUS.IsInternetAvailable() == false)
            {
                MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
                btnSua.Enabled = false;
            }
            if(Properties.Settings.Default.scaleType == false)
            {
                btnSave.Enabled = false;
                btnSua.Enabled = false;
            }    
            if(Properties.Settings.Default.scaleType == true)
            {
                DiemCanDTO item = new DiemCanDTO();
                item = dcBUS.GetThongTinDiemCan(Properties.Settings.Default.connectString, bBUS.GetMac());

                txtSoMay.Text = item.SoMay.ToString();
                txtTenDiemCan.Text = item.TenDiemCan;
            }    
            else
            {
                DiemCanDTO item = new DiemCanDTO();
                item = dcBUS.GetThongTinDiemCanOff(bBUS.GetMac());

                txtSoMay.Text = item.SoMay.ToString();
                txtTenDiemCan.Text = item.TenDiemCan;
            }    
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(txtSoMay.Text.Trim()) || String.IsNullOrEmpty(txtTenDiemCan.Text.Trim()))
                {
                    MessageBox.Show("Tên máy hoặc tên điểm cân không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }    
                if (bBUS.IsInternetAvailable() == false)
                {
                    MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DiemCanDTO item = new DiemCanDTO();
                item.SoMay = Convert.ToInt32(txtSoMay.Text);
                item.TenDiemCan = txtTenDiemCan.Text.Trim();
                item.MAC = bBUS.GetMac();

                if (dcBUS.KiemTraSoMay(Properties.Settings.Default.connectString, Convert.ToInt32(txtSoMay.Text)) == false)
                {
                    if (dcBUS.UpdateDiemCan(Properties.Settings.Default.connectString, item) && bBUS.IsInternetAvailable())
                    {
                        dcBUS.UpdateDiemCanOff(item);
                        if (frmck != null)
                        {
                            frmck.LoadThongTinDiemCan();                           
                        }
                        MessageBox.Show("Update thông tin điểm cân thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Update thông tin điểm cân không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
                else
                    MessageBox.Show("Không tìm thấy số máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(bBUS.IsInternetAvailable() == false)
                {
                    MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
                if (dcBUS.KiemTraSoMay(Properties.Settings.Default.connectString, Convert.ToInt32(txtSoMay.Text)))
                {
                    DiemCanDTO item = new DiemCanDTO();
                    item.SoMay = Convert.ToInt32(txtSoMay.Text);
                    item.TenDiemCan = txtTenDiemCan.Text.Trim();
                    item.MAC = bBUS.GetMac();

                    Properties.Settings.Default.Machine_Name = Convert.ToInt32(txtSoMay.Text);
                    Properties.Settings.Default.Save();

                    if(dcBUS.InsertDiemCan(Properties.Settings.Default.connectString, item))
                    {
                        dcBUS.InsertDiemCanOff(item);
                        if (frmck != null)
                        {
                            frmck.LoadThongTinDiemCan();
                        }
                        MessageBox.Show($"Cập nhập tên máy thành công, tên máy: {Properties.Settings.Default.Machine_Name}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }    
                    else
                        MessageBox.Show($"Cập nhập thông tin điểm cân không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                {
                    MessageBox.Show("Số máy đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }
    }
}
