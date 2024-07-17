using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.GUI
{
    public class baseDTO
    {
        public string Nhap { get; set; }
        public string Xuat { get; set; }    
        public string DichVu { get; set; }
        public baseDTO()
        {
            Nhap = "Nhập";
            Xuat = "Xuất";
            DichVu = "Dịch Vụ";
        }
    }
}
