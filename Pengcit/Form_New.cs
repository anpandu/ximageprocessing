using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Window;

namespace WindowsFormsApplication1
{
    public partial class Form_New : Form
    {
        public Form_New()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Form_New_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openImageDialog.ShowDialog() == DialogResult.OK) {
                
            }
            try {
                Form_image fimage = new Form_image(openImageDialog.FileName);
                fimage.MdiParent = this;
                fimage.Show();

                //gambar_ori = new Bitmap(openImageDialog.FileName);
                //add_log_text("Load file : " + tb_input_file.Text);
            }
            catch (Exception) {
                MessageBox.Show("Canceled or Failed loading image");
                //throw new ApplicationException("Failed loading image");
            }
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form chform in this.MdiChildren)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void restoreAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form chform in this.MdiChildren)
                chform.WindowState = FormWindowState.Normal;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form chform in this.MdiChildren)
                chform.Close();
        }
    }
}
