using Can.DAL;
using Can.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.BUS
{
    public class LoaiHangBUS
    {
        public List<LoaiHangDTO> GetLoaiHang(string connectString)
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.GetLoaiHang(connectString);
        }
        public List<LoaiHangDTO> GetLoaiHangOff()
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.GetLoaiHangOff();
        }
        public Int64 DeletLoaiHang(string connectString, LoaiHangDTO item)
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.DeletLoaiHang(connectString, item);
        }
        public Int64 DeletLoaiHangOff(LoaiHangDTO item)
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.DeletLoaiHangOff(item);
        }
        public Int64 InsertLoaiHang(string connectString, LoaiHangDTO item)
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.InsertLoaiHang(connectString, item);
        }
        public Int64 InsertLoaiHangOff(LoaiHangDTO item)
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.InsertLoaiHangOff(item);
        }
        public Int64 KiemTraMaHang(string connectString, string mahang)
        {
            LoaiHangDAL lhDAL = new LoaiHangDAL();
            return lhDAL.KiemTraMaHang(connectString, mahang);
        }
    }
}
