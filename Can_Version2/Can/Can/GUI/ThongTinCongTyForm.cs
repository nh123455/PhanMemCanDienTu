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
    public partial class ThongTinCongTyForm : Form
    {
        CompanyBUS cBUS = new CompanyBUS();
        CompanyDTO cDTO = new CompanyDTO();
        baseBUS baseBUS = new baseBUS();
        public ThongTinCongTyForm()
        {
            InitializeComponent();
            this.Load += ThongTinCongTyForm_Load;
        }

        private void ThongTinCongTyForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            cDTO = cBUS.GetCompany(Properties.Settings.Default.connectString);
            if(Properties.Settings.Default.admin == true)
            {
                txtCompanyName.Enabled = true;
                txtAdress.Enabled = true;
                txtFax.Enabled = true;
                txtPhone.Enabled = true;
                txtEmail.Enabled = true;
                btnSave.Enabled = true;
            }
            LoadData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (baseBUS.IsInternetAvailable() == false)
            {
                MessageBox.Show("Edit thông tin công ty phải có Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cDTO = new CompanyDTO();
            cDTO.Company_name = txtCompanyName.Text.Trim();
            cDTO.Adress = txtAdress.Text.Trim();
            cDTO.Email = txtEmail.Text.Trim();
            cDTO.Phone = txtPhone.Text.Trim();
            cDTO.Fax = txtFax.Text.Trim();
            if (cBUS.UpdateCompany(Properties.Settings.Default.connectString, cDTO) != 0)
            {
                MessageBox.Show("Cập nhật thông tin công ty thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Cập nhật thông tin công ty không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void LoadData()
        {
            if (cDTO == null) return;

            txtCompanyName.Text = cDTO.Company_name;
            txtAdress.Text = cDTO.Adress;
            txtFax.Text = cDTO.Fax;
            txtPhone.Text = cDTO.Phone;
            txtEmail.Text = cDTO.Email;
        }
    }
}
