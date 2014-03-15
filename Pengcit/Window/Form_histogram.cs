using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Pustaka;

namespace WindowsFormsApplication1
{
    public partial class Form_histogram : Form
    {
        private XHistogram his;
        private Bitmap graph_his_white;

        public Form_histogram(String _title, Bitmap _g) {
            his = new XHistogram(_g);
            InitializeComponent();
            this.Icon = Properties.Resources.Rubik_Cube_Mixed;
            this.Text = _title;
            graph_his_white = new Bitmap(256, 256);
            for (int i = 0; i < graph_his_white.Width; i++) {
                for (int j = 0; j < graph_his_white.Height; j++) {
                    graph_his_white.SetPixel(i, j, Color.White);
                }
            }
        }

        private void Form_histogram_Load(object sender, EventArgs e) {
            Bitmap graph_his_r = XImage.copy(graph_his_white);
            Bitmap graph_his_g = XImage.copy(graph_his_white);
            Bitmap graph_his_b = XImage.copy(graph_his_white);
            Bitmap graph_his2_r = XImage.copy(graph_his_white);
            Bitmap graph_his2_g = XImage.copy(graph_his_white);
            Bitmap graph_his2_b = XImage.copy(graph_his_white);
            his.scaleHistogram(255);
            for (int i = 0; i < 256; i++) {
                colorHistogramGraph(graph_his_r, i, his.data[0][i], Color.Red);
                colorHistogramGraph(graph_his_g, i, his.data[1][i], Color.Green);
                colorHistogramGraph(graph_his_b, i, his.data[2][i], Color.Blue);
                colorHistogramGraph(graph_his2_r, i, his.data2[0][i], Color.Red);
                colorHistogramGraph(graph_his2_g, i, his.data2[1][i], Color.Green);
                colorHistogramGraph(graph_his2_b, i, his.data2[2][i], Color.Blue);
            }
            grafik_his_r.Image = graph_his_r;
            grafik_his_g.Image = graph_his_g;
            grafik_his_b.Image = graph_his_b;
            grafik_his2_r.Image = graph_his2_r;
            grafik_his2_g.Image = graph_his2_g;
            grafik_his2_b.Image = graph_his2_b;
        }

        private void colorHistogramGraph(Bitmap _b, int x, int y, Color _c) {
            for (int i=0; i<y; i++) _b.SetPixel(x, 255-i, _c);
        }
    }
}
