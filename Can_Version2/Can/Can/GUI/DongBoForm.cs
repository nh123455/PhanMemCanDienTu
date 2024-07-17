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
    public partial class DongBoForm : Form
    {
        private readonly frmMain frmck;
        PhieuCanBUS phieuBUS = new PhieuCanBUS();
        public DongBoForm(frmMain frm)
        {
            InitializeComponent();
            frmck = frm;
            this.Load += DongBoForm_Load;
            btnDongBo.Click += BtnDongBo_Click;
        }

        private void BtnDongBo_Click(object sender, EventArgs e)
        {
            if (gvDongBo.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu đồng bộ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (phieuBUS.DongBo() == true)
            {
                phieuBUS.UpdateStatusSync();
                LoadData();
                MessageBox.Show("Đồng bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Đồng bộ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //while (phieuBUS.CheckSoLuongPhieuSync())
            //{
            //    MessageBox.Show("Số lượng còn");
            //} 
        }

        private void DongBoForm_Load(object sender, EventArgs e)
        {
            gvDongBo.DoubleClick += GvDongBo_Click;

            LoadData();
        }

        private void GvDongBo_Click(object sender, EventArgs e)
        {
            PhieuCanDTO item = gvDongBo.GetFocusedRow() as PhieuCanDTO;
            if (item == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phiếu cân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(item.LanCan == 2)
            {
                MessageBox.Show("Phiếu cân đã cân xong lần cân thứ 2", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            if (MessageBox.Show($"Cân phiếu: {item.SoPhieu} lần 2?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (frmck != null)
                {
                    frmck.LoadPhieuCanOffline(item);
                    this.Close();
                }
            }
        }

        public void LoadData()
        {
            PhieuCanSqliteBindingSource.DataSource = phieuBUS.GetPhieuCanSqlite();
        }
    }
}
