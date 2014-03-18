using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.Pustaka;

namespace WindowsFormsApplication1 {
    public partial class Form_Old : Form {

        private Bitmap gambar_ori;
        private Bitmap gambar_1;
        private Bitmap gambar_2;
        private Form_histogram fh1;
        private Form_histogram fh2;
        private int order;

        public Form_Old() {
            InitializeComponent();
            this.Icon = Properties.Resources.Rubik_Cube_Mixed;
            order = 0;
            combo_img1.SelectedIndex = 0;
            combo_img2.SelectedIndex = 0;
        }

        private void add_log_text(String _s) {
            rtb_log.Text = "[" + (++order) + "] - " + _s + "\n" + rtb_log.Text;
        }

        private void proses_gambar(Bitmap _g, String _opt, PictureBox _pb) {
            if (gambar_ori != null) {
                if (_opt.Equals("Tugas 1 - Bikin Cerah")) {
                    _g = XImage.toContrast1(_g);
                    add_log_text("Tugas 1 Pengolahan Citra");
                } else if (_opt.Equals("Tugas 2 - Bikin Cerah 2")) {
                    _g = XImage.toContrast2(_g);
                    add_log_text("Tugas 2 Pengolahan Citra");
                } else if (_opt.Equals("Tugas 3 - Sharpen")) {
                    _g = XImage.sharpen(_g,5);
                    add_log_text("Tugas 3 Pengolahan Citra");
                } else if (_opt.Equals("Tugas 4 - Rekognisi")) {
                    XRecognizer r = new XRecognizer(Color.FromArgb(0,0,0), _g);
                    r.classify();
                    _g = r.gambaredited;
                    String message = "Tugas 4 Pengolahan Citra\n";
                    message += ("jumlah bangun = "+r.codes.Count+"\n");
                    foreach (String code in r.codes) {
                       message += ("Stringcode "+r.codes.IndexOf(code)+" = "+code+"\n");
                    }
                    add_log_text(message);
                } else if (_opt.Equals("Tugas 5a - Difference 4")) {
                    _g = XImage.edgeDiff4(_g );
                    add_log_text("Tugas 5a - Difference 4");
                } else if (_opt.Equals("Tugas 5b - Difference 2")) {
                    _g = XImage.edgeDiff2(_g );
                    add_log_text("Tugas 5b - Difference 2");
                } else if (_opt.Equals("Tugas 6a - Convolution Matrix (Prewitt)")) {
                    _g = XImage.toGrayscale(_g);
                    _g = XImage.processDegreeOne(_g, 0);
                    add_log_text("Tugas 6a - Convolution Matrix (Prewitt)");
                } else if (_opt.Equals("Tugas 6b - Convolution Matrix (Sobel)")) {
                    _g = XImage.toGrayscale(_g);
                    _g = XImage.processDegreeOne(_g, 1);
                    add_log_text("Tugas 6b - Convolution Matrix (Sobel)");
                } else if (_opt.Equals("Tugas 6c - Convolution Matrix (FreiChen)")) {
                    _g = XImage.toGrayscale(_g);
                    _g = XImage.processDegreeOne(_g, 2);
                    add_log_text("Tugas 6c - Convolution Matrix (FreiChen)");
                } else if (_opt.Equals("Tugas 6d - Convolution Matrix (Robert)")) {
                    _g = XImage.toGrayscale(_g);
                    _g = XImage.processDegreeOne(_g, 3);
                    add_log_text("Tugas 6d - Convolution Matrix (Robert)");
                } else if (_opt.Equals("Tugas 6e - Convolution Matrix (Kayyali)")) {
                    _g = XImage.toGrayscale(_g);
                    _g = XImage.processDegreeOne(_g, 4);
                    add_log_text("Tugas 6e - Convolution Matrix (Kayyali)");
                } else if (_opt.Equals("Clear")) {
                    _g = XImage.copy(gambar_ori);
                    add_log_text("Back to Original");
                } else if (_opt.Equals("Grayscale")) {
                    _g = XImage.toGrayscale(_g);
                    add_log_text("Grayscale");
                } else if (_opt.Equals("Invert")) {
                    _g = XImage.toInverted(_g );
                    add_log_text("Invert");
                } else {

                }
                _pb.Image = _g;
                _pb.Image = XImage.toBinary(_g, 128);
            }
        }

        private void btn_input_file_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                tb_input_file.Text = openFileDialog1.FileName;
            }
            try {
                gambar_ori = new Bitmap(openFileDialog1.FileName);
                gambar_1 = new Bitmap(openFileDialog1.FileName);
                gambar_2 = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = gambar_1;
                pictureBox2.Image = gambar_2;
                add_log_text("Load file : " + tb_input_file.Text);
            }
            catch (Exception) {
                MessageBox.Show("Canceled or Failed loading image");
                //throw new ApplicationException("Failed loading image");
            }
        }
        private void btn_act_1_Click(object sender, EventArgs e) {
            proses_gambar(gambar_1, combo_img1.Text, pictureBox1);
            gambar_1 = (Bitmap)pictureBox1.Image;
        }
        private void btn_act_2_Click(object sender, EventArgs e) {
            proses_gambar(gambar_2, combo_img2.Text, pictureBox2);
            gambar_2 = (Bitmap)pictureBox2.Image;
        }
        private void btn_histogram_1_Click(object sender, EventArgs e) {
            if (gambar_ori != null) {
                fh1 = new Form_histogram("Histogram Gambar 1", gambar_1);
                fh1.Show();
            }
        }
        private void btn_histogram_2_Click(object sender, EventArgs e) {
            if (gambar_ori != null) {
                fh2 = new Form_histogram("Histogram Gambar 2", gambar_2);
                fh2.Show();
            }
        }

        private void btn_clear_1_Click(object sender, EventArgs e) {
            proses_gambar(gambar_1, "Clear", pictureBox1);
            gambar_1 = (Bitmap)pictureBox1.Image;
        }

        private void btn_clear_2_Click(object sender, EventArgs e) {
            proses_gambar(gambar_2, "Clear", pictureBox2);
            gambar_2 = (Bitmap)pictureBox2.Image;
        }
    }
}
