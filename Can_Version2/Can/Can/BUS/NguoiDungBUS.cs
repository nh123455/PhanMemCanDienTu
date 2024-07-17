using Can.DAL;
using Can.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.BUS
{
    public class NguoiDungBUS
    {
        public List<TaiKhoanDTO> GetListNguoiDung()
        {
            NguoiDungDAL ndDAL = new NguoiDungDAL();
            return ndDAL.GetListNguoiDung();
        }
        public Int64 InsertUser(TaiKhoanDTO item)
        {
            NguoiDungDAL ndDAL = new NguoiDungDAL();
            return ndDAL.InsertUser(item);
        }
        public TaiKhoanDTO GetNameByUser(string user)
        {
            NguoiDungDAL ndDAL = new NguoiDungDAL();
            return ndDAL.GetNameByUser(user);
        }
        public TaiKhoanDTO GetPassByUser(string user)
        {
            NguoiDungDAL ndDAL = new NguoiDungDAL();
            return ndDAL.GetPassByUser(user);
        }
        public Int64 DeleteUserByUserName(TaiKhoanDTO item)
        {
            NguoiDungDAL ndDAL = new NguoiDungDAL();
            return ndDAL.DeleteUserByUserName(item);
        }
    }
}
