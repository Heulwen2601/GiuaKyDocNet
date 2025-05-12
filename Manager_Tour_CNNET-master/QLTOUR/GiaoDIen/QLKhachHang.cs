using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace QLTOUR.GiaoDIen
{
     public partial class QLKhachHang : Form
     {
          DBConnection db = new DBConnection();
          Ve formVe;
          private bool isFromVe = false;

          public string MaNV { get; set; }

          public QLKhachHang(string manv, Ve veForm)
          {
                InitializeComponent();
                MaNV = manv;
                formVe = veForm;
                isFromVe = true; // Đánh dấu rằng form này được mở từ form Ve
          }

          public QLKhachHang(string manv)
          {
               InitializeComponent();
               MaNV = manv;
               isFromVe = false; // Đánh dấu rằng form này không được mở từ form Ve
          }

          void Reset()
          {
               txt_makh.Clear();
               txt_hoten.Clear();
               txt_sdt.Clear();
               txt_email.Clear();
          }
          void HienThiDSKH()
          {
              dgv_khachhang.ReadOnly = true;
               string chuoitruyvan = "SELECT * FROM KHACHHANG";
               DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_khachhang.DataSource = dt;
          }
          private void QLKhachHang_Load(object sender, EventArgs e)
          {
               HienThiDSKH();
               btn_GoToDatVe.Visible = isFromVe;
          }



          private void btn_TrangChu_Click_1(object sender, EventArgs e)
          {
               this.Hide();


               MAIN_QL main = new MAIN_QL(MaNV);
               main.ShowDialog();
          }

          private string TaoMaSP()
          {
              int maNVTangDan = 1;
              string Lay3KiTuCuoi = Lay3KiTuCuoiTuCSDL();

              // Nếu có mã sản phẩm trong CSDL, sử dụng 3 kí tự cuối cùng của mã SP để tăng dần
              if (!string.IsNullOrEmpty(Lay3KiTuCuoi))
              {
                  maNVTangDan = int.Parse(Lay3KiTuCuoi) + 1;
              }
              string maNV = "KH" + maNVTangDan.ToString("D3");

              return maNV;
          }
          private string Lay3KiTuCuoiTuCSDL()
          {
                  db.Open();
                  string maNVToCheck = txt_makh.Text;

                  string sql = "SELECT TOP 1 RIGHT(MaKH, 3) FROM KhachHang ORDER BY MaKH DESC";
                    
                
                      object result = db.getScalar(sql);

                      // Trả về 3 kí tự cuối hoặc chuỗi rỗng nếu không có mã SP trong CSDL
                      return result != null ? result.ToString() : string.Empty;
                
          }

         
          private void btn_makh_Click(object sender, EventArgs e)
          {
              string maNV = TaoMaSP();
              txt_makh.Text = maNV;   
          }

          bool checkKH_HD(string MaKH)
          {
              string checkKH_HD = "SELECT MAKH FROM HOADON WHERE MAKH = (SELECT MaKH FROM KHACHHANG WHERE MAKH = '"+MaKH+"' ) ";
              int kq = db.CheckData(checkKH_HD);

              if(kq!=0)
              {
                  return true;
              }
              return false;

          }

          private void btn_xoa_Click(object sender, EventArgs e)
          {
               DataTable dt = (DataTable)dgv_khachhang.DataSource;
               dt.PrimaryKey = new DataColumn[] { dt.Columns["MaKH"] };
               DataRow dr = dt.Rows.Find(txt_makh.Text);
               //Xóa


               if (checkKH_HD(txt_makh.Text))
               {
                   MessageBox.Show("Không xóa khách hàng được vì khách hàng này đang có hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               else
               {
                   if (dr != null)
                   {
                        dr.Delete();
                        //cap nhat csdl
                        string chuoitruyvan = "Select * from KHACHHANG";
                        int k = db.updateDataTable(dt, chuoitruyvan);
                        if (k != 0)
                        {
                             MessageBox.Show("Đã xóa thành công");
                             Reset();

                        }
                        else
                             MessageBox.Show("Xóa không thành công");
                   }
                   else
                   {
                        MessageBox.Show("Khong tim thay Khoa");
                   }

               }

          }

          private void dgv_khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
          {
              
               if (e.RowIndex >= 0)
               {

                    DataGridViewRow row = dgv_khachhang.Rows[e.RowIndex];

                    txt_makh.Text = row.Cells["MaKH"].Value.ToString();

                    txt_hoten.Text = row.Cells["HOTEN"].Value.ToString();
                    txt_sdt.Text = row.Cells["Sdt"].Value.ToString();
                    txt_email.Text = row.Cells["Email"].Value.ToString();


                    if (row.Cells["GioiTinh"].Value.ToString() == "Nữ")
                    {
                         rdo_nu.Checked = true;
                    }
                    else
                    {
                         rdo_nam.Checked = true;
                    }
                    //dt_ngaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

               }
          }

          private void btn_sua_Click(object sender, EventArgs e)
          {
               dgv_khachhang.AllowUserToAddRows = false;
               btn_luu.Visible = true;
               btn_luu.Enabled = true;
               btn_them.Enabled = false;

               string gioiTinh = rdo_nam.Checked ? rdo_nam.Text : (rdo_nu.Checked ? rdo_nu.Text : null);

               DataTable dt = (DataTable)dgv_khachhang.DataSource;
               DataColumn[] key = new DataColumn[1];
               key[0] = dt.Columns[0];
               dt.PrimaryKey = key;
               DataRow dr = dt.Rows.Find(txt_makh.Text);
               if (dr != null)
               {
                   dr["MaKH"] = txt_makh.Text;
                   dr["HOTEN"] = txt_hoten.Text;
                   dr["Sdt"] = txt_sdt.Text;
                   dr["Email"] = txt_email.Text;
                   dr["GioiTinh"] = gioiTinh;
               }

               //dt.Rows.Add(dr);

               // Cập nhật DataSource của DataGridView
               dgv_khachhang.DataSource = dt;

               // Hiển thị dữ liệu trên DataGridView
               dgv_khachhang.Refresh();
              
          }

          private void btn_luu_Click(object sender, EventArgs e)
          {
               string gioiTinh = rdo_nam.Checked ? rdo_nam.Text : rdo_nu.Text;
               DataTable dt = (DataTable)dgv_khachhang.DataSource;
               DataColumn[] key = new DataColumn[1];
               key[0] = dt.Columns[0];
               dt.PrimaryKey = key;
               DataRow dr = dt.Rows.Find(txt_makh.Text);
               if (dr != null)
               {
                    dr["MaKH"] = txt_makh.Text;
                    dr["HOTEN"] = txt_hoten.Text;
                    dr["Sdt"] = txt_sdt.Text;
                    dr["Email"] = txt_email.Text;
                    dr["GioiTinh"] = gioiTinh;
               }
               string chuoitruyvan = "Select * from KHACHHANG";
               int kq = db.updateDataTable(dt, chuoitruyvan);
               if (kq > 0)
               {
                    MessageBox.Show("Cập nhật thành công");
                    btn_them.Enabled = true;
                    btn_luu.Visible = false;
               }
               else
                    MessageBox.Show("Cập nhật không thành công");

          }

          private void btn_reset_Click(object sender, EventArgs e)
          {
               Reset();
          }

          void LoadDataBySearch(string searchName)
          {
               string chuoitruyvan = "SELECT * FROM KHACHHANG WHERE HoTen COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%' + '" + txt_timkh.Text.Trim() + "' + N'%'";
               DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_khachhang.DataSource = dt;

          }
          private void btn_tim_Click(object sender, EventArgs e)
          {

               string searchName = txt_timkh.Text.Trim();
               LoadDataBySearch(searchName);
          }

          bool checkMa(string ma)
          {
              string checkMa = "SELECT MaKH FROM KHACHHANG Where MAKH = '" + ma + "'";
              int kq = db.CheckData(checkMa);
              if (kq != 0)
              {
                  return true;
              }
              return false;
          }

          private void btn_them_Click(object sender, EventArgs e)
          {
              if (checkMa(txt_makh.Text))
              {
                  MessageBox.Show("Mã khách hàng này đã bị trùng. Hãy kiểm tra lại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  txt_makh.Clear();
              }
              else
              {
                  dgv_khachhang.ReadOnly = false;
                  btn_luu.Enabled = true;

                  if (string.IsNullOrWhiteSpace(txt_makh.Text) == false)
                  {
                      string gioiTinh = rdo_nam.Checked ? rdo_nam.Text : (rdo_nu.Checked? rdo_nu.Text : null);

                      DataTable dt = (DataTable)dgv_khachhang.DataSource;
                      DataRow dr = dt.NewRow();

                      dr["MAKH"] = txt_makh.Text;
                      dr["HOTEN"] = txt_hoten.Text;
                      dr["Sdt"] = txt_sdt.Text;
                      dr["Email"] = txt_email.Text;
                      dr["GioiTinh"] = gioiTinh;



                      dt.Rows.Add(dr);

                      string chuoitruyvan = "SELECT * FROM KHACHHANG";
                      int kq = db.updateDataTable(dt, chuoitruyvan);

                      if (kq > 0)
                      {
                          MessageBox.Show("Thêm khách hàng thành công");
                          Reset();
                          HienThiDSKH();
                      }
                      else
                      {
                          MessageBox.Show("Thêm khách hàng thất bại");
                      }
                  }
                  else
                  {
                      MessageBox.Show("Hãy Tạo Mã Khách Hàng");
                  }

              }

          }

          private void btn_all_Click(object sender, EventArgs e)
          {
              HienThiDSKH();
          }

          private void btn_GoToDatVe_Click(object sender, EventArgs e)
          {
              formVe.MaKH = txt_makh.Text;
              this.Close(); // Đóng QLKhachHang
              formVe.Show(); // Hiển thị lại form đặt vé
        }

     }
}
