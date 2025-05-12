namespace QuanLyHopDong
{
    partial class DanhMuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.báoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchGửiBàiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảngCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChiPhi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoiNhuan = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuBaoCao,
            this.trợGiúpToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1075, 40);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhachHang,
            this.mnuNhanVien,
            this.báoToolStripMenuItem,
            this.kháchGửiBàiToolStripMenuItem,
            this.quảngCáoToolStripMenuItem});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(127, 34);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(315, 40);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(315, 40);
            this.mnuNhanVien.Text = "Nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // báoToolStripMenuItem
            // 
            this.báoToolStripMenuItem.Name = "báoToolStripMenuItem";
            this.báoToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.báoToolStripMenuItem.Text = "Báo";
            this.báoToolStripMenuItem.Click += new System.EventHandler(this.báoToolStripMenuItem_Click);
            // 
            // kháchGửiBàiToolStripMenuItem
            // 
            this.kháchGửiBàiToolStripMenuItem.Name = "kháchGửiBàiToolStripMenuItem";
            this.kháchGửiBàiToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.kháchGửiBàiToolStripMenuItem.Text = "Khách gửi bài";
            this.kháchGửiBàiToolStripMenuItem.Click += new System.EventHandler(this.kháchGửiBàiToolStripMenuItem_Click);
            // 
            // quảngCáoToolStripMenuItem
            // 
            this.quảngCáoToolStripMenuItem.Name = "quảngCáoToolStripMenuItem";
            this.quảngCáoToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.quảngCáoToolStripMenuItem.Text = "Quảng cáo";
            this.quảngCáoToolStripMenuItem.Click += new System.EventHandler(this.quảngCáoToolStripMenuItem_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoanhThu,
            this.mnuChiPhi,
            this.mnuLoiNhuan});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(105, 34);
            this.mnuBaoCao.Text = "Báo cáo";
            // 
            // mnuDoanhThu
            // 
            this.mnuDoanhThu.Name = "mnuDoanhThu";
            this.mnuDoanhThu.Size = new System.Drawing.Size(230, 40);
            this.mnuDoanhThu.Text = "Doanh thu";
            this.mnuDoanhThu.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // mnuChiPhi
            // 
            this.mnuChiPhi.Name = "mnuChiPhi";
            this.mnuChiPhi.Size = new System.Drawing.Size(230, 40);
            this.mnuChiPhi.Text = "Chi phí";
            this.mnuChiPhi.Click += new System.EventHandler(this.chiPhíToolStripMenuItem_Click);
            // 
            // mnuLoiNhuan
            // 
            this.mnuLoiNhuan.Name = "mnuLoiNhuan";
            this.mnuLoiNhuan.Size = new System.Drawing.Size(230, 40);
            this.mnuLoiNhuan.Text = "Lợi nhuận";
            this.mnuLoiNhuan.Click += new System.EventHandler(this.mnuLoiNhuan_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(107, 34);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(84, 34);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::QuanLyHopDong.Properties.Resources.R;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1075, 609);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DanhMuc";
            this.Text = "DANHMUC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem báoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchGửiBàiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảngCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem mnuChiPhi;
        private System.Windows.Forms.ToolStripMenuItem mnuLoiNhuan;
    }
}