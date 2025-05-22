using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHopDong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new DoanhThu());

        }

        private void OpenFormInPanel(Form form)
        {
            panelMain.Controls.Clear();        // Xóa form cũ
            form.TopLevel = false;             // Cho phép nhúng
            form.FormBorderStyle = FormBorderStyle.None; // Bỏ viền
            form.Dock = DockStyle.Fill;        // Chiếm toàn bộ panel
            panelMain.Controls.Add(form);      // Thêm vào panel
            form.Show();                       // Hiển thị form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFormInPanel(new FrmNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmKhachHang());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FrmNhanVien());
        }

        private void btnBao_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmBao());
        }

        private void btnQuangCao_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmKhachQuangCao());
        }

        private void btnKhachGuiBai_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmKhachGuiBai());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
