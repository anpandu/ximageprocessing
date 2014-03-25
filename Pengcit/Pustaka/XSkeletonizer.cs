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
                Debug.WriteLine(count);
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
                Debug.WriteLine(count);/**/
                Debug.WriteLine(countNonLatarPixel + " " + countNotErased);/**/
                notSkeleton = !(countNonLatarPixel==countNotErased);//&&(count<10);
                countNonLatarPixel = 0;
                countNotErased = 0;
            }/**/
            return res;
        }
        
        /*
        public static Bitmap zhangsuen (Bitmap _b) {
            Bitmap res = XImage.addFrame(_b, latar);
            bool notSkeleton = true;
            int count = 0;
            int countNonLatarPixel = 0;
            int countNotErased = 0;
            while (notSkeleton) {
                Stack<int> pxCanBeErasedX = new Stack<int>();
                Stack<int> pxCanBeErasedY = new Stack<int>();
                for (int i=1; i<_b.Height+1; i++) {
                    bool on = true;
                    for (int j=1; j<_b.Width+1; j++) {
                        Color temp = res.GetPixel(j, i);
                            if ((!XColor.isEqual(temp, latar))) {
                                countNonLatarPixel++;
                                if (canBeErased2(res, j, i)) {
                                    //res.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                                    pxCanBeErasedX.Push(j);
                                    pxCanBeErasedY.Push(i);
                                } else
                                    countNotErased++;
                                on = false;
                            }
                    }
                }
                while ((pxCanBeErasedX.Count != 0) && (pxCanBeErasedY.Count != 0)) {
                    int tx = pxCanBeErasedX.Pop();
                    int ty = pxCanBeErasedY.Pop();
                    res.SetPixel(tx, ty, Color.FromArgb(0, 0, 0));
                }
                for (int i=1; i<_b.Height+1; i++) {
                    bool on = true;
                    for (int j=1; j<_b.Width+1; j++) {
                        Color temp = res.GetPixel(j, i);
                            if ((!XColor.isEqual(temp, latar))) {
                                countNonLatarPixel++;
                                if (canBeErased3(res, j, i)) {
                                    //res.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                                    pxCanBeErasedX.Push(j);
                                    pxCanBeErasedY.Push(i);
                                } else
                                    countNotErased++;
                                on = false;
                            }
                    }
                }
                while ((pxCanBeErasedX.Count != 0) && (pxCanBeErasedY.Count != 0)) {
                    int tx = pxCanBeErasedX.Pop();
                    int ty = pxCanBeErasedY.Pop();
                    res.SetPixel(tx, ty, Color.FromArgb(0, 0, 0));
                }
                count++;                
                Debug.WriteLine(count);
                Debug.WriteLine(countNonLatarPixel + " " + countNotErased);
                notSkeleton = (count<40);
                countNonLatarPixel = 0;
                countNotErased = 0;
            }
            return res;
        }
        
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
        }/**/

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
    }
}
