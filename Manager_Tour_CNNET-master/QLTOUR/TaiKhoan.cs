using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace QLTOUR
{
    class TaiKhoan
    {

        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }

        public TaiKhoan()
        {

        }
        public TaiKhoan(string tenTaiKhoan, string matKhau)
        {
            this.TenTaiKhoan = tenTaiKhoan;
            this.MatKhau = matKhau;
        }

        DBConnection db = new DBConnection();

        public TaiKhoan TimTaiKhoan(string tentk)
        {
            TaiKhoan tk = new TaiKhoan();
            string chuoitruyvan = "SELECT * FROM TAIKHOAN WHERE TenDangNhap = '" + tentk + "'";
            SqlDataReader Reader = db.ExcuteQuery(chuoitruyvan);
            if (Reader.Read())
            {
                tk.TenTaiKhoan = Reader["TenDangNhap"].ToString();
                tk.MatKhau = Reader["MatKhau"].ToString();
                tk.MaNV = Reader["MaNV"].ToString();
                return tk;
            }
            return null;
           
        }
    }
}
