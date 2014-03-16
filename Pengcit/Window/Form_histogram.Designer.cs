namespace WindowsFormsApplication1
{
    partial class Form_histogram
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
            this.grafik_his_r = new System.Windows.Forms.PictureBox();
            this.grafik_his_g = new System.Windows.Forms.PictureBox();
            this.grafik_his_b = new System.Windows.Forms.PictureBox();
            this.grafik_his2_b = new System.Windows.Forms.PictureBox();
            this.grafik_his2_g = new System.Windows.Forms.PictureBox();
            this.grafik_his2_r = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his2_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his2_g)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his2_r)).BeginInit();
            this.SuspendLayout();
            // 
            // grafik_his_r
            // 
            this.grafik_his_r.Location = new System.Drawing.Point(12, 12);
            this.grafik_his_r.Name = "grafik_his_r";
            this.grafik_his_r.Size = new System.Drawing.Size(256, 256);
            this.grafik_his_r.TabIndex = 1;
            this.grafik_his_r.TabStop = false;
            // 
            // grafik_his_g
            // 
            this.grafik_his_g.Location = new System.Drawing.Point(274, 12);
            this.grafik_his_g.Name = "grafik_his_g";
            this.grafik_his_g.Size = new System.Drawing.Size(256, 256);
            this.grafik_his_g.TabIndex = 2;
            this.grafik_his_g.TabStop = false;
            // 
            // grafik_his_b
            // 
            this.grafik_his_b.Location = new System.Drawing.Point(536, 12);
            this.grafik_his_b.Name = "grafik_his_b";
            this.grafik_his_b.Size = new System.Drawing.Size(256, 256);
            this.grafik_his_b.TabIndex = 3;
            this.grafik_his_b.TabStop = false;
            // 
            // grafik_his2_b
            // 
            this.grafik_his2_b.Location = new System.Drawing.Point(536, 274);
            this.grafik_his2_b.Name = "grafik_his2_b";
            this.grafik_his2_b.Size = new System.Drawing.Size(256, 256);
            this.grafik_his2_b.TabIndex = 6;
            this.grafik_his2_b.TabStop = false;
            // 
            // grafik_his2_g
            // 
            this.grafik_his2_g.Location = new System.Drawing.Point(274, 274);
            this.grafik_his2_g.Name = "grafik_his2_g";
            this.grafik_his2_g.Size = new System.Drawing.Size(256, 256);
            this.grafik_his2_g.TabIndex = 5;
            this.grafik_his2_g.TabStop = false;
            // 
            // grafik_his2_r
            // 
            this.grafik_his2_r.Location = new System.Drawing.Point(12, 274);
            this.grafik_his2_r.Name = "grafik_his2_r";
            this.grafik_his2_r.Size = new System.Drawing.Size(256, 256);
            this.grafik_his2_r.TabIndex = 4;
            this.grafik_his2_r.TabStop = false;
            // 
            // Form_histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 538);
            this.Controls.Add(this.grafik_his2_b);
            this.Controls.Add(this.grafik_his2_g);
            this.Controls.Add(this.grafik_his2_r);
            this.Controls.Add(this.grafik_his_b);
            this.Controls.Add(this.grafik_his_g);
            this.Controls.Add(this.grafik_his_r);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_histogram";
            this.Text = "Histogram";
            this.Load += new System.EventHandler(this.Form_histogram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his2_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his2_g)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafik_his2_r)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox grafik_his_r;
        private System.Windows.Forms.PictureBox grafik_his_g;
        private System.Windows.Forms.PictureBox grafik_his_b;
        private System.Windows.Forms.PictureBox grafik_his2_b;
        private System.Windows.Forms.PictureBox grafik_his2_g;
        private System.Windows.Forms.PictureBox grafik_his2_r;
    }
}