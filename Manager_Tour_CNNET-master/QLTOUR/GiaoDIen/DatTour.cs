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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLTOUR.GiaoDIen
{
     public partial class DatTour : Form
     {
          DBConnection db = new DBConnection();
          public string MaNV { get; set; }
          public DatTour(string manv)
          {
               InitializeComponent();
               MaNV = manv;
               TenNV();
          }

          void TenNV()
          {
               string sqltennv = "SELECT HOTEN FROM NhanVien WHERE MANV = '" + MaNV + "'";
               SqlDataReader reader = db.ExcuteQuery(sqltennv);
               if (reader.Read())
               {
                    string tennv = reader["HOTEN"].ToString();
                    lb_tennv.Text = tennv;
                    db.Close();
               }
               else
               {
                    lb_tennv.Text = "Không tìm thấy thông tin";
                    db.Close();
               }
          }

          private void QLTour_Load(object sender, EventArgs e)
          {
               HienDSTOUR();
               
          }
          void clear()
          {
               txt_timtour.Clear();

          }
          void HienDSTOUR()
          {
               dgv_thongtintour.ReadOnly = true;
               string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien ";
               DataTable dt = db.getDataTable(chuoitruyvan);
               DataColumn[] key = new DataColumn[1];
               key[0] = dt.Columns[0];

               dgv_thongtintour.DataSource = dt;
               dgv_thongtintour.Columns["MoTaTour"].Visible = false;
               dgv_thongtintour.Columns["TGBatDau"].Visible = false;
               dgv_thongtintour.Columns["TGKetThuc"].Visible = false;
               dgv_thongtintour.Columns["MaLoaiTour"].Visible = false;
               dgv_thongtintour.Columns["MaPhuongTien"].Visible = false;
               dgv_thongtintour.Columns["MaPhuongTien1"].Visible = false;
               dgv_thongtintour.Columns["MAXP"].Visible = false;
               dgv_thongtintour.Columns["MAXP1"].Visible = false;
               dgv_thongtintour.Columns["MaLoaiTour"].Visible = false;
               dgv_thongtintour.Columns["MaLoaiTour1"].Visible = false;
               dgv_thongtintour.Columns["TenLoaiTour"].Visible = false;

               dgv_thongtintour.Columns["AnhTour"].Visible = false;


          }

          private void btn_tim_Click(object sender, EventArgs e)
          {
               string searchName = txt_timtour.Text.Trim();
               LoadDataBySearch(searchName);
          }

          private void dgv_thongtintour_CellClick(object sender, DataGridViewCellEventArgs e)
          {


          }
          private void LoadDataBySearch(string searchName)
          {

               string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien WHERE TenTour COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%' + '" + txt_timtour.Text.Trim() + "' + N'%'";

               DataTable dt = db.getDataTable(chuoitruyvan);
               dgv_thongtintour.DataSource = dt;
          }

          private void btn_caocap_Click(object sender, EventArgs e)
          {
               string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien WHERE ttt.MaLoaiTour = 'TCC'";

               DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_thongtintour.DataSource = dt;
          }

          private void btn_tieuchuan_Click(object sender, EventArgs e)
          {
               string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien WHERE ttt.MaLoaiTour = 'TTC'";


               DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_thongtintour.DataSource = dt;
          }

          private void btn_tietkiem_Click(object sender, EventArgs e)
          {
               string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien WHERE ttt.MaLoaiTour = 'TTK'";


               DataTable dt = db.getDataTable(chuoitruyvan);

               dgv_thongtintour.DataSource = dt;
          }

          private void dgv_thongtintour_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
               dgv_thongtintour.ReadOnly = true;
               if (e.RowIndex >= 0)
               {
                    DataGridViewRow row = dgv_thongtintour.Rows[e.RowIndex];

                    btn_datve.Visible = true;
                    lb_matour.Text = row.Cells["MaTour"].Value.ToString();
                    lb_matour.Visible = true;
                    lb_tenloaitour.Text = row.Cells["TenLoaiTour"].Value.ToString();
                    lb_tenloaitour.Visible = true;
                    lb_tentour.Text = row.Cells["TenTour"].Value.ToString();
                    lb_tentour.Visible = true;
                    lb_giatour.Text = ((decimal)row.Cells["GiaTour"].Value).ToString("C0");
                    lb_giatour.Visible = true;
                    //lb_motatour.Text = row.Cells["MoTaTour"].Value.ToString();
                    //lb_motatour.Visible = true;
                    richboxDescription.Text = row.Cells["MoTaTour"].Value.ToString();
                    richboxDescription.Visible = true;
                    lb_valuexp.Text = row.Cells["MaXP"].Value.ToString();
                    lb_valuexp.Visible = true;
                    lb_xp.Visible = true;
                    lb_valuephuongtien.Text = row.Cells["MaPhuongTien"].Value.ToString();
                    lb_valuephuongtien.Visible = true;
                    lb_phuongtien.Visible = true;
                    lb_valueslve.Text = row.Cells["SLVeConLai"].Value.ToString();
                    lb_valueslve.Visible = true;
                    lb_slve.Visible = true;

                    lb_thoigian.Visible = true;
                    lb_tgbatdau.Text = row.Cells["TGBatDau"].Value.ToString();
                    lb_tgbatdau.Visible = true;
                    lb_tgketthuc.Text = row.Cells["TGKetThuc"].Value.ToString();
                    lb_tgketthuc.Visible = true;

                    lbIDTour.Visible = true;
                    lbDescription.Visible = true;
                    lbPrice.Visible = true;
                    lbType.Visible = true;
                    string anhtour = row.Cells["AnhTour"].Value.ToString();


                    ptb_anhtour.Visible = true;
                    // Đặt chỉ mục của hình ảnh cần sử dụng từ ImageList
                    int imageIndex = imageList1.Images.IndexOfKey(anhtour);

                    // Kiểm tra xem chỉ mục có hợp lệ không
                    if (imageIndex != -1)
                    {
                         // Gán hình ảnh từ ImageList cho PictureBox
                         ptb_anhtour.Image = imageList1.Images[imageIndex];
                    }
                    else
                    {
                         // Xử lý khi hình ảnh không tồn tại trong ImageList
                        ptb_anhtour.Image = imageList1.Images[1];
                    }

                    //dt_ngaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

               }
          }

          private void btn_datve_Click(object sender, EventArgs e)
          {
               string matour = lb_matour.Text;
               Ve datve = new Ve(matour, MaNV);
               this.Hide();
               datve.ShowDialog();
          }

          private void comboBoxTourType_SelectedIndexChanged(object sender, EventArgs e)
          {
              FilterTours();
          }

          private void comboBoxBudget_SelectedIndexChanged(object sender, EventArgs e)
          {
              FilterTours();
          }
 
          private void comboBoxTransport_SelectedIndexChanged(object sender, EventArgs e)
          {
              FilterTours();
          }


        private void FilterTours()
          {
              StringBuilder query = new StringBuilder();
              query.Append("SELECT * FROM LOAITOUR lt ");
              query.Append("JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour ");
              query.Append("JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP ");
              query.Append("JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien ");

              List<string> conditions = new List<string>();

              // Loại tour
              if (comboBoxTourType.SelectedItem != null)
              {
                  string loai = comboBoxTourType.SelectedItem.ToString();
                  if (loai == "Cao Cấp") conditions.Add("ttt.MaLoaiTour = 'TCC'");
                  else if (loai == "Tiêu Chuẩn") conditions.Add("ttt.MaLoaiTour = 'TTC'");
                  else if (loai == "Tiết Kiệm") conditions.Add("ttt.MaLoaiTour = 'TTK'");
              }

              // Mức giá
              if (comboBoxBudget.SelectedItem != null)
              {
                  string budget = comboBoxBudget.SelectedItem.ToString();
                  if (budget == "Dưới $200") conditions.Add("ttt.GiaTour < 200");
                  else if (budget == "Từ $200 đến $400") conditions.Add("ttt.GiaTour >= 200 AND ttt.GiaTour <= 400");
                  else if (budget == "Từ $400 đến $800") conditions.Add("ttt.GiaTour >= 400 AND ttt.GiaTour <= 800");
                  else if (budget == "Trên $800") conditions.Add("ttt.GiaTour > 800");
              }

              // Phương tiện
              if (comboBoxTransport.SelectedItem != null)
              {
                  string transport = comboBoxTransport.SelectedItem.ToString();
                  conditions.Add($"ptt.TenPhuongTien = N'{transport}'");
              }

              if (conditions.Count > 0)
              {
                  query.Append(" WHERE ");
                  query.Append(string.Join(" AND ", conditions));
              }

              DataTable dt = db.getDataTable(query.ToString());
              dgv_thongtintour.DataSource = dt;
          }


        private void btn_all_Click(object sender, EventArgs e)
          {
              HienDSTOUR();
          }
          //private void btn_TrangChu_Click(object sender, EventArgs e)
          //{
          //     this.Hide();
          //     MAIN_QL main = new MAIN_QL(MaNV);
          //     main.ShowDialog();
          //}
     }
}
