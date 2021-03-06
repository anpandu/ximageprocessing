﻿using System;
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
        public Color nonbackground;
        public Color mark;
        public Bitmap gambar_ori;
        public Bitmap gambar;
        public Bitmap gambaredited;

        public List<string> codes;
        public List<string> codes_delta;
        public List<double[]> freqs_code_delta;

        public List<string> labels_classified;

        /**/
        
        private static Dictionary<String, double[,]> GeometryDatabase = new Dictionary<String, double[,]>()
        {
            { "circle", new double[4, 8] { {0.502008032128514,0.265060240963855,0,0,0,0,0,0.232931726907631},
                                        {0.539823008849557,0.247787610619469,0,0,0,0,0,0.212389380530973},
                                        {0.510416666666667,0.21875,0.03125,0,0,0,0,0.239583333333333},
                                        {0.520325203252033,0.260162601626016,0.00813008130081301,0,0,0,0,0.211382113821138}} },
            { "triangle", new double[5, 8] {{0.556363636363636,0.236363636363636,0,0,0,0,0,0.207272727272727},
                                        {0.571428571428571,0.204761904761905,0.019047619047619,0,0,0,0,0.204761904761905},
                                        {0.53475935828877,0.197860962566845,0.0374331550802139,0,0,0,0,0.229946524064171},
                                        {0.551470588235294,0.220588235294118,0.0220588235294118,0,0,0,0,0.205882352941176},
                                        {0.54945054945055,0.208791208791209,0.010989010989011,0.021978021978022,0,0,0,0.208791208791209}} },                                        
            { "square", new double[5, 8] { {0.993031358885017,0,0.00696864111498258,0,0,0,0,0},
                                        {0.990697674418605,0,0.00930232558139535,0,0,0,0,0},
                                        {0.989417989417989,0,0.0105820105820106,0,0,0,0,0},
                                        {0.985915492957747,0,0.0140845070422535,0,0,0,0,0},
                                        {0.978723404255319,0,0.0212765957446809,0,0,0,0,0}} }
        };

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

        private static Dictionary<String, double[,]> AlphabetDatabase = new Dictionary<String, double[,]>()
        {
            { "A", new double[1, 8] { {0.440217391304348,0.277173913043478,0.016304347826087,0,0,0,0,0.266304347826087,}} },
            { "B", new double[1, 8] { {0.739393939393939,0.157575757575758,0,0,0,0,0.00606060606060606,0.096969696969697,}} },
            { "C", new double[1, 8] { {0.540284360189573,0.227488151658768,0.014218009478673,0,0,0,0,0.218009478672986,}} },
            { "D", new double[1, 8] { {0.746987951807229,0.150602409638554,0,0,0,0,0,0.102409638554217,}} },
            { "E", new double[1, 8] { {0.911290322580645,0.0483870967741935,0.00806451612903226,0,0,0,0,0.032258064516129,}} },
            { "F", new double[1, 8] { {0.91747572815534,0.0242718446601942,0.0242718446601942,0,0,0,0,0.0339805825242718,}} },
            { "G", new double[1, 8] { {0.648648648648649,0.168918918918919,0.0135135135135135,0,0,0,0,0.168918918918919,}} },
            { "H", new double[1, 8] { {0.929078014184397,0.0283687943262411,0.0141843971631206,0,0,0,0,0.0283687943262411,}} },
            { "I", new double[1, 8] { {0.967741935483871,0,0.032258064516129,0,0,0,0,0,}} },
            { "J", new double[1, 8] { {0.823943661971831,0.0845070422535211,0.0211267605633803,0,0,0,0,0.0704225352112676,}} },
            { "K", new double[1, 8] { {0.746835443037975,0.122362869198312,0.0168776371308017,0,0,0,0.00843881856540084,0.105485232067511,}} },
            { "L", new double[1, 8] { {0.932515337423313,0.049079754601227,0.00613496932515337,0,0,0,0,0.0122699386503067,}} },
            { "M", new double[1, 8] { {0.634204275534442,0.178147268408551,0.0118764845605701,0,0,0,0.00712589073634204,0.168646080760095,}} },
            { "N", new double[1, 8] { {0.715654952076677,0.134185303514377,0.0159744408945687,0,0,0,0.00638977635782748,0.12779552715655,}} },
            { "O", new double[1, 8] { {0.506172839506173,0.271604938271605,0,0,0,0,0,0.222222222222222,}} },
            { "P", new double[1, 8] { {0.796178343949045,0.10828025477707,0.0127388535031847,0,0,0,0,0.0828025477707006,}} },
            { "Q", new double[1, 8] { {0.476923076923077,0.266666666666667,0.0102564102564103,0,0,0,0,0.246153846153846,}} },
            { "R", new double[1, 8] { {0.6875,0.163461538461538,0.00961538461538462,0,0,0,0.00480769230769231,0.134615384615385,}} },
            { "S", new double[1, 8] { {0.485714285714286,0.261904761904762,0.00952380952380952,0,0,0,0,0.242857142857143,}} },
            { "T", new double[1, 8] { {0.936842105263158,0.0210526315789474,0.0210526315789474,0,0,0,0,0.0210526315789474,}} },
            { "U", new double[1, 8] { {0.769230769230769,0.119230769230769,0.00769230769230769,0,0,0,0,0.103846153846154,}} },
            { "V", new double[1, 8] { {0.371681415929204,0.314159292035398,0.0132743362831858,0,0,0,0.00442477876106195,0.29646017699115,}} },
            { "W", new double[1, 8] { {0.491358024691358,0.25679012345679,0.00740740740740741,0,0,0,0.00740740740740741,0.237037037037037,}} },
            { "X", new double[1, 8] { {0.257777777777778,0.364444444444444,0.0177777777777778,0,0,0,0.00444444444444444,0.355555555555556,}} },
            { "Y", new double[1, 8] { {0.355191256830601,0.306010928961749,0.0273224043715847,0,0,0,0.00546448087431694,0.306010928961749,}} },
            { "Z", new double[1, 8] { {0.655172413793103,0.172413793103448,0.0129310344827586,0,0,0,0.00431034482758621,0.155172413793103,}} },
        };

        int[] arahx;
        int[] arahy;
        
        public XRecognizer (Color _latar, Bitmap _gambar) {
            background = _latar;
            mark = Color.FromArgb(255, 0, 0);
            gambar_ori = new Bitmap(_gambar);
            gambar = XImage.addFrame(_gambar, background);
            gambaredited = new Bitmap(gambar_ori);
            arahx = new int[9] { 0, 1, 1, 1, 0, -1, -1, -1, 0 };
            arahy = new int[9] { -1, -1, 0, 1, 1, 1, 0, -1, 0 };
        }

        private bool isBackground(Color _c) {
            bool hasil = ((_c.R==background.R)&&(_c.G==background.G)&&(_c.B==background.B));
            return hasil;
        }
        
        public void classifyAsAlphabet() {
            this.calculateChainCodeDelta();
            this.classifyByDatabase(AlphabetDatabase);
        }
        
        public void classifyAsNumber() {
            this.calculateChainCodeDelta();
            this.classifyByDatabase(NumDatabase);
        }
        
        public void classifyAsGeometryShape() {
            this.calculateChainCodeDelta();
            this.classifyByDatabase(GeometryDatabase);
        }

        private void calculateChainCode () {
            gambar = XImage.addFrame(gambar_ori, background);
            //gambaredited = new Bitmap(gambar_ori);
            gambaredited = XImage.getPlainImage(gambar_ori, Color.FromArgb(0,0,0));
            codes = new List<string>();
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
        }
        
        private void calculateChainCodeDelta () {
            this.calculateChainCode();
            codes_delta = new List<string>();
            freqs_code_delta = new List<double[]>();
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

        private void classifyByDatabase(Dictionary<String, double[,]> _database) {
            // classify
            labels_classified = new List<string>();
            foreach (double[] freq_code_delta in freqs_code_delta) {
                Dictionary<double, string> DiffLabelPair = new Dictionary<double, string>();
                double smallest_diff = 100;
                foreach (KeyValuePair<string, double[,]> number in _database) {
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
                    DiffLabelPair[local_smallest_diff] = number.Key;
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
            // 6 8 2
            // 5 4 3
            int a=4, k; // arah kiri (counter-clockwise) dari a, diwakili 0..7
            int ix = x;
            int iy = y;
            int count = 0;
            List<Point> track = new List<Point>();
            track.Add(new Point(ix, iy));
            do {
                Debug.WriteLine(count+" "+(ix-1)+" "+(iy-1)+" | "+arahx[a]+" "+arahy[a]);
                marking(ix-1, iy-1); // dikurangi 1 karena ada frame
                int nix, niy, nkx, nky;
                Color nextPixel;
                Color kiriPixel;
                int aopposite = (a+4)%8;
                int ga_count = 0;
                List<int> next_a = new List<int>();
                while (ga_count<=8)
                {
                    ga_count += 1;
                    a = (a+1)%8; // diputar clockwise 45 drjt
                    k = (a+7)%8;
                    nix = ix+arahx[a]; 
                    niy = iy+arahy[a]; 
                    nkx = ix+arahx[k]; 
                    nky = iy+arahy[k];
                    nextPixel = gambar.GetPixel(nix, niy);
                    kiriPixel = gambar.GetPixel(nkx, nky);
                    bool landPixel = !isBackground(nextPixel) && isBackground(kiriPixel);
                    if (landPixel) {
                        next_a.Add(a);
                    }
                    //count++;
                }
                //count = 0;
                bool tracked = false;
                a = 8;
                int next_a_tracked = 8;
                foreach(int _a in next_a) {
                    int _ix = ix+arahx[_a];
                    int _iy = iy+arahy[_a];
                    bool tracked_now = false;
                    foreach(Point p in track) {
                        next_a_tracked = (p.X==_ix && p.Y==_iy) ? _a : next_a_tracked;
                        tracked_now = (p.X==_ix && p.Y==_iy && _a!=aopposite);
                        tracked = tracked||tracked_now;
                    }
                    if (_a!=aopposite && !tracked_now)
                        a = _a;
                }/**/
                if ((a == 8) && !(ix == x && iy == y)) {
                    if (!tracked)
                        a = aopposite;
                    else
                        a = next_a_tracked;
                }
                code += a;
                ix = ix+arahx[a];
                iy = iy+arahy[a];
                track.Add(new Point(ix,iy));
                count++;
            } while (!(ix==x&&iy==y)&&(count<2222));
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
                if (!isBackground(gambar.GetPixel(tx+1, ty+1))) {
                    stackx.Push(tx + 1);
                    stacky.Push(ty + 1);
                }
                if (!isBackground(gambar.GetPixel(tx-1, ty+1))) {
                    stackx.Push(tx - 1);
                    stacky.Push(ty + 1);
                }
                if (!isBackground(gambar.GetPixel(tx+1, ty-1))) {
                    stackx.Push(tx + 1);
                    stacky.Push(ty - 1);
                }
                if (!isBackground(gambar.GetPixel(tx-1, ty-1))) {
                    stackx.Push(tx - 1);
                    stacky.Push(ty - 1);
                }
                gambar.SetPixel(tx, ty, background);
            }
        }
    }
}
