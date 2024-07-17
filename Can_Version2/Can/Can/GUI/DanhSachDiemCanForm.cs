using Can.BUS;
using DevExpress.XtraEditors;
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
    public partial class DanhSachDiemCanForm : DevExpress.XtraEditors.XtraForm
    {
        DiemCanBUS dcBUS = new DiemCanBUS();
        baseBUS bBUS = new baseBUS();
        public DanhSachDiemCanForm()
        {
            InitializeComponent();
            this.Load += DanhSachDiemCanForm_Load;
        }

        private void DanhSachDiemCanForm_Load(object sender, EventArgs e)
        {
            if (bBUS.IsInternetAvailable())
            {
                gridControl1.DataSource = dcBUS.GetThongTinDiemCanToanBo(Properties.Settings.Default.connectString);
            }
            else
                MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}