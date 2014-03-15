﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1.Pustaka
{
    class XImage {

        private static Dictionary<String, double[,]> mat1degree = new Dictionary<String, double[,]>()
        {
            { "prewitt", new double[3, 3] {{-1, 0, 1}, {-1, 0, 1}, {-1, 0, 1}}},
            { "sobel", new double[3, 3] {{-1, 0, 1}, {-2, 0, 2}, {-1, 0, 1}}},
            { "freichen", new double[3, 3] {{-1, 0, 1}, {-1.414, 0, 1.414}, {-1, 0, 1}}},
            { "robert", new double[3, 3] {{0, 0, -1}, {0, 1, 0}, {0, 0, 0}}},
            { "kayyali", new double[3, 3] {{6, 0, -6}, {0, 0, 0}, {-6, 0, 6}}}
        };

        public static Bitmap copy(Bitmap _b) {
            Bitmap temp = new Bitmap(_b);
            return temp;
        }
        
        public static Bitmap addFrame(Bitmap _b, Color _f) {
            Bitmap framedImage = new Bitmap(_b.Width+2, _b.Height+2);
            for (int i = 0; i < framedImage.Width; i++) {
                for (int j = 0; j < framedImage.Height; j++) {
                    framedImage.SetPixel(i, j, _f);
                }
            }
            for (int i = 0; i < _b.Width; i++) {
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = _b.GetPixel(i,j);
                    framedImage.SetPixel(i+1, j+1, ct);
                }
            }
            return framedImage;
        }

        public static Bitmap addMirroredFrame(Bitmap _b) {
            Bitmap framedImage = new Bitmap(_b.Width+2, _b.Height+2);
            for (int i = 0; i < framedImage.Width; i++) {
                for (int j = 0; j < framedImage.Height; j++) {
                    Color ct = Color.FromArgb(255, 255, 255);
                    framedImage.SetPixel(i, j, ct);
                    int ti = i;
                    int tj = j; 
                    if ((i==0)||(j==0)||(i>=framedImage.Width-2)||(j>=framedImage.Height-2)) {
                        if (ti==0)
                            ti=1;
                        if (tj==0)
                            tj=1;
                        if (ti>=framedImage.Width-2)
                            ti=framedImage.Width-4;
                        if (tj>=framedImage.Height-2)
                            tj=framedImage.Height-4;
                        ct = _b.GetPixel(ti, tj);
                        framedImage.SetPixel(i, j, ct);
                    }
                }
            }
            for (int i = 0; i < _b.Width; i++) {
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = _b.GetPixel(i,j);
                    framedImage.SetPixel(i+1, j+1, ct);
                }
            }
            return framedImage;
        }
        
        public static Bitmap edgeDiff4(Bitmap _b) { // inversi warna
            Bitmap result = copy(_b);
            Bitmap framedImage = addMirroredFrame(_b);
            for (int i = 1; i < framedImage.Width-1; i++) {
                for (int j = 1; j < framedImage.Height-1; j++) {
                    Color dc1 = XColor.differrence(framedImage.GetPixel(i,j-1), framedImage.GetPixel(i,j+1));
                    Color dc2 = XColor.differrence(framedImage.GetPixel(i+1,j-1), framedImage.GetPixel(i-1,j+1));
                    Color dc3 = XColor.differrence(framedImage.GetPixel(i+1,j), framedImage.GetPixel(i-1,j));
                    Color dc4 = XColor.differrence(framedImage.GetPixel(i+1,j+1), framedImage.GetPixel(i-1,j-1));
                    int maxdr = Math.Max(dc1.R, Math.Max(dc2.R, Math.Max(dc3.R, dc4.R)));
                    int maxdg = Math.Max(dc1.G, Math.Max(dc2.G, Math.Max(dc3.G, dc4.G)));
                    int maxdb = Math.Max(dc1.B, Math.Max(dc2.B, Math.Max(dc3.B, dc4.B)));
                    result.SetPixel(i-1, j-1, Color.FromArgb(maxdr, maxdr, maxdb));
                }
            }
            return result;
        }
        
        public static Bitmap edgeDiff2(Bitmap _b) { // inversi warna
            Bitmap result = copy(_b);
            Bitmap framedImage = addMirroredFrame(_b);
            for (int i = 1; i < framedImage.Width-1; i++) {
                for (int j = 1; j < framedImage.Height-1; j++) {
                    Color dc1 = XColor.differrence(framedImage.GetPixel(i,j-1), framedImage.GetPixel(i,j+1));
                    Color dc2 = XColor.differrence(framedImage.GetPixel(i+1,j), framedImage.GetPixel(i-1,j));
                    int maxdr = Math.Max(dc1.R, dc2.R);
                    int maxdg = Math.Max(dc1.G, dc2.G);
                    int maxdb = Math.Max(dc1.B, dc2.B);
                    result.SetPixel(i-1, j-1, Color.FromArgb(maxdr, maxdr, maxdb));
                }
            }
            return result;
        }

        public static Bitmap toGrayscale(Bitmap _b) { // jadikan abu-abu
            Bitmap temp = copy(_b);
            for (int i = 0; i < _b.Width; i++) {
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = XColor.toGrayscale(temp.GetPixel(i, j));
                    temp.SetPixel(i, j, ct);
                }
            }
            return temp;
        }

        public static Bitmap toInverted(Bitmap _b) { // inversi warna
            Bitmap temp = copy(_b);
            for (int i = 0; i < _b.Width; i++) {
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = XColor.toInverted(temp.GetPixel(i, j));
                    temp.SetPixel(i, j, ct);
                }
            }
            return temp;
        }
        
        public static Bitmap toBinary(Bitmap _b, int _thres) { // jadikan abu-abu
            Bitmap temp = copy(_b);
            for (int i = 0; i < _b.Width; i++) {
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = XColor.toBinary(temp.GetPixel(i, j), _thres);
                    temp.SetPixel(i, j, ct);
                }
            }
            return temp;
        }

        public static Bitmap sharpen(Bitmap _b, int _range) { // sharpen warna 3x3 pixel
            Bitmap temp = copy(_b);
            int range = _range;
            for (int i = 0; i < _b.Width; i++) {
                for (int j = 0; j < _b.Height; j++) {
                    int maxR = 0;
                    int maxG = 0;
                    int maxB = 0;
                    for (int ti=i-range/2; ti<(i+range/2); ti++) { // mulai proses pemilihan nilai pixel tertinggi, range: (i-r/2..i+r/2)
                        for (int tj=j-range/2; tj<(j+range/2); tj++) {
                            int tti = (ti%_b.Width<0) ? _b.Width+ti : ti%_b.Width;      // agar tidak keluar batas
                            int ttj = (tj%_b.Height<0) ? _b.Height+tj : tj%_b.Height;
                            Color colortemp = _b.GetPixel(tti,ttj);
                            maxR = (maxR < colortemp.R) ? colortemp.R : maxR;
                            maxG = (maxG < colortemp.G) ? colortemp.G : maxG;
                            maxB = (maxB < colortemp.B) ? colortemp.B : maxB;
                        }
                    }
                    Color ct = Color.FromArgb(maxR, maxG, maxB);
                    temp.SetPixel(i, j, ct);
                }
            }
            return temp;
        }

        public static Bitmap toContrast1(Bitmap _b) {
            Bitmap temp = copy(_b);
            int rmin = 255;
            int rmax = 0;
            int gmin = 255;
            int gmax = 0;
            int bmin = 255;
            int bmax = 0;
            for (int i = 0; i < _b.Width; i++) { // menentukan r g b max & min
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = temp.GetPixel(i, j);
                    rmin = (ct.R <= rmin) ? ct.R : rmin;
                    rmax = (ct.R >= rmax) ? ct.R : rmax;
                    gmin = (ct.G <= gmin) ? ct.G : gmin;
                    gmax = (ct.G >= gmax) ? ct.G : gmax;
                    bmin = (ct.B <= bmin) ? ct.B : bmin;
                    bmax = (ct.B >= bmax) ? ct.B : bmax;
                }
            }
            for (int i = 0; i < _b.Width; i++) { // edit gambar dgn transformasi linear
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = temp.GetPixel(i, j);
                    int dr = rmax-rmin;
                    int dg = gmax-gmin;
                    int db = bmax-bmin;
                    int rt = 255*(ct.R-rmin)/((dr==0) ? 1 : dr);
                    int gt = 255*(ct.G-gmin)/((dg==0) ? 1 : dg);
                    int bt = 255*(ct.B-bmin)/((db==0) ? 1 : db);
                    temp.SetPixel(i, j, Color.FromArgb(rt, gt, bt));
                }
            }
            return temp;
        }
        
        public static Bitmap toContrast2(Bitmap _b) {
            Bitmap temp = copy(_b);
            XHistogram his = new XHistogram(_b);
            his.scaleHistogram(255);
            int[][] LUT;  // look up table
            LUT = new int[3][];
            for (int i = 0; i < LUT.Length; i++) { // isi dengan 0
                LUT[i] = new int[256];
                for (int j = 0; j < LUT[i].Length; j++) {
                    LUT[i][j] = 0;
                }
            }
            int rmin = 255;
            int rmax = 0;
            int gmin = 255;
            int gmax = 0;
            int bmin = 255;
            int bmax = 0;
            for (int i = 0; i < his.data2[0].Length; i++) { // menentukan r g b max & min dari histo incremental
                rmin = (his.data2[0][i] <= rmin) ? his.data2[0][i] : rmin;
                rmax = (his.data2[0][i] >= rmax) ? his.data2[0][i] : rmax;
                gmin = (his.data2[1][i] <= gmin) ? his.data2[1][i] : gmin;
                gmax = (his.data2[1][i] >= gmax) ? his.data2[1][i] : gmax;
                bmin = (his.data2[2][i] <= bmin) ? his.data2[2][i] : bmin;
                bmax = (his.data2[2][i] >= bmax) ? his.data2[2][i] : bmax;
            }
            for (int j = 0; j < LUT[0].Length; j++) { // bikin LUT
                LUT[0][j] = 255 * (his.data2[0][j] - rmin) / (rmax - rmin);
                LUT[1][j] = 255 * (his.data2[1][j] - gmin) / (gmax - gmin);
                LUT[2][j] = 255 * (his.data2[2][j] - bmin) / (bmax - bmin);
            }
            for (int i = 0; i < _b.Width; i++) { // Apply LUT ke gambar
                for (int j = 0; j < _b.Height; j++) {
                    Color ct = temp.GetPixel(i, j);
                    int rt = LUT[0][ct.R];
                    int gt = LUT[1][ct.G];
                    int bt = LUT[2][ct.B];
                    temp.SetPixel(i, j, Color.FromArgb(rt, gt, bt));
                }
            }
            return temp;
        }

        public static Bitmap processOneDegree(Bitmap _b, int _mode)
        {
            Bitmap temp = addMirroredFrame(_b);
            Bitmap output = new Bitmap(_b.Width, _b.Height);

            double[,] convmatrix;
            switch (_mode) {
                case 0:
                    convmatrix = mat1degree["prewitt"];
                    break;
                case 1:
                    convmatrix = mat1degree["sobel"];
                    break;
                case 2:
                    convmatrix = mat1degree["freichen"];
                    break;
                case 3:
                    convmatrix = mat1degree["robert"];
                    break;
                case 4:
                    convmatrix = mat1degree["kayyali"];
                    break;
                default:
                    convmatrix = mat1degree["prewitt"];
                    break;
            }

            for (int i = 1; i < temp.Width - 1; i++)
            {              // iterasi
                for (int j = 1; j < temp.Height - 1; j++)
                {
                    double vertical = (double)temp.GetPixel(i - 1, j - 1).R * convmatrix[0, 0] +
                        (double)temp.GetPixel(i - 1, j).R * convmatrix[0, 1] +
                        (double)temp.GetPixel(i - 1, j + 1).R * convmatrix[0, 2] +
                        (double)temp.GetPixel(i, j - 1).R * convmatrix[1, 0] +
                        (double)temp.GetPixel(i, j).R * convmatrix[1, 1] +
                        (double)temp.GetPixel(i, j + 1).R * convmatrix[1, 2] +
                        (double)temp.GetPixel(i + 1, j - 1).R * convmatrix[2, 0] +
                        (double)temp.GetPixel(i + 1, j).R * convmatrix[2, 1] +
                        (double)temp.GetPixel(i + 1, j + 1).R * convmatrix[2, 2];

                    double horizontal = (double)temp.GetPixel(i - 1, j - 1).R * convmatrix[0, 2] +
                        (double)temp.GetPixel(i - 1, j).R * convmatrix[1, 2] +
                        (double)temp.GetPixel(i - 1, j + 1).R * convmatrix[2, 2] +
                        (double)temp.GetPixel(i, j - 1).R * convmatrix[0, 1] +
                        (double)temp.GetPixel(i, j).R * convmatrix[1, 1] +
                        (double)temp.GetPixel(i, j + 1).R * convmatrix[2, 1] +
                        (double)temp.GetPixel(i + 1, j - 1).R * convmatrix[0, 0] +
                        (double)temp.GetPixel(i + 1, j).R * convmatrix[1, 0] +
                        (double)temp.GetPixel(i + 1, j + 1).R * convmatrix[2, 0];

                    int jarak = distance(vertical, horizontal) > 255 ? 255 : distance(vertical, horizontal);

                    output.SetPixel(i - 1, j - 1, Color.FromArgb(jarak, jarak, jarak));
                }
            }

            return output;
        }

        private static int distance(double a, double b)
        {
            return (int)Math.Pow(Math.Pow(a, 2) + Math.Pow(b, 2), 0.5);
        }
    }
}