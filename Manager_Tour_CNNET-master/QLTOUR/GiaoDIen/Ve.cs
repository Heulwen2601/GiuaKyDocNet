using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTOUR.GiaoDIen
{
     public partial class Ve : Form
     {
          DBConnection db = new DBConnection();
          public string MaNV { get; set; }
          public string MaTour { get; set; }
          public string MaKH { get; set; }
          public Ve(string maTour, string manv)
          {
               InitializeComponent();
               MaNV = manv;
               MaTour = maTour;
               string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien Where MaTour = '"+maTour+"'";
               DataTable dt = db.getDataTable(chuoitruyvan);
               if (dt.Rows.Count > 0)
               {
                    DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên của kết quả truy vấn

                    lb_matour.Text = row["MaTour"].ToString();
                    lb_tentour.Text = row["TenTour"].ToString();
                    lb_giatour.Text = ((Decimal)row["GiaTour"]).ToString("");
                    lb_tgbatdau.Text = ((DateTime)row["TGBatDau"]).ToString("dd/MM/yyyy");
                    lb_tgketthuc.Text = ((DateTime)row["TGKetThuc"]).ToString("dd/MM/yyyy");
                    lb_valueslve.Text = row["SLVeConLai"].ToString();
                    lb_valuexp.Text = row["DiaDiemXP"].ToString();
                    lb_valuephuongtien.Text = row["TenPhuongTien"].ToString();


                    TimeSpan songay = ((DateTime)row["TGKetThuc"]) - ((DateTime)row["TGBatDau"]);
                    int soNgay = songay.Days;
                    lb_thoigian.Text = soNgay.ToString();


               }



          }





          private void btn_kiemtraKH_Click(object sender, EventArgs e)
          {
               if (string.IsNullOrWhiteSpace(txt_sdt.Text) || txt_sdt.Text.Length != 10 || !txt_sdt.Text.All(char.IsDigit))
               {
                    errorProvider1.SetError(txt_sdt, "Mời nhập đúng 10 số điện thoại");
               }
               else
               {
                    // Xóa thông báo lỗi nếu hợp lệ
                    errorProvider1.SetError(txt_slgve, string.Empty);
                    string sdt = txt_sdt.Text;
                    string chuoitruyvan = "SELECT COUNT(*) FROM KHACHHANG WHERE Sdt = '" + sdt + "'";
                    int count = Convert.ToInt32(db.getScalar(chuoitruyvan));

                    //Có thì hiện thông tin KH
                    if (count > 0)
                    {
                         string thongtinKh = "SELECT * FROM KHACHHANG WHERE Sdt = '" + sdt + "'";
                         DataTable dt = db.getDataTable(thongtinKh);
                         DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên của kết quả truy vấn
                         if (dt.Rows.Count > 0)
                         {
                              gb_thongtinKH.Visible = true;
                              MaKH = row["MaKH"].ToString();
                              lb_hoten.Text = row["HoTen"].ToString();
                              lb_sdt.Text = row["Sdt"].ToString();
                              lb_email.Text = row["Email"].ToString();
                              lb_gioitinh.Text = row["GioiTinh"].ToString();
                         }
                    }

                    //Không thì cập nhật thông tin KH
                    else
                    {
                         DialogResult r;
                         r = MessageBox.Show("Chưa có KH này. Nạn có muốn đắng ký KH bằng sdt này luôn không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                         if (r == DialogResult.Yes)
                         {
                              this.Hide();
                              QLKhachHang qlkh = new QLKhachHang(MaNV, this); // Truyền this (FormDatVe) vào
                              qlkh.ShowDialog();
                              this.Show();
                    }


                    }


               }


          }


          private void txt_slgve_TextChanged(object sender, EventArgs e)
          {
               Control ctr = (Control)sender;
               if ((txt_slgve.Text == "") || ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 1]))
                    this.errorProvider1.SetError(ctr, "Hãy nhập đúng số lượng vé");
               else
               {
                    double slg = double.Parse(txt_slgve.Text);
                    double giatien = double.Parse(lb_giatour.Text);

                    double thanhtien = slg * giatien;

                    lb_thanhtien.Text = thanhtien.ToString();

                    lb_thanhtien.Visible = true;
                    this.errorProvider1.Clear();

               }

          }

          private void btn_thanhtoan_Click(object sender, EventArgs e)
          {
              try
              {

                   if (gb_thongtinKH.Visible == false)
                   {
                        MessageBox.Show("Mời nhập thông tin KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   else if (txt_slgve.Text.Trim() == "")
                   {
                        MessageBox.Show("Mời nhập số lượng vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
                   else
                   {
                        DialogResult r;
                        r = MessageBox.Show("Xác nhận thanh toán", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (r == DialogResult.Yes)
                        {
                             string sohd = "SELECT dbo.GenerateSoHD() AS SoHD";
                             DataTable dtSoHD = db.getDataTable(sohd);


                             string chuoitruyvan = "select* from HOADON";
                             DataTable dt = db.getDataTable(chuoitruyvan);
                             DataRow dr = dt.NewRow();
                             dr["SoHD"] = dtSoHD.Rows[0]["SoHD"];
                             dr["MaNV"] = MaNV;
                             dr["MaKH"] = MaKH;
                             dr["MaTour"] = MaTour;
                             dr["NgayLapHD"] = DateTime.Now;
                             dr["ThanhTien"] = lb_thanhtien.Text;
                             dr["SLVe"] = txt_slgve.Text;
                             dt.Rows.Add(dr);
                             int k = db.updateDataTable(dt, chuoitruyvan);

                             DialogResult r1;
                             r1 = MessageBox.Show("Bạn có muốn xuất hóa đơn không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                             if (k != 0 && r1 == DialogResult.Yes)
                             {
                                  string matour = lb_matour.Text;
                                  string mahd = dr["SoHD"].ToString();
                                  ChiTietHD hoadon = new ChiTietHD(matour, mahd);
                                  this.Hide();

                                  hoadon.ShowDialog();
                             }
                             else
                             {
                                  MessageBox.Show("Cảm ơn quý khách đã đặt vé. Chúc quý khách có chuyến đi vui vẻ ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                  DatTour qltour = new DatTour(MaNV);
                                  this.Hide();
                                  qltour.ShowDialog();


                             }
                        }
                   }
              }

              catch(Exception ex)
              {

                  MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
              }

             

             
          }




          private void btn_TrangChu_Click(object sender, EventArgs e)
          {
               this.Hide();
               MAIN_QL main = new MAIN_QL(MaNV);
               main.ShowDialog();
          }

          private void QLVe_Load(object sender, EventArgs e)
          {

          }

          private void button2_Click(object sender, EventArgs e)
          {
               Close();
          }

          private void gb_thongtinKH_Enter(object sender, EventArgs e)
          {

          }
     }
}
