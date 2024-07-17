using Can.DAL;
using Can.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.BUS
{
    public class DiemCanBUS
    {
        public bool InsertDiemCan(string connectString, DiemCanDTO item)
        {
            DiemCanDAL cDAL = new DiemCanDAL();
            return cDAL.InsertDiemCan(connectString, item);
        }
        public bool InsertDiemCanOff(DiemCanDTO item)
        {
            DiemCanDAL cDAL = new DiemCanDAL();
            return cDAL.InsertDiemCanOff(item);
        }
        public bool KiemTraSoMay(string connectString, Int32 SoMay)
        {
            DiemCanDAL cDAL = new DiemCanDAL();
            return cDAL.KiemTraSoMay(connectString, SoMay);
        }
        public bool UpdateDiemCan(string connectString, DiemCanDTO item)
        {
            DiemCanDAL cDAL = new DiemCanDAL();
            return cDAL.UpdateDiemCan(connectString, item);
        }
        public bool UpdateDiemCanOff(DiemCanDTO item)
        {
            DiemCanDAL cDAL = new DiemCanDAL();
            return cDAL.UpdateDiemCanOff(item);
        }
        public DiemCanDTO GetThongTinDiemCan(string connectString, string MAC)
        {
            DiemCanDAL pcDAL = new DiemCanDAL();
            return pcDAL.GetThongTinDiemCan(connectString, MAC);
        }
        public DiemCanDTO GetThongTinDiemCanOff(string MAC)
        {
            DiemCanDAL pcDAL = new DiemCanDAL();
            return pcDAL.GetThongTinDiemCanOff(MAC);
        }
        public List<DiemCanDTO> GetThongTinDiemCanToanBo(string connecstring)
        {
            DiemCanDAL pcDAL = new DiemCanDAL();
            return pcDAL.GetThongTinDiemCanToanBo(connecstring);
        }
    }
}
