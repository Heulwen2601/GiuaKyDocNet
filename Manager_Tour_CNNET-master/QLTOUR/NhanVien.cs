using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTOUR
{
    class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string ChucVu { get; set; }
        public NhanVien()
        {
            MaNV = "";
            TenNV = "";
            GioiTinh = "";
            Email = "";
            DiaChi = "";
            SDT = "";
            ChucVu = "";        
        }
    }
}
