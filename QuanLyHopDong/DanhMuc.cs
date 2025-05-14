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
    public partial class DanhMuc : Form
    {
        public DanhMuc()
        {
            InitializeComponent();
        }
        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Khởi tạo đối tượng DoanhThu

            DoanhThu f1 = new DoanhThu();
            f1.StartPosition = FormStartPosition.CenterScreen;
            f1.Show();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //Đóng form hiện tại
            QuanLyHopDong.Functions.Disconnect(); //Đóng kết nối
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.Show();
        }

        private void chiPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiPhi f2 = new ChiPhi();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Show();

        }

        private void mnuLoiNhuan_Click(object sender, EventArgs e)
        {
            LoiNhuan f3 = new LoiNhuan();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();

        }

        private void kháchGửiBàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachGuiBai f = new frmKhachGuiBai();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void quảngCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachQuangCao f = new frmKhachQuangCao();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void báoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBao f = new frmBao();
            f.Show();
        }

<<<<<<< HEAD
        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien f = new FrmNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen; 
            f.Show();
        }
=======
        
>>>>>>> 0301ddae417245b25ca4e017adccad6ce4229631
    }
}
