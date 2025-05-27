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
            txtNam.Enabled = false;
            txtThang.Enabled = false;
            mskTu.Enabled = false;
            mskDen.Enabled = false;


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
            exRange.Range["C2:E2"].Value = "BÁO CÁO ";

            // ======= THÔNG TIN THỜI GIAN =========
            exRange.Range["B5:C6"].Font.Size = 12;
            exRange.Range["B5:C6"].Font.Name = "Times New Roman";
            exRange.Range["B5:B5"].Value = "Năm báo cáo:";
            exRange.Range["C5:C5"].Value = txtNam1.Text; // Lấy năm từ txtNam1 (dùng trong btnLamMoi_Click)

            // ======= IN DỮ LIỆU TỪ CHARTDOANHTHU =========
            int rowStart = 8;
            exRange.Range["A8:C8"].Font.Bold = true;
            exRange.Range["A8:C8"].Font.Size = 12;
            exRange.Range["A8:C8"].Font.Name = "Times New Roman";
            exRange.Range["A8:C8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A8:A8"].ColumnWidth = 10;
            exRange.Range["B8:B8"].ColumnWidth = 15;
            exRange.Range["C8:C8"].ColumnWidth = 15; // Thêm dòng này để chỉnh độ rộng cho cột Chi phí


            exSheet.Cells[rowStart, 1] = "Tháng";
            exSheet.Cells[rowStart, 2] = "Doanh thu";
            exSheet.Cells[rowStart, 3] = "Chi phí ";


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
                sql = "SELECT CONCAT(YEAR(KQ.NgayKT), '-', MONTH(KQ.NgayKT)) AS ThoiGian, " +
                      "SUM(KQ.Tongtien) AS DoanhThu, " +
                      "(SELECT SUM(KGB.Nhuanbut) " +
                      " FROM Khachguibai KGB " +
                      " WHERE MONTH(KGB.Ngaydang) = MONTH(KQ.NgayKT) AND YEAR(KGB.Ngaydang) = YEAR(KQ.NgayKT)) AS ChiPhi " +
                      "FROM KhachQuangcao KQ " +
                      "WHERE MONTH(KQ.NgayKT) = " + txtThang.Text + " AND YEAR(KQ.NgayKT) = " + txtNam.Text + " " +
                      "GROUP BY YEAR(KQ.NgayKT), MONTH(KQ.NgayKT);";



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

                sql =
                "SELECT FORMAT(KQ.NgayKT, 'yyyy-MM') AS ThoiGian, " +
                "SUM(KQ.Tongtien) AS DoanhThu, " +
                "(SELECT SUM(KGB.Nhuanbut) " +
                " FROM Khachguibai KGB " +
                " WHERE FORMAT(KGB.Ngaydang, 'yyyy-MM') = FORMAT(KQ.NgayKT, 'yyyy-MM')) AS ChiPhi " +
                "FROM KhachQuangcao KQ " +
                "WHERE KQ.NgayKT BETWEEN '" + tuNgay.ToString("yyyy-MM-dd") + "' AND '" + denNgay.ToString("yyyy-MM-dd") + "' " +
                "GROUP BY FORMAT(KQ.NgayKT, 'yyyy-MM') " +
                "ORDER BY FORMAT(KQ.NgayKT, 'yyyy-MM');";

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
            exRange.Value = "BÁO CÁO ";

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
            exSheet.Cells[rowStart, 4] = "Tổng chi phí";

            exRange = exSheet.Range["A" + rowStart, "D" + rowStart];
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
                exSheet.Cells[rowStart + 1 + i, 4] = dataGridView1.Rows[i].Cells["ChiPhi"].Value?.ToString();

                // ======= CĂN CHỈNH KÍCH THƯỚC CỘT =========
                exSheet.Columns.AutoFit();

                // Hiển thị Excel

                exApp.Visible = true;
            }
        }
    }
}
