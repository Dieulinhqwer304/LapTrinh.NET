using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHopDong
{
    internal static class Program
    {
      
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Functions.Connect(); 
            using (var loginForm = new frmLogin())
            {
        
                var result = loginForm.ShowDialog();

                if (result == DialogResult.OK) // đăng nhập thành công
                {
                    Application.Run(new frmDanhMuc()); // mở form chính
                }
                //else
                //{
                //    // Đăng nhập thất bại hoặc đóng form login -> thoát app
                //    Application.Exit();
                //}
            }
        }
    }
}
