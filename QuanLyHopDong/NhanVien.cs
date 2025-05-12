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
    public partial class NhanVien: Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable dtNhanVien;
        bool isEditing = false;
        /* public NhanVien()
         {
             InitializeComponent();
             connection = new SqlConnection("Data Source=LAPTOP-AJ9TO7IE\\SQLEXPRESS;Initial Catalog=QLHD;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
         }*/
        private void NhanVien_Load (object sender, EventArgs e)
        {
            Functions.Connect();
            LoadComboBox();
            LoadDataToGridView();
        }
        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM Nhanvien";
                adapter = new SqlDataAdapter(query, connection);
                dtNhanVien = new DataTable();
                adapter.Fill(dtNhanVien);
                dgvNhanVien.DataSource = dtNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
     
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEditing = false;
            SetControlsState(true); // Bật các textbox, combobox cho phép nhập liệu
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isEditing) // Nếu là sửa
            {
                string updateQuery = "UPDATE Nhanvien SET TenNV=@TenNV, Mabao=@Mabao, Maphong=@Maphong, Machucvu=@Machucvu, Matrinhdo=@Matrinhdo, MaCM=@MaCM, Diachi=@Diachi, Ngaysinh=@Ngaysinh, Gioitinh=@Gioitinh, Dienthoai=@Dienthoai, Mobile=@Mobile, Email=@Email WHERE MaNV=@MaNV";
                cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@Mabao", cboBao.SelectedValue);
                cmd.Parameters.AddWithValue("@Maphong", cboPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@Machucvu", cboChucVu.SelectedValue);
                cmd.Parameters.AddWithValue("@Matrinhdo", cboTrinhDo.SelectedValue);
                cmd.Parameters.AddWithValue("@MaCM", cboChuyenMon.SelectedValue);
                cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Ngaysinh", mtxtNgaySinh.Text);
                cmd.Parameters.AddWithValue("@Gioitinh", cboGioiTinh.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Dienthoai", mtbDienThoai.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else // Nếu là thêm mới
            {
                string insertQuery = "INSERT INTO Nhanvien (MaNV, TenNV, Mabao, Maphong, Machucvu, Matrinhdo, MaCM, Diachi, Ngaysinh, Gioitinh, Dienthoai, Mobile, Email) VALUES (@MaNV, @TenNV, @Mabao, @Maphong, @Machucvu, @Matrinhdo, @MaCM, @Diachi, @Ngaysinh, @Gioitinh, @Dienthoai, @Mobile, @Email)";
                cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@Mabao", cboBao.SelectedValue);
                cmd.Parameters.AddWithValue("@Maphong", cboPhong.SelectedValue);
                cmd.Parameters.AddWithValue("@Machucvu", cboChucVu.SelectedValue);
                cmd.Parameters.AddWithValue("@Matrinhdo", cboTrinhDo.SelectedValue);
                cmd.Parameters.AddWithValue("@MaCM", cboChuyenMon.SelectedValue);
                cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Ngaysinh", mtxtNgaySinh.Text);
                cmd.Parameters.AddWithValue("@Gioitinh", cboGioiTinh.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Dienthoai", mtbDienThoai.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            SetControlsState(false); // Tắt nhập liệu sau khi lưu
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM Nhanvien WHERE MaNV=@MaNV";
                cmd = new SqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // Tìm kiếm nhân viên
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Nhanvien WHERE TenNV LIKE @TenNV";
            cmd = new SqlCommand(searchQuery, connection);
            cmd.Parameters.AddWithValue("@TenNV", "%" + txtTenNV.Text + "%");

            try
            {
                adapter = new SqlDataAdapter(cmd);
                dtNhanVien = new DataTable();
                adapter.Fill(dtNhanVien);
               dgvNhanVien.DataSource = dtNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        // Bỏ qua thao tác hiện tại
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetControlsState(false);
        }
        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Thiết lập trạng thái các control
        private void SetControlsState(bool enable)
        {
            txtMaNV.Enabled = enable;
            txtTenNV.Enabled = enable;
            cboBao.Enabled = enable;
            cboPhong.Enabled = enable;
            cboChucVu.Enabled = enable;
            cboTrinhDo.Enabled = enable;
            cboChuyenMon.Enabled = enable;
            txtDiaChi.Enabled = enable;
            mtxtNgaySinh.Enabled = enable;
            cboGioiTinh.Enabled = enable;
            mtbDienThoai.Enabled = enable;
            txtMobile.Enabled = enable;
            txtEmail.Enabled = enable;
        }

        // Xóa các textbox, combobox
        private void ClearFields()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cboBao.SelectedIndex = -1;
            cboPhong.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;
            cboTrinhDo.SelectedIndex = -1;
            cboChuyenMon.SelectedIndex = -1;
            txtDiaChi.Text = "";
            mtxtNgaySinh.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            mtbDienThoai.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
        }

        // Form Load
        private void Nhanvien_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlsState(false); // Khi form load, chỉ có thể tìm kiếm và thoát
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
