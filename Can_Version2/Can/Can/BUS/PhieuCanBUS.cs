using Can.DAL;
using Can.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.BUS
{
    public class PhieuCanBUS
    {
        public Int64 InsertPhieuCanLan1(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.InsertPhieuCanLan1(connectString, item);
        }
        public bool InsertPhieuCanLan(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.InsertPhieuCanLan(connectString, item);
        }
        public List<PhieuCanDTO> GetPhieuCan(string connectString)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCan(connectString);
        }
        public List<PhieuCanDTO> GetPhieuCanByDate(string connectString, DateTime fromDate, DateTime toDate, int soMay)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanByDate(connectString, fromDate, toDate, soMay);
        }
        public List<PhieuCanDTO> GetPhieuCanByDateOff(DateTime fromDate, DateTime toDate)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanByDateOff(fromDate, toDate);
        }
        public List<PhieuCanDTO> GetPhieuCanLan1(string connectString)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanLan1(connectString);
        }
        public List<PhieuCanDTO> GetPhieuCanLan1Sqlite()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanLan1Sqlite();
        }
        public List<PhieuCanDTO> GetPhieuCanLan2(string connectString)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanLan2(connectString);
        }
        public List<PhieuCanDTO> GetPhieuCanLan2Sqlite()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanLan2Sqlite();
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan1(string connectString, string soPhieu)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetReportBySoPhieuAndLanCan1(connectString, soPhieu);
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan1Off(string soPhieu)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetReportBySoPhieuAndLanCan1Off(soPhieu);
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan2(string connectString, string soPhieu)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetReportBySoPhieuAndLanCan2(connectString, soPhieu);
        }
        public List<PhieuCanDTO> GetReportBySoPhieuAndLanCan2Off(string soPhieu)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetReportBySoPhieuAndLanCan2Off(soPhieu);
        }
        public Int64 UpdatePhieuCan(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdatePhieuCan(connectString, item);
        }
        public bool UpdatePhieuCan1(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdatePhieuCan1(connectString, item);
        }
        public bool UpdatePhieuCan1Off(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdatePhieuCan1Off(item);
        }
        public bool UpdatePhieuCan2(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdatePhieuCan2(connectString, item);
        }
        public bool UpdatePhieuCan2Off(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdatePhieuCan2Off(item);
        }
        public List<PhieuCanDTO> GetPhieuCanSqlite()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetPhieuCanSqlite();
        }
        public bool InsertPhieuCanLanSqlite(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.InsertPhieuCanLanSqlite(item);
        }
        public bool DongBo()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.DongBo();
        }
        public bool DongBo1Phieu(string sophieu)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.DongBo1Phieu(sophieu);
        }
        public bool DeleteDataOffline()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.DeleteDataOffline();
        }
        public bool UpdateStatusSync()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdateStatusSync();
        }
        public bool CheckSoLuongPhieuSync()
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.CheckSoLuongPhieuSync();
        }
        public bool UpdateStatusSyncSoPhieu(string sophieu)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdateStatusSyncSoPhieu(sophieu);
        }
        public bool DeletePhieuCan(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.DeletePhieuCan(connectString, item);
        }
        public bool DeletePhieuCanOff(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.DeletePhieuCanOff(item);
        }
        public bool DeletePhieuCanOffSync(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.DeletePhieuCanOffSync(item);
        }
        public bool UpdateStatusPC1(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdateStatusPC1(connectString, item);
        }
        public List<PhieuCanDTO> GetListThongTinPhieuCan(string connectString)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.GetListThongTinPhieuCan(connectString);
        }
        public bool UpdateSqliteStatusPC1(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.UpdateSqliteStatusPC1(item);
        }
        public bool CheckPhieuCanLan1(string connectString, PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.CheckPhieuCanLan1(connectString, item);
        }
        public bool CheckPhieuCanLan1Sqlite(PhieuCanDTO item)
        {
            PhieuCanDAL pcDAL = new PhieuCanDAL();
            return pcDAL.CheckPhieuCanLan1Sqlite(item);
        }
    }
}
