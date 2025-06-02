using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyHopDong
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu khi bắt đầu
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"SELECT tk.MaNV, nv.TenNV FROM TaiKhoan tk
                           JOIN Nhanvien nv ON tk.MaNV = nv.MaNV
                           WHERE tk.TenDangNhap = @username AND tk.MatKhau = @password AND tk.TrangThai = 1";

            using (SqlCommand cmd = new SqlCommand(sql, Functions.Conn))
            {
                cmd.Parameters.AddWithValue("@username", txtTaiKhoan.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtMatKhau.Text.Trim()); // TODO: Hash mật khẩu thật

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    StaticData.MaNV = dt.Rows[0]["MaNV"].ToString();
                    this.DialogResult = DialogResult.OK; // Đánh dấu đăng nhập thành công
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
