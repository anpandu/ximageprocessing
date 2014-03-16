using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WindowsFormsApplication1.Pustaka
{
    class XRecognizer
    {
        public Color background;
        public Color mark;
        public Bitmap gambar_ori;
        public Bitmap gambar;
        public Bitmap gambaredited;

        public List<string> codes;
        public List<string> codes_delta;
        public List<double[]> freqs_code_delta;

        int[] arahx;
        int[] arahy;
        
        public XRecognizer (Color _latar, Bitmap _gambar) {
            background = _latar;
            codes = new List<string>();
            codes_delta = new List<string>();
            freqs_code_delta = new List<double[]>();
            mark = Color.FromArgb(255, 0, 0);
            gambar_ori = new Bitmap(_gambar);
            gambar = XImage.addFrame(_gambar, background);
            gambaredited = new Bitmap(_gambar);
            arahx = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };
            arahy = new int[8] { -1, -1, 0, 1, 1, 1, 0, -1 };
        }

        private bool isBackground(Color _c) {
            bool hasil = ((_c.R==background.R)&&(_c.G==background.G)&&(_c.B==background.B));
            return hasil;
        }

        public void proses () {
            for (int i = 1; i < gambar.Width-1; i++) {              // iterasi
                for (int j = 1; j < gambar.Height-1; j++) {
                    Color ctemp = gambar.GetPixel(i, j);
                    if (!isBackground(ctemp)) {                     // jika tidak sama dgn latar
                        String codetemp = tanganKiriBasah(i, j);    // dapatkan chaincode + kasih tanda merah pada edge
                        codes.Add(codetemp);                        // add ke list
                        floodDelete(i, j);                          // hapus bangun
                    }
                }
            }
            // stringcode delta
            foreach (String code in codes) {
                char[] char_arr = (char[])code.ToCharArray().Clone();
                String code_delta = "";
                for (int i = 0; i < char_arr.Length; i++) {
                    int cc_curr = int.Parse(char_arr[i].ToString());
                    int cc_next = int.Parse(char_arr[(i+1)%char_arr.Length].ToString());
                    int delta = (cc_next - cc_curr);
                    delta = delta >= 0 ? delta : delta+8;
                    //delta = delta < 4 ? delta : 8 - delta;
                    code_delta += delta.ToString();
                }
                codes_delta.Add(code_delta);
            }
            // frequency of code in stringcode delta
            foreach (String code_delta in codes_delta) {
                double[] freq_code_delta = new double[8];
                int total = 0;
                for (int i = 0; i < 8; i++) {
                    freq_code_delta[i] = 0;
                }
                char[] char_arr = (char[])code_delta.ToCharArray().Clone();
                for (int i = 0; i < char_arr.Length; i++) {
                    int cc_curr = int.Parse(char_arr[i].ToString());
                    freq_code_delta[cc_curr] += 1;
                    total += 1;
                }
                for (int i = 0; i < 8; i++) {
                    freq_code_delta[i] /= total;
                }
                freqs_code_delta.Add(freq_code_delta);/**/
            }
        }

        private void marking (int _x, int _y) { 
            gambaredited.SetPixel(_x, _y, mark);
            //for (int a=0; a<8; a+=8) {
                //int nix = _x+arahx[a];
                //int niy = _y+arahy[a];
                //gambaredited.SetPixel(nix, niy, mark);
            //}
        }

        private string tanganKiriBasah (int x, int y) {
            String code = "";
            // == ARAH (8 tetangga) ==
            // 7 0 1
            // 6 - 2
            // 5 4 3
            int a = 0;       // arah, diwakili 0..7
            int k = (a+7)%8; // arah kiri (counter-clockwise) dari a, diwakili 0..7
            int ix = x;
            int iy = y;
            int count = 0;
            do {
                marking(ix-1, iy-1); // dikurangi 1 karena ada frame
                int nix = ix+arahx[a]; 
                int niy = iy+arahy[a]; 
                int nkx = ix+arahx[k]; 
                int nky = iy+arahy[k];
                Color nextPixel = gambar.GetPixel(nix, niy);
                Color kiriPixel = gambar.GetPixel(nkx, nky);
                //Debug.WriteLine("telusur " + ix + " " + iy + " " + arahx[a] + " " + arahy[a] + " " + arahx[k] + " " + arahy[k] + " " + (isLatar(nextPixel)) + " " + (isLatar(kiriPixel)) + " ");
                //Debug.WriteLine(count+" telusur " + ix + " " + iy);
                while ( !(!isBackground(nextPixel)&&isBackground(kiriPixel))&&(count<3000) )
                {
                    a = (a+1)%8; // diputar clockwise 45 drjt
                    k = (a+7)%8;
                    nix = ix+arahx[a]; 
                    niy = iy+arahy[a]; 
                    nkx = ix+arahx[k]; 
                    nky = iy+arahy[k];
                    nextPixel = gambar.GetPixel(nix, niy);
                    kiriPixel = gambar.GetPixel(nkx, nky);
                    //Debug.WriteLine(count+" gantiarah "+" "+arahx[a]+" "+arahy[a]+" "+arahx[k]+" "+arahy[k]);
                    count++;
                }
                count = 0;
                ix = nix;
                iy = niy;
                code += a;
                //count++;
            } while (!(ix==x&&iy==y)&&(count<6000));
            return code;
        }


        private void floodDelete(int _x, int _y) { // delete pixel non-latar
            Stack<int> stackx = new Stack<int>();
            Stack<int> stacky = new Stack<int>();
            stackx.Push(_x);
            stacky.Push(_y);
            while ((stackx.Count!=0)&&(stacky.Count!=0)) {
                int tx = stackx.Pop();
                int ty = stacky.Pop();
                if (!isBackground(gambar.GetPixel(tx+1, ty))) {
                    stackx.Push(tx + 1);
                    stacky.Push(ty);
                }
                if (!isBackground(gambar.GetPixel(tx-1, ty))) {
                    stackx.Push(tx - 1);
                    stacky.Push(ty);
                }
                if (!isBackground(gambar.GetPixel(tx, ty+1))) {
                    stackx.Push(tx);
                    stacky.Push(ty + 1);
                }
                if (!isBackground(gambar.GetPixel(tx, ty-1))) {
                    stackx.Push(tx);
                    stacky.Push(ty - 1);
                }
                gambar.SetPixel(tx, ty, background);
            }
        }
    }
}
