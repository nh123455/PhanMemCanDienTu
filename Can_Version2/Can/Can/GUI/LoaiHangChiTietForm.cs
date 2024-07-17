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
    public partial class LoaiHangChiTietForm : Form
    {
        private readonly LoaiHangForm frmck;
        LoaiHangDTO lhDTO = new LoaiHangDTO();
        LoaiHangBUS lhBUS = new LoaiHangBUS();
        baseBUS baseBUS = new baseBUS();
        public LoaiHangChiTietForm(LoaiHangForm frm)
        {
            InitializeComponent();
            frmck = frm;

            this.Load += LoaiHangChiTietForm_Load;
        }

        private void LoaiHangChiTietForm_Load(object sender, EventArgs e)
        {
            btnSave.Click += BtnSave_Click;
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(baseBUS.IsInternetAvailable() == false)
            {
                MessageBox.Show("Thêm mới loại hàng phải đảm bảo có Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            if(txtMaHang.Text.Trim() == "" || txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Mã hàng hoặc tên hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(lhBUS.KiemTraMaHang(Properties.Settings.Default.connectString,txtMaHang.Text.Trim()) == 1)
            {
                MessageBox.Show("Mã hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            lhDTO = new LoaiHangDTO();
            lhDTO.MaHang = txtMaHang.Text.Trim();
            lhDTO.TenHang = txtTenHang.Text.Trim();

            if(lhBUS.InsertLoaiHang(Properties.Settings.Default.connectString, lhDTO) == 1 && lhBUS.InsertLoaiHangOff(lhDTO) == 1)
            {
                MessageBox.Show("Thêm mới loại hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.ResetText();
                txtTenHang.ResetText();
                if (frmck != null)
                {
                    frmck.LoadData();
                }
            }   
            else
            {
                MessageBox.Show("Thêm mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
  
        }
    }
}
