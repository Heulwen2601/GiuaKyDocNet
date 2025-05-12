using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLTOUR.GiaoDIen
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        DBConnection db = new DBConnection();
        void loadTongDoanhThu()
        {
            double tong = 0;

            // Tạo DataTable
            // doanh thu được tính theo biểu đồ chart
            foreach (var item in chart.Series["Doanh thu"].Points)
            {
                double value = item.YValues[0];
                tong += value;
            }
            string temp = string.Format("{0:N0} $", tong);

            lblTongDoanhThu.Text = temp;
        }

        void loadChart(string query)
        {
           
            DataTable dt = db.getDataTable(query);
            if (dt.Rows.Count > 0)
            {

                chart.Series["Doanh thu"].XValueType = ChartValueType.Auto;

                chart.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
                if (cbDate.SelectedItem.ToString() == "Năm nay")
                {
                    chart.Series["Doanh thu"].XValueType = ChartValueType.String;

                    chart.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                }


                chart.ChartAreas["ChartArea1"].AxisY.Title = "Số tiền";
                chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart.Series["Doanh thu"]["DrawingStyle"] = "Cylinder";
                chart.Series["Doanh thu"].LabelFormat = "{0:0,0} $";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chart.Series["Doanh thu"].Points.AddXY(dt.Rows[i]["NgayLap"], dt.Rows[i]["TongTienTongCong"]);
                }
                loadTongDoanhThu();
            }

        }

        void loadChart_TOUR(string query)
        {

            DataTable dt = db.getDataTable(query);
            if (dt.Rows.Count > 0)
            {

                //chart.Series["Tổng Tour"].XValueType = ChartValueType.Auto;

                chart.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";

                //if (cbDate.SelectedItem.ToString() == "Năm nay")
                //{
                //    chart.Series["Doanh thu"].XValueType = ChartValueType.String;

                //    chart.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                //}


                chart.ChartAreas["ChartArea1"].AxisY.Title = "Số vé";
                chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                //chart.Series["Số vé"]["DrawingStyle"] = "Cylinder";
                //chart.Series["Số vé"].LabelFormat = "{0:0,0} VNĐ";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //chart.Series["Doanh thu"].Points.AddXY(dt.Rows[i]["SLVe"], dt.Rows[i]["ThanhTien"]);
                }
                //loadTongDoanhThu();
            }

        }

        void clearChart()
        {
            chart.Series["Doanh thu"].Points.Clear();

        }
      
        private void ThongKe_Load(object sender, EventArgs e)
        {
            
        }

        private void cbDate_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            clearChart();
            string query = "";
            if (cbDate.SelectedItem.ToString() == "7 ngày qua")
            {
                query = @"SELECT CAST(NgayLapHD AS DATE) AS NgayLap, SUM(ThanhTien) AS TongTienTongCong
                     FROM HOADON
                    WHERE NgayLapHD >= DATEADD(DAY, -7, GETDATE()) AND NgayLapHD <= GETDATE() 
                     GROUP BY CAST(NgayLapHD AS DATE)
                    ORDER BY CAST(NgayLapHD AS DATE) ASC;
                ";

            }
            if (cbDate.SelectedItem.ToString() == "Hôm nay")
            {
                query = @"SELECT CAST(NgayLapHD AS DATE) AS NgayLap,
                          SUM(ThanhTien) AS TongTienTongCong
                    FROM HoaDon
                    WHERE CAST(NgayLapHD AS DATE) = CAST(GETDATE() AS DATE)
                    GROUP BY CAST(NgayLapHD AS DATE)
                    ORDER BY CAST(NgayLapHD AS DATE) ASC;
                ";
            }
            if (cbDate.SelectedItem.ToString() == "Hôm qua")
            {
                query = @"SELECT CAST(NgayLapHD AS DATE) AS NgayLap, SUM(ThanhTien) AS TongTienTongCong
                    FROM HOADON
                   WHERE CAST(NgayLapHD AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
                   GROUP BY CAST(NgayLapHD AS DATE)
                   ORDER BY CAST(NgayLapHD AS DATE) ASC; ";
            }
            if (cbDate.SelectedItem.ToString() == "Tháng trước")
            {
                query = @"SELECT CAST(NgayLapHD AS DATE) AS NgayLap, SUM(ThanhTien) AS TongTienTongCong
                     FROM HOADON
                     WHERE DATEPART(YEAR, NgayLapHD) = DATEPART(YEAR, DATEADD(MONTH, -1, GETDATE()))
                    AND DATEPART(MONTH, NgayLapHD) = DATEPART(MONTH, DATEADD(MONTH, -1, GETDATE()))
                   
                    GROUP BY CAST(NgayLapHD AS DATE)
                    ORDER BY CAST(NgayLapHD AS DATE) ASC; ";
            }
            if (cbDate.SelectedItem.ToString() == "Tháng này")
            {
                query = @"SELECT CAST(NgayLapHD AS DATE) AS NgayLap, SUM(ThanhTien) AS TongTienTongCong
                        FROM HOADON
                         WHERE DATEPART(YEAR, NgayLapHD) = DATEPART(YEAR, GETDATE())
                         AND DATEPART(MONTH, NgayLapHD) = DATEPART(MONTH, GETDATE())    
                        GROUP BY CAST(NgayLapHD AS DATE)
                        ORDER BY CAST(NgayLapHD AS DATE) ASC; ";
            }
            if (cbDate.SelectedItem.ToString() == "Năm nay")
            {
                query = @"SELECT MONTH(HOADON.NgayLapHD) AS NgayLap, SUM(ThanhTien) as TongTienTongCong
                     FROM HOADON
                     WHERE YEAR(HOADON.NgayLapHD) = DATEPART(YEAR, GETDATE())GROUP BY MONTH(HOADON.NgayLapHD)
                    ORDER BY  MONTH(HOADON.NgayLapHD)";
            }



            loadChart(query);

        }

        private void cbb_thongketour_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            clearChart();
            string query = "";
            if (cbb_thongketour.SelectedItem.ToString() == "Tour")
            {
                query = @"SELECT MaTour, COUNT(MaTour) AS SoLanDat FROM HoaDon GROUP BY MaTour ORDER BY SoLanDat DESC ";

            }

            loadChart_TOUR(query);
        }
    }
}
