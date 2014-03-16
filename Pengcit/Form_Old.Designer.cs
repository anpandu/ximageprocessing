namespace WindowsFormsApplication1
{
    partial class Form_Old
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Tugas = new System.Windows.Forms.TabPage();
            this.btn_clear_2 = new System.Windows.Forms.Button();
            this.btn_clear_1 = new System.Windows.Forms.Button();
            this.btn_histogram_2 = new System.Windows.Forms.Button();
            this.btn_histogram_1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.combo_img2 = new System.Windows.Forms.ComboBox();
            this.btn_act_2 = new System.Windows.Forms.Button();
            this.combo_img1 = new System.Windows.Forms.ComboBox();
            this.btn_act_1 = new System.Windows.Forms.Button();
            this.btn_input_file = new System.Windows.Forms.Button();
            this.tb_input_file = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lain = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.Tugas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Tugas);
            this.tabControl1.Controls.Add(this.Lain);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 474);
            this.tabControl1.TabIndex = 0;
            // 
            // Tugas
            // 
            this.Tugas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Tugas.Controls.Add(this.btn_clear_2);
            this.Tugas.Controls.Add(this.btn_clear_1);
            this.Tugas.Controls.Add(this.btn_histogram_2);
            this.Tugas.Controls.Add(this.btn_histogram_1);
            this.Tugas.Controls.Add(this.groupBox1);
            this.Tugas.Controls.Add(this.combo_img2);
            this.Tugas.Controls.Add(this.btn_act_2);
            this.Tugas.Controls.Add(this.combo_img1);
            this.Tugas.Controls.Add(this.btn_act_1);
            this.Tugas.Controls.Add(this.btn_input_file);
            this.Tugas.Controls.Add(this.tb_input_file);
            this.Tugas.Controls.Add(this.pictureBox2);
            this.Tugas.Controls.Add(this.pictureBox1);
            this.Tugas.Location = new System.Drawing.Point(4, 22);
            this.Tugas.Name = "Tugas";
            this.Tugas.Padding = new System.Windows.Forms.Padding(3);
            this.Tugas.Size = new System.Drawing.Size(935, 448);
            this.Tugas.TabIndex = 0;
            this.Tugas.Text = "Tugas";
            // 
            // btn_clear_2
            // 
            this.btn_clear_2.Location = new System.Drawing.Point(823, 97);
            this.btn_clear_2.Name = "btn_clear_2";
            this.btn_clear_2.Size = new System.Drawing.Size(50, 21);
            this.btn_clear_2.TabIndex = 14;
            this.btn_clear_2.Text = "Clear";
            this.btn_clear_2.UseVisualStyleBackColor = true;
            this.btn_clear_2.Click += new System.EventHandler(this.btn_clear_2_Click);
            // 
            // btn_clear_1
            // 
            this.btn_clear_1.Location = new System.Drawing.Point(360, 97);
            this.btn_clear_1.Name = "btn_clear_1";
            this.btn_clear_1.Size = new System.Drawing.Size(50, 21);
            this.btn_clear_1.TabIndex = 13;
            this.btn_clear_1.Text = "Clear";
            this.btn_clear_1.UseVisualStyleBackColor = true;
            this.btn_clear_1.Click += new System.EventHandler(this.btn_clear_1_Click);
            // 
            // btn_histogram_2
            // 
            this.btn_histogram_2.Location = new System.Drawing.Point(879, 97);
            this.btn_histogram_2.Name = "btn_histogram_2";
            this.btn_histogram_2.Size = new System.Drawing.Size(50, 21);
            this.btn_histogram_2.TabIndex = 12;
            this.btn_histogram_2.Text = "Histo";
            this.btn_histogram_2.UseVisualStyleBackColor = true;
            this.btn_histogram_2.Click += new System.EventHandler(this.btn_histogram_2_Click);
            // 
            // btn_histogram_1
            // 
            this.btn_histogram_1.Location = new System.Drawing.Point(416, 97);
            this.btn_histogram_1.Name = "btn_histogram_1";
            this.btn_histogram_1.Size = new System.Drawing.Size(50, 21);
            this.btn_histogram_1.TabIndex = 11;
            this.btn_histogram_1.Text = "Histo";
            this.btn_histogram_1.UseVisualStyleBackColor = true;
            this.btn_histogram_1.Click += new System.EventHandler(this.btn_histogram_1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_log);
            this.groupBox1.Location = new System.Drawing.Point(469, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 85);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // rtb_log
            // 
            this.rtb_log.Location = new System.Drawing.Point(7, 19);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(447, 60);
            this.rtb_log.TabIndex = 0;
            this.rtb_log.Text = "";
            // 
            // combo_img2
            // 
            this.combo_img2.FormattingEnabled = true;
            this.combo_img2.Items.AddRange(new object[] {
            "--- Pilih ---",
            "Tugas 1 - Bikin Cerah",
            "Tugas 2 - Bikin Cerah 2",
            "Tugas 3 - Sharpen",
            "Tugas 4 - Rekognisi",
            "Tugas 5a - Difference 4",
            "Tugas 5b - Difference 2",
            "Tugas 6a - Convolution Matrix (Prewitt)",
            "Tugas 6b - Convolution Matrix (Sobel)",
            "Tugas 6c - Convolution Matrix (FreiChen)",
            "Tugas 6d - Convolution Matrix (Robert)",
            "Tugas 6e - Convolution Matrix (Kayyali)",
            "",
            "--- Lain-lain ---",
            "Clear",
            "Grayscale",
            "Invert"});
            this.combo_img2.Location = new System.Drawing.Point(469, 97);
            this.combo_img2.Name = "combo_img2";
            this.combo_img2.Size = new System.Drawing.Size(265, 21);
            this.combo_img2.TabIndex = 9;
            // 
            // btn_act_2
            // 
            this.btn_act_2.Location = new System.Drawing.Point(740, 97);
            this.btn_act_2.Name = "btn_act_2";
            this.btn_act_2.Size = new System.Drawing.Size(77, 21);
            this.btn_act_2.TabIndex = 8;
            this.btn_act_2.Text = "Execute";
            this.btn_act_2.UseVisualStyleBackColor = true;
            this.btn_act_2.Click += new System.EventHandler(this.btn_act_2_Click);
            // 
            // combo_img1
            // 
            this.combo_img1.FormattingEnabled = true;
            this.combo_img1.Items.AddRange(new object[] {
            "--- Pilih ---",
            "Tugas 1 - Bikin Cerah",
            "Tugas 2 - Bikin Cerah 2",
            "Tugas 3 - Sharpen",
            "Tugas 4 - Rekognisi",
            "Tugas 5a - Difference 4",
            "Tugas 5b - Difference 2",
            "Tugas 6a - Convolution Matrix (Prewitt)",
            "Tugas 6b - Convolution Matrix (Sobel)",
            "Tugas 6c - Convolution Matrix (FreiChen)",
            "Tugas 6d - Convolution Matrix (Robert)",
            "Tugas 6e - Convolution Matrix (Kayyali)",
            "",
            "--- Lain-lain ---",
            "Clear",
            "Grayscale",
            "Invert"});
            this.combo_img1.Location = new System.Drawing.Point(6, 97);
            this.combo_img1.Name = "combo_img1";
            this.combo_img1.Size = new System.Drawing.Size(265, 21);
            this.combo_img1.TabIndex = 7;
            // 
            // btn_act_1
            // 
            this.btn_act_1.Location = new System.Drawing.Point(277, 97);
            this.btn_act_1.Name = "btn_act_1";
            this.btn_act_1.Size = new System.Drawing.Size(77, 21);
            this.btn_act_1.TabIndex = 6;
            this.btn_act_1.Text = "Execute";
            this.btn_act_1.UseVisualStyleBackColor = true;
            this.btn_act_1.Click += new System.EventHandler(this.btn_act_1_Click);
            // 
            // btn_input_file
            // 
            this.btn_input_file.Location = new System.Drawing.Point(6, 32);
            this.btn_input_file.Name = "btn_input_file";
            this.btn_input_file.Size = new System.Drawing.Size(460, 59);
            this.btn_input_file.TabIndex = 4;
            this.btn_input_file.Text = "Load Gambar";
            this.btn_input_file.UseVisualStyleBackColor = true;
            this.btn_input_file.Click += new System.EventHandler(this.btn_input_file_Click);
            // 
            // tb_input_file
            // 
            this.tb_input_file.Location = new System.Drawing.Point(6, 6);
            this.tb_input_file.Name = "tb_input_file";
            this.tb_input_file.Size = new System.Drawing.Size(460, 20);
            this.tb_input_file.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(469, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(460, 318);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 318);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Lain
            // 
            this.Lain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lain.Location = new System.Drawing.Point(4, 22);
            this.Lain.Name = "Lain";
            this.Lain.Padding = new System.Windows.Forms.Padding(3);
            this.Lain.Size = new System.Drawing.Size(935, 448);
            this.Lain.TabIndex = 1;
            this.Lain.Text = "Lain-lain";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 498);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Pengolahan Citra";
            this.tabControl1.ResumeLayout(false);
            this.Tugas.ResumeLayout(false);
            this.Tugas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Tugas;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_input_file;
        private System.Windows.Forms.TextBox tb_input_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_act_1;
        private System.Windows.Forms.ComboBox combo_img1;
        private System.Windows.Forms.ComboBox combo_img2;
        private System.Windows.Forms.Button btn_act_2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Button btn_histogram_1;
        private System.Windows.Forms.Button btn_histogram_2;
        private System.Windows.Forms.TabPage Lain;
        private System.Windows.Forms.Button btn_clear_2;
        private System.Windows.Forms.Button btn_clear_1;



    }
}

