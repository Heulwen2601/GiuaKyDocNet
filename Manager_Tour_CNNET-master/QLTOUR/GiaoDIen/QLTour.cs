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
    public partial class QLTour : Form
    {
        DBConnection db = new DBConnection();
        public QLTour()
        {
            InitializeComponent();
        }

        void Reset()
        {
            txt_matour.Clear();
            txt_tentour.Clear();
            txt_anhtour.Clear();
            txt_giatour.Clear();
            txt_mota.Clear();
        }
        void HienThiDSTour()
        {
            string chuoitruyvan = "SELECT * FROM THONGTINTOUR";
            DataTable dt = db.getDataTable(chuoitruyvan);

            dgv_thongtintour.DataSource = dt;
           
        }
        
        void Load_CbbMaLoaiTour()
        {
            string chuoitruyvan = "SELECT * FROM LOAITOUR";
            DataTable dt = db.getDataTable(chuoitruyvan);

            DataRow dr = dt.NewRow();
            dr["MaLoaiTour"] = "All";
            dr["TenLoaiTour"] = "Chọn loại tour";
            dt.Rows.InsertAt(dr, 0);

            cbb_maloaitour.DataSource = dt;
            cbb_maloaitour.DisplayMember = "TenLoaiTour";
            cbb_maloaitour.ValueMember = "MaLoaiTour";
        }

        void Load_CbbPhuongTien()
        {
            string chuoitruyvan = "SELECT * FROM PHUONGTIENTOUR";
            DataTable dt = db.getDataTable(chuoitruyvan);

            DataRow dr = dt.NewRow();
            dr["MaPhuongTien"] = "All";
            dr["TenPhuongTien"] = "Chọn phương tiện";
            dt.Rows.InsertAt(dr, 0);
           
            cbb_phuongtien.DataSource = dt;
            cbb_phuongtien.DisplayMember = "TenPhuongTien";
            cbb_phuongtien.ValueMember = "MaPhuongTien";
        }

        void Load_CbbXuatPhat()
        {
            string chuoitruyvan = "SELECT * FROM XUATPHATTOUR";
            DataTable dt = db.getDataTable(chuoitruyvan);

            DataRow dr = dt.NewRow();
            dr["MaXP"] = "All";
            dr["DiaDiemXP"] = "Chọn xuất phát";
            dt.Rows.InsertAt(dr, 0);
            cbb_xp.DataSource = dt;
            cbb_xp.DisplayMember = "DiaDiemXP";
            cbb_xp.ValueMember = "MaXP";
        }

        private void QLTour_Load(object sender, EventArgs e)
        {
            HienThiDSTour();
            Load_CbbMaLoaiTour();
            Load_CbbPhuongTien();
            Load_CbbXuatPhat();
        }

        private void dgv_dstour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             dgv_thongtintour.ReadOnly = true;
             if (e.RowIndex >= 0)
             {

                 DataGridViewRow row = dgv_thongtintour.Rows[e.RowIndex];
                 txt_matour.Text = row.Cells["MaTour"].Value.ToString();
                 txt_tentour.Text = row.Cells["TenTour"].Value.ToString();
                 txt_mota.Text = row.Cells["MoTaTour"].Value.ToString();               
                 txt_anhtour.Text = row.Cells["AnhTour"].Value.ToString();
                 txt_giatour.Text = row.Cells["GiaTOur"].Value.ToString();
                 dpt_batdau.Value = DateTime.Parse(row.Cells["TGBatDau"].Value.ToString());
                 dpt_ketthuc.Value = DateTime.Parse(row.Cells["TGKETTHUC"].Value.ToString());

                 cbb_maloaitour.SelectedValue = row.Cells["MaLoaiTour"].Value.ToString();
                 cbb_phuongtien.SelectedValue = row.Cells["MaPhuongTien"].Value.ToString();
                 cbb_xp.SelectedValue = row.Cells["MaXP"].Value.ToString();

                 txt_slve.Text = row.Cells["SLVeConLai"].Value.ToString();     
             }
           
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkMa(txt_matour.Text))
                {
                    MessageBox.Show("Mã Tour này đã bị trùng. Hãy kiểm tra lại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_matour.Clear();
                }
                else
                {
                    dgv_thongtintour.ReadOnly = false;
                    btn_luu.Enabled = true;

           
                    if (string.IsNullOrWhiteSpace(txt_matour.Text) == false)
                    {

                        DataTable dt = (DataTable)dgv_thongtintour.DataSource;
                        DataRow dr = dt.NewRow();

                        dr["MaTour"] = txt_matour.Text;
                        dr["TenTour"] = txt_tentour.Text;
                        dr["MoTaTour"] = txt_mota.Text;
                        dr["AnhTour"] = txt_anhtour.Text;
                        dr["TGBatDau"] = dpt_batdau.Value.ToString();
                        dr["TGKETTHUC"] = dpt_ketthuc.Value.ToString();
                        dr["MaLoaiTour"] = cbb_maloaitour.SelectedValue.ToString();
                        dr["MaPhuongTien"] = cbb_maloaitour.SelectedValue.ToString();
                        dr["MaXP"] = cbb_maloaitour.SelectedValue;
                        dr["GiaTOur"] = txt_giatour.Text;
                        dr["SLVeConLai"] = txt_slve.Text;




                        dr["TGBatDau"] = dpt_batdau.Value.ToString();
                        dr["TGKETTHUC"] = dpt_ketthuc.Value.ToString();

                        dt.Rows.Add(dr);

                        // Cập nhật DataSource của DataGridView
                        dgv_thongtintour.DataSource = dt;

                        // Hiển thị dữ liệu trên DataGridView
                        dgv_thongtintour.Refresh();

                        btn_luu.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Hãy Tạo Mã TOUR");
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool checkTourHoatDong()
        {
            string chuoitruyvan = "SELECT MaTour FROM HOADON  Where MaTour = (SELECT MaTour FROM THONGTINTOUR Where MaTour ='" + txt_matour.Text+ "')";
            int kq = db.CheckData(chuoitruyvan);
            if(kq>0)
            {
                return true;
            }
           
            return false;
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(checkTourHoatDong())
            {
                MessageBox.Show("Tour này có khách đặt vé. Không thể xóa được");
            }
            else
            {
                DataTable dt = (DataTable)dgv_thongtintour.DataSource;
                dt.PrimaryKey = new DataColumn[] { dt.Columns["MaTour"] };
                DataRow dr = dt.Rows.Find(txt_matour.Text);
                //Xóa
                if (dr != null)
                {
                    dr.Delete();
                    //cap nhat csdl
                    string chuoitruyvan = "Select * from THONGTINTOUR";
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
                    MessageBox.Show("Không tìm thấy TOUR cần xóa","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            dgv_thongtintour.AllowUserToAddRows = false;
            btn_luu.Visible = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;



            DataTable dt = (DataTable)dgv_thongtintour.DataSource;
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns[0];
            dt.PrimaryKey = key;
            DataRow dr = dt.Rows.Find(txt_matour.Text);
            if (dr != null)
            {
                dr["MaTour"] = txt_matour.Text;
                dr["TenTour"] = txt_tentour.Text;
                dr["MoTaTour"] = txt_mota.Text;
                dr["AnhTour"] = txt_anhtour.Text;
                dr["TGBatDau"] = dpt_batdau.Value.ToString();
                dr["TGKETTHUC"] = dpt_ketthuc.Value.ToString();
                dr["MaLoaiTour"] = cbb_maloaitour.SelectedValue.ToString();
                dr["MaPhuongTien"] = cbb_maloaitour.SelectedValue.ToString();
                dr["MaXP"] = cbb_maloaitour.SelectedValue;

                dr["GiaTOur"] = txt_giatour.Text;
                dr["SLVeConLai"] = txt_slve.Text;
            }

 

            // Cập nhật DataSource của DataGridView
            dgv_thongtintour.DataSource = dt;

            // Hiển thị dữ liệu trên DataGridView
            dgv_thongtintour.Refresh();
        }


        private string TaoMa()
        {
            int maTangDan = 1;
            string Lay3KiTuCuoi = Lay3KiTuCuoiTuCSDL();

            // Nếu có mã sản phẩm trong CSDL, sử dụng 3 kí tự cuối cùng của mã SP để tăng dần
            if (!string.IsNullOrEmpty(Lay3KiTuCuoi))
            {
                maTangDan = int.Parse(Lay3KiTuCuoi) + 1;
            }
            string ma = "TO" + maTangDan.ToString("D3");

            return ma;
        }
        private string Lay3KiTuCuoiTuCSDL()
        {
            db.Open();
            string maToCheck = txt_matour.Text;

            string sql = "SELECT TOP 1 RIGHT(MaTour, 3) FROM THONGTINTOUR ORDER BY MaTour DESC";


            object result = db.getScalar(sql);

            // Trả về 3 kí tự cuối hoặc chuỗi rỗng nếu không có mã SP trong CSDL
            return result != null ? result.ToString() : string.Empty;


        }


        private void btn_taoma_Click_1(object sender, EventArgs e)
        {
            string ma = TaoMa();
            txt_matour.Text = ma;
        }

        bool checkMa(string MaTour)
        {
            string checkMa = "SELECT MaTour FROM THONGTINTOUR Where MaTour = '" + MaTour + "'";
            int kq = db.CheckData(checkMa);
            if(kq!=0)
            {
                return true;
            }
            return false;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgv_thongtintour.DataSource;
         
           
                    DataColumn[] key = new DataColumn[1];
                    key[0] = dt.Columns[0];
                    dt.PrimaryKey = key;
                    DataRow dr = dt.Rows.Find(txt_matour.Text);
                    if (dr != null)
                    {
                        dr["MaTour"] = txt_matour.Text;
                        dr["TenTour"] = txt_tentour.Text;
                        dr["MoTaTour"] = txt_mota.Text;
                        dr["AnhTour"] = txt_anhtour.Text;
                        dr["TGBatDau"] = dpt_batdau.Value.ToString();
                        dr["TGKETTHUC"] = dpt_ketthuc.Value.ToString();
                        dr["MaLoaiTour"] = cbb_maloaitour.SelectedValue.ToString();
                        dr["MaPhuongTien"] = cbb_phuongtien.SelectedValue.ToString();
                        dr["MaXP"] = cbb_xp.SelectedValue;

                        dr["GiaTOur"] = txt_giatour.Text;
                        dr["SLVeConLai"] = txt_slve.Text;
                    }
                    string chuoitruyvan = "Select * from THONGTINTOUR";
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
            catch(Exception ex)
            {
                MessageBox.Show("Ngày bắt đầu phải bé hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

   

       
     
    }
}
