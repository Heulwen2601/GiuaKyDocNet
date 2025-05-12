namespace QLTOUR.GiaoDIen
{
    partial class QLTour
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLTour));
            this.dgv_thongtintour = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_matour = new System.Windows.Forms.TextBox();
            this.txt_tentour = new System.Windows.Forms.TextBox();
            this.txt_anhtour = new System.Windows.Forms.TextBox();
            this.txt_giatour = new System.Windows.Forms.TextBox();
            this.dpt_batdau = new System.Windows.Forms.DateTimePicker();
            this.dpt_ketthuc = new System.Windows.Forms.DateTimePicker();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.cbb_maloaitour = new System.Windows.Forms.ComboBox();
            this.cbb_phuongtien = new System.Windows.Forms.ComboBox();
            this.cbb_xp = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txt_slve = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_taoma = new System.Windows.Forms.Button();
            this.txt_mota = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtintour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_thongtintour
            // 
            this.dgv_thongtintour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_thongtintour.BackgroundColor = System.Drawing.Color.White;
            this.dgv_thongtintour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thongtintour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_thongtintour.ColumnHeadersHeight = 25;
            this.dgv_thongtintour.Location = new System.Drawing.Point(31, 483);
            this.dgv_thongtintour.Name = "dgv_thongtintour";
            this.dgv_thongtintour.RowHeadersWidth = 51;
            this.dgv_thongtintour.Size = new System.Drawing.Size(1322, 281);
            this.dgv_thongtintour.TabIndex = 0;
            this.dgv_thongtintour.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dstour_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Tour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô tả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hình Ảnh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã Tour";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Giá tour";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(428, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ngày khởi hành";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(428, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ngày kết thúc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(428, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "Loại tour";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(428, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "Phương tiện";
            // 
            // txt_matour
            // 
            this.txt_matour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_matour.Enabled = false;
            this.txt_matour.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_matour.Location = new System.Drawing.Point(31, 132);
            this.txt_matour.Name = "txt_matour";
            this.txt_matour.Size = new System.Drawing.Size(233, 35);
            this.txt_matour.TabIndex = 10;
            // 
            // txt_tentour
            // 
            this.txt_tentour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tentour.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tentour.Location = new System.Drawing.Point(31, 192);
            this.txt_tentour.Name = "txt_tentour";
            this.txt_tentour.Size = new System.Drawing.Size(378, 28);
            this.txt_tentour.TabIndex = 11;
            // 
            // txt_anhtour
            // 
            this.txt_anhtour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_anhtour.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_anhtour.Location = new System.Drawing.Point(33, 258);
            this.txt_anhtour.Name = "txt_anhtour";
            this.txt_anhtour.Size = new System.Drawing.Size(376, 28);
            this.txt_anhtour.TabIndex = 13;
            // 
            // txt_giatour
            // 
            this.txt_giatour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_giatour.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_giatour.Location = new System.Drawing.Point(33, 318);
            this.txt_giatour.Name = "txt_giatour";
            this.txt_giatour.Size = new System.Drawing.Size(376, 28);
            this.txt_giatour.TabIndex = 14;
            // 
            // dpt_batdau
            // 
            this.dpt_batdau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpt_batdau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpt_batdau.Location = new System.Drawing.Point(431, 132);
            this.dpt_batdau.Name = "dpt_batdau";
            this.dpt_batdau.Size = new System.Drawing.Size(355, 27);
            this.dpt_batdau.TabIndex = 17;
            // 
            // dpt_ketthuc
            // 
            this.dpt_ketthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpt_ketthuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpt_ketthuc.Location = new System.Drawing.Point(431, 192);
            this.dpt_ketthuc.Name = "dpt_ketthuc";
            this.dpt_ketthuc.Size = new System.Drawing.Size(355, 27);
            this.dpt_ketthuc.TabIndex = 18;
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btn_them.FlatAppearance.BorderSize = 0;
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_them.Location = new System.Drawing.Point(817, 359);
            this.btn_them.Name = "btn_them";
            this.btn_them.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_them.Size = new System.Drawing.Size(175, 49);
            this.btn_them.TabIndex = 19;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_xoa.FlatAppearance.BorderSize = 0;
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_xoa.Image")));
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(998, 359);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_xoa.Size = new System.Drawing.Size(175, 49);
            this.btn_xoa.TabIndex = 20;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_sua.FlatAppearance.BorderSize = 0;
            this.btn_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.ForeColor = System.Drawing.Color.White;
            this.btn_sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_sua.Image")));
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(1179, 359);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_sua.Size = new System.Drawing.Size(175, 49);
            this.btn_sua.TabIndex = 21;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // cbb_maloaitour
            // 
            this.cbb_maloaitour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_maloaitour.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.75F);
            this.cbb_maloaitour.FormattingEnabled = true;
            this.cbb_maloaitour.Location = new System.Drawing.Point(431, 259);
            this.cbb_maloaitour.Name = "cbb_maloaitour";
            this.cbb_maloaitour.Size = new System.Drawing.Size(355, 30);
            this.cbb_maloaitour.TabIndex = 22;
            // 
            // cbb_phuongtien
            // 
            this.cbb_phuongtien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_phuongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.75F);
            this.cbb_phuongtien.FormattingEnabled = true;
            this.cbb_phuongtien.Location = new System.Drawing.Point(431, 317);
            this.cbb_phuongtien.Name = "cbb_phuongtien";
            this.cbb_phuongtien.Size = new System.Drawing.Size(355, 30);
            this.cbb_phuongtien.TabIndex = 23;
            // 
            // cbb_xp
            // 
            this.cbb_xp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_xp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.75F);
            this.cbb_xp.FormattingEnabled = true;
            this.cbb_xp.Location = new System.Drawing.Point(431, 376);
            this.cbb_xp.Name = "cbb_xp";
            this.cbb_xp.Size = new System.Drawing.Size(355, 30);
            this.cbb_xp.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(428, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "Xuất phát";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(139, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(226, 37);
            this.label11.TabIndex = 28;
            this.label11.Text = "Quản Lý Tour";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(817, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(536, 313);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // txt_slve
            // 
            this.txt_slve.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_slve.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_slve.Location = new System.Drawing.Point(431, 433);
            this.txt_slve.Name = "txt_slve";
            this.txt_slve.Size = new System.Drawing.Size(355, 28);
            this.txt_slve.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(428, 412);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 18);
            this.label12.TabIndex = 32;
            this.label12.Text = "Số lượng vé";
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_luu.Enabled = false;
            this.btn_luu.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_luu.FlatAppearance.BorderSize = 0;
            this.btn_luu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu.ForeColor = System.Drawing.Color.White;
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_luu.Location = new System.Drawing.Point(1178, 433);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_luu.Size = new System.Drawing.Size(175, 49);
            this.btn_luu.TabIndex = 34;
            this.btn_luu.Text = "Lưu dữ liệu";
            this.btn_luu.UseVisualStyleBackColor = false;
            this.btn_luu.Visible = false;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_taoma
            // 
            this.btn_taoma.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_taoma.FlatAppearance.BorderSize = 0;
            this.btn_taoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_taoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_taoma.ForeColor = System.Drawing.Color.White;
            this.btn_taoma.Location = new System.Drawing.Point(281, 132);
            this.btn_taoma.Name = "btn_taoma";
            this.btn_taoma.Size = new System.Drawing.Size(128, 36);
            this.btn_taoma.TabIndex = 39;
            this.btn_taoma.Text = "Tạo Mã Tour";
            this.btn_taoma.UseVisualStyleBackColor = false;
            this.btn_taoma.Click += new System.EventHandler(this.btn_taoma_Click_1);
            // 
            // txt_mota
            // 
            this.txt_mota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_mota.Location = new System.Drawing.Point(33, 383);
            this.txt_mota.Name = "txt_mota";
            this.txt_mota.Size = new System.Drawing.Size(376, 79);
            this.txt_mota.TabIndex = 40;
            this.txt_mota.Text = "";
            // 
            // QLTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 789);
            this.Controls.Add(this.txt_mota);
            this.Controls.Add(this.btn_taoma);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.txt_slve);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbb_xp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbb_phuongtien);
            this.Controls.Add(this.cbb_maloaitour);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.dpt_ketthuc);
            this.Controls.Add(this.dpt_batdau);
            this.Controls.Add(this.txt_giatour);
            this.Controls.Add(this.txt_anhtour);
            this.Controls.Add(this.txt_tentour);
            this.Controls.Add(this.txt_matour);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_thongtintour);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QLTour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QLTour";
            this.Load += new System.EventHandler(this.QLTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thongtintour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_thongtintour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_matour;
        private System.Windows.Forms.TextBox txt_tentour;
        private System.Windows.Forms.TextBox txt_anhtour;
        private System.Windows.Forms.TextBox txt_giatour;
        private System.Windows.Forms.DateTimePicker dpt_batdau;
        private System.Windows.Forms.DateTimePicker dpt_ketthuc;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.ComboBox cbb_maloaitour;
        private System.Windows.Forms.ComboBox cbb_phuongtien;
        private System.Windows.Forms.ComboBox cbb_xp;
        private System.Windows.Forms.Label label10;
          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.Label label11;
          private System.Windows.Forms.PictureBox pictureBox2;
          private System.Windows.Forms.TextBox txt_slve;
          private System.Windows.Forms.Label label12;
          private System.Windows.Forms.Button btn_luu;
          private System.Windows.Forms.Button btn_taoma;
          private System.Windows.Forms.RichTextBox txt_mota;
     }
}