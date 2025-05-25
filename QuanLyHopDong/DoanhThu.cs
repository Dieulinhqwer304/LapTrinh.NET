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
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;




namespace QuanLyHopDong
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {



        }


        private void DoanhThu_Load(object sender, EventArgs e)
        {
            QuanLyHopDong.Functions.Connect();


        }

        private void rdoTheoThang_CheckedChanged(object sender, EventArgs e)
        {

            if (rdoTheoThang.Checked == true)
            {
                txtThang.Enabled = true;
                txtNam.Enabled = true;
                mskTu.Enabled = false;
                mskDen.Enabled = false;
            }
            else
            {
                txtThang.Enabled = false;
                txtNam.Enabled = false;
                mskTu.Enabled = true;
                mskDen.Enabled = true;
            }
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdoTheoThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheoThoiGian.Checked == true)
            {
                mskTu.Enabled = true;
                mskDen.Enabled = true;
                txtThang.Enabled = false;
                txtNam.Enabled = false;
            }
            else
            {
                mskTu.Enabled = false;
                mskDen.Enabled = false;
                txtThang.Enabled = true;
                txtNam.Enabled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Tạo ứng dụng Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
            COMExcel.Range exRange;

            exSheet.Name = "Bao cao";

            // ======= HEADER THÔNG TIN =========
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times New Roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;

            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;

            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "HỆ THỐNG QUẢN LÝ BÁO";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Xã Đàn - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04) 4444 8888";

            // ======= TIÊU ĐỀ =========
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times New Roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; // Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "BÁO CÁO DOANH THU";

            // ======= THÔNG TIN THỜI GIAN =========
            exRange.Range["B5:C6"].Font.Size = 12;
            exRange.Range["B5:C6"].Font.Name = "Times New Roman";
            exRange.Range["B5:B5"].Value = "Năm báo cáo:";
            exRange.Range["C5:C5"].Value = txtNam1.Text; // Lấy năm từ txtNam1 (dùng trong btnLamMoi_Click)

            // ======= IN DỮ LIỆU TỪ CHARTDOANHTHU =========
            int rowStart = 8;
            exRange.Range["A8:B8"].Font.Bold = true;
            exRange.Range["A8:B8"].Font.Size = 12;
            exRange.Range["A8:B8"].Font.Name = "Times New Roman";
            exRange.Range["A8:B8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A8:A8"].ColumnWidth = 10;
            exRange.Range["B8:B8"].ColumnWidth = 15;

            exSheet.Cells[rowStart, 1] = "Tháng";
            exSheet.Cells[rowStart, 2] = "Doanh thu";

            int dataRowCount = 0;
            if (chartDoanhThu.Series["DoanhThu"].Points.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong chartDoanhThu để in! Vui lòng nhấn 'Làm mới' trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                exApp.Quit();
                return;
            }

            // Lấy dữ liệu từ chartDoanhThu
            foreach (var point in chartDoanhThu.Series["DoanhThu"].Points)
            {
                string thang = point.XValue.ToString(); // Tháng (đã là dạng số: 1, 2, 3,...)
                double doanhThu = point.YValues[0]; // Doanh thu (đã ở dạng triệu VNĐ từ btnLamMoi_Click)

                exSheet.Cells[dataRowCount + rowStart + 1, 1] = thang;
                exSheet.Cells[dataRowCount + rowStart + 1, 2] = doanhThu;
                dataRowCount++;
            }

            // ======= VẼ BIỂU ĐỒ =========
            COMExcel.ChartObjects charts = (COMExcel.ChartObjects)exSheet.ChartObjects();
            COMExcel.ChartObject chartObject = charts.Add(300, 100, 400, 250); // Vị trí và kích thước biểu đồ
            COMExcel.Chart chart = chartObject.Chart;

            // Xác định vùng dữ liệu vẽ biểu đồ (bao gồm tiêu đề: A8:B...)
            string dataStart = "A" + rowStart; // Bao gồm tiêu đề
            string dataEnd = "B" + (rowStart + dataRowCount);
            COMExcel.Range chartRange = exSheet.get_Range(dataStart, dataEnd);

            // Đặt nguồn dữ liệu cho biểu đồ
            chart.SetSourceData(chartRange, COMExcel.XlRowCol.xlColumns);

            // Thay đổi loại biểu đồ nếu chỉ có 1 hàng dữ liệu
            if (dataRowCount == 1)
            {
                chart.ChartType = COMExcel.XlChartType.xlColumnClustered; // Biểu đồ cột cho 1 điểm
            }
            else
            {
                chart.ChartType = COMExcel.XlChartType.xlLine; // Biểu đồ đường cho nhiều điểm
            }

            // Tiêu đề biểu đồ
            chart.HasTitle = true;
            chart.ChartTitle.Text = "Biểu đồ doanh thu (triệu VNĐ)";

            // Trục X: Chỉ hiển thị tháng
            chart.Axes(COMExcel.XlAxisType.xlCategory).HasTitle = true;
            chart.Axes(COMExcel.XlAxisType.xlCategory).AxisTitle.Text = "Tháng";
            chart.Axes(COMExcel.XlAxisType.xlCategory).CategoryType = COMExcel.XlCategoryType.xlCategoryScale; // Đảm bảo trục X là danh mục (chỉ hiển thị tháng)

            // Trục Y: Doanh thu (triệu VNĐ), với các mức nhảy 10, 20, 30, 40
            chart.Axes(COMExcel.XlAxisType.xlValue).HasTitle = true;
            chart.Axes(COMExcel.XlAxisType.xlValue).AxisTitle.Text = "Doanh thu (triệu VNĐ)";
            chart.Axes(COMExcel.XlAxisType.xlValue).MinimumScale = 0;
            chart.Axes(COMExcel.XlAxisType.xlValue).MaximumScale = 40; // Tối đa 40 triệu
            chart.Axes(COMExcel.XlAxisType.xlValue).MajorUnit = 10; // Nhảy 10 triệu mỗi bước

            // Định dạng biểu đồ
            chart.Legend.Position = COMExcel.XlLegendPosition.xlLegendPositionBottom;

            // ======= HIỂN THỊ EXCEL =========
            exApp.Visible = true;
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {




        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ibtnHienThi_Click(object sender, EventArgs e)
        {
            string sql = "";
            if ((rdoTheoThang.Checked == false) && (rdoTheoThoiGian.Checked == false))
            {
                MessageBox.Show("Vui lòng chọn một trong hai phương thức hiển thị doanh thu",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (rdoTheoThang.Checked == true)
            {
                if (txtThang.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tháng báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtThang.Focus();
                    return;
                }
                if ((Convert.ToDouble(txtThang.Text) < 1) || (Convert.ToDouble(txtThang.Text) > 12))
                {
                    MessageBox.Show("Bạn nhập sai tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtThang.Text = "";
                    txtThang.Focus();
                    return;
                }
                if (txtNam.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập năm báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNam.Focus();
                    return;
                }
                if ((Convert.ToDouble(txtNam.Text) < 2020))
                {
                    MessageBox.Show("Bạn nhập sai năm \n Cửa hàng mở từ năm 2020, vui lòng không nhập các năm trước đó", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNam.Text = "";
                    txtNam.Focus();
                    return;
                }
                sql = "SELECT CONCAT(YEAR(NgayKT), '-', MONTH(NgayKT)) AS ThoiGian,SUM(Tongtien) AS DoanhThu" +
                    " From KhachQuangcao"
                    + " WHERE MONTH(NgayKT) = " + txtThang.Text + " AND YEAR(NgayKT) = " + txtNam.Text +
                    " GROUP BY YEAR(NgayKT), MONTH(NgayKT);";


            }
            if (rdoTheoThoiGian.Checked == true)
            {
                if (mskTu.Text.Trim() == "  /")
                {
                    MessageBox.Show("Bạn chưa nhập thời gian bắt đầu của báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskTu.Focus();
                    return;
                }
                if (mskDen.Text.Trim() == "  /")
                {
                    MessageBox.Show("Bạn chưa nhập thời gian kết thúc của báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDen.Focus();
                    return;
                }

                DateTime tuNgay, denNgay;
                try
                {
                    tuNgay = DateTime.ParseExact("01/" + mskTu.Text, "dd/MM/yyyy", null);
                }
                catch
                {
                    MessageBox.Show("Bạn nhập sai định dạng thời gian bắt đầu (MM/yyyy)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskTu.Focus();
                    return;
                }

                try
                {
                    DateTime temp = DateTime.ParseExact("01/" + mskDen.Text, "dd/MM/yyyy", null);
                    denNgay = new DateTime(temp.Year, temp.Month, DateTime.DaysInMonth(temp.Year, temp.Month));
                }
                catch
                {
                    MessageBox.Show("Bạn nhập sai định dạng thời gian kết thúc (MM/yyyy)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskDen.Focus();
                    return;
                }

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sql = "SELECT FORMAT(NgayKT, 'yyyy-MM') AS ThoiGian, " +
                      "SUM(Tongtien) AS DoanhThu " +
                      "FROM KhachQuangcao " +
                      "WHERE NgayKT BETWEEN '" + tuNgay.ToString("yyyy-MM-dd") + "' AND '" + denNgay.ToString("yyyy-MM-dd") + "' " +
                      "GROUP BY FORMAT(NgayKT, 'yyyy-MM') " +
                      "ORDER BY FORMAT(NgayKT, 'yyyy-MM');";
            }
            DataTable dataTable = QuanLyHopDong.Functions.GetDataToTable(sql);
            dataGridView1.DataSource = dataTable;
        }

        private void ibtnLamMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNam1.Text))
            {
                MessageBox.Show("Vui lòng nhập năm để hiển thị biểu đồ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql1 = "SELECT MONTH(NgayKT) AS Thang, SUM(Tongtien) AS DoanhThu " +
                          "FROM KhachQuangcao " +
                          "WHERE YEAR(NgayKT) = " + txtNam1.Text +
                          " GROUP BY MONTH(NgayKT);";

            DataTable dataTable = QuanLyHopDong.Functions.GetDataToTable(sql1);

            // Dọn dữ liệu cũ
            chartDoanhThu.Series["DoanhThu"].Points.Clear();
            chartDoanhThu.Legends.Clear();

            // Cấu hình series
            chartDoanhThu.Series["DoanhThu"].LabelFormat = "#,##0,, ";
            chartDoanhThu.Series["DoanhThu"].Color = Color.FromArgb(34, 139, 34);
            chartDoanhThu.Series["DoanhThu"]["PointWidth"] = "0.5";

            // Cấu hình trục X/Y
            var chartArea = chartDoanhThu.ChartAreas["ChartArea1"];
            chartArea.AxisX.Title = "Tháng";
            chartArea.AxisY.Title = "Doanh thu (triệu VNĐ)";
            chartArea.AxisX.Interval = 1;  // Đảm bảo khoảng cách giữa các tháng đều
            chartArea.AxisX.Minimum = 0;  // Bắt đầu từ tháng 1
            chartArea.AxisX.Maximum = 12; // Kết thúc ở tháng 12
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 8);  // Tăng kích thước font chữ nếu cần
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 8);
            chartArea.AxisY.LabelStyle.Format = "#,##0,,";

            // Thêm dữ liệu vào biểu đồ
            foreach (DataRow row in dataTable.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                double doanhThu = Convert.ToDouble(row["DoanhThu"]);

                // Thêm dữ liệu vào biểu đồ
                chartDoanhThu.Series["DoanhThu"].Points.AddXY(thang, doanhThu);
            }

            // Cập nhật lại trục X để hiển thị từ tháng 1 đến tháng 12
            foreach (var point in chartDoanhThu.Series["DoanhThu"].Points)
            {
                // Đảm bảo các điểm trên trục X không bị trùng
                point.AxisLabel = point.XValue.ToString();
            }

            // Điều chỉnh khoảng cách nhãn trục X
            chartArea.AxisX.Interval = 1;  // Đảm bảo mỗi tháng được hiển thị một lần

        }

        private void ibtnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
            COMExcel.Range exRange;

            exSheet.Name = "Bao cao";

            // ======= HEADER THÔNG TIN =========
            // ====== DÒNG 1: BÁO CÁO DOANH THU THEO THÁNG TẠI E1 ======
            exRange = exSheet.Range["E1:G1"];
            exRange.Font.Size = 16;
            exRange.Font.Name = "Times New Roman";
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 3; // Màu đỏ
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "BÁO CÁO DOANH THU THEO THÁNG";

            // ====== DÒNG 2: HỆ THỐNG ======
            exRange = exSheet.Range["A2:C2"];
            exRange.Font.Size = 10;
            exRange.Font.Name = "Times New Roman";
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 5;
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "HỆ THỐNG QUẢN LÝ BÁO";

            // ====== DÒNG 3: ĐỊA CHỈ ======
            exRange = exSheet.Range["A3:C3"];
            exRange.Font.Size = 10;
            exRange.Font.Name = "Times New Roman";
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 5;
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "Xã Đàn - Hà Nội";

            // ====== DÒNG 4: ĐIỆN THOẠI ======
            exRange = exSheet.Range["A4:C4"];
            exRange.Font.Size = 10;
            exRange.Font.Name = "Times New Roman";
            exRange.Font.Bold = true;
            exRange.Font.ColorIndex = 5;
            exRange.MergeCells = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value = "Điện thoại: (04) 4444 8888";

            // ======= TIÊU ĐỀ CỘT =========
            int rowStart = 8;
            exSheet.Cells[rowStart, 1] = "STT";
            exSheet.Cells[rowStart, 2] = "Thời gian";
            exSheet.Cells[rowStart, 3] = "Tổng doanh thu";

            exRange = exSheet.Range["A" + rowStart, "C" + rowStart];
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;

            // ======= IN DỮ LIỆU TỪ CHARTDOANHTHU =========
            int stt = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].IsNewRow) continue;

                exSheet.Cells[rowStart + 1 + i, 1] = stt++;
                exSheet.Cells[rowStart + 1 + i, 2] = dataGridView1.Rows[i].Cells["ThoiGian"].Value?.ToString();
                exSheet.Cells[rowStart + 1 + i, 3] = dataGridView1.Rows[i].Cells["DoanhThu"].Value?.ToString();
            }

            // ======= CĂN CHỈNH KÍCH THƯỚC CỘT =========
            exSheet.Columns.AutoFit();

            // Hiển thị Excel

            exApp.Visible = true;
        }
    }
}
