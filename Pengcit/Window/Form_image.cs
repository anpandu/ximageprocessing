﻿using System;
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
            image = XImage.processOneDegree(image, 0);
            imageBox.Image = image;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processOneDegree(image, 1);
            imageBox.Image = image;
        }

        private void freiChenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processOneDegree(image, 2);
            imageBox.Image = image;
        }

        private void robertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processOneDegree(image, 3);
            imageBox.Image = image;
        }

        private void kayyaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = XImage.toGrayscale(image);
            image = XImage.processOneDegree(image, 4);
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
        {
            XRecognizer r = new XRecognizer(Color.FromArgb(0,0,0), image);
            r.proses();
            image = r.gambaredited;
            String message = "Tugas 4 Pengolahan Citra\n";
            message += ("jumlah bangun = "+r.codes.Count+"\n");
            foreach (String code in r.codes) {
                message += ("Stringcode "+r.codes.IndexOf(code)+" = "+code+"\n");
            }
            imageBox.Image = image;
        }
    }
}