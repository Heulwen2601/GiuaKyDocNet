namespace QLTOUR.GiaoDIen
{
    partial class QLHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLHoaDon));
            this.dtHD = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_chitietHD = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dtg_HD = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_sohd = new System.Windows.Forms.Label();
            this.lb_thanhtien = new System.Windows.Forms.Label();
            this.lb_tentour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_HD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtHD
            // 
            this.dtHD.Font = new System.Drawing.Font("Roboto", 11.75F);
            this.dtHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHD.Location = new System.Drawing.Point(615, 431);
            this.dtHD.Name = "dtHD";
            this.dtHD.Size = new System.Drawing.Size(204, 26);
            this.dtHD.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 19);
            this.label6.TabIndex = 37;
            this.label6.Text = "Tên Tour";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 38;
            this.label5.Text = "Thành Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(512, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ngày lập HD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 42;
            this.label1.Text = "Số hóa đơn";
            // 
            // btn_chitietHD
            // 
            this.btn_chitietHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(185)))), ((int)(((byte)(239)))));
            this.btn_chitietHD.FlatAppearance.BorderSize = 0;
            this.btn_chitietHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chitietHD.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chitietHD.ForeColor = System.Drawing.Color.White;
            this.btn_chitietHD.Image = ((System.Drawing.Image)(resources.GetObject("btn_chitietHD.Image")));
            this.btn_chitietHD.Location = new System.Drawing.Point(640, 606);
            this.btn_chitietHD.Name = "btn_chitietHD";
            this.btn_chitietHD.Size = new System.Drawing.Size(179, 53);
            this.btn_chitietHD.TabIndex = 30;
            this.btn_chitietHD.UseVisualStyleBackColor = false;
            this.btn_chitietHD.Click += new System.EventHandler(this.btn_chitietHD_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Roboto Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(41, 606);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnXoa.Size = new System.Drawing.Size(160, 53);
            this.btnXoa.TabIndex = 31;
            this.btnXoa.Text = "Hủy Vé";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dtg_HD
            // 
            this.dtg_HD.BackgroundColor = System.Drawing.Color.White;
            this.dtg_HD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_HD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_HD.Location = new System.Drawing.Point(41, 114);
            this.dtg_HD.Name = "dtg_HD";
            this.dtg_HD.Size = new System.Drawing.Size(778, 299);
            this.dtg_HD.TabIndex = 29;
            this.dtg_HD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_HD_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(147, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 38);
            this.label7.TabIndex = 44;
            this.label7.Text = "Hóa Đơn";
            // 
            // lb_sohd
            // 
            this.lb_sohd.AutoSize = true;
            this.lb_sohd.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sohd.ForeColor = System.Drawing.Color.Red;
            this.lb_sohd.Location = new System.Drawing.Point(152, 431);
            this.lb_sohd.Name = "lb_sohd";
            this.lb_sohd.Size = new System.Drawing.Size(79, 26);
            this.lb_sohd.TabIndex = 46;
            this.lb_sohd.Text = "lb_sohd";
            this.lb_sohd.Visible = false;
            // 
            // lb_thanhtien
            // 
            this.lb_thanhtien.AutoSize = true;
            this.lb_thanhtien.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thanhtien.ForeColor = System.Drawing.Color.Black;
            this.lb_thanhtien.Location = new System.Drawing.Point(152, 528);
            this.lb_thanhtien.Name = "lb_thanhtien";
            this.lb_thanhtien.Size = new System.Drawing.Size(65, 26);
            this.lb_thanhtien.TabIndex = 47;
            this.lb_thanhtien.Text = "label8";
            this.lb_thanhtien.Visible = false;
            // 
            // lb_tentour
            // 
            this.lb_tentour.AutoSize = true;
            this.lb_tentour.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tentour.ForeColor = System.Drawing.Color.Black;
            this.lb_tentour.Location = new System.Drawing.Point(152, 480);
            this.lb_tentour.Name = "lb_tentour";
            this.lb_tentour.Size = new System.Drawing.Size(65, 26);
            this.lb_tentour.TabIndex = 48;
            this.lb_tentour.Text = "label8";
            this.lb_tentour.Visible = false;
            // 
            // QLHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 715);
            this.Controls.Add(this.lb_tentour);
            this.Controls.Add(this.lb_thanhtien);
            this.Controls.Add(this.lb_sohd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtHD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_chitietHD);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dtg_HD);
            this.Name = "QLHoaDon";
            this.Text = "QLHoaDon";
            this.Load += new System.EventHandler(this.QLHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_HD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtHD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_chitietHD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dtg_HD;
          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.Label lb_sohd;
          private System.Windows.Forms.Label lb_thanhtien;
          private System.Windows.Forms.Label lb_tentour;
     }
}