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
using System.Diagnostics;

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
            Bitmap timage = XImage.toGrayscale(image);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toInverted(image);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toContrast1(image);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.sharpen(image, 3);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void resetImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.copy(image_ori);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void differenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.edgeDiff2(timage);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void differenceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.edgeDiff4(timage);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeOne(timage, 0);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeOne(timage, 1);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void freiChenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeOne(timage, 2);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void robertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeOne(timage, 3);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void kayyaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeOne(timage, 4);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
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
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeTwo(timage, 0);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void robinsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeTwo(timage, 1);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void kirschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.processDegreeTwo(timage, 2);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void classifyAsAlphabetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XRecognizer r = new XRecognizer(Color.FromArgb(0, 0, 0), image);
            r.classifyAsAlphabet();

            String message = "";
            message += ("Jumlah Bangun = " + r.codes.Count + "\n\n");
            foreach (var label_classified in r.labels_classified.Select((x, i) => new { val = x, idx = i }))
            {
                message += ("Bangun #" + label_classified.idx + " dikenali sebagai \"" + label_classified.val + "\"\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes)
            {
                message += ("Chaincode #" + r.codes.IndexOf(code) + " = " + code + "\n");
            }
            message += "======================================================\n\n";
            foreach (String code in r.codes_delta)
            {
                message += ("Chaincode_delta #" + r.codes_delta.IndexOf(code) + " = " + code + "\n");
            }
            message += "======================================================\n\n";
            foreach (double[] freq in r.freqs_code_delta)
            {
                message += ("Chaincode_delta #" + r.freqs_code_delta.IndexOf(freq) + " = \n\n");
                for (int i = 0; i < freq.Length; i++)
                    message += ("" + i + " = " + freq[i] + "\n");
                message += "\n";
            }
            message += "======================================================\n\n";
            
            Form_image fimage = new Form_image(this.filepath, r.gambaredited);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
            Form_chaincode fcc = new Form_chaincode("Chaincode " + this.filename, message);
            fcc.MdiParent = this.MdiParent;
            fcc.Show();
        }

        private void classifyAsNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XRecognizer r = new XRecognizer(Color.FromArgb(0,0,0), image);
            r.classifyAsNumber();

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
            
            Form_image fimage = new Form_image(this.filepath, r.gambaredited);
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

            Form_image fimage = new Form_image(this.filepath, r.gambaredited);
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
            Bitmap timage = XImage.toGrayscale(image);
            timage = XImage.toBinary(timage, 96);
            timage = XSkeletonizer.zhangsuen(timage);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }

        private void gradationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap timage = XImage.toGrayscale(image);
            Form_image fimage = new Form_image(this.filepath, timage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
            Bitmap dimage = XImage.grad(timage);
            Form_image fdimage = new Form_image(this.filepath, dimage);
            fdimage.MdiParent = this.MdiParent;
            fdimage.Show();
            Bitmap d2image = XImage.grad2(dimage);
            Form_image fd2image = new Form_image(this.filepath, d2image);
            fd2image.MdiParent = this.MdiParent;
            fd2image.Show();
        }

        private void rectangleMorphingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap mimage = XImage.RectangleMorph(image);
            Form_image fimage = new Form_image(this.filepath, mimage);
            fimage.MdiParent = this.MdiParent;
            fimage.Show();
        }
    }
}
