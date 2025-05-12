using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTOUR.GiaoDIen
{
     public partial class MAIN_QL : Form
     {
          DBConnection db = new DBConnection();

          public string MaNV { get; set; }
          private Form currentForm; // Biến lưu trữ form hiện tại trong panelShowDesktop

          bool checkQuyen(string manv)
          {
              string chuoitruyvan = "SELECT MaNV FROM NhanVien Where MaNV = '" + manv + "' AND MaCV = (SELECT MaCV FROM ChucVu Where TenCV = N'Quản Lý')";
               int kq = db.CheckData(chuoitruyvan);
               if (kq > 0)
               {
                    return true;
               }

               return false;
          }
          public MAIN_QL(string manv)
          {

               InitializeComponent();
               MaNV = manv;
               TenNV();
          }

          private void btn_QLTour_Click(object sender, EventArgs e)
          {
               //DatTour form_QLTour = new DatTour(MaNV);
               //this.Hide();
               //form_QLTour.ShowDialog();
               panelFloating.Show();
               panelFloating.Height = btn_DatTour.Height;
               panelFloating.Top = btn_DatTour.Top;
               OpenChildForm(new DatTour(MaNV));
               labelShowDesktop.Text = btn_DatTour.Text;
          }

          private void btn_QLNV_Click(object sender, EventArgs e)
          {
               //QLNhanVien fQLNV = new QLNhanVien(MaNV);
               //this.Hide();
               //fQLNV.ShowDialog();
               panelFloating.Show();
               panelFloating.Height = btn_QLNV.Height;
               panelFloating.Top = btn_QLNV.Top;
               OpenChildForm(new QLNhanVien(MaNV));
               labelShowDesktop.Text = btn_QLNV.Text;
          }

          private void btn_QLKH_Click(object sender, EventArgs e)
          {
               //this.Hide();
               //QLKhachHang qlkh = new QLKhachHang(MaNV);
               //qlkh.ShowDialog();
               panelFloating.Show();
               panelFloating.Height = btn_QLKH.Height;
               panelFloating.Top = btn_QLKH.Top;
               OpenChildForm(new QLKhachHang(MaNV));
               labelShowDesktop.Text = btn_QLKH.Text;
          }
          private void btn_QLTour_Click_1(object sender, EventArgs e)
          {
               //this.Hide();
               //QLTour qltour = new QLTour();
               //qltour.ShowDialog();
               panelFloating.Show();
               panelFloating.Height = btn_QLTour.Height;
               panelFloating.Top = btn_QLTour.Top;
               OpenChildForm(new QLTour());
               labelShowDesktop.Text = btn_QLTour.Text;
          }

          private void btn_QLDT_Click(object sender, EventArgs e)
          {
               //ThongKe report = new ThongKe();
               //report.ShowDialog();
               panelFloating.Show();
               panelFloating.Height = btn_thongke.Height;
               panelFloating.Top = btn_thongke.Top;
               OpenChildForm(new ThongKe());
               labelShowDesktop.Text = btn_thongke.Text;
          }
          private Form currentChildForm;
          private void OpenChildForm(Form childForm)
          {
               if (currentChildForm != null)
               {
                    currentChildForm.Close();
               }
               currentChildForm = childForm;
               childForm.TopLevel = false;
               childForm.FormBorderStyle = FormBorderStyle.None;
               childForm.Dock = DockStyle.Fill;
               panelShowDesktop.Controls.Add(childForm);
               panelShowDesktop.Tag = childForm;
               childForm.BringToFront();
               childForm.Show();
          }

          private void pictureBox1_Click(object sender, EventArgs e)
          {
               panelFloating.Hide();
               if (currentChildForm != null)
               {
                    currentChildForm.Close();
               }
          }


          private void MAIN_QL_FormClosing(object sender, FormClosingEventArgs e)
          {
               DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
               if (r == DialogResult.No)
               {
                    e.Cancel = true;
                   
               }
          }

          private void btn_LogOut_Click(object sender, EventArgs e)
          {
               DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
               if (r == DialogResult.Yes)
               {
                    DangNhap dn = new DangNhap();
                    this.Hide();
                    dn.ShowDialog();
               }
          }

          private void MAIN_QL_Load(object sender, EventArgs e)
          {
               if (checkQuyen(MaNV))
               {
                    btn_QLNV.Enabled = true;
                    btn_thongke.Enabled = true;
                  
                   
               }
               panelFloating.Hide();
          }

          private void btnBill_Click(object sender, EventArgs e)
          {
               panelFloating.Height = btnBill.Height;
               panelFloating.Top = btnBill.Top;
               OpenChildForm(new QLHoaDon());
               labelShowDesktop.Text = btnBill.Text;
          }
          void TenNV()
          {
               string sqltennv = "SELECT HOTEN FROM NhanVien WHERE MANV = '" + MaNV + "'";
               SqlDataReader reader = db.ExcuteQuery(sqltennv);
               if (reader.Read())
               {
                    string tennv = reader["HOTEN"].ToString();
                    labelTenNV.Text = tennv;
                    db.Close();
               }
               else
               {
                    labelTenNV.Text = "Không tìm thấy thông tin";
                    db.Close();
               }
          }
     }
}
