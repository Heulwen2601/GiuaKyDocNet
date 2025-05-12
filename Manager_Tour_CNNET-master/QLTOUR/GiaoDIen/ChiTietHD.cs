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
    public partial class ChiTietHD : Form
    {
        DBConnection db = new DBConnection();
        string MaHD { get; set; }

        public ChiTietHD(string maTour,string mahd)
        {
            InitializeComponent();
            MaHD = mahd;
            string chuoitruyvan = "SELECT * FROM LOAITOUR lt JOIN THONGTINTOUR ttt ON lt.MaLoaiTour = ttt.MaLoaiTour JOIN XUATPHATTOUR xpt ON ttt.MaXP = xpt.MaXP JOIN PHUONGTIENTOUR ptt ON ttt.MaPhuongTien = ptt.MaPhuongTien";
            DataTable dt = db.getDataTable(chuoitruyvan);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên của kết quả truy vấn

                //lb_matour.Text = row["MaTour"].ToString();
                lb_tentour.Text = row["TenTour"].ToString();
                lb_diemxp.Text = row["DiaDiemXP"].ToString();
                lb_phuongtien.Text = row["TenPhuongTien"].ToString();
              
                lb_ngaydi.Text = ((DateTime)row["TGBatDau"]).ToString("dd/MM/yyyy");
                lb_ngayketthuc.Text = ((DateTime)row["TGKetThuc"]).ToString("dd/MM/yyyy");

                lb_sove.Text = row["SLVeConLai"].ToString();


                //TimeSpan songay = ((DateTime)row["TGKetThuc"]) - ((DateTime)row["TGBatDau"]);
                //int soNgay = songay.Days;
                //lb_thoigian.Text = soNgay.ToString();


            }
        }

        void HienThongTinHoaDon(string MaHD)
        {
            string chuoitruyvan = "SELECT * FROM HOADON WHERE SoHD = '"+MaHD+"'";
            

            DataTable dt = db.getDataTable(chuoitruyvan);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; // Lấy dòng đầu tiên của kết quả truy vấn


                string manv = row["MaNV"].ToString();
                string makh = row["MaKH"].ToString();
                string truyvan2 = "SELECT nv.HoTen AS HoTenNV, kh.HoTen AS HoTenKH FROM NhanVien nv JOIN KHACHHANG kh ON nv.MaNV = '"+manv+"' AND kh.MaKH = '"+makh+"';";
                DataTable dt2 = db.getDataTable(truyvan2);
                DataRow row2 = dt2.Rows[0];

                lb_sohd.Text = row["SoHD"].ToString();
                lb_tennv.Text = row2["HoTenNV"].ToString();
                lb_tenkh.Text = row2["HoTenKH"].ToString();
                lb_ngaylaphd.Text = ((DateTime)row["NgayLapHD"]).ToString("dd/MM/yyyy");
               

                lb_sove.Text = row["SLVe"].ToString();
                lb_thanhtien.Text = row["ThanhTien"].ToString();



            }
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            HienThongTinHoaDon(MaHD);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Hóa Đơn", new Font("Time New Roman",18 , FontStyle.Bold ), Brushes.DarkRed, new PointF(100, 100));
            e.Graphics.DrawString("Số Hóa Đơn: " + lb_sohd.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(50, 140));
            e.Graphics.DrawString("Tên Khách Hàng: " + lb_tenkh.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(50, 170));
            e.Graphics.DrawString("Ngày Lập Hóa Đơn: " + lb_ngaylaphd.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(50, 200));
            e.Graphics.DrawString("Số Vé: " + lb_sove.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(50, 230));
            e.Graphics.DrawString("Thành Tiền: " + lb_thanhtien.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(50, 260));
            e.Graphics.DrawString("Chúc quý khách có một chuyến đi vui vẻ" , new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(30, 300));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

          private void exitButton_Click(object sender, EventArgs e)
          {

          }

          private void button2_Click(object sender, EventArgs e)
          {
               this.Close();
             
          }

          private void groupBox1_Enter(object sender, EventArgs e)
          {

          }
     }
}
