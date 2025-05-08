using System;
using System.Data;
using System.Data.SqlClient;
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
            string sql = "SELECT * FROM KhachGuiBai";
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
            mtxtNgaydang.Text = "";
            txtNhuanbut.Text = "";
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
                mtxtNgaydang.Text = dataGridViewKGuiBai.CurrentRow.Cells[7].Value.ToString();
                txtNhuanbut.Text = dataGridViewKGuiBai.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string malan = txtmaLanGui.Text.Trim();
            string makh = cboMaKH.Text.Trim();
            string matl = cboMaTL.Text.Trim();
            string mabao = cboMaBao.Text.Trim();
            string tieude = txtTieude.Text.Trim();
            string noidung = txtNoidung.Text.Trim();
            string manv = cboMaNV.Text.Trim();
            string ngaydang = mtxtNgaydang.Text.Trim();
            string nhuanbut = txtNhuanbut.Text.Trim();

            if (malan == "")
            {
                MessageBox.Show("Bạn chưa nhập mã lần gửi");
                txtmaLanGui.Focus();
                return;
            }

            string sqlCheck = "SELECT * FROM KhachGuiBai WHERE Malangui = N'" + malan + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO KhachGuiBai VALUES " +
                             $"(N'{malan}', N'{makh}', N'{matl}', N'{mabao}', N'{tieude}', N'{noidung}', N'{manv}', '{ngaydang}', {nhuanbut})";

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
                MessageBox.Show("Trùng mã lần gửi!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaLanGui.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            string sql = $"UPDATE Khachguibai SET " +
                         $"MaKH=N'{cboMaKH.Text}', Matheloai=N'{cboMaTL.Text}', Mabao=N'{cboMaBao.Text}', " +
                         $"Tieude=N'{txtTieude.Text}', Noidung=N'{txtNoidung.Text}', MaNV=N'{cboMaNV.Text}', " +
                         $"Ngaydang='{mtxtNgaydang.Text}', Nhuanbut={txtNhuanbut.Text} " +
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

        private void btnXoa_Click(object sender, EventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
