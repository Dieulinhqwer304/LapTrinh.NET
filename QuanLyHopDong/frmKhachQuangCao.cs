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
            dataGridViewKQcao.Columns[3].HeaderText = "Mã Nhân viên";
            dataGridViewKQcao.Columns[4].HeaderText = "Mã quảng cáo";
            dataGridViewKQcao.Columns[5].HeaderText = "Nội dung";
            dataGridViewKQcao.Columns[6].HeaderText = "Ngày bắt đầu";
            dataGridViewKQcao.Columns[7].HeaderText = "Ngày kết thúc";
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
            mtxtNgayBD.Text = "";
            mtxtNgayKT.Text = "";
            txtTongtien.Text = "";
        }
        private void dataGridViewKQcao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKQcao.Rows.Count > 0)
            {
                txtmaLanQC.Text = dataGridViewKQcao.CurrentRow.Cells[0].Value.ToString();
                cboMaKH.Text = dataGridViewKQcao.CurrentRow.Cells[1].Value.ToString();
                cboMaBao.Text = dataGridViewKQcao.CurrentRow.Cells[1].Value.ToString();
                cboMaNV.Text = dataGridViewKQcao.CurrentRow.Cells[2].Value.ToString();
                cboMaQC.Text = dataGridViewKQcao.CurrentRow.Cells[3].Value.ToString();
                txtNoidung.Text = dataGridViewKQcao.CurrentRow.Cells[4].Value.ToString();
                mtxtNgayBD.Text = dataGridViewKQcao.CurrentRow.Cells[5].Value.ToString();
                mtxtNgayKT.Text = dataGridViewKQcao.CurrentRow.Cells[6].Value.ToString();
                txtTongtien.Text = dataGridViewKQcao.CurrentRow.Cells[7].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string malanqc = txtmaLanQC.Text.Trim();
            string makh = cboMaKH.Text.Trim();
            string mabao = cboMaBao.Text.Trim();
            string manv = cboMaNV.Text.Trim();
            string maqc = cboMaQC.Text.Trim();
            string noidung = txtNoidung.Text.Trim();
            string ngaybatdau = mtxtNgayBD.Text.Trim();
            string ngayketthuc = mtxtNgayKT.Text.Trim();
            string tongtien = txtTongtien.Text.Trim();

            if (malanqc == "")
            {
                MessageBox.Show("Bạn chưa nhập mã lần quảng cáo");
                txtmaLanQC.Focus();
                return;
            }

            string sqlCheck = "SELECT * FROM KhachQuangcao WHERE MalanQC = N'" + malanqc + "'";
            if (!Functions.CheckKey(sqlCheck))
            {
                string sql = "INSERT INTO KhachQuangcao VALUES " +
                             $"(N'{malanqc}', N'{makh}', N'{mabao}', N'{manv}', N'{maqc}', N'{noidung}', N'{ngaybatdau}', '{ngayketthuc}', {tongtien})";

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaLanQC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa");
                return;
            }

            string sql = $"UPDATE KhachQuangcao SET " +
                         $"MaKH=N'{cboMaKH.Text}', Mabao=N'{cboMaBao.Text}', MaNV=N'{cboMaNV.Text}', " +
                         $"MaQcao=N'{cboMaQC.Text}', Noidung=N'{txtNoidung.Text}', NgayBD=N'{mtxtNgayBD.Text}', " +
                         $"NgayKT='{mtxtNgayKT.Text}', Tongtien={txtTongtien.Text} " +
                         $"WHERE Malangui=N'{txtmaLanQC.Text}'";

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
            if (txtmaLanQC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = $"DELETE FROM KhachQuangcao WHERE MalanQC = N'{txtmaLanQC.Text}'";
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
        


    }
}
