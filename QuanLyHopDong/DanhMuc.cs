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

        private void DanhMuc_Load(object sender, EventArgs e)
        {

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
    }
}
