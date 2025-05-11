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
    public partial class frmKhachHang : Form
    {

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadDataToGridView();
        }
        private void LoadDataToGridView()
        {
            string sql = "SELECT * FROM Khachhang";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, Functions.Conn);
            da.Fill(dt);
            dgvKhachHang.DataSource = dt;
        }

        private void clear()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            cboVaiTro.Text = "";
        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0) 
            {
                DataGridViewRow row = dgvKhachHang.Rows[i];

                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = row.Cells["Diachi"].Value.ToString();
                txtDienThoai.Text = row.Cells["Dienthoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cboVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
                txtMaKH.ReadOnly = true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            txtMaKH.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text.Trim();
            if (makh == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng");
                txtMaKH.Focus();
                return;
            }

            string sqlCheck = "SELECT * FROM Khachhang WHERE MaKH = N'" + makh + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO Khachhang (MaKH, TenKH, DiaChi, DienThoai, Email, VaiTro) " +
             "VALUES (@MaKH, @TenKH, @DiaChi, @DienThoai, @Email, @VaiTro)";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text.Trim());
                cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@VaiTro", cboVaiTro.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    clear();
                    MessageBox.Show("Lưu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Trùng mã khách hàng!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            string sql = $"UPDATE Khachhang SET TenKH=N'{txtTenKH.Text}', DiaChi=N'{txtDiaChi.Text}', DienThoai=N'{txtDienThoai.Text}', Email=N'{txtEmail.Text}', VaiTro=N'{cboVaiTro.Text}' WHERE MaKH=N'{txtMaKH.Text}'";
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null || dgvKhachHang.CurrentRow.Index == -1)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi để xóa");
                return;
            }

            string makh = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng '{makh}' không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = $"DELETE FROM Khachhang WHERE MaKH = N'{makh}'";
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Khachhang WHERE TenKH LIKE N'%{txtTenKH.Text}%'";
            DataTable dt = Functions.GetDataToTable(sql);
            dgvKhachHang.DataSource = dt;
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
