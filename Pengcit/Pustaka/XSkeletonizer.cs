using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace WindowsFormsApplication1.Pustaka
{
    class XSkeletonizer
    {
        private static Color latar = Color.FromArgb(0, 0, 0);

        /**
        public static Bitmap zhangsein (Bitmap _b) {
            Bitmap res = XImage.addFrame(_b, latar);
            bool notSkeleton = true;
            int count = 0;
            int countNonLatarPixel = 0;
            int countNotErased = 0;
            while (notSkeleton) {
                for (int i=1; i<_b.Height+1; i++) {
                    bool on = true;
                    for (int j=1; j<_b.Width+1; j++) {
                        Color temp = res.GetPixel(j, i);
                        if (on) {
                            if ((!XColor.isEqual(temp, latar))) {
                                countNonLatarPixel++;
                                if (canBeErased(res, j, i)) {
                                    res.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                                } else
                                    countNotErased++;
                                on = false;
                            }
                        }
                        if ((XColor.isEqual(temp, latar)))
                            on = true;
                    }
                    for (int j=_b.Width-1+1; j>=1; j--) {
                        Color temp = res.GetPixel(j, i);
                        if (on) {
                            if ((!XColor.isEqual(temp, latar))) {
                                countNonLatarPixel++;
                                if (canBeErased(res, j, i)) {
                                    res.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                                } else
                                    countNotErased++;
                                on = false;
                            }
                        }
                        if ((XColor.isEqual(temp, latar)))
                            on = true;
                    }
                }
                count++;                
                //Debug.WriteLine(count);
                for (int i=1; i<_b.Width+1; i++) {
                    bool on = true;
                    for (int j=1; j<_b.Height+1; j++) {
                        Color temp = res.GetPixel(i, j);
                        if (on) {
                            if ((!XColor.isEqual(temp, latar))) {
                                countNonLatarPixel++;
                                if (canBeErased(res, i, j)) {
                                    res.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                                } else
                                    countNotErased++;
                                on = false;
                            }
                        }
                        if ((XColor.isEqual(temp, latar)))
                            on = true;
                    }
                    for (int j=_b.Height-1+1; j>=1; j--) {
                        Color temp = res.GetPixel(i, j);
                        if (on) {
                            if ((!XColor.isEqual(temp, latar))) {
                                countNonLatarPixel++;
                                if (canBeErased(res, i, j)) {
                                    res.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                                } else
                                    countNotErased++;
                                on = false;
                            }
                        }
                        if ((XColor.isEqual(temp, latar)))
                            on = true;
                    }
                }
                count++;
                //Debug.WriteLine(count);
                //Debug.WriteLine(countNonLatarPixel + " " + countNotErased);
                notSkeleton = !(countNonLatarPixel==countNotErased);//&&(count<10);
                countNonLatarPixel = 0;
                countNotErased = 0;
            }
            return res;
        }
        /**/
        
        public static Bitmap zhangsuen (Bitmap _b) {
            Bitmap framedImage = XImage.addFrame(_b, latar);
            bool notSkeleton = true;
            //int count = 0;
            List<System.Drawing.Point> pointsToChange = new List<System.Drawing.Point>();
            int a, b; int p2 = 0; int p4 = 0; int p6 = 0; int p8 = 0;
            while (notSkeleton) {

                notSkeleton = false;

                for (int i=1; i<_b.Height+1; i++) {
                    for (int j=1; j<_b.Width+1; j++) {
                        if (isNotLatar(framedImage, j, i)) {
                            a = getA(framedImage, j, i);
                            b = getB(framedImage, j, i, ref p8, ref p4, ref p6, ref p8);
                            if (2 <= b && b <= 6 && a == 1 && (p2 * p4 * p6 == 0) && (p4 * p6 * p8 == 0)) {
                                pointsToChange.Add(new System.Drawing.Point(j, i));
                                notSkeleton = true;
                            }
                        }
                    }
                }

                foreach (System.Drawing.Point point in pointsToChange) {
                    framedImage.SetPixel(point.X, point.Y, latar); 
                } 
                pointsToChange.Clear();

                for (int i=1; i<_b.Height+1; i++) {
                    for (int j=1; j<_b.Width+1; j++) {
                        if (isNotLatar(framedImage, j, i)) {
                            a = getA(framedImage, j, i);
                            b = getB(framedImage, j, i, ref p8, ref p4, ref p6, ref p8);
                            if (2 <= b && b <= 6 && a == 1 && (p2 * p4 * p8 == 0) && (p2 * p6 * p8 == 0)) {
                                pointsToChange.Add(new System.Drawing.Point(j, i));
                                notSkeleton = true;
                            }
                        }
                    }
                }

                foreach (System.Drawing.Point point in pointsToChange) {
                    framedImage.SetPixel(point.X, point.Y, latar); 
                } 
                pointsToChange.Clear();

                //count++;                
                //Debug.WriteLine(count);
                //Debug.WriteLine(countNonLatarPixel + " " + countNotErased);
                //notSkeleton = (count<3);
            }
            return XImage.removeFrame(framedImage);
        }
        
        /*
        private static bool canBeErased2(Bitmap _b, int i, int j) {
            bool res = false;
            int count = 0;
            int counttrans = 0;
            Color[] tetangga = new Color[8] {
                _b.GetPixel(i-1,j-1),
                _b.GetPixel(i-1,j), // 8
                _b.GetPixel(i-1,j+1),
                _b.GetPixel(i,j-1), // 2
                _b.GetPixel(i,j+1), // 6
                _b.GetPixel(i+1,j-1),
                _b.GetPixel(i+1,j), // 4
                _b.GetPixel(i+1,j+1)
            };
            for (int p=0; p<tetangga.Length; p++) {
                bool trans = XColor.isEqual(tetangga[p],latar) && !XColor.isEqual(tetangga[(p+1)%8],latar);
                counttrans += trans ? 1 : 0;
            }
            foreach (Color c in tetangga) {
                count += (!XColor.isEqual(c,latar)) ? 1 : 0;
            }
            bool b = (count>=2)&&(count<=6);
            bool b2 = XColor.isEqual(tetangga[3],latar) || XColor.isEqual(tetangga[6],latar) || XColor.isEqual(tetangga[4],latar);
            bool b3 = XColor.isEqual(tetangga[6],latar) || XColor.isEqual(tetangga[4],latar) || XColor.isEqual(tetangga[1],latar);
            bool b4 = counttrans == 1;
            res = b && b2 && b3 && b4;
            return res;
        }
        
        private static bool canBeErased3(Bitmap _b, int i, int j) {
            bool res = false;
            int count = 0;
            int counttrans = 0;
            Color[] tetangga = new Color[8] {
                _b.GetPixel(i-1,j-1),
                _b.GetPixel(i-1,j), // 8
                _b.GetPixel(i-1,j+1),
                _b.GetPixel(i,j-1), // 2
                _b.GetPixel(i,j+1), // 6
                _b.GetPixel(i+1,j-1),
                _b.GetPixel(i+1,j), // 4
                _b.GetPixel(i+1,j+1)
            };
            for (int p=0; p<tetangga.Length; p++) {
                bool trans = XColor.isEqual(tetangga[p],latar) && !XColor.isEqual(tetangga[(p+1)%8],latar);
                counttrans += trans ? 1 : 0;
            }
            foreach (Color c in tetangga) {
                count += (!XColor.isEqual(c,latar)) ? 1 : 0;
            }
            bool b = (count>=2)&&(count<=6);
            bool b2 = XColor.isEqual(tetangga[3],latar) || XColor.isEqual(tetangga[6],latar) || XColor.isEqual(tetangga[1],latar);
            bool b3 = XColor.isEqual(tetangga[3],latar) || XColor.isEqual(tetangga[4],latar) || XColor.isEqual(tetangga[1],latar);
            bool b4 = counttrans == 1;
            res = b && b2 && b3 && b4;
            return res;
        }

        private static bool canBeErased(Bitmap _b, int i, int j) {
            bool res = false;
            int count = 0;
            Color[] tetangga = new Color[8] {
                _b.GetPixel(i-1,j-1),
                _b.GetPixel(i-1,j),
                _b.GetPixel(i-1,j+1),
                _b.GetPixel(i,j-1),
                _b.GetPixel(i,j+1),
                _b.GetPixel(i+1,j-1),
                _b.GetPixel(i+1,j),
                _b.GetPixel(i+1,j+1)
            };
            foreach (Color c in tetangga) {
                count += (!XColor.isEqual(c,latar)) ? 1 : 0;
            }
            res = (count >= 3);
            return res;
        }

        /**/

        private static bool isLatar(Bitmap _b, int i, int j) {
            Color temp = _b.GetPixel(i, j);
            return XColor.isEqual(temp, latar);
        }
        
        private static bool isNotLatar(Bitmap _b, int i, int j) {
            Color temp = _b.GetPixel(i, j);
            return !XColor.isEqual(temp, latar);
        }

        
        private static int getA(Bitmap image, int x, int y) { 
            int count = 0; 
            //p2 p3 
            if (isLatar(image, x, y - 1) && isNotLatar(image, x + 1, y - 1)) count++; 
            //p3 p4 
            if (isLatar(image, x + 1, y - 1) && isNotLatar(image, x + 1, y)) count++; 
            //p4 p5 
            if (isLatar(image, x + 1, y) && isNotLatar(image, x + 1, y + 1)) count++; 
            //p5 p6 
            if (isLatar(image, x + 1, y + 1) && isNotLatar(image, x, y + 1)) count++; 
            //p6 p7 
            if (isLatar(image, x, y + 1) && isNotLatar(image, x - 1, y + 1)) count++; 
            //p7 p8 
            if (isLatar(image, x - 1, y + 1) && isNotLatar(image, x - 1, y)) count++; 
            //p8 p9 
            if (isLatar(image, x - 1, y) && isNotLatar(image, x - 1, y - 1)) count++; 
            //p9 p2 
            if (isLatar(image, x - 1, y - 1) && isNotLatar(image, x, y - 1)) count++; 
            return count; 
        } 
        
        private static int getB(Bitmap image, int x, int y, ref int p2, ref int p4, ref int p6, ref int p8) { 
            int count = 0; 
            //p2 
            if (isNotLatar(image, x, y - 1)) { p2 = 1; count++; } else p2 = 0; 
            //p3 
            if (isNotLatar(image, x + 1, y - 1)) count++; 
            //p4 
            if (isNotLatar(image, x + 1, y)) { p4 = 1; count++; } else p4 = 0; 
            //p5 
            if (isNotLatar(image, x + 1, y + 1)) count++; 
            //p6 
            if (isNotLatar(image, x, y + 1)) { p6 = 1; count++; } else p6 = 0; 
            //p7 
            if (isNotLatar(image, x - 1, y + 1)) count++; 
            //p8 
            if (isNotLatar(image, x - 1, y)) { p8 = 1; count++; } else p8 = 0; 
            //p9 
            if (isNotLatar(image, x - 1, y - 1)) count++; 
            return count; 
        }
        /*
        public Bitmap ZhangSuen2()
        {
            Bitmap result = image.Clone(new Rectangle(0, 0, image.Width, image.Height), image.PixelFormat);
            result = Normalisasi(result);
            Bitmap framed = AddFrame(result);
            int a, b; int p2 = 0; int p4 = 0; int p6 = 0; int p8 = 0;
            List<System.Drawing.Point> pointsToChange = new List<System.Drawing.Point>();
            bool hasChange = false;
            do { 
                hasChange = false; 
                for (int i = 1; i < framed.Height - 1; i++) { 
                    for (int j = 1; j < framed.Width - 1; j++) { 
                        a = getA(framed, j, i); 
                        b = getB(framed, j, i, ref p2, ref p4, ref p6, ref p8); 
                        if (CheckBlack(framed, j, i) && 2 <= b && b <= 6 && a == 1 && (p2 * p4 * p6 == 0) && (p4 * p6 * p8 == 0)) { 
                            pointsToChange.Add(new System.Drawing.Point(j, i)); hasChange = true; 
                        } 
                    } 
                } 
                foreach (System.Drawing.Point point in pointsToChange) { 
                    framed.SetPixel(point.X, point.Y, putih); 
                    result.SetPixel(point.X - 1, point.Y - 1, putih); 
                } 
                pointsToChange.Clear(); 
                for (int i = 1; i < framed.Height - 1; i++) { 
                    for (int j = 1; j < framed.Width - 1; j++) { 
                        a = getA(framed, j, i); 
                        b = getB(framed, j, i, ref p2, ref p4, ref p6, ref p8); 
                        if (CheckBlack(framed, j, i) && 2 <= b && b <= 6 && a == 1 && (p2 * p4 * p8 == 0) && (p2 * p6 * p8 == 0)) { 
                            pointsToChange.Add(new System.Drawing.Point(j, i)); 
                            hasChange = true; 
                        } 
                    } 
                } 
                foreach (System.Drawing.Point point in pointsToChange) { 
                    framed.SetPixel(point.X, point.Y, putih); 
                    result.SetPixel(point.X - 1, point.Y - 1, putih); 
                } 
                pointsToChange.Clear(); 
            } while (hasChange); 
            return result;
        }/**/

    }
}
