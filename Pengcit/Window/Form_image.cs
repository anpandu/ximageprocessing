using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Pustaka;

namespace WindowsFormsApplication1.Window
{
    public partial class Form_image : Form
    {
        private String filepath;
        private String filename;
        private Bitmap image_ori;
        private Bitmap image;

        public Form_image(string _filepath)
        {
            InitializeComponent();
            filepath = _filepath;
            filename = Path.GetFileNameWithoutExtension(filepath);
            image_ori = new Bitmap(filepath);
            image = new Bitmap(filepath);
            imageBox.Image = image;
            this.Text = filename;
            this.Width = imageBox.Width + 6;
            this.Height = imageBox.Height + 28;
        }

        public Form_image(string _filepath, Bitmap _image)
        {
            InitializeComponent();
            filepath = _filepath;
            filename = Path.GetFileNameWithoutExtension(filepath);
            image_ori = XImage.copy(_image);
            image = XImage.copy(_image);
            imageBox.Image = image;
            this.Text = filename;
            this.Width = imageBox.Width + 6;
            this.Height = imageBox.Height + 28;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            imageBox.Image = image;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toInverted(image);
            imageBox.Image = image;
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toContrast1(image);
            imageBox.Image = image;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.sharpen(image, 3);
            imageBox.Image = image;
        }

        private void resetImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.copy(image_ori);
            imageBox.Image = image;
        }

        private void differenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.edgeDiff2(image_ori);
            imageBox.Image = image;
        }

        private void differenceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.edgeDiff4(image_ori);
            imageBox.Image = image;
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeOne(image, 0);
            imageBox.Image = image;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeOne(image, 1);
            imageBox.Image = image;
        }

        private void freiChenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeOne(image, 2);
            imageBox.Image = image;
        }

        private void robertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeOne(image, 3);
            imageBox.Image = image;
        }

        private void kayyaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeOne(image, 4);
            imageBox.Image = image;
        }

        private void showHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null) {
                Form_histogram fh = new Form_histogram("Histogram "+this.filename, image);
                fh.MdiParent = this.MdiParent;
                fh.Show();
            }
        }

        private void chainCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {   /*
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            XRecognizer r = new XRecognizer(Color.FromArgb(0,0,0), image);
            r.classifyAsNumber();
            image = r.gambaredited;

            String message = "";
            message += ("Jumlah Bangun = "+r.codes.Count+"\n\n");
            foreach (var label_classified in r.labels_classified.Select((x,i) => new { val = x, idx =i })) {
                message += ("Bangun #" + label_classified.idx + " dikenali sebagai \"" + label_classified.val + "\"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes) {
                message += ("Chaincode #"+r.codes.IndexOf(code)+" = "+code+"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes_delta) {
                message += ("Chaincode_delta #" + r.codes_delta.IndexOf(code) + " = " + code + "\n");
            }
            message += "======================================================\n\n";
            foreach (double[] freq in r.freqs_code_delta) {
                message += ("Chaincode_delta #" + r.freqs_code_delta.IndexOf(freq) + " = \n\n");
                for (int i=0; i<freq.Length; i++)
                    message += ("" + i + " = " + freq[i] + "\n");
                message += "\n";
            }
            message += "======================================================\n\n";
            foreach (double[] freq in r.freqs_code_delta) {
                for (int i=0; i<freq.Length; i++)
                    message += ("" + freq[i].ToString() + ",");
                //message += r.freqs_code_delta.IndexOf(freq) + "\n";
                message += "\n";
            }
            /**/
            //imageBox.Image = image;
            /*
            Form_image fimage = new Form_image(this.filepath, image);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
            Form_chaincode fcc = new Form_chaincode("Chaincode " + this.filename, message);
            fcc.MdiParent = this.MdiParent;
            fcc.Show();/**/
        }

        private void prewittToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeTwo(image, 0);
            imageBox.Image = image;
        }

        private void robinsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeTwo(image, 1);
            imageBox.Image = image;
        }

        private void kirschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processDegreeTwo(image, 2);
            imageBox.Image = image;
        }

        private void classifyAsNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XRecognizer r = new XRecognizer(Color.FromArgb(0,0,0), image);
            r.classifyAsNumber();
            image = r.gambaredited;

            String message = "";
            message += ("Jumlah Bangun = "+r.codes.Count+"\n\n");
            foreach (var label_classified in r.labels_classified.Select((x,i) => new { val = x, idx =i })) {
                message += ("Bangun #" + label_classified.idx + " dikenali sebagai \"" + label_classified.val + "\"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes) {
                message += ("Chaincode #"+r.codes.IndexOf(code)+" = "+code+"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes_delta) {
                message += ("Chaincode_delta #" + r.codes_delta.IndexOf(code) + " = " + code + "\n");
            }
            message += "======================================================\n\n";
            foreach (double[] freq in r.freqs_code_delta) {
                message += ("Chaincode_delta #" + r.freqs_code_delta.IndexOf(freq) + " = \n\n");
                for (int i=0; i<freq.Length; i++)
                    message += ("" + i + " = " + freq[i] + "\n");
                message += "\n";
            }
            message += "======================================================\n\n";

            Form_image fimage = new Form_image(this.filepath, image);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
            Form_chaincode fcc = new Form_chaincode("Chaincode " + this.filename, message);
            fcc.MdiParent = this.MdiParent;
            fcc.Show();
        }

        private void classifyAsShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XRecognizer r = new XRecognizer(Color.FromArgb(0,0,0), image);
            r.classifyAsGeometryShape();
            image = r.gambaredited;

            String message = "";
            message += ("Jumlah Bangun = "+r.codes.Count+"\n\n");
            foreach (var label_classified in r.labels_classified.Select((x,i) => new { val = x, idx =i })) {
                message += ("Bangun #" + label_classified.idx + " dikenali sebagai \"" + label_classified.val + "\"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes) {
                message += ("Chaincode #"+r.codes.IndexOf(code)+" = "+code+"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes_delta) {
                message += ("Chaincode_delta #" + r.codes_delta.IndexOf(code) + " = " + code + "\n");
            }
            message += "======================================================\n\n";
            foreach (double[] freq in r.freqs_code_delta) {
                message += ("Chaincode_delta #" + r.freqs_code_delta.IndexOf(freq) + " = \n\n");
                for (int i=0; i<freq.Length; i++)
                    message += ("" + i + " = " + freq[i] + "\n");
                message += "\n";
            }
            message += "======================================================\n\n";

            Form_image fimage = new Form_image(this.filepath, image);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
            Form_chaincode fcc = new Form_chaincode("Chaincode " + this.filename, message);
            fcc.MdiParent = this.MdiParent;
            fcc.Show();
        }

        private void tesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void zhangSuenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //image = XImage.toGrayscale(image);
            //image = XImage.toBinary(image, 96);
            image = XSkeletonizer.zhangsuen(image);
            Form_image fimage = new Form_image(this.filepath, image);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }
    }
}
