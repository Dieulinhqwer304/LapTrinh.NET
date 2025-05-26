using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyHopDong
{
    public partial class frmKhachGuiBai : Form
    {
        public frmKhachGuiBai()
        {
            InitializeComponent();
        }

        private void frmKhachGuiBai_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadComboBox();
            LoadDataToGridView();
            txtNhuanbut.ReadOnly = true;
            dtpNgaydang.Format = DateTimePickerFormat.Custom;
            dtpNgaydang.CustomFormat = "dd/MM/yyyy";
        }

        private void LoadComboBox()
        {
            Functions.FillCombo("SELECT MaKH FROM Khachhang", cboMaKH, "MaKH", "MaKH");
            Functions.FillCombo("SELECT Matheloai FROM Theloai", cboMaTL, "Matheloai", "Matheloai");
            Functions.FillCombo("SELECT MaBao FROM Bao", cboMaBao, "Mabao", "Mabao");
            Functions.FillCombo("SELECT MaNV FROM Nhanvien", cboMaNV, "MaNV", "MaNV");

            cboMaKH.SelectedIndex = -1;
            cboMaTL.SelectedIndex = -1;
            cboMaBao.SelectedIndex = -1;
            cboMaNV.SelectedIndex = -1;
        }

        private void LoadDataToGridView()
        {
            string sql = "SELECT * FROM Khachguibai";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, Functions.Conn);
            da.Fill(dt);
            dataGridViewKGuiBai.DataSource = dt;

            dataGridViewKGuiBai.Columns[0].HeaderText = "Mã lần gửi";
            dataGridViewKGuiBai.Columns[1].HeaderText = "Mã khách hàng";
            dataGridViewKGuiBai.Columns[2].HeaderText = "Mã thể loại";
            dataGridViewKGuiBai.Columns[3].HeaderText = "Mã báo";
            dataGridViewKGuiBai.Columns[4].HeaderText = "Tiêu đề";
            dataGridViewKGuiBai.Columns[5].HeaderText = "Nội dung";
            dataGridViewKGuiBai.Columns[6].HeaderText = "Mã nhân viên";
            dataGridViewKGuiBai.Columns[7].HeaderText = "Ngày đăng";
            dataGridViewKGuiBai.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewKGuiBai.Columns[8].HeaderText = "Nhuận bút";
        }

        private void clear()
        {
            txtmaLanGui.Text = "";
            cboMaKH.Text = "";
            cboMaTL.Text = "";
            cboMaBao.Text = "";
            txtTieude.Text = "";
            txtNoidung.Text = "";
            cboMaNV.Text = "";
            dtpNgaydang.Text = "";
            txtNhuanbut.Text = "";
            txtNhuanbut.ReadOnly = true;
        }

        private void dataGridViewKGuiBai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKGuiBai.Rows.Count > 0)
            {
                txtmaLanGui.Text = dataGridViewKGuiBai.CurrentRow.Cells[0].Value.ToString();
                cboMaKH.Text = dataGridViewKGuiBai.CurrentRow.Cells[1].Value.ToString();
                cboMaTL.Text = dataGridViewKGuiBai.CurrentRow.Cells[2].Value.ToString();
                cboMaBao.Text = dataGridViewKGuiBai.CurrentRow.Cells[3].Value.ToString();
                txtTieude.Text = dataGridViewKGuiBai.CurrentRow.Cells[4].Value.ToString();
                txtNoidung.Text = dataGridViewKGuiBai.CurrentRow.Cells[5].Value.ToString();
                cboMaNV.Text = dataGridViewKGuiBai.CurrentRow.Cells[6].Value.ToString();

                if(DateTime.TryParse(dataGridViewKGuiBai.CurrentRow.Cells[7].Value.ToString(), out DateTime ngayDang))
                {
                    dtpNgaydang.Value = ngayDang;
                }

                txtNhuanbut.Text = dataGridViewKGuiBai.CurrentRow.Cells[8].Value.ToString();
                txtNhuanbut.ReadOnly = true;
            }
        }

        private void iconbtnThem_Click(object sender, EventArgs e)
        {
            clear();
            txtNhuanbut.ReadOnly = true;
        }

        private void iconbtnSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewKGuiBai.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaLanGui.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã lần gửi");
                return;
            }
            if (txtTieude.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tiêu đề");
                txtTieude.Focus();
                return;
            }
            if (txtNoidung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập nội dung");
                txtNoidung.Focus();
                return;
            }
            if (dtpNgaydang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ngày đăng");
                dtpNgaydang.Focus();
                return;
            }

            // Parse ngày đăng
            if (!DateTime.TryParse(dtpNgaydang.Text.Trim(), out DateTime dtNgaydang))
            {
                MessageBox.Show("Ngày đăng không hợp lệ");
                return;
            }

            // Tính nhuận bút tự động
            string sqlGetNB = $@"SELECT TOP 1 Nhuanbut FROM Bao_Theloai 
                         WHERE MaBao = N'{cboMaBao.Text}' 
                         AND MaTheloai = N'{cboMaTL.Text}'
                         AND MONTH(NgayApdung) = {dtNgaydang.Month} 
                         AND YEAR(NgayApdung) = {dtNgaydang.Year}";

            SqlCommand cmdNB = new SqlCommand(sqlGetNB, Functions.Conn);
            object result = cmdNB.ExecuteScalar();

            if (result == null)
            {
                MessageBox.Show("Không tìm thấy nhuận bút tương ứng trong bảng Bao_Theloai!");
                return;
            }

            decimal nhuanbutValue = Convert.ToDecimal(result);
            txtNhuanbut.Text = nhuanbutValue.ToString();   // ✅ Sửa đổi: Gán vào textbox để người dùng xem

            // Cập nhật
            string sql = $"UPDATE Khachguibai SET " +
                         $"MaKH=N'{cboMaKH.Text}', Matheloai=N'{cboMaTL.Text}', Mabao=N'{cboMaBao.Text}', " +
                         $"Tieude=N'{txtTieude.Text}', Noidung=N'{txtNoidung.Text}', MaNV=N'{cboMaNV.Text}', " +
                         $"Ngaydang='{dtpNgaydang.Text}', Nhuanbut={nhuanbutValue} " +
                         $"WHERE Malangui=N'{txtmaLanGui.Text}'";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                cmd.ExecuteNonQuery();
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
            if (txtmaLanGui.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = $"DELETE FROM Khachguibai WHERE Malangui = N'{txtmaLanGui.Text}'";
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                    cmd.ExecuteNonQuery();
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
            string malan = txtmaLanGui.Text.Trim();
            string makh = cboMaKH.Text.Trim();
            string matl = cboMaTL.Text.Trim();
            string mabao = cboMaBao.Text.Trim();
            string tieude = txtTieude.Text.Trim();
            string noidung = txtNoidung.Text.Trim();
            string manv = cboMaNV.Text.Trim();
            string ngaydang = dtpNgaydang.Text.Trim();

            // Parse ngày đăng
            if (!DateTime.TryParseExact(ngaydang, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtNgaydang))
            {
                MessageBox.Show("Ngày đăng không hợp lệ. Định dạng đúng: dd/MM/yyyy");
                return;
            }


            // Truy vấn nhuận bút mới: Lấy dòng có Ngayapdung <= NgayDang gần nhất
            string sqlGetNB = @"
            SELECT TOP 1 Nhuanbut 
            from Bao_Theloai 
            WHERE Mabao = @MaBao 
            AND Matheloai = @MaTheloai 
            AND Ngayapdung <= @NgayDang
            ORDER BY Ngayapdung DESC";

            decimal nhuanbutValue = 0;
            using (SqlCommand cmdNB = new SqlCommand(sqlGetNB, Functions.Conn))
            {
                cmdNB.Parameters.AddWithValue("@MaBao", mabao);
                cmdNB.Parameters.AddWithValue("@MaTheloai", matl);
                cmdNB.Parameters.AddWithValue("@NgayDang", dtNgaydang);

                object result = cmdNB.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Không tìm thấy nhuận bút tương ứng trong bảng Bao_Theloai!");
                    return;
                }

                nhuanbutValue = Convert.ToDecimal(result);
            }

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(malan))
            {
                MessageBox.Show("Bạn chưa nhập mã lần gửi");
                txtmaLanGui.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tieude))
            {
                MessageBox.Show("Bạn chưa nhập tiêu đề");
                txtTieude.Focus();
                return;
            }
            if (string.IsNullOrEmpty(noidung))
            {
                MessageBox.Show("Bạn chưa nhập nội dung");
                txtNoidung.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ngaydang))
            {
                MessageBox.Show("Bạn chưa nhập ngày đăng");
                dtpNgaydang.Focus();
                return;
            }

            // Thiết lập combobox mặc định nếu chưa chọn
            if (cboMaKH.SelectedIndex == -1 && cboMaKH.Items.Count > 0)
                cboMaKH.SelectedIndex = 0;
            if (cboMaTL.SelectedIndex == -1 && cboMaTL.Items.Count > 0)
                cboMaTL.SelectedIndex = 0;
            if (cboMaBao.SelectedIndex == -1 && cboMaBao.Items.Count > 0)
                cboMaBao.SelectedIndex = 0;
            if (cboMaNV.SelectedIndex == -1 && cboMaNV.Items.Count > 0)
                cboMaNV.SelectedIndex = 0;

            // Kiểm tra trùng mã
            string sqlCheck = "SELECT * FROM Khachguibai WHERE Malangui = N'" + malan + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sqlInsert = @"INSERT INTO Khachguibai 
                VALUES (N'" + malan + "', N'" + makh + "', N'" + matl + "', N'" + mabao + "', N'" + tieude + "', N'" + noidung + "', N'" + manv + "', '" + dtNgaydang.ToString("yyyy-MM-dd") + "', " + nhuanbutValue + ")";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, Functions.Conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadDataToGridView();
                        clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Trùng mã lần gửi!");
            }

        }

        private void iconbtnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void iconbtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpNgaydang_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
