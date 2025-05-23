namespace QuanLyHopDong
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnBao = new System.Windows.Forms.Button();
            this.btnQuangCao = new System.Windows.Forms.Button();
            this.btnKhachGuiBai = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnKhachGuiBai);
            this.panel1.Controls.Add(this.btnQuangCao);
            this.panel1.Controls.Add(this.btnBao);
            this.panel1.Controls.Add(this.btnNhanVien);
            this.panel1.Controls.Add(this.btnBaocao);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Location = new System.Drawing.Point(2, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 465);
            this.panel1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(155, 44);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(818, 465);
            this.panelMain.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(2, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(971, 34);
            this.panel3.TabIndex = 1;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(3, 15);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(144, 37);
            this.btnKhachHang.TabIndex = 0;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(0, 342);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(144, 38);
            this.btnBaocao.TabIndex = 1;
            this.btnBaocao.Text = "Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(0, 89);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(144, 37);
            this.btnNhanVien.TabIndex = 2;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnBao
            // 
            this.btnBao.Location = new System.Drawing.Point(0, 153);
            this.btnBao.Name = "btnBao";
            this.btnBao.Size = new System.Drawing.Size(144, 37);
            this.btnBao.TabIndex = 3;
            this.btnBao.Text = "Báo";
            this.btnBao.UseVisualStyleBackColor = true;
            this.btnBao.Click += new System.EventHandler(this.btnBao_Click);
            // 
            // btnQuangCao
            // 
            this.btnQuangCao.Location = new System.Drawing.Point(0, 214);
            this.btnQuangCao.Name = "btnQuangCao";
            this.btnQuangCao.Size = new System.Drawing.Size(144, 37);
            this.btnQuangCao.TabIndex = 4;
            this.btnQuangCao.Text = "Quảng Cáo";
            this.btnQuangCao.UseVisualStyleBackColor = true;
            this.btnQuangCao.Click += new System.EventHandler(this.btnQuangCao_Click);
            // 
            // btnKhachGuiBai
            // 
            this.btnKhachGuiBai.Location = new System.Drawing.Point(0, 274);
            this.btnKhachGuiBai.Name = "btnKhachGuiBai";
            this.btnKhachGuiBai.Size = new System.Drawing.Size(144, 37);
            this.btnKhachGuiBai.TabIndex = 5;
            this.btnKhachGuiBai.Text = "Khách gửi bài";
            this.btnKhachGuiBai.UseVisualStyleBackColor = true;
            this.btnKhachGuiBai.Click += new System.EventHandler(this.btnKhachGuiBai_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 513);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBaocao;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnKhachGuiBai;
        private System.Windows.Forms.Button btnQuangCao;
        private System.Windows.Forms.Button btnBao;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button button1;
    }
}