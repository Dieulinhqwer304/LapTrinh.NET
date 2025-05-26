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
using System.Globalization;

namespace QuanLyHopDong
{
    public partial class frmKhachQuangCao : Form
    {
        public frmKhachQuangCao()
        {
            InitializeComponent();
        }

        private void frmKhachQuangCao_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadComboBox();
            LoadDataToGridView();
            txtTongtien.ReadOnly = true;
            txtTongtien.BackColor = SystemColors.Control;
            txtTongtien.TabStop = false;
            dtpNgayBD.Format = DateTimePickerFormat.Custom;
            dtpNgayBD.CustomFormat = "dd/MM/yyyy";
            dtpNgayKT.Format = DateTimePickerFormat.Custom;
            dtpNgayKT.CustomFormat = "dd/MM/yyyy";
        }

        private void LoadComboBox()
        {
            Functions.FillCombo("SELECT MaKH FROM Khachhang", cboMaKH, "MaKH", "MaKH");
            Functions.FillCombo("SELECT MaBao FROM Bao", cboMaBao, "Mabao", "Mabao");
            Functions.FillCombo("SELECT MaNV FROM Nhanvien", cboMaNV, "MaNV", "MaNV");
            Functions.FillCombo("SELECT MaQCao FROM TTQuangCao", cboMaQC, "MaQcao", "MaQcao");

            cboMaKH.SelectedIndex = -1;
            cboMaBao.SelectedIndex = -1;
            cboMaNV.SelectedIndex = -1;
            cboMaQC.SelectedIndex = -1;
        }

        private void LoadDataToGridView()
        {
            string sql = "SELECT * FROM KhachQuangcao";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, Functions.Conn);
            da.Fill(dt);
            dataGridViewKQcao.DataSource = dt;
            
            dataGridViewKQcao.Columns[0].HeaderText = "Mã lần quảng cáo";
            dataGridViewKQcao.Columns[1].HeaderText = "Mã khách hàng";
            dataGridViewKQcao.Columns[2].HeaderText = "Mã báo";
            dataGridViewKQcao.Columns[3].HeaderText = "Mã nhân viên";
            dataGridViewKQcao.Columns[4].HeaderText = "Mã quảng cáo";
            dataGridViewKQcao.Columns[5].HeaderText = "Nội dung";
            dataGridViewKQcao.Columns[6].HeaderText = "Ngày bắt đầu";
            dataGridViewKQcao.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewKQcao.Columns[7].HeaderText = "Ngày kết thúc";
            dataGridViewKQcao.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewKQcao.Columns[8].HeaderText = "Tổng tiền";
        }

        private void clear()
        {
            txtmaLanQC.Text = "";
            cboMaKH.Text = "";
            cboMaBao.Text = "";
            cboMaNV.Text = "";
            cboMaQC.Text = "";
            txtNoidung.Text = "";
            dtpNgayBD.Text = "";
            dtpNgayKT.Text = "";
            txtTongtien.Text = "";
            txtTongtien.ReadOnly = true;
        }

        private void dataGridViewKQcao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewKQcao.Rows.Count > 0)
            {
                txtmaLanQC.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                cboMaKH.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                cboMaBao.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                cboMaNV.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
                cboMaQC.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";
                txtNoidung.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
                if (DateTime.TryParse(dataGridViewKQcao.Rows[e.RowIndex].Cells[6].Value.ToString(), out DateTime ngayBD))
                {
                    dtpNgayBD.Value = ngayBD;
                }
                else
                {
                    //dtpNgayBD.Value = DateTime.Now;
                }

                if (DateTime.TryParse(dataGridViewKQcao.Rows[e.RowIndex].Cells[7].Value.ToString(), out DateTime ngayKT))
                {
                    dtpNgayKT.Value = ngayKT;
                }
                else
                {
                    //dtpNgayKT.Value = DateTime.Now;
                }
                //dtpNgayKT.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[7].Value?.ToString() ?? "";
                txtTongtien.Text = dataGridViewKQcao.Rows[e.RowIndex].Cells[8].Value?.ToString() ?? "";
                Console.WriteLine(dataGridViewKQcao.Rows[e.RowIndex].Cells[6].Value);
            }
        }

        private void iconbtnThem_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void iconbtnSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewKQcao.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaLanQC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            // Kiểm tra ngày
            DateTime bd, kt;
            if (!DateTime.TryParseExact(dtpNgayBD.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out bd) ||
                !DateTime.TryParseExact(dtpNgayKT.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out kt))
            {
                MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ. Định dạng đúng: dd/MM/yyyy");
                return;
            }

            // Tính tổng tiền
            int songay = (kt - bd).Days + 1;
            string sqlDonGia = "SELECT Dongia FROM BangGia WHERE MaBao = @MaBao AND MaQcao = @MaQcao";
            using (SqlCommand cmdDonGia = new SqlCommand(sqlDonGia, Functions.Conn))
            {
                cmdDonGia.Parameters.AddWithValue("@MaBao", cboMaBao.Text);
                cmdDonGia.Parameters.AddWithValue("@MaQcao", cboMaQC.Text);
                object donGiaObj = cmdDonGia.ExecuteScalar();
                if (donGiaObj == null || donGiaObj.ToString() == "")
                {
                    MessageBox.Show("Không tìm thấy đơn giá trong bảng giá.");
                    return;
                }
                decimal dongia = Convert.ToDecimal(donGiaObj);
                decimal tongtien = songay * dongia;
                txtTongtien.Text = tongtien.ToString();
            }

            // Cập nhật bản ghi
            string sql = "UPDATE KhachQuangcao SET MaKH = @MaKH, Mabao = @MaBao, MaNV = @MaNV, MaQcao = @MaQcao, " +
                         "Noidung = @Noidung, NgayBD = @NgayBD, NgayKT = @NgayKT, Tongtien = @Tongtien " +
                         "WHERE MalanQC = @MalanQC";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, Functions.Conn))
                {
                    cmd.Parameters.AddWithValue("@MalanQC", txtmaLanQC.Text);
                    cmd.Parameters.AddWithValue("@MaKH", cboMaKH.Text);
                    cmd.Parameters.AddWithValue("@MaBao", cboMaBao.Text);
                    cmd.Parameters.AddWithValue("@MaNV", cboMaNV.Text);
                    cmd.Parameters.AddWithValue("@MaQcao", cboMaQC.Text);
                    cmd.Parameters.AddWithValue("@Noidung", txtNoidung.Text);
                    cmd.Parameters.AddWithValue("@NgayBD", dtpNgayBD.Text);
                    cmd.Parameters.AddWithValue("@NgayKT", dtpNgayKT.Text);
                    cmd.Parameters.AddWithValue("@Tongtien", Convert.ToDecimal(txtTongtien.Text));
                    cmd.ExecuteNonQuery();
                }
                LoadDataToGridView();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void iconbtnXoa_Click(object sender, EventArgs e)
        {
            if (txtmaLanQC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = "DELETE FROM KhachQuangcao WHERE MalanQC = @MalanQC";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, Functions.Conn))
                    {
                        cmd.Parameters.AddWithValue("@MalanQC", txtmaLanQC.Text);
                        cmd.ExecuteNonQuery();
                    }
                    LoadDataToGridView();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void iconbtnLuu_Click(object sender, EventArgs e)
        {
            string malanqc = txtmaLanQC.Text.Trim();
            string makh = cboMaKH.Text.Trim();
            string mabao = cboMaBao.Text.Trim();
            string manv = cboMaNV.Text.Trim();
            string maqc = cboMaQC.Text.Trim();
            string noidung = txtNoidung.Text.Trim();
            string ngaybatdau = dtpNgayBD.Text.Trim();
            string ngayketthuc = dtpNgayKT.Text.Trim();

            if (malanqc == "")
            {
                MessageBox.Show("Bạn chưa nhập mã lần quảng cáo");
                txtmaLanQC.Focus();
                return;
            }

            // Kiểm tra trùng mã
            string sqlCheck = "SELECT * FROM KhachQuangcao WHERE MalanQC = @MalanQC";
            SqlParameter param = new SqlParameter("@MalanQC", malanqc);
            if (Functions.CheckKey(sqlCheck, param))
            {
                MessageBox.Show("Trùng mã lần quảng cáo!");
                return;
            }

            // Kiểm tra ngày
            DateTime bd, kt;
            if (!DateTime.TryParseExact(ngaybatdau, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out bd) ||
                !DateTime.TryParseExact(ngayketthuc, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out kt))
            {
                MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ. Định dạng đúng: dd/MM/yyyy");
                return;
            }

            // Tính tổng tiền
            int songay = (kt - bd).Days + 1;
            string sqlDonGia = "SELECT Dongia FROM BangGia WHERE MaBao = @MaBao AND MaQcao = @MaQcao";
            decimal tongtien;
            using (SqlCommand cmdDonGia = new SqlCommand(sqlDonGia, Functions.Conn))
            {
                cmdDonGia.Parameters.AddWithValue("@MaBao", mabao);
                cmdDonGia.Parameters.AddWithValue("@MaQcao", maqc);
                object donGiaObj = cmdDonGia.ExecuteScalar();
                if (donGiaObj == null || donGiaObj.ToString() == "")
                {
                    MessageBox.Show("Không tìm thấy đơn giá trong bảng giá.");
                    return;
                }
                decimal dongia = Convert.ToDecimal(donGiaObj);
                tongtien = songay * dongia;
                txtTongtien.Text = tongtien.ToString();
            }

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(noidung))
            {
                MessageBox.Show("Bạn chưa nhập nội dung");
                txtNoidung.Focus();
                return;
            }

            // Thiết lập combobox mặc định nếu chưa chọn
            if (cboMaKH.Items.Count > 0 && cboMaKH.SelectedIndex == -1)
                cboMaKH.SelectedIndex = 0;
            if (cboMaBao.Items.Count > 0 && cboMaBao.SelectedIndex == -1)
                cboMaBao.SelectedIndex = 0;
            if (cboMaNV.Items.Count > 0 && cboMaNV.SelectedIndex == -1)
                cboMaNV.SelectedIndex = 0;
            if (cboMaQC.Items.Count > 0 && cboMaQC.SelectedIndex == -1)
                cboMaQC.SelectedIndex = 0;

            // Thêm bản ghi
            string sql = "INSERT INTO KhachQuangcao VALUES (@MalanQC, @MaKH, @MaBao, @MaNV, @MaQcao, @Noidung, @NgayBD, @NgayKT, @Tongtien)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, Functions.Conn))
                {
                    cmd.Parameters.AddWithValue("@MalanQC", malanqc);
                    cmd.Parameters.AddWithValue("@MaKH", makh);
                    cmd.Parameters.AddWithValue("@MaBao", mabao);
                    cmd.Parameters.AddWithValue("@MaNV", manv);
                    cmd.Parameters.AddWithValue("@MaQcao", maqc);
                    cmd.Parameters.AddWithValue("@Noidung", noidung);
                    cmd.Parameters.AddWithValue("@NgayBD", ngaybatdau);
                    cmd.Parameters.AddWithValue("@NgayKT", ngayketthuc);
                    cmd.Parameters.AddWithValue("@Tongtien", tongtien);
                    cmd.ExecuteNonQuery();
                }
                LoadDataToGridView();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
        private void iconbtnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpNgayBD_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dtpNgayKT_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dtpNgayBD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}