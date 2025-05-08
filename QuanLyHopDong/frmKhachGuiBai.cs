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
    public partial class frmKhachGuiBai : Form
    {
        public frmKhachGuiBai()
        {
            InitializeComponent();
        }
        private void frmKhachGuiBai_Load(object sender, EventArgs e)
        {
            DAO.connect();
            // Load data to grigview
            LoadDataToGridView();
        }
        private void LoadDataToGridView()
        {
            string sql = "Select * from Khachguibai";
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, DAO.conn);
            sqlDataAdapter.Fill(dt);
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

    }
}
