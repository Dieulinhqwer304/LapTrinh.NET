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
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Địa chỉ";
            dgvNhanVien .Columns[5].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[6].HeaderText = "Email";
            dgvNhanVien .Columns[7].HeaderText = "Mã chức vụ";
            dgvNhanVien.Columns[8].HeaderText = "Mã chuyên môn";
            dgvNhanVien.Columns[9].HeaderText = "Mã phòng";
            dgvNhanVien.Columns[10].HeaderText = "Mã trình độ";
            dgvNhanVien.Columns[11].HeaderText = "Mã báo";
        }
        private void LoadComboBox()
        {
            Functions.FillCombo("SELECT Machucvu FROM Chucvu", cboMaChucVu, "Machucvu", "Machucvu");
            Functions.FillCombo("SELECT MaBao FROM Bao", cboMaBao, "Mabao", "Mabao");
            Functions.FillCombo("SELECT Maphong FROM Phongban", cboMaPhong, "Maphong", "Maphong");
            Functions.FillCombo("SELECT MaTD FROM Trinhdo", cboMaTrinhDo, "MaTD", "MaTD");
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
                cboGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
                cboMaChucVu.Text = dgvNhanVien  .CurrentRow.Cells[6].Value.ToString();
                cboMaChuyenMon.Text = dgvNhanVien.CurrentRow.Cells[7].Value.ToString();
                cboMaPhong.Text = dgvNhanVien.CurrentRow.Cells[8].Value.ToString();
                cboMaTrinhDo.Text = dgvNhanVien .CurrentRow .Cells[9].Value.ToString();
                cboMaBao.Text = dgvNhanVien.CurrentRow.Cells[10].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string gioitinh = cboGioiTinh.Text.Trim();
            string ngaysinh = dtpNgaySinh.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string dienthoai = txtDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string machucvu = cboMaChucVu.Text.Trim();
            string machuyenmon = cboMaChuyenMon.Text.Trim();
            string maphong = cboMaPhong.Text.Trim();
            string matrinhdo = cboMaTrinhDo.Text.Trim();
            string mabao = cboMaBao.Text.Trim();

            if (manv == "")
            {
                MessageBox.Show("Bạn chưa nhập mã lần quảng cáo");
                txtMaNV.Focus();
                return;
            }

            string sqlCheck = "SELECT * FROM Nhanvien WHERE MaNV = N'" + manv + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO  VALUES " +
                             $"(N'{manv}', N'{tennv}', N'{mabao}, N'{maphong}', N'{machucvu}', N'{matrinhdo}', N'{machuyenmon}', N'{diachi}', N'{ngaysinh}', N'{gioitinh}', '{dienthoai}', N'{email}')";

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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTenNV.Text.Trim();
            if (keyword == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa tìm kiếm.");
                return;
            }

            string sql = $"SELECT * FROM Nhanvien WHERE TenNV LIKE N'%{keyword}%'";
            DataTable dt = Functions.GetDataToTable(sql);
            dgvNhanVien.DataSource = dt;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
