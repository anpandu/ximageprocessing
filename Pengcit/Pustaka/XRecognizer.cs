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

        public List<string> labels_classified;

        private static Dictionary<String, double[,]> NumDatabase = new Dictionary<String, double[,]>()
        {
            { "nol", new double[2, 8] { {0.564516129032258,0.25,0,0,0,0,0,0.185483870967742},
                                        {0.523076923076923,0.269230769230769,0,0,0,0,0,0.207692307692308}} },
            { "satu", new double[2, 8] {{0.836477987421384,0.050314465408805,0.0377358490566038,0,0,0,0,0.0754716981132075},
                                        {0.759124087591241,0.131386861313869,0.0145985401459854,0,0,0,0.0072992700729927,0.0875912408759124}} },
            { "dua", new double[2, 8] { {0.676300578034682,0.144508670520231,0.0289017341040462,0,0,0,0.00578034682080925,0.144508670520231},
                                        {0.605263157894737,0.210526315789474,0.00526315789473684,0,0,0,0,0.178947368421053}} },
            { "tiga", new double[2, 8] {    {0.526315789473684,0.236842105263158,0.0157894736842105,0,0,0,0.00526315789473684,0.215789473684211},
                                            {0.43455497382199,0.282722513089005,0.0157068062827225,0,0,0,0.00523560209424084,0.261780104712042}} },
            { "empat", new double[2, 8] {   {0.703703703703704,0.155555555555556,0.0148148148148148,0,0,0,0,0.125925925925926},
                                            {0.708029197080292,0.175182481751825,0,0,0,0,0,0.116788321167883}} },
            { "lima", new double[2, 8] {    {0.709183673469388,0.127551020408163,0.0255102040816327,0,0,0,0,0.137755102040816},
                                            {0.639130434782609,0.178260869565217,0.0130434782608696,0,0,0,0,0.169565217391304}} },
            { "enam", new double[2, 8] {    {0.57051282051282,0.230769230769231,0.00641025641025641,0,0,0,0,0.192307692307692},
                                            {0.588235294117647,0.242647058823529,0,0,0,0,0.0147058823529412,0.154411764705882}} },
            { "tujuh", new double[2, 8] {   {0.503355704697987,0.268456375838926,0.00671140939597315,0,0,0,0.00671140939597315,0.214765100671141},
                                            {0.538961038961039,0.25974025974026,0,0,0,0,0.00649350649350649,0.194805194805195}} },
            { "delapan", new double[2, 8] { {0.559701492537313,0.246268656716418,0.00746268656716418,0,0,0,0.0149253731343284,0.171641791044776},
                                            {0.492537313432836,0.283582089552239,0,0,0,0,0,0.223880597014925}} },
            { "sembilan", new double[2, 8] {    {0.569620253164557,0.240506329113924,0,0,0,0,0,0.189873417721519},
                                                {0.516556291390728,0.271523178807947,0,0,0,0,0.00662251655629139,0.205298013245033}} },
        };

        int[] arahx;
        int[] arahy;
        
        public XRecognizer (Color _latar, Bitmap _gambar) {
            background = _latar;
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

            codes = new List<string>();
            codes_delta = new List<string>();
            freqs_code_delta = new List<double[]>();
            labels_classified = new List<string>();

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
            // classify
            foreach (double[] freq_code_delta in freqs_code_delta) {
                Dictionary<double, string> DiffLabelPair = new Dictionary<double, string>();
                double smallest_diff = 100;
                foreach (KeyValuePair<string, double[,]> number in NumDatabase) {
                    double[,] temp = number.Value;
                    //Debug.WriteLine(number.Key);
                    double local_smallest_diff = 100;
                    for (int j = 0; j < temp.GetLength(0); j++) {
                        double diff = 0;
                        //Debug.Write("[" + j + "] -> ");
                        for (int k = 0; k < temp.GetLength(1); k++) {
                            //Debug.Write(temp[j, k]+" ");
                        }
                        //Debug.WriteLine("");
                        for (int k = 0; k < temp.GetLength(1); k++) {
                            //Debug.Write(Math.Abs(freq_code_delta[k]-temp[j, k]) + " ");
                            diff += Math.Abs(freq_code_delta[k] - temp[j, k]);
                        }
                        //Debug.Write("<" + j + "> -> " + diff);
                        local_smallest_diff = (diff<local_smallest_diff) ? diff : local_smallest_diff;
                        //Debug.WriteLine("");
                    }
                    //Debug.WriteLine("LSD = " + local_smallest_diff);
                    DiffLabelPair.Add(local_smallest_diff, number.Key);
                    smallest_diff = (local_smallest_diff < smallest_diff) ? local_smallest_diff : smallest_diff;
                }
                //Debug.WriteLine("Label = " + DiffLabelPair[smallest_diff] + " | Diff = " + smallest_diff);
                labels_classified.Add(DiffLabelPair[smallest_diff]);
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
