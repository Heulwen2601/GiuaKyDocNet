using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace QLTOUR.GiaoDIen
{
     public partial class DangNhap : Form
     {
          DBConnection con = new DBConnection();
          public DangNhap()
          {
               InitializeComponent();
               TextBox customTextBox = new TextBox();
               customTextBox.Padding = new Padding(10); // Đặt giá trị Padding tùy ý
               Controls.Add(customTextBox);
          }

          bool checkChucVu()
          {
               string tentk = txt_TK.Text;
               string mk = txt_MK.Text;
               string chuoitruyvan = "SELECT TenDangNhap,MatKhau,tk.MaNV from TaiKhoan tk,NhanVien nv where TenDangNhap= '" + tentk + "' and MatKhau= '" + mk + "' AND tk.MaNV=nv.MaNV and nv.MaCV = (SELECT MaCV FROM ChucVu WHERE TenCV = N'Quản lý')";
               
              if (con.TaiKhoans(chuoitruyvan).Count != 0)
               {
                    return true;
               }
               return false;
          }

          private void btn_DangNhap_Click(object sender, EventArgs e)
          {
               string tentk = txt_TK.Text;
               string mk = txt_MK.Text;
               DBConnection con = new DBConnection();
               if (tentk.Trim() == "" && mk.Trim() == "")
               {
                    MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và mật khẩu");
               }
               else
               {
                    TaiKhoan tk = new TaiKhoan();
                    tk = tk.TimTaiKhoan(tentk);
                    if (tk != null)
                    {
                         if (tk.MatKhau == mk && tk.TenTaiKhoan == tentk)
                         {
                              if (checkChucVu())
                              {
                                   MessageBox.Show("Đăng nhập thành công với quyền Quản Lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   string manv = tk.MaNV;
                                  
                                   MAIN_QL main = new MAIN_QL(manv);
                                   this.Hide();
                                   main.ShowDialog();
                              }
                              else
                              {
                                   MessageBox.Show("Đăng nhập thành công với quyền Nhân Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   string manv = tk.MaNV;

                                   MAIN_QL main = new MAIN_QL(manv);
                                   this.Hide();
                                   main.ShowDialog();

                              }

                         }
                         else
                         {
                              MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                         }
                    }

               }
          }

          private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
          {
               this.Hide();
               DangKy dk = new DangKy();
               dk.ShowDialog();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               Close();
          }

          private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
          {
               DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
               if (r == DialogResult.No)
                    e.Cancel = true;
          }

          private void pictureBoxShowPass_Click(object sender, EventArgs e)
          {
               txt_MK.UseSystemPasswordChar = false;
               pictureBoxShowPass.Hide();
               pictureBoxHidePass.Show();
          }

          private void pictureBoxHidePass_Click(object sender, EventArgs e)
          {
               txt_MK.UseSystemPasswordChar = true;
               pictureBoxHidePass.Hide();
               pictureBoxShowPass.Show();
          }

          private void DangNhap_Load(object sender, EventArgs e)
          {
               txt_MK.UseSystemPasswordChar = true;
               pictureBoxHidePass.Hide();
          }

          private void pictureBox1_Click(object sender, EventArgs e)
          {

          }
     }
}
