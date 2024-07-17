using Can.BUS;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Svg;
using System.Windows.Forms;

namespace Can.GUI.MauIn
{
    public partial class PhieuCanXe : DevExpress.XtraReports.UI.XtraReport
    {
        PhieuCanBUS pcBUS = new PhieuCanBUS();
        baseBUS baseBUS = new baseBUS();
        public PhieuCanXe(string soPhieu, int lanCan)
        {
            InitializeComponent();
            if(lanCan == 1)
            {
                if(Properties.Settings.Default.scaleType == true)
                {
                    if(baseBUS.IsInternetAvailable())
                    {
                        this.DataSource = pcBUS.GetReportBySoPhieuAndLanCan1(Properties.Settings.Default.connectString, soPhieu);
                    }    
                    else
                    {
                        MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }    
                }   
                //else
                //{
                //    this.DataSource = pcBUS.GetReportBySoPhieuAndLanCan1Off(soPhieu);
                //}    
                
            }
            else
            {
                if (Properties.Settings.Default.scaleType == true)
                {
                    if(baseBUS.IsInternetAvailable())
                    {
                        this.DataSource = pcBUS.GetReportBySoPhieuAndLanCan2(Properties.Settings.Default.connectString, soPhieu);
                    }
                    else
                    {
                        MessageBox.Show("Không có kết nối Internet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }   
                //else
                //{
                //    this.DataSource = pcBUS.GetReportBySoPhieuAndLanCan2Off(soPhieu);
                //}    
            } 
                
                
            try
            {
                logo.ImageUrl = @"Logo\\logo.png";
            }
            catch
            {

            }
        }

    }
}
