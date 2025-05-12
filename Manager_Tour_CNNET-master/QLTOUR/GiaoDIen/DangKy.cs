using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace QLTOUR.GiaoDIen
{
     public partial class DangKy : Form
     {
         DBConnection db = new DBConnection();
          public DangKy()
          {
               InitializeComponent();
          }
          public bool checkAccount(string ac)// check tài khoản mật khẩu
          {
               return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
          }
          public string getMaNVNext()
          {
               DBConnection conn = new DBConnection();

               return "";
          }
         void Load_CbbMaNV()
          {
             string chuoitruyvan ="SELECT MANV FROM NHANVIEN";
             DataTable dt = db.getDataTable(chuoitruyvan);

             cbb_MaNV.DataSource = dt;
             cbb_MaNV.ValueMember = "MaNV";
             cbb_MaNV.DisplayMember = "HoTen";

          }
          private void btn_DangKy_Click(object sender, EventArgs e)
          {            
               string tentk = txt_TenDN.Text;
               string mk = txt_MK.Text;
               string xnmatkhau = txt_XNMK.Text;

               if (!checkAccount(tentk) && !checkAccount(mk))
               {
                   MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 ký tự bao gồm ký tự chữ và số, chữ hoa và chữ thường!", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
               }             
               if (xnmatkhau != mk)
               {
                   MessageBox.Show("Mật khẩu xác nhận không chính xác!\n Vui lòng nhập lại mật khẩu xác nhận!");
                   return;
               }

               string manv = cbb_MaNV.SelectedValue.ToString();

               string chuoitruyvan = "insert into TaiKhoan values ('" + tentk + "','" + mk + "','" + manv + "')";

               int kq = db.getNonQuery(chuoitruyvan);
               if (kq > 0)
                   MessageBox.Show("Đăng ký thành công");
               else
                   MessageBox.Show("Đăng ký không thành công");

              
          }

       
          private void exitButton_Click(object sender, EventArgs e)
          {
               Close();
          }

          private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
          {
              
          }

          private void cbShowPass_CheckedChanged(object sender, EventArgs e)
          {
               txt_MK.UseSystemPasswordChar = !cbShowPass.Checked;
               txt_XNMK.UseSystemPasswordChar = !cbShowPass.Checked;
          }

          private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
          {

          }

          private void DangKy_Load(object sender, EventArgs e)
          {
              Load_CbbMaNV();
          }
         
         
        
     }
}
