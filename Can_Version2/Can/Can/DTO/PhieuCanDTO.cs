using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.GUI
{
    public class PhieuCanDTO
    {
        public String SoPhieu { get; set; }
        public String BienSoXe { get; set; }
        public String NguoiBan { get; set; }
        public String NguoiMua { get; set; }
        public String LaiXe { get; set; }
        public String MaHang { get; set; }
        public String TenHang { get; set; }
        public String KhoHang { get; set; }
        public String GhiChu { get; set; }
        public String KieuCan { get; set; }
        public Int32 SoMay { get; set; }
        public Int32? KhoiLuongCan1 { get; set; }
        public Int32? KhoiLuongCan { get; set; }
        public DateTime? ThoiGianCan1 { get; set; }
        public Int32? KhoiLuongCan2 { get; set; }
        public DateTime? ThoiGianCan2 { get; set; }
        public byte[] Image1_1 { get; set; }
        public byte[] Image1_2 { get; set; }
        public byte[] Image1_3 { get; set; }
        public byte[] Image2_1 { get; set; }
        public byte[] Image2_2 { get; set; }
        public byte[] Image2_3 { get; set; }
        public Int32 LanCan { get; set; }
        public String NhanVienCanLan1 { get; set; }
        public String NhanVienCanLan2 { get; set; }
        public String Companyname { get; set; }
        public String Adress { get; set; }
        public String Phone { get; set; }
        public String Fax { get; set; }
        public DateTime created_at { get; set; }
        public String status_show { get; set; }
        public String sync { get; set; }
        public String TenDiemCan { get; set; }
        public PhieuCanDTO()
        {
            KhoiLuongCan1 = 0;
            KhoiLuongCan2 = 0;
            KhoiLuongCan = 0;
        }
    }
}
