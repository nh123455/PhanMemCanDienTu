using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
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
    public partial class ViewReportForm : DevExpress.XtraEditors.XtraForm
    {
        string _sReportPath = "";
        DataTable _dtValue = new DataTable();
        bool bDirect = false;
        XtraReport _xReport = null;
        public ViewReportForm()
        {
            InitializeComponent();
        }
        public ViewReportForm(XtraReport xReport)
        {
            InitializeComponent();
            this.Load += ViewReportForm_Load;
            _xReport = xReport;
            //if (PublicVariable.User.supper_user && PublicVariable.TaiKhoan == "sysadmin") btnEditReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            LoadReport();
            documentViewer1.ExecCommand(PrintingSystemCommand.PrintDirect);
            MessageBox.Show("In phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        
        
        public void ViewReportForm_Load(object sender, EventArgs e)
        {
        }
        private void LoadReport()
        {

            //string[] sSplit = _sReportPath.Split(new string[] { @"\" }, StringSplitOptions.None);
            //string sServerPath = Program.sPathServer + @"Report\" + sSplit[sSplit.Length - 1];
            //CheckVersionReports(sServerPath, _sReportPath);
            if(_xReport == null)
            {
                this.Text = _sReportPath;
                if (_dtValue == null)
                {
                    XtraMessageBox.Show("Không có dữ liệu để in!");
                    return;
                }
                if (_dtValue.Rows.Count <= 0)
                {
                    XtraMessageBox.Show("Không có dữ liệu để in!");
                    return;
                }
                try
                {

                    XtraReport xNew = new XtraReport();
                    xNew.LoadLayout(_sReportPath);
                    xNew.DataSource = _dtValue;
                    xNew.RequestParameters = false;
                    xNew.ShowPrintMarginsWarning = false;
                    xNew.CreateDocument();
                    ReportPrintTool ReportPrintTool = new ReportPrintTool(xNew);
                    ReportPrintTool.AutoShowParametersPanel = false;
                    documentViewer1.PrintingSystem = ReportPrintTool.PrintingSystem;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "File not found.")
                        XtraMessageBox.Show("Không tồn tại tập tin \n'" + _sReportPath + "'", "File not found.");
                    else
                        XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (File.Exists(@"Report\" + _xReport.ToString() + ".repx"))
                    {
                        _xReport.LoadLayout(@"Report\" + _xReport.ToString() + ".repx");
                    }
                    _xReport.PrintingSystem.ShowMarginsWarning = false;
                    _xReport.ShowPrintMarginsWarning = false;
                    documentViewer1.PrintingSystem = _xReport.PrintingSystem;
                    _xReport.CreateDocument();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
        public bool CheckVersionReports(string sServerFileName, string sFileName)
        {
            try
            {
                if (!System.IO.File.Exists(sFileName))
                {
                    if (System.IO.File.Exists(sServerFileName))
                    {
                        System.IO.File.Copy(sServerFileName, sFileName);
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                else
                {
                    if (System.IO.File.Exists(sServerFileName))
                    {
                        DateTime dtServer = System.IO.File.GetLastWriteTime(sServerFileName);
                        DateTime dtClient = System.IO.File.GetLastWriteTime(sFileName);
                        if (dtServer > dtClient)
                        {
                            if (DevExpress.XtraEditors.XtraMessageBox.Show("Có mẫu báo báo cáo mới trên máy chủ.\nBạn có muốn cập nhật không? Nếu đồng ý thì chọn Yes, ngược lại chọn No.", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                System.IO.File.Copy(sServerFileName, sFileName, true);
                            }
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
            }
            catch (FileNotFoundException fo)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tìm thấy file: " + sServerFileName, fo.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return (System.IO.File.Exists(sFileName));
        }
    }
}