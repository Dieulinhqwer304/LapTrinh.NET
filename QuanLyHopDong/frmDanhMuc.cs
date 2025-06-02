using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace QuanLyHopDong
{
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
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
            OpenFormInPanel(new frmTrangchu());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
        private void iconButton6_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new frmTrangchu());
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new frmBao());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new frmKhachQuangCao());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new frmKhachGuiBai());
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new FrmNhanVien());
        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new DoanhThu());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Functions.ActivateButton((IconButton)sender);
            OpenFormInPanel(new frmKhachHang());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
        "Bạn có muốn đăng xuất không?",
        "Đăng xuất",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại và hiển thị form đăng nhập
                this.Hide();
                var loginForm = new frmLogin();
                loginForm.Show();
            }
        }
    }
}
