namespace QuanLyHopDong
{
    partial class DoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mskDen = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoTheoThoiGian = new System.Windows.Forms.RadioButton();
            this.mskTu = new System.Windows.Forms.MaskedTextBox();
            this.rdoTheoThang = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.khachQuangcaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLHDDataSet = new QuanLyHopDong.QLHDDataSet();
            this.txtNam1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.khachQuangcaoTableAdapter = new QuanLyHopDong.QLHDDataSetTableAdapters.KhachQuangcaoTableAdapter();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ibtnHienThi = new FontAwesome.Sharp.IconButton();
            this.ibtnLamMoi = new FontAwesome.Sharp.IconButton();
            this.ibtnIn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachQuangcaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLHDDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 239);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(356, 199);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mskDen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.txtThang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdoTheoThoiGian);
            this.groupBox1.Controls.Add(this.mskTu);
            this.groupBox1.Controls.Add(this.rdoTheoThang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(29, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 162);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // mskDen
            // 
            this.mskDen.Location = new System.Drawing.Point(241, 118);
            this.mskDen.Mask = "00/0000";
            this.mskDen.Name = "mskDen";
            this.mskDen.Size = new System.Drawing.Size(100, 22);
            this.mskDen.TabIndex = 13;
            this.mskDen.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Từ";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(241, 60);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(100, 22);
            this.txtNam.TabIndex = 9;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(70, 60);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(100, 22);
            this.txtThang.TabIndex = 8;
            this.txtThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThang_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm";
            // 
            // rdoTheoThoiGian
            // 
            this.rdoTheoThoiGian.AutoSize = true;
            this.rdoTheoThoiGian.Location = new System.Drawing.Point(20, 95);
            this.rdoTheoThoiGian.Name = "rdoTheoThoiGian";
            this.rdoTheoThoiGian.Size = new System.Drawing.Size(161, 20);
            this.rdoTheoThoiGian.TabIndex = 3;
            this.rdoTheoThoiGian.TabStop = true;
            this.rdoTheoThoiGian.Text = "Theo khoảng thời gian";
            this.rdoTheoThoiGian.UseVisualStyleBackColor = true;
            this.rdoTheoThoiGian.CheckedChanged += new System.EventHandler(this.rdoTheoThoiGian_CheckedChanged);
            // 
            // mskTu
            // 
            this.mskTu.Location = new System.Drawing.Point(70, 121);
            this.mskTu.Mask = "00/0000";
            this.mskTu.Name = "mskTu";
            this.mskTu.Size = new System.Drawing.Size(100, 22);
            this.mskTu.TabIndex = 5;
            this.mskTu.ValidatingType = typeof(System.DateTime);
            // 
            // rdoTheoThang
            // 
            this.rdoTheoThang.AutoSize = true;
            this.rdoTheoThang.Location = new System.Drawing.Point(20, 31);
            this.rdoTheoThang.Name = "rdoTheoThang";
            this.rdoTheoThang.Size = new System.Drawing.Size(96, 20);
            this.rdoTheoThang.TabIndex = 2;
            this.rdoTheoThang.TabStop = true;
            this.rdoTheoThang.Text = "Theo tháng";
            this.rdoTheoThang.UseVisualStyleBackColor = true;
            this.rdoTheoThang.CheckedChanged += new System.EventHandler(this.rdoTheoThang_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(242, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "BÁO CÁO DOANH THU";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.DataSource = this.khachQuangcaoBindingSource;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(402, 239);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartDoanhThu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(380, 199);
            this.chartDoanhThu.TabIndex = 10;
            this.chartDoanhThu.Text = "Doanh thu theo tháng";
            // 
            // khachQuangcaoBindingSource
            // 
            this.khachQuangcaoBindingSource.DataMember = "KhachQuangcao";
            this.khachQuangcaoBindingSource.DataSource = this.qLHDDataSet;
            // 
            // qLHDDataSet
            // 
            this.qLHDDataSet.DataSetName = "QLHDDataSet";
            this.qLHDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNam1
            // 
            this.txtNam1.Location = new System.Drawing.Point(465, 209);
            this.txtNam1.Name = "txtNam1";
            this.txtNam1.Size = new System.Drawing.Size(100, 22);
            this.txtNam1.TabIndex = 14;
            this.txtNam1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm";
            this.label6.UseWaitCursor = true;
            // 
            // khachQuangcaoTableAdapter
            // 
            this.khachQuangcaoTableAdapter.ClearBeforeFill = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ibtnHienThi
            // 
            this.ibtnHienThi.IconChar = FontAwesome.Sharp.IconChar.Display;
            this.ibtnHienThi.IconColor = System.Drawing.Color.ForestGreen;
            this.ibtnHienThi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnHienThi.IconSize = 20;
            this.ibtnHienThi.Location = new System.Drawing.Point(402, 63);
            this.ibtnHienThi.Name = "ibtnHienThi";
            this.ibtnHienThi.Size = new System.Drawing.Size(102, 32);
            this.ibtnHienThi.TabIndex = 15;
            this.ibtnHienThi.Text = "Hiển thị";
            this.ibtnHienThi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnHienThi.UseVisualStyleBackColor = true;
            this.ibtnHienThi.Click += new System.EventHandler(this.ibtnHienThi_Click);
            // 
            // ibtnLamMoi
            // 
            this.ibtnLamMoi.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.ibtnLamMoi.IconColor = System.Drawing.Color.ForestGreen;
            this.ibtnLamMoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnLamMoi.IconSize = 20;
            this.ibtnLamMoi.Location = new System.Drawing.Point(673, 201);
            this.ibtnLamMoi.Name = "ibtnLamMoi";
            this.ibtnLamMoi.Size = new System.Drawing.Size(109, 32);
            this.ibtnLamMoi.TabIndex = 16;
            this.ibtnLamMoi.Text = "Làm mới ";
            this.ibtnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnLamMoi.UseVisualStyleBackColor = true;
            this.ibtnLamMoi.Click += new System.EventHandler(this.ibtnLamMoi_Click);
            // 
            // ibtnIn
            // 
            this.ibtnIn.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.ibtnIn.IconColor = System.Drawing.Color.ForestGreen;
            this.ibtnIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnIn.IconSize = 20;
            this.ibtnIn.Location = new System.Drawing.Point(402, 117);
            this.ibtnIn.Name = "ibtnIn";
            this.ibtnIn.Size = new System.Drawing.Size(83, 32);
            this.ibtnIn.TabIndex = 17;
            this.ibtnIn.Text = "In";
            this.ibtnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnIn.UseVisualStyleBackColor = true;
            this.ibtnIn.Click += new System.EventHandler(this.ibtnIn_Click);
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ibtnIn);
            this.Controls.Add(this.ibtnLamMoi);
            this.Controls.Add(this.ibtnHienThi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNam1);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DoanhThu";
            this.Text = "DoanhThu";
            this.Load += new System.EventHandler(this.DoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachQuangcaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLHDDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoTheoThoiGian;
        private System.Windows.Forms.MaskedTextBox mskTu;
        private System.Windows.Forms.RadioButton rdoTheoThang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.TextBox txtNam1;
        private System.Windows.Forms.Label label6;
        private QLHDDataSet qLHDDataSet;
        private System.Windows.Forms.BindingSource khachQuangcaoBindingSource;
        private QLHDDataSetTableAdapters.KhachQuangcaoTableAdapter khachQuangcaoTableAdapter;
        private System.Windows.Forms.ImageList imageList1;
        private FontAwesome.Sharp.IconButton ibtnHienThi;
        private FontAwesome.Sharp.IconButton ibtnLamMoi;
        private FontAwesome.Sharp.IconButton ibtnIn;
    }
}