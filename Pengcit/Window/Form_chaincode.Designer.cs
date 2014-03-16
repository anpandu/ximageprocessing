namespace WindowsFormsApplication1.Window
{
    partial class Form_chaincode
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
            this.cc_textbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cc_textbox
            // 
            this.cc_textbox.Location = new System.Drawing.Point(12, 12);
            this.cc_textbox.Name = "cc_textbox";
            this.cc_textbox.Size = new System.Drawing.Size(490, 251);
            this.cc_textbox.TabIndex = 0;
            this.cc_textbox.Text = "";
            // 
            // Form_chaincode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 275);
            this.Controls.Add(this.cc_textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_chaincode";
            this.Text = "Chaincode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cc_textbox;
    }
}