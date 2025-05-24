namespace QuanLyHopDong
{
    partial class frmKhachQuangCao
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
            this.label10 = new System.Windows.Forms.Label();
            this.cboMaQC = new System.Windows.Forms.ComboBox();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.cboMaKH = new System.Windows.Forms.ComboBox();
            this.txtmaLanQC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtNgayBD = new System.Windows.Forms.MaskedTextBox();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mtxtNgayKT = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewKQcao = new System.Windows.Forms.DataGridView();
            this.cboMaBao = new System.Windows.Forms.ComboBox();
            this.iconbtnThem = new FontAwesome.Sharp.IconButton();
            this.iconbtnSua = new FontAwesome.Sharp.IconButton();
            this.iconbtnXoa = new FontAwesome.Sharp.IconButton();
            this.iconbtnLuu = new FontAwesome.Sharp.IconButton();
            this.iconbtnHuy = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKQcao)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label10.Location = new System.Drawing.Point(7, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(285, 31);
            this.label10.TabIndex = 22;
            this.label10.Text = "KHÁCH GỬI QUẢNG CÁO";
            // 
            // cboMaQC
            // 
            this.cboMaQC.FormattingEnabled = true;
            this.cboMaQC.Location = new System.Drawing.Point(12, 248);
            this.cboMaQC.Name = "cboMaQC";
            this.cboMaQC.Size = new System.Drawing.Size(120, 24);
            this.cboMaQC.TabIndex = 32;
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(11, 200);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(120, 24);
            this.cboMaNV.TabIndex = 31;
            // 
            // cboMaKH
            // 
            this.cboMaKH.FormattingEnabled = true;
            this.cboMaKH.Location = new System.Drawing.Point(11, 105);
            this.cboMaKH.Name = "cboMaKH";
            this.cboMaKH.Size = new System.Drawing.Size(120, 24);
            this.cboMaKH.TabIndex = 29;
            // 
            // txtmaLanQC
            // 
            this.txtmaLanQC.Location = new System.Drawing.Point(11, 62);
            this.txtmaLanQC.Name = "txtmaLanQC";
            this.txtmaLanQC.Size = new System.Drawing.Size(120, 22);
            this.txtmaLanQC.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "Mã Quảng cáo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mã báo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mã KH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mã lần quảng cáo";
            // 
            // mtxtNgayBD
            // 
            this.mtxtNgayBD.Location = new System.Drawing.Point(381, 62);
            this.mtxtNgayBD.Mask = "00/00/0000";
            this.mtxtNgayBD.Name = "mtxtNgayBD";
            this.mtxtNgayBD.Size = new System.Drawing.Size(140, 22);
            this.mtxtNgayBD.TabIndex = 36;
            this.mtxtNgayBD.ValidatingType = typeof(System.DateTime);
            // 
            // txtNoidung
            // 
            this.txtNoidung.Location = new System.Drawing.Point(192, 62);
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(139, 22);
            this.txtNoidung.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Ngày bắt đầu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Nội dung";
            // 
            // mtxtNgayKT
            // 
            this.mtxtNgayKT.Location = new System.Drawing.Point(575, 62);
            this.mtxtNgayKT.Mask = "00/00/0000";
            this.mtxtNgayKT.Name = "mtxtNgayKT";
            this.mtxtNgayKT.Size = new System.Drawing.Size(140, 22);
            this.mtxtNgayKT.TabIndex = 38;
            this.mtxtNgayKT.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(572, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Ngày kết thúc";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(11, 325);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(121, 22);
            this.txtTongtien.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Tổng tiền";
            // 
            // dataGridViewKQcao
            // 
            this.dataGridViewKQcao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKQcao.Location = new System.Drawing.Point(163, 105);
            this.dataGridViewKQcao.Name = "dataGridViewKQcao";
            this.dataGridViewKQcao.RowHeadersWidth = 51;
            this.dataGridViewKQcao.RowTemplate.Height = 24;
            this.dataGridViewKQcao.Size = new System.Drawing.Size(618, 242);
            this.dataGridViewKQcao.TabIndex = 41;
            this.dataGridViewKQcao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKQcao_CellClick);
            // 
            // cboMaBao
            // 
            this.cboMaBao.FormattingEnabled = true;
            this.cboMaBao.Location = new System.Drawing.Point(11, 154);
            this.cboMaBao.Name = "cboMaBao";
            this.cboMaBao.Size = new System.Drawing.Size(120, 24);
            this.cboMaBao.TabIndex = 48;
            // 
            // iconbtnThem
            // 
            this.iconbtnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconbtnThem.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconbtnThem.IconColor = System.Drawing.Color.PaleVioletRed;
            this.iconbtnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnThem.IconSize = 23;
            this.iconbtnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconbtnThem.Location = new System.Drawing.Point(163, 353);
            this.iconbtnThem.Name = "iconbtnThem";
            this.iconbtnThem.Size = new System.Drawing.Size(86, 30);
            this.iconbtnThem.TabIndex = 49;
            this.iconbtnThem.Text = "Thêm";
            this.iconbtnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnThem.UseVisualStyleBackColor = true;
            this.iconbtnThem.Click += new System.EventHandler(this.iconbtnThem_Click);
            // 
            // iconbtnSua
            // 
            this.iconbtnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconbtnSua.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.iconbtnSua.IconColor = System.Drawing.Color.PaleVioletRed;
            this.iconbtnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSua.IconSize = 23;
            this.iconbtnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconbtnSua.Location = new System.Drawing.Point(270, 353);
            this.iconbtnSua.Name = "iconbtnSua";
            this.iconbtnSua.Size = new System.Drawing.Size(86, 30);
            this.iconbtnSua.TabIndex = 50;
            this.iconbtnSua.Text = "Sửa";
            this.iconbtnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSua.UseVisualStyleBackColor = true;
            this.iconbtnSua.Click += new System.EventHandler(this.iconbtnSua_Click);
            // 
            // iconbtnXoa
            // 
            this.iconbtnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconbtnXoa.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.iconbtnXoa.IconColor = System.Drawing.Color.PaleVioletRed;
            this.iconbtnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnXoa.IconSize = 23;
            this.iconbtnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconbtnXoa.Location = new System.Drawing.Point(376, 353);
            this.iconbtnXoa.Name = "iconbtnXoa";
            this.iconbtnXoa.Size = new System.Drawing.Size(86, 30);
            this.iconbtnXoa.TabIndex = 51;
            this.iconbtnXoa.Text = "Xóa";
            this.iconbtnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnXoa.UseVisualStyleBackColor = true;
            this.iconbtnXoa.Click += new System.EventHandler(this.iconbtnXoa_Click);
            // 
            // iconbtnLuu
            // 
            this.iconbtnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconbtnLuu.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconbtnLuu.IconColor = System.Drawing.Color.PaleVioletRed;
            this.iconbtnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnLuu.IconSize = 23;
            this.iconbtnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconbtnLuu.Location = new System.Drawing.Point(480, 353);
            this.iconbtnLuu.Name = "iconbtnLuu";
            this.iconbtnLuu.Size = new System.Drawing.Size(86, 30);
            this.iconbtnLuu.TabIndex = 52;
            this.iconbtnLuu.Text = "Lưu";
            this.iconbtnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnLuu.UseVisualStyleBackColor = true;
            this.iconbtnLuu.Click += new System.EventHandler(this.iconbtnLuu_Click);
            // 
            // iconbtnHuy
            // 
            this.iconbtnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconbtnHuy.IconChar = FontAwesome.Sharp.IconChar.X;
            this.iconbtnHuy.IconColor = System.Drawing.Color.PaleVioletRed;
            this.iconbtnHuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnHuy.IconSize = 20;
            this.iconbtnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconbtnHuy.Location = new System.Drawing.Point(591, 353);
            this.iconbtnHuy.Name = "iconbtnHuy";
            this.iconbtnHuy.Size = new System.Drawing.Size(86, 30);
            this.iconbtnHuy.TabIndex = 53;
            this.iconbtnHuy.Text = "Hủy";
            this.iconbtnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnHuy.UseVisualStyleBackColor = true;
            this.iconbtnHuy.Click += new System.EventHandler(this.iconbtnHuy_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.iconButton1.IconColor = System.Drawing.Color.PaleVioletRed;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 23;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(695, 353);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(86, 30);
            this.iconButton1.TabIndex = 54;
            this.iconButton1.Text = "Thoát";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // frmKhachQuangCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 392);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.iconbtnHuy);
            this.Controls.Add(this.iconbtnLuu);
            this.Controls.Add(this.iconbtnXoa);
            this.Controls.Add(this.iconbtnSua);
            this.Controls.Add(this.iconbtnThem);
            this.Controls.Add(this.cboMaBao);
            this.Controls.Add(this.dataGridViewKQcao);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mtxtNgayKT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtxtNgayBD);
            this.Controls.Add(this.txtNoidung);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboMaQC);
            this.Controls.Add(this.cboMaNV);
            this.Controls.Add(this.cboMaKH);
            this.Controls.Add(this.txtmaLanQC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Name = "frmKhachQuangCao";
            this.Text = "Khách - Quảng cáo";
            this.Load += new System.EventHandler(this.frmKhachQuangCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKQcao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMaQC;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.ComboBox cboMaKH;
        private System.Windows.Forms.TextBox txtmaLanQC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtNgayBD;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtxtNgayKT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewKQcao;
        private System.Windows.Forms.ComboBox cboMaBao;
        private FontAwesome.Sharp.IconButton iconbtnThem;
        private FontAwesome.Sharp.IconButton iconbtnSua;
        private FontAwesome.Sharp.IconButton iconbtnXoa;
        private FontAwesome.Sharp.IconButton iconbtnLuu;
        private FontAwesome.Sharp.IconButton iconbtnHuy;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}