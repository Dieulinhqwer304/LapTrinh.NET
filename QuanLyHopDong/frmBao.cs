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
using FontAwesome.Sharp;

namespace QuanLyHopDong
{
    public partial class frmBao : Form
    {
        public frmBao()
        {
            InitializeComponent();
        }

        private void frmBao_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadDataToGridView();

            btnThem.IconChar = IconChar.Plus;
            btnThem.IconColor = Color.SeaGreen;
            btnThem.IconSize = 20;
            btnThem.IconFont = IconFont.Auto;
            btnThem.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnSua.IconChar = IconChar.Edit;
            btnSua.IconColor = Color.SeaGreen;
            btnSua.IconSize = 20;
            btnSua.IconFont = IconFont.Auto;
            btnSua.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnXoa.IconChar = IconChar.Trash;
            btnXoa.IconColor = Color.SeaGreen;
            btnXoa.IconSize = 20;
            btnXoa.IconFont = IconFont.Auto;
            btnXoa.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnLuu.IconChar = IconChar.FloppyDisk;
            btnLuu.IconColor = Color.SeaGreen;
            btnLuu.IconSize = 20;
            btnLuu.IconFont = IconFont.Auto;
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnBoQua.IconChar = IconChar.X;
            btnBoQua.IconColor = Color.SeaGreen;
            btnBoQua.IconSize = 20;
            btnBoQua.IconFont = IconFont.Auto;
            btnBoQua.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnTimKiem.IconChar = IconChar.MagnifyingGlass;
            btnTimKiem.IconColor = Color.SeaGreen;
            btnTimKiem.IconSize = 20;
            btnTimKiem.IconFont = IconFont.Auto;
            btnTimKiem.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnThoat.IconChar = IconChar.RightFromBracket;
            btnThoat.IconColor = Color.SeaGreen;
            btnThoat.IconSize = 20;
            btnThoat.IconFont = IconFont.Auto;
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
        private void LoadDataToGridView()
        {
            string sql = "SELECT * FROM Bao";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, Functions.Conn);
            da.Fill(dt);
            dgvBao.DataSource = dt;
        }

        private void clear()
        {
            txtMaBao.Text = "";
            txtTenBao.Text = "";
            txtMaChucNang.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
        }


        private void dgvBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0 && !dgvBao.Rows[i].IsNewRow)
            {
                DataGridViewRow row = dgvBao.Rows[i];
                txtMaBao.Text = row.Cells[0].Value?.ToString() ?? "";
                txtTenBao.Text = row.Cells[1].Value?.ToString() ?? "";
                txtMaChucNang.Text = row.Cells[2].Value?.ToString() ?? "";  
                txtDiaChi.Text = row.Cells[3].Value?.ToString() ?? "";
                txtDienThoai.Text = row.Cells[4].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells[5].Value?.ToString() ?? "";
                txtMaBao.ReadOnly = true;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            txtMaBao.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mabao = txtMaBao.Text.Trim();

            if (mabao == "")
            {
                MessageBox.Show("Bạn chưa nhập mã báo");
                txtMaBao.Focus();
                return;
            }

            string sqlCheck = "SELECT * FROM Bao WHERE Mabao = N'" + mabao + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO Bao (Mabao, Tenbao, Machucnang, Diachi, Dienthoai, Email) " +
                             "VALUES (@Mabao, @Tenbao, @Machucnang, @Diachi, @Dienthoai, @Email)";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                cmd.Parameters.AddWithValue("@Mabao", txtMaBao.Text.Trim());
                cmd.Parameters.AddWithValue("@Tenbao", txtTenBao.Text.Trim());
                cmd.Parameters.AddWithValue("@Machucnang", txtMaChucNang.Text.Trim()); 
                cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@Dienthoai", txtDienThoai.Text.Trim());   
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

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
                MessageBox.Show("Trùng mã báo!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaBao.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            string sql = $"UPDATE Bao SET Tenbao = N'{txtTenBao.Text}', Machucnang = N'{txtMaChucNang.Text}', " +
                         $"Diachi = N'{txtDiaChi.Text}', Dienthoai = N'{txtDienThoai.Text}', Email = N'{txtEmail.Text}' " +
                         $"WHERE Mabao = N'{txtMaBao.Text}'";
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
            if (dgvBao.CurrentRow == null || dgvBao.CurrentRow.Index == -1)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi để xóa");
                return;
            }

            string mabao = dgvBao.CurrentRow.Cells[0].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa báo '{mabao}' không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = $"DELETE FROM Bao WHERE Mabao = N'{mabao}'";
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
            string keyword = txtTenBao.Text.Trim();
            if (keyword == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa tìm kiếm.");
                return;
            }

            string sql = $"SELECT * FROM Bao WHERE Tenbao LIKE N'%{keyword}%'";
            DataTable dt = Functions.GetDataToTable(sql);
            dgvBao.DataSource = dt;
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
