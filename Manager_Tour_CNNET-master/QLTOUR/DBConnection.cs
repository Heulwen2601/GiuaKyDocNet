using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLTOUR
{
     class DBConnection
     {
          SqlConnection conn;
          SqlCommand cmd;
          string chuoiketnoi = @"Data Source = HEULWEN_UWU; Initial Catalog = TOUR_CNN; Integrated Security=True";

          public DBConnection()
          {
               conn = new SqlConnection(chuoiketnoi);
          }
          public DBConnection(string chuoikn)
          {
               conn = new SqlConnection(chuoikn);
          }
          public void Open()
          {
               if (conn.State == ConnectionState.Closed)
                    conn.Open();
          }
          public void Close()
          {
               if (conn.State == ConnectionState.Open)
                    conn.Close();
          }

          public int CheckData(string chuoitruyvan)
          {
              Open();
              cmd = new SqlCommand(chuoitruyvan, conn);
              SqlDataReader dta = cmd.ExecuteReader();

              // Kiểm tra xem có dữ liệu hay không
              if (dta.HasRows)
              {
                  // Đóng DataReader
                  dta.Close();
                  Close();
                  return 1;
              }

              // Đóng DataReader và kết nối
              dta.Close();
              Close();
              return 0;
          }


          public int getNonQuery(string chuoitruyvan)
          {
               Open();
               SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
               int kq = cmd.ExecuteNonQuery();
               Close();
               return kq;
          }
          public object getScalar(string chuoitruyvan)//select count
          {
               Open();
               SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
               //thực thi
               object kq = cmd.ExecuteScalar();
               Close();
               return kq;
          }
          public DataTable getDataTable(string chuoitruyvan)
          {
               SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds.Tables[0];
          }
          public int updateDataTable(DataTable dt, string chuoitruyvan)
          {
               SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
               SqlCommandBuilder cb = new SqlCommandBuilder(da);
               int kq = da.Update(dt);
               return kq;
          }

          public int getQuery(string query)
          {
               Open();
               cmd = new SqlCommand(query, conn);
               int kq = cmd.ExecuteNonQuery();
               Close();
               return kq;
          }



          public List<TaiKhoan> TaiKhoans(string query)// đọc dữ liệu trong tài khoản
          {
               List<TaiKhoan> taikhoan = new List<TaiKhoan>();
               Open();
               cmd = new SqlCommand(query, conn);
               SqlDataReader dta;
               dta = cmd.ExecuteReader();
               while (dta.Read())
               {
                    taikhoan.Add(new TaiKhoan(dta.GetString(0), dta.GetString(1)));
               }
               Close();
               return taikhoan;
          }


          public SqlDataReader ExcuteQuery(string sql)
          {
               Open();
               SqlCommand cmd = new SqlCommand(sql, conn);
               SqlDataReader rd = cmd.ExecuteReader();
               return rd;
          }
          public List<NhanVien> NhanViens()
          {
               List<NhanVien> nvs = new List<NhanVien>();
               Open();
               SqlDataReader dta = ExcuteQuery("SELECT*FROM NHANVIEN");
               while (dta.Read())
               {
                    NhanVien nv = new NhanVien();
                    nv.MaNV = dta["MaNV"].ToString();
                    nvs.Add(nv);
               }
               return nvs;

          }
          public string getMaNVNext()
          {
               Open();
               List<NhanVien> list = NhanViens();
               if (list.Count == 0)
               {
                    Close();
                    return "NV001";
               }
               else
               {
                    string MaMax = list[list.Count - 1].MaNV.ToString();
                    MaMax = MaMax.Substring(MaMax.Length - 3, 3);
                    int max = int.Parse(MaMax);
                    max++;
                    if (max < 10)
                    {
                         Close();
                         return "NV00" + max.ToString();
                    }
                    else if (max < 100)
                    {
                         Close();
                         return "NV0" + max.ToString();
                    }
                    Close();
                    return "NV" + max.ToString();
               }
          }
     }
}
