using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _151213117_ESRA_DEMIR
{
    public partial class Form2 : Form
    {
        public Image dosyam,anadosyam;
        public Form2(Image DosyaYolu)
        {
            InitializeComponent();
            pictureBox1.Image = DosyaYolu;
            anadosyam = DosyaYolu;

            dosyam = DosyaYolu;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3sec = new Form3(dosyam);
            form3sec.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1sec = new Form1();
            form1sec.Show();
            this.Hide();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            dosyam =pictureBox1.Image;
            anadosyam = dosyam;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //label1.Text = comboBox1.SelectedItem.ToString();       içindeki yazı yazar
            //label1.Text = comboBox1.SelectedIndex.ToString();      indexi yazar
            Color OkunanRenk1, DonusenRenk1;
            Bitmap GirisResmi1;
            Bitmap CikisResmi1;
            GirisResmi1 = new Bitmap(pictureBox1.Image);
            int ResimGenisligi1 = GirisResmi1.Width;
            int ResimYuksekligi1 = GirisResmi1.Height;
            Bitmap GirisResmi, CikisResmi;
            int ResimGenisligi, ResimYuksekligi;
            int x, y;
            int i, j;
            Color OkunanRenk;
            pictureBox1.Image = anadosyam;
            switch (comboBox1.SelectedIndex)
            {

                case 0:
                    GirisResmi = new Bitmap(pictureBox1.Image);
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {
                            int GriDegeri = (GirisResmi.GetPixel(x, y).R + GirisResmi.GetPixel(x, y).G + GirisResmi.GetPixel(x, y).B) / 3;
                            CikisResmi.SetPixel(x, y, Color.FromArgb(GriDegeri, GriDegeri, GriDegeri));
                        }
                    }
                    pictureBox1.Image = CikisResmi;
                    break;
                case 1:
                   0

                    break;
                case 2:
                   
                    GirisResmi1 = new Bitmap(pictureBox1.Image);
                     ResimGenisligi1 = GirisResmi1.Width;
                     ResimYuksekligi1 = GirisResmi1.Height;
                    CikisResmi1 = new Bitmap(ResimGenisligi1, ResimYuksekligi1);
                    int x2 = 0, y2=0 ; //Çıkış resminin x ve y si olacak.
                    int KucultmeKatsayisi = 2;
                    for (int x3 = 0; x3 < ResimGenisligi1; x3 = x3 + KucultmeKatsayisi)
                    {
                        y2 = 0;
                        for (int y3 = 0; y3 < ResimYuksekligi1; y3 = y3 + KucultmeKatsayisi)
                        {
                            OkunanRenk1 = GirisResmi1.GetPixel(x3, y3);
                            DonusenRenk1 = OkunanRenk1;
                            CikisResmi1.SetPixel(x2, y2, DonusenRenk1);
                            y2++;
                        }
                        x2++;
                    }
                    pictureBox1.Image = CikisResmi1;

                    break;
                case 3:
                  
                    break;
                case 4:

                    GirisResmi1 = new Bitmap(pictureBox1.Image);
                    ResimGenisligi1 = GirisResmi1.Width;
                    ResimYuksekligi1 = GirisResmi1.Height;
                    CikisResmi1 = new Bitmap(ResimGenisligi1, ResimYuksekligi1);

                    for (x = 10; x < GirisResmi1.Width - 30; x++)
                    {
                        for (y = 10; y < GirisResmi1.Height - 30; y++)
                        {
                            OkunanRenk1 = GirisResmi1.GetPixel(x, y);
                            DonusenRenk1 = OkunanRenk1;
                            CikisResmi1.SetPixel(x, y, DonusenRenk1);


                        }

                    }
                    pictureBox1.Image = CikisResmi1;

                    break;
                case 5:

                    ArrayList DiziPiksel = new ArrayList();
                    int OrtalamaRenk = 0;

                
                    //Histogram için giriş resmi gri-ton olmalıdır.

                    GirisResmi = new Bitmap(pictureBox1.Image);
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                    for (x = 0; x < GirisResmi.Width; x++)
                    {
                        for ( y = 0; y < GirisResmi.Height; y++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x, y); OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3;
                            DiziPiksel.Add(OrtalamaRenk); //Resimdeki değerler atılıyor.
                        }
                    }
                    int[] DiziPikselSayilari = new int[256];
                    for (int r = 0; r < 255; r++) //256 tane renk tonu için dönecek. 
                    {
                        int PikselSayisi = 0;
                        for (int s = 0; s < DiziPiksel.Count; s++) //resimdeki piksel sayısınca dönecek. 
                        { 
                            if (r == Convert.ToInt16(DiziPiksel[s])) PikselSayisi++;
                        }
                            DiziPikselSayilari[r] = PikselSayisi;
                    }
                    int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak. 
                    for (int k = 0; k <= 255; k++)
                    {
                        if (DiziPikselSayilari[k] > RenkMaksPikselSayisi) { RenkMaksPikselSayisi = DiziPikselSayilari[k]; }
                    }
                   
                this.chart1.Titles.Add("HİSTOGRAM GRAFİĞİ");
                chart1.Series.Add("Piexel");
                    for (i = 1; i < 255; i++)

                    {

                        chart1.Series["Piexel"].Points.AddXY(i, DiziPikselSayilari[i]);

                    }
                    break;
                       
                    } 
            }


        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
                comboBox1.Enabled = true;
            
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
           
        }
    }
}

