namespace WindowsFormsApplication1.Window
{
    partial class Form_image
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.preprocessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.convMatrix1stDegreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freiChenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kayyaliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convMatrix2ndDegreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.robinsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kirschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skeletonizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chainCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classifyAsNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classifyAsShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.zhangSuenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preprocessToolStripMenuItem,
            this.recognitionToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // preprocessToolStripMenuItem
            // 
            this.preprocessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.resetImageToolStripMenuItem});
            this.preprocessToolStripMenuItem.Name = "preprocessToolStripMenuItem";
            this.preprocessToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.preprocessToolStripMenuItem.Text = "Preprocess";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(139, 6);
            // 
            // resetImageToolStripMenuItem
            // 
            this.resetImageToolStripMenuItem.Name = "resetImageToolStripMenuItem";
            this.resetImageToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.resetImageToolStripMenuItem.Text = "Reset Image";
            this.resetImageToolStripMenuItem.Click += new System.EventHandler(this.resetImageToolStripMenuItem_Click);
            // 
            // recognitionToolStripMenuItem
            // 
            this.recognitionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeDetectionToolStripMenuItem,
            this.skeletonizerToolStripMenuItem,
            this.chainCodeToolStripMenuItem});
            this.recognitionToolStripMenuItem.Name = "recognitionToolStripMenuItem";
            this.recognitionToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.recognitionToolStripMenuItem.Text = "Recognition";
            // 
            // edgeDetectionToolStripMenuItem
            // 
            this.edgeDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.differenceToolStripMenuItem,
            this.convMatrix1stDegreeToolStripMenuItem,
            this.convMatrix2ndDegreeToolStripMenuItem});
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.edgeDetectionToolStripMenuItem.Text = "Edge Detection";
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.differenceToolStripMenuItem1,
            this.differenceToolStripMenuItem2});
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.differenceToolStripMenuItem.Text = "Difference";
            // 
            // differenceToolStripMenuItem1
            // 
            this.differenceToolStripMenuItem1.Name = "differenceToolStripMenuItem1";
            this.differenceToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.differenceToolStripMenuItem1.Text = "2-Difference";
            this.differenceToolStripMenuItem1.Click += new System.EventHandler(this.differenceToolStripMenuItem1_Click);
            // 
            // differenceToolStripMenuItem2
            // 
            this.differenceToolStripMenuItem2.Name = "differenceToolStripMenuItem2";
            this.differenceToolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
            this.differenceToolStripMenuItem2.Text = "4-Difference";
            this.differenceToolStripMenuItem2.Click += new System.EventHandler(this.differenceToolStripMenuItem2_Click);
            // 
            // convMatrix1stDegreeToolStripMenuItem
            // 
            this.convMatrix1stDegreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prewittToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.freiChenToolStripMenuItem,
            this.robertToolStripMenuItem,
            this.kayyaliToolStripMenuItem});
            this.convMatrix1stDegreeToolStripMenuItem.Name = "convMatrix1stDegreeToolStripMenuItem";
            this.convMatrix1stDegreeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.convMatrix1stDegreeToolStripMenuItem.Text = "Conv. Matrix 1st Degree";
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.prewittToolStripMenuItem.Text = "Prewitt";
            this.prewittToolStripMenuItem.Click += new System.EventHandler(this.prewittToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // freiChenToolStripMenuItem
            // 
            this.freiChenToolStripMenuItem.Name = "freiChenToolStripMenuItem";
            this.freiChenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.freiChenToolStripMenuItem.Text = "Frei Chen";
            this.freiChenToolStripMenuItem.Click += new System.EventHandler(this.freiChenToolStripMenuItem_Click);
            // 
            // robertToolStripMenuItem
            // 
            this.robertToolStripMenuItem.Name = "robertToolStripMenuItem";
            this.robertToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.robertToolStripMenuItem.Text = "Robert";
            this.robertToolStripMenuItem.Click += new System.EventHandler(this.robertToolStripMenuItem_Click);
            // 
            // kayyaliToolStripMenuItem
            // 
            this.kayyaliToolStripMenuItem.Name = "kayyaliToolStripMenuItem";
            this.kayyaliToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.kayyaliToolStripMenuItem.Text = "Kayyali";
            this.kayyaliToolStripMenuItem.Click += new System.EventHandler(this.kayyaliToolStripMenuItem_Click);
            // 
            // convMatrix2ndDegreeToolStripMenuItem
            // 
            this.convMatrix2ndDegreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prewittToolStripMenuItem1,
            this.robinsonToolStripMenuItem,
            this.kirschToolStripMenuItem});
            this.convMatrix2ndDegreeToolStripMenuItem.Name = "convMatrix2ndDegreeToolStripMenuItem";
            this.convMatrix2ndDegreeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.convMatrix2ndDegreeToolStripMenuItem.Text = "Conv. Matrix 2nd Degree";
            // 
            // prewittToolStripMenuItem1
            // 
            this.prewittToolStripMenuItem1.Name = "prewittToolStripMenuItem1";
            this.prewittToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.prewittToolStripMenuItem1.Text = "Prewitt";
            this.prewittToolStripMenuItem1.Click += new System.EventHandler(this.prewittToolStripMenuItem1_Click);
            // 
            // robinsonToolStripMenuItem
            // 
            this.robinsonToolStripMenuItem.Name = "robinsonToolStripMenuItem";
            this.robinsonToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.robinsonToolStripMenuItem.Text = "Robinson";
            this.robinsonToolStripMenuItem.Click += new System.EventHandler(this.robinsonToolStripMenuItem_Click);
            // 
            // kirschToolStripMenuItem
            // 
            this.kirschToolStripMenuItem.Name = "kirschToolStripMenuItem";
            this.kirschToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.kirschToolStripMenuItem.Text = "Kirsch";
            this.kirschToolStripMenuItem.Click += new System.EventHandler(this.kirschToolStripMenuItem_Click);
            // 
            // skeletonizerToolStripMenuItem
            // 
            this.skeletonizerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zhangSuenToolStripMenuItem});
            this.skeletonizerToolStripMenuItem.Name = "skeletonizerToolStripMenuItem";
            this.skeletonizerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.skeletonizerToolStripMenuItem.Text = "Skeletonizer";
            // 
            // chainCodeToolStripMenuItem
            // 
            this.chainCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classifyAsNumberToolStripMenuItem,
            this.classifyAsShapeToolStripMenuItem});
            this.chainCodeToolStripMenuItem.Name = "chainCodeToolStripMenuItem";
            this.chainCodeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.chainCodeToolStripMenuItem.Text = "Chain Code";
            this.chainCodeToolStripMenuItem.Click += new System.EventHandler(this.chainCodeToolStripMenuItem_Click);
            // 
            // classifyAsNumberToolStripMenuItem
            // 
            this.classifyAsNumberToolStripMenuItem.Name = "classifyAsNumberToolStripMenuItem";
            this.classifyAsNumberToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.classifyAsNumberToolStripMenuItem.Text = "Classify As Number";
            this.classifyAsNumberToolStripMenuItem.Click += new System.EventHandler(this.classifyAsNumberToolStripMenuItem_Click);
            // 
            // classifyAsShapeToolStripMenuItem
            // 
            this.classifyAsShapeToolStripMenuItem.Name = "classifyAsShapeToolStripMenuItem";
            this.classifyAsShapeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.classifyAsShapeToolStripMenuItem.Text = "Classify As Shape";
            this.classifyAsShapeToolStripMenuItem.Click += new System.EventHandler(this.classifyAsShapeToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHistogramToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // showHistogramToolStripMenuItem
            // 
            this.showHistogramToolStripMenuItem.Name = "showHistogramToolStripMenuItem";
            this.showHistogramToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showHistogramToolStripMenuItem.Text = "Show Histogram";
            this.showHistogramToolStripMenuItem.Click += new System.EventHandler(this.showHistogramToolStripMenuItem_Click);
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(0, 3);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(500, 500);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBox.TabIndex = 1;
            this.imageBox.TabStop = false;
            // 
            // zhangSuenToolStripMenuItem
            // 
            this.zhangSuenToolStripMenuItem.Name = "zhangSuenToolStripMenuItem";
            this.zhangSuenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zhangSuenToolStripMenuItem.Text = "Zhang-Suen";
            this.zhangSuenToolStripMenuItem.Click += new System.EventHandler(this.zhangSuenToolStripMenuItem_Click);
            // 
            // Form_image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 503);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_image";
            this.ShowInTaskbar = false;
            this.Text = "Form_image";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem preprocessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recognitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem convMatrix1stDegreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convMatrix2ndDegreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chainCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHistogramToolStripMenuItem;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freiChenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem resetImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kayyaliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem robinsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kirschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classifyAsNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classifyAsShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skeletonizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zhangSuenToolStripMenuItem;

    }
}