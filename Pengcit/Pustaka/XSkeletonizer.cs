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
        
        public static Bitmap zhangsuen (Bitmap _b) {
            Bitmap framedImage = XImage.addFrame(_b, latar);
            int[,,] framedImage_imgarr = XImage.getImgArrFromBitmap(framedImage);
            List<System.Drawing.Point> pointsToChange = new List<System.Drawing.Point>();
            int a, b; int p2 = 0; int p4 = 0; int p6 = 0; int p8 = 0;
            bool notSkeleton = true;
            while (notSkeleton) {
                notSkeleton = false;
                for (int i=1; i<_b.Height+1; i++) {
                    for (int j=1; j<_b.Width+1; j++) {
                        if (isNotLatar(framedImage_imgarr, j, i)) {
                            a = getA(framedImage_imgarr, j, i);
                            b = getB(framedImage_imgarr, j, i, ref p2, ref p4, ref p6, ref p8);
                            if (2 <= b && b <= 6 && a == 1 && (p2 * p4 * p6 == 0) && (p4 * p6 * p8 == 0)) {
                                pointsToChange.Add(new System.Drawing.Point(j, i));
                                notSkeleton = true;
                            }
                        }
                    }
                }
                foreach (System.Drawing.Point point in pointsToChange) {
                    framedImage_imgarr[0,point.X,point.Y] = latar.R;
                    framedImage_imgarr[1,point.X,point.Y] = latar.G;
                    framedImage_imgarr[2,point.X,point.Y] = latar.B;
                } 
                pointsToChange.Clear();
                for (int i=1; i<_b.Height+1; i++) {
                    for (int j=1; j<_b.Width+1; j++) {
                        if (isNotLatar(framedImage_imgarr, j, i)) {
                            a = getA(framedImage_imgarr, j, i);
                            b = getB(framedImage_imgarr, j, i, ref p2, ref p4, ref p6, ref p8);
                            if (2 <= b && b <= 6 && a == 1 && (p2 * p4 * p8 == 0) && (p2 * p6 * p8 == 0)) {
                                pointsToChange.Add(new System.Drawing.Point(j, i));
                                notSkeleton = true;
                            }
                        }
                    }
                }
                foreach (System.Drawing.Point point in pointsToChange) {
                    framedImage_imgarr[0,point.X,point.Y] = latar.R;
                    framedImage_imgarr[1,point.X,point.Y] = latar.G;
                    framedImage_imgarr[2,point.X,point.Y] = latar.B;
                } 
                pointsToChange.Clear();
            }
            return XImage.removeFrame(XImage.getBitmapFromImgArr(framedImage_imgarr));
        }

        private static bool isLatar(int[,,] _b, int i, int j) {
            Color temp = Color.FromArgb(_b[0,i,j],_b[1,i,j],_b[2,i,j]);
            return XColor.isEqual(temp, latar);
        }
        
        private static bool isNotLatar(int[,,] _b, int i, int j) {
            return !isLatar(_b,i,j);
        }
        
        private static int getA(int[,,] image, int x, int y) { 
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
        
        private static int getB(int[,,] image, int x, int y, ref int p2, ref int p4, ref int p6, ref int p8) { 
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
        

    }
}
