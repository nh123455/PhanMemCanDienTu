using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Can.GUI
{
    public class LoaiHangDTO
    {
        public Int64 id { get; set; }
        public String MaHang { get; set; }
        public String TenHang { get; set; }
        public DateTime created_at { get; set; }
    }
}
