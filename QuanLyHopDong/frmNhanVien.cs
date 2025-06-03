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

namespace QuanLyHopDong
{
    public partial class FrmNhanVien: Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
            txtDienThoai.KeyPress += txtDienThoai_KeyPress;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadComboBox();
            LoadDataToGridView();
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");
            // Cấu hình định dạng ngày theo yyyy/MM/dd
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "yyyy/MM/dd";
        }
        private void LoadDataToGridView()
        {
            string sql = "SELECT * FROM Nhanvien";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, Functions.Conn);
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;

            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Mã báo";
            dgvNhanVien.Columns[3].HeaderText = "Mã phòng";
            dgvNhanVien.Columns[4].HeaderText = "Mã chức vụ";
            dgvNhanVien .Columns[5].HeaderText = "Mã trình độ";
            dgvNhanVien.Columns[6].HeaderText = "Mã chuyên môn";
            dgvNhanVien .Columns[7].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[8].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[9].HeaderText = "Giới tính";
            dgvNhanVien.Columns[10].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[11].HeaderText = "Email";
        }
        private void LoadComboBox()
        {
            Functions.FillCombo("SELECT Machucvu FROM Chucvu", cboMaChucVu, "Machucvu", "Machucvu");
            Functions.FillCombo("SELECT MaBao FROM Bao", cboMaBao, "Mabao", "Mabao");
            Functions.FillCombo("SELECT Maphong FROM Phongban", cboMaPhong, "Maphong", "Maphong");
            Functions.FillCombo("SELECT MaTD FROM Trinhdo", cboMaTrinhDo, "MaTD", "Matrinhdo");
            Functions.FillCombo("SELECT MaCM FROM Chuyenmon", cboMaChuyenMon, "MaCM", "MaCM");

            cboMaChucVu.SelectedIndex = -1;
            cboMaBao.SelectedIndex = -1;
            cboMaPhong.SelectedIndex = -1;
            cboMaTrinhDo.SelectedIndex = -1;
            cboMaChuyenMon.SelectedIndex = -1;
        }
        private void clear()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            cboGioiTinh .Text = "";
            cboMaChucVu.Text = "";
            cboMaChuyenMon.Text = "";
            cboMaPhong.Text = "";
            cboMaBao.Text = "";
            cboMaTrinhDo.Text = "";
            dtpNgaySinh.Text = "";
        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                cboMaBao.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                cboMaPhong.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                cboMaChucVu.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
                cboMaTrinhDo.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
                cboMaChuyenMon.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[7].Value.ToString();
                if (DateTime.TryParse(dgvNhanVien.CurrentRow.Cells[8].Value.ToString(), out DateTime ngaySinh))
                {
                    dtpNgaySinh.Value = ngaySinh;
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now; // hoặc chọn giá trị mặc định nếu không hợp lệ
                }
                cboGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[9].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells[10].Value.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells[11].Value.ToString();
            }
        }
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển như Backspace và các số (0-9)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconbtnThem_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void iconbtnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            string manv = txtMaNV.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string mabao = cboMaBao.Text.Trim();
            string maphong = cboMaPhong.Text.Trim();
            string machucvu = cboMaChucVu.Text.Trim();
            string matrinhdo = cboMaTrinhDo.Text.Trim();
            string machuyenmon = cboMaChuyenMon.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string ngaysinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string gioitinh = cboGioiTinh.Text.Trim();
            string dienthoai = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            string sql = "UPDATE Nhanvien SET " +
                         $"TenNV = N'{tennv}', " +
                         $"MaBao = N'{mabao}', " +
                         $"MaPhong = N'{maphong}', " +
                         $"MaChucVu = N'{machucvu}', " +
                         $"MaTrinhDo = N'{matrinhdo}', " +
                         $"MaCM = N'{machuyenmon}', " +
                         $"DiaChi = N'{diachi}', " +
                         $"NgaySinh = '{ngaysinh}', " +
                         $"GioiTinh = N'{gioitinh}', " +
                         $"DienThoai = N'{dienthoai}', " +
                         $"Email = N'{email}' " +
                         $"WHERE MaNV = N'{manv}'";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                cmd.ExecuteNonQuery();
                LoadDataToGridView();
                clear();
                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void iconbtnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = $"DELETE FROM Nhanvien WHERE MaNV = N'{txtMaNV.Text}'";
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

        private void iconbtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTenNV.Text.Trim();
            if (keyword == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa tìm kiếm.");
                return;
            }

            string sql = $"SELECT * FROM Nhanvien WHERE TenNV LIKE N'%{keyword}%'";
            DataTable dt = Functions.GetDataToTable(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào.");
            }
            dgvNhanVien.DataSource = dt;
        }

        private void iconbtnLuu_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string mabao = cboMaBao.Text.Trim();
            string maphong = cboMaPhong.Text.Trim();
            string machucvu = cboMaChucVu.Text.Trim();
            string matrinhdo = cboMaTrinhDo.Text.Trim();
            string machuyenmon = cboMaChuyenMon.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string ngaysinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string gioitinh = cboGioiTinh.Text.Trim();
            string dienthoai = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
  

            if (manv == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }

            string sqlCheck = "SELECT * FROM Nhanvien WHERE MaNV = N'" + manv + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO Nhanvien (MaNV, TenNV, MaBao, MaPhong, MaChucVu, MaTrinhDo, MaChuyenMon, DiaChi, NgaySinh, GioiTinh, DienThoai, Email) " +
                $"VALUES (N'{manv}', N'{tennv}', N'{mabao}', N'{maphong}', N'{machucvu}', N'{matrinhdo}', N'{machuyenmon}', N'{diachi}', N'{ngaysinh}', N'{gioitinh}', N'{dienthoai}', N'{email}')";

                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
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
            else
            {
                MessageBox.Show("Trùng mã lần quảng cáo!");
            }
        }

        private void iconbtnBoQua_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void iconbtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }

}
