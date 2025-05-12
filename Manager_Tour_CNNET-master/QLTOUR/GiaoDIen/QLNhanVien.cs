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
    public partial class QLNhanVien : Form
    {

        public string MaNV { get; set; }

        public QLNhanVien(string manv)
        {
            InitializeComponent();

            MaNV = manv;
        }
        DBConnection db = new DBConnection();
        void Load_DSNV()
        {
            string chuoitruyvan = "Select * from NhanVien";
            DataTable dt = db.getDataTable(chuoitruyvan);
            dgv_NhanVien.DataSource = dt;
            
        }

        void Load_CbbChucVu()
        {
            string chuoitruyvan = "SELECT * FROM ChucVu";
            DataTable dt = db.getDataTable(chuoitruyvan);

            cbb_chucvu.DataSource = dt;
            cbb_chucvu.ValueMember = "MaCV";
            cbb_chucvu.DisplayMember = "TenCV";

        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            Load_DSNV();
            Load_CbbChucVu();
        }
        //KT mã nhân viên
        bool check_MaNV(string mnv)
        {
            string chuoitruyvan = "Select MaNV from NhanVien where MaNV='" + mnv + "'";
            int r = (int)db.getScalar(chuoitruyvan);
            if (r == 0)
                return true;
            return false;
        }

        //Kiểm tra thông tin nhập vào
        private bool KiemTraThongTin()
        {
            if (txt_tennv.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ và tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tennv.Focus();
                return false;
            }
            if (txt_diachi.Text == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_diachi.Focus();
                return false;
            }
            if (txt_email.Text == "")
            {
                MessageBox.Show("Vui lòng điền Email của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_email.Focus();
                return false;
            }
            if (rdo_nam.Checked == false && rdo_nu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txt_sdt.Text == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return false;
            }
            if (txt_manv.Text == "")
            {
                MessageBox.Show("Vui lòng điền mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_sdt.Focus();
                return false;
            }
            return true;
        }
        private void Reset()
        {
            txt_tennv.Text = "";
            txt_manv.Text = "";
            txt_sdt.Text = "";
            txt_diachi.Text = "";
            rdo_nam.Checked = false;
            rdo_nu.Checked = false;
            dtp_ngaysinh.Value = DateTime.Now;
            txt_email.Text = "";
        }
        private void dgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_NhanVien.ReadOnly = true;
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = dgv_NhanVien.Rows[e.RowIndex];
                txt_manv.Text = row.Cells["MaNV"].Value.ToString();
                txt_tennv.Text = row.Cells["HoTen"].Value.ToString();
                txt_email.Text = row.Cells["Email"].Value.ToString();
                dtp_ngaysinh.Text = row.Cells["NgaySinh"].Value.ToString();
                txt_diachi.Text = row.Cells["DiaChi"].Value.ToString();
                txt_sdt.Text = row.Cells["Sdt"].Value.ToString();
                if (row.Cells["GioiTinh"].Value.ToString() == Convert.ToString(rdo_nam.Text))
                {
                    rdo_nam.Checked = true;
                    rdo_nu.Checked = false;
                }
                else
                {
                    rdo_nam.Checked = false;
                    rdo_nu.Checked = true;
                }
                cbb_chucvu.SelectedValue = row.Cells["MaCV"].Value.ToString();
            }
        }


        private void btn_TimNV_Click(object sender, EventArgs e)
        {
            string timkiem = txt_TimNV.Text.Trim();
            LoadDataBySearch(timkiem);
        }
        private void LoadDataBySearch(string timkiem)
        {
            string chuoitruyvan = "SELECT * FROM NhanVien WHERE HoTen COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%' + '" + txt_TimNV.Text.Trim() + "' + N'%'";

            DataTable dt = db.getDataTable(chuoitruyvan);
            dgv_NhanVien.DataSource = dt;
        }
        private void txt_TimNV_TextChanged(object sender, EventArgs e)
        {
            string timkiem = txt_TimNV.Text.Trim();
            LoadDataBySearch(timkiem);
        }

       

        private void btn_TrangChu_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MAIN_QL main = new MAIN_QL(MaNV);
            main.ShowDialog();
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            //this.Hide();
            DangKy dk = new DangKy();
            dk.ShowDialog();
        }

        bool checkMa(string ma)
        {
            string checkMa = "SELECT MANV FROM NHANVIEN Where MANV = '" + ma + "'";
            int kq = db.CheckData(checkMa);
            if (kq != 0)
            {
                return true;
            }
            return false;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
          
          
                string gioiTinh = rdo_nam.Checked ? rdo_nam.Text : rdo_nu.Text;
                DataTable dt = (DataTable)dgv_NhanVien.DataSource;
                DataColumn[] key = new DataColumn[1];
                key[0] = dt.Columns[0];
                dt.PrimaryKey = key;
                DataRow dr = dt.Rows.Find(txt_manv.Text);
                if (dr != null)
                {
                    dr["MaNV"] = txt_manv.Text;
                    dr["HoTen"] = txt_tennv.Text;
                    dr["GioiTinh"] = gioiTinh;
                    dr["NgaySinh"] = dtp_ngaysinh.Value.ToString();
                    dr["Email"] = txt_email.Text;
                    dr["DiaChi"] = txt_diachi.Text;
                    dr["Sdt"] = txt_sdt.Text;
                    dr["MaCV"] = cbb_chucvu.SelectedValue.ToString();
                }
                string chuoitruyvan = "Select * from NHANVIEN";
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (checkMa(txt_manv.Text))
            {
                MessageBox.Show("Mã nhân viên này đã bị trùng. Hãy kiểm tra lại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manv.Clear();
            }
            else
            {
                dgv_NhanVien.ReadOnly = false;
                btn_luu.Enabled = true;

                if (string.IsNullOrWhiteSpace(txt_manv.Text) == false)
                {
                    string gioiTinh = rdo_nam.Checked ? rdo_nam.Text : (rdo_nu.Checked ? rdo_nu.Text : null);

                    DataTable dt = (DataTable)dgv_NhanVien.DataSource;
                    DataRow dr = dt.NewRow();

                    dr["MaNV"] = txt_manv.Text;
                    dr["HoTen"] = txt_tennv.Text;
                    dr["GioiTinh"] = gioiTinh;
                    dr["NgaySinh"] = dtp_ngaysinh.Value.ToString();
                    dr["Email"] = txt_email.Text;
                    dr["DiaChi"] = txt_diachi.Text;
                    dr["Sdt"] = txt_sdt.Text;
                    dr["MaCV"] = cbb_chucvu.SelectedValue.ToString();



                    dt.Rows.Add(dr);

                    // Cập nhật DataSource của DataGridView
                    dgv_NhanVien.DataSource = dt;

                    // Hiển thị dữ liệu trên DataGridView
                    dgv_NhanVien.Refresh();

                    btn_luu.Visible = true;
                }
                else
                {
                    MessageBox.Show("Hãy Tạo Mã Nhân Viên");
                }


            }


        }

        bool checkNV_HD(string MaNV)
        {
            string checkKH_HD = "SELECT MANV FROM HOADON WHERE MANV = (SELECT MANV FROM NHANVIEN WHERE MANV = '" + MaNV + "' ) ";
            int kq = db.CheckData(checkKH_HD);

            if (kq != 0)
            {
                return true;
            }
            return false;

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            
            if(checkNV_HD(txt_manv.Text))
            {
                MessageBox.Show("Không xóa nhân viên được vì nhân viên này đang có quản lý hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string chuoitruyvan = "DELETE FROM TAIKHOAN WHere MaNV = (Select MaNV FROM NHANVIEN WHERE MaNV = '"+txt_manv.Text+"')";

                int kq = db.getNonQuery(chuoitruyvan);
                if (kq > 0)
                {
                    MessageBox.Show("Xóa nhân viên thành công");
                    Load_DSNV();
                
                }
                else
                {
                    string chuoitruyvan2 = "DELETE FROM NhanVien WHERE MaNV = '" + txt_manv.Text + "'";
                    int kq2 = db.getNonQuery(chuoitruyvan2);
                    if (kq2 > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công");
                        Load_DSNV();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên không thành công");
                    }
                }

            }

         
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgv_NhanVien.AllowUserToAddRows = false;
            btn_luu.Visible = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;

            string gioiTinh = rdo_nam.Checked ? rdo_nam.Text : (rdo_nu.Checked ? rdo_nu.Text : null);

            DataTable dt = (DataTable)dgv_NhanVien.DataSource;
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            DataRow dr = dt.Rows.Find(txt_manv.Text);
            if (dr != null)
            {
                dr["MaNV"] = txt_manv.Text;
                dr["HoTen"] = txt_tennv.Text;
                dr["GioiTinh"] = gioiTinh;
                dr["NgaySinh"] = dtp_ngaysinh.Value.ToString();
                dr["Email"] = txt_email.Text;
                dr["DiaChi"] = txt_diachi.Text;
                dr["Sdt"] = txt_sdt.Text;
                dr["MaCV"] = cbb_chucvu.SelectedValue.ToString();
               

            }

            //dt.Rows.Add(dr);

            // Cập nhật DataSource của DataGridView
            dgv_NhanVien.DataSource = dt;

            // Hiển thị dữ liệu trên DataGridView
            dgv_NhanVien.Refresh();
        }


        private string TaoMa()
        {
            int maNVTangDan = 1;
            string Lay3KiTuCuoi = Lay3KiTuCuoiTuCSDL();

            // Nếu có mã sản phẩm trong CSDL, sử dụng 3 kí tự cuối cùng của mã SP để tăng dần
            if (!string.IsNullOrEmpty(Lay3KiTuCuoi))
            {
                maNVTangDan = int.Parse(Lay3KiTuCuoi) + 1;
            }
            string maNV = "NV" + maNVTangDan.ToString("D3");

            return maNV;
        }
        private string Lay3KiTuCuoiTuCSDL()
        {
            db.Open();
            string maNVToCheck = txt_manv.Text;

            string sql = "SELECT TOP 1 RIGHT(MaNV, 3) FROM NHANVIEN ORDER BY MaNV DESC";


            object result = db.getScalar(sql);

            // Trả về 3 kí tự cuối hoặc chuỗi rỗng nếu không có mã SP trong CSDL
            return result != null ? result.ToString() : string.Empty;


        }



        private void btn_taoma_Click(object sender, EventArgs e)
        {
            string maNV = TaoMa();
            txt_manv.Text = maNV;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            Load_DSNV();
        }

       
    }
}
