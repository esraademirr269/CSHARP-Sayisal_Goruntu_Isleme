using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _151213117_ESRA_DEMIR
{
    public partial class Form3 : Form
    {
        public Image anadosyam,dosyam;
        public Form3(Image  DosyaYolu)
        {
            InitializeComponent();
            radioButton2.Checked = true;
            pictureBox1.Image = DosyaYolu;
            dosyam = pictureBox1.Image;
            anadosyam = pictureBox1.Image;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi;
            int ResimGenisligi, ResimYuksekligi;
            int SablonBoyutu, ElemanSayisi;
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
                    SablonBoyutu = 3;
                    int toplam1 = 0, toplam2 = 0, toplam3;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;
                   
                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {

                            toplam1 = (GirisResmi.GetPixel(x - 1, y - 1).R
                             + GirisResmi.GetPixel(x, y - 1).R
                             + GirisResmi.GetPixel(x + 1, y - 1).R
                             + GirisResmi.GetPixel(x - 1, y).R
                             + GirisResmi.GetPixel(x, y).R
                             + GirisResmi.GetPixel(x + 1, y).R
                             + GirisResmi.GetPixel(x - 1, y + 1).R
                             + GirisResmi.GetPixel(x, y + 1).R
                             + GirisResmi.GetPixel(x + 1, y + 1).R)/9;

                            toplam2 = (GirisResmi.GetPixel(x - 1, y - 1).G
                           + GirisResmi.GetPixel(x, y - 1).G
                           + GirisResmi.GetPixel(x + 1, y - 1).G
                           + GirisResmi.GetPixel(x - 1, y).G
                           + GirisResmi.GetPixel(x, y).G
                           + GirisResmi.GetPixel(x + 1, y).G
                           + GirisResmi.GetPixel(x - 1, y + 1).G
                           + GirisResmi.GetPixel(x, y + 1).G
                           + GirisResmi.GetPixel(x + 1, y + 1).G)/9;

                            toplam3 =( GirisResmi.GetPixel(x - 1, y - 1).B
                           + GirisResmi.GetPixel(x, y - 1).B
                           + GirisResmi.GetPixel(x + 1, y - 1).B
                           + GirisResmi.GetPixel(x - 1, y).B
                           + GirisResmi.GetPixel(x, y).B
                           + GirisResmi.GetPixel(x + 1, y).B
                           + GirisResmi.GetPixel(x - 1, y + 1).B
                           + GirisResmi.GetPixel(x, y + 1).B
                           + GirisResmi.GetPixel(x + 1, y + 1).B)/9;

                         CikisResmi.SetPixel(x, y, Color.FromArgb(toplam1, toplam2, toplam3));
                        }
                    }

                    pictureBox1.Image = CikisResmi;
                    break;
                case 1:

                    GirisResmi = new Bitmap(pictureBox1.Image);
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                    SablonBoyutu = 3;
                    int maskeboyutu = 3;
                    toplam1 = 0; toplam2 = 0; toplam3 = 0;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;
                    int[] dizi1 = { 0, -1, 0, -1, 5,-1, 0, -1, 0 };
                    //int[] dizi1 = {0,1,0,1,-4,1,0,1,0};
                    for (x = (maskeboyutu-1)/2; x < GirisResmi.Width - ((maskeboyutu - 1) / 2); x++)
                    {
                        for (y = (maskeboyutu - 1) / 2; y < GirisResmi.Height - ((maskeboyutu - 1) / 2); y++)
                        {

                            toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R * dizi1[0]
                            + GirisResmi.GetPixel(x, y - 1).R * dizi1[1]
                            + GirisResmi.GetPixel(x + 1, y - 1).R * dizi1[2]
                            + GirisResmi.GetPixel(x - 1, y).R * dizi1[3]
                            + GirisResmi.GetPixel(x, y).R * dizi1[4]
                            + GirisResmi.GetPixel(x + 1, y).R * dizi1[5]
                            + GirisResmi.GetPixel(x - 1, y + 1).R * dizi1[6]
                            + GirisResmi.GetPixel(x, y + 1).R * dizi1[7]
                            + GirisResmi.GetPixel(x + 1, y + 1).R * dizi1[8];

                            toplam2 = GirisResmi.GetPixel(x - 1, y - 1).G * dizi1[0]
                           + GirisResmi.GetPixel(x, y - 1).G * dizi1[1]
                           + GirisResmi.GetPixel(x + 1, y - 1).G * dizi1[2]
                           + GirisResmi.GetPixel(x - 1, y).G * dizi1[3]
                           + GirisResmi.GetPixel(x, y).G * dizi1[4]
                           + GirisResmi.GetPixel(x + 1, y).G * dizi1[5]
                           + GirisResmi.GetPixel(x - 1, y + 1).G * dizi1[6]
                           + GirisResmi.GetPixel(x, y + 1).G * dizi1[7]
                           + GirisResmi.GetPixel(x + 1, y + 1).G * dizi1[8];

                            toplam3 = GirisResmi.GetPixel(x - 1, y - 1).B * dizi1[0]
                           + GirisResmi.GetPixel(x, y - 1).B * dizi1[1]
                           + GirisResmi.GetPixel(x + 1, y - 1).B * dizi1[2]
                           + GirisResmi.GetPixel(x - 1, y).B * dizi1[3]
                           + GirisResmi.GetPixel(x, y).B * dizi1[4]
                           + GirisResmi.GetPixel(x + 1, y).B * dizi1[5]
                           + GirisResmi.GetPixel(x - 1, y + 1).B * dizi1[6]
                           + GirisResmi.GetPixel(x, y + 1).B * dizi1[7]
                           + GirisResmi.GetPixel(x + 1, y + 1).B * dizi1[8];

                            if (toplam1 > 255) toplam1 = 255;
                            if (toplam2 > 255) toplam2 = 255;
                            if (toplam3 > 255) toplam3 = 255;

                            if (toplam1 < 0) toplam1 = 0;
                            if (toplam2 < 0) toplam2 = 0;
                            if (toplam3 < 0) toplam3 = 0;
                            CikisResmi.SetPixel(x, y, Color.FromArgb(toplam1, toplam2, toplam3));
                        }
                    }

                    pictureBox1.Image = CikisResmi;


                    break;
                case 2:

                             
                    GirisResmi = new Bitmap(pictureBox1.Image);
                         ResimGenisligi = GirisResmi.Width; 
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                     SablonBoyutu = 3; 
                     ElemanSayisi = SablonBoyutu * SablonBoyutu;
                    int[] R = new int[ElemanSayisi];
                    int[] G = new int[ElemanSayisi];
                    int[] B = new int[ElemanSayisi];
                    int[] Gri = new int[ElemanSayisi];

                    for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
                    {
                        for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                        { //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                            int k = 0; for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                            {
                                for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                                {
                                    OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                                    R[k] = OkunanRenk.R;
                                    G[k] = OkunanRenk.G;
                                    B[k] = OkunanRenk.B;
                                    Gri[k] = Convert.ToInt16(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114); //Gri ton formülü
                                    k++;
                                }
                            }
                            //Gri tona göre sıralama yapıyor. Aynı anda üç rengide değiştiriyor.
                            int GeciciSayi = 0;
                            for (i = 0; i < ElemanSayisi; i++)
                            {
                                for (j = i + 1; j < ElemanSayisi; j++)
                                {
                                    if (Gri[j] < Gri[i])
                                    {
                                        GeciciSayi = Gri[i]; Gri[i] = Gri[j]; Gri[j] = GeciciSayi;
                                        GeciciSayi = R[i]; R[i] = R[j]; R[j] = GeciciSayi;
                                        GeciciSayi = G[i]; G[i] = G[j]; G[j] = GeciciSayi;
                                        GeciciSayi = B[i];
                                        B[i] = B[j];
                                        B[j] = GeciciSayi;
                                    }
                                }
                            }
                      
                            CikisResmi.SetPixel(x, y, Color.FromArgb(R[(ElemanSayisi - 1) / 2], G[(ElemanSayisi - 1) / 2], B[(ElemanSayisi - 1) / 2]));
                        }
                    }
                    pictureBox1.Image = CikisResmi;
                        break;
                case 3:
                    GirisResmi = new Bitmap(pictureBox1.Image);
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                    SablonBoyutu = 3;
                    toplam1 = 0; toplam2 = 0; toplam3=0;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;
                    //int []dizi={ 0,1,0,1,-4,1,0,1,0};
                    int[] dizi = { -1,-1,-1,-1,8,-1,-1,-1,-1 };
                    for ( x = 1; x < GirisResmi.Width-1; x++)
                    {
                        for ( y = 1; y < GirisResmi.Height-1; y++)
                        {

                            toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R * dizi[0]
                            + GirisResmi.GetPixel(x, y - 1).R*dizi[1]
                            + GirisResmi.GetPixel(x + 1, y - 1).R*dizi[2]
                            +GirisResmi.GetPixel(x - 1, y).R*dizi[3]
                            + GirisResmi.GetPixel(x, y).R*dizi[4]
                            + GirisResmi.GetPixel(x + 1, y).R*dizi[5]
                            +GirisResmi.GetPixel(x - 1, y + 1).R*dizi[6]
                            + GirisResmi.GetPixel(x, y + 1).R*dizi[7]
                            + GirisResmi.GetPixel(x + 1, y + 1).R*dizi[8];

                            toplam2 = GirisResmi.GetPixel(x - 1, y - 1).G * dizi[0]
                           + GirisResmi.GetPixel(x, y - 1).G * dizi[1]
                           + GirisResmi.GetPixel(x + 1, y - 1).G * dizi[2]
                           + GirisResmi.GetPixel(x - 1, y).G * dizi[3]
                           + GirisResmi.GetPixel(x, y).G * dizi[4]
                           + GirisResmi.GetPixel(x + 1, y).G * dizi[5]
                           + GirisResmi.GetPixel(x - 1, y + 1).G * dizi[6]
                           + GirisResmi.GetPixel(x, y + 1).G * dizi[7]
                           + GirisResmi.GetPixel(x + 1, y + 1).G * dizi[8];

                            toplam3 = GirisResmi.GetPixel(x - 1, y - 1).B * dizi[0]
                           + GirisResmi.GetPixel(x, y - 1).B * dizi[1]
                           + GirisResmi.GetPixel(x + 1, y - 1).B * dizi[2]
                           + GirisResmi.GetPixel(x - 1, y).B * dizi[3]
                           + GirisResmi.GetPixel(x, y).B * dizi[4]
                           + GirisResmi.GetPixel(x + 1, y).B * dizi[5]
                           + GirisResmi.GetPixel(x - 1, y + 1).B * dizi[6]
                           + GirisResmi.GetPixel(x, y + 1).B * dizi[7]
                           + GirisResmi.GetPixel(x + 1, y + 1).B * dizi[8];

                            if (toplam1 > 255) toplam1 = 255;
                            if (toplam2 > 255) toplam2 = 255;
                            if (toplam3 > 255) toplam3 = 255;

                            if (toplam1 < 0) toplam1 = 0;
                            if (toplam2 < 0) toplam2 = 0;
                            if (toplam3 < 0) toplam3 = 0; 
                            CikisResmi.SetPixel(x, y, Color.FromArgb(toplam1,toplam2,toplam3));
                        }
                    }
                    
                    pictureBox1.Image = CikisResmi;

                            break;
                case 4:

                    //GirisResmi = new Bitmap(pictureBox1.Image);
                    GirisResmi = new Bitmap(pictureBox1.Image);
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                    SablonBoyutu = 3;
                    toplam1 = 0; toplam2 = 0; toplam3 = 0;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;
                    //int []dizi={ 0,1,0,1,-4,1,0,1,0};

                    int[] dizi3 = { 1, 1, 1, 1, -8, 1, 1, 1, 1 };
                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {

                           
                            toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R * dizi3[0]
                            + GirisResmi.GetPixel(x, y - 1).R * dizi3[1]
                            + GirisResmi.GetPixel(x + 1, y - 1).R * dizi3[2]
                            + GirisResmi.GetPixel(x - 1, y).R * dizi3[3]
                            + GirisResmi.GetPixel(x, y).R * dizi3[4]
                            + GirisResmi.GetPixel(x + 1, y).R * dizi3[5]
                            + GirisResmi.GetPixel(x - 1, y + 1).R * dizi3[6]
                            + GirisResmi.GetPixel(x, y + 1).R * dizi3[7]
                            + GirisResmi.GetPixel(x + 1, y + 1).R * dizi3[8];

                            toplam2 = GirisResmi.GetPixel(x - 1, y - 1).G * dizi3[0]
                           + GirisResmi.GetPixel(x, y - 1).G * dizi3[1]
                           + GirisResmi.GetPixel(x + 1, y - 1).G * dizi3[2]
                           + GirisResmi.GetPixel(x - 1, y).G * dizi3[3]
                           + GirisResmi.GetPixel(x, y).G * dizi3[4]
                           + GirisResmi.GetPixel(x + 1, y).G * dizi3[5]
                           + GirisResmi.GetPixel(x - 1, y + 1).G * dizi3[6]
                           + GirisResmi.GetPixel(x, y + 1).G * dizi3[7]
                           + GirisResmi.GetPixel(x + 1, y + 1).G * dizi3[8];

                            toplam3 = GirisResmi.GetPixel(x - 1, y - 1).B * dizi3[0]
                           + GirisResmi.GetPixel(x, y - 1).B * dizi3[1]
                           + GirisResmi.GetPixel(x + 1, y - 1).B * dizi3[2]
                           + GirisResmi.GetPixel(x - 1, y).B * dizi3[3]
                           + GirisResmi.GetPixel(x, y).B * dizi3[4]
                           + GirisResmi.GetPixel(x + 1, y).B * dizi3[5]
                           + GirisResmi.GetPixel(x - 1, y + 1).B * dizi3[6]
                           + GirisResmi.GetPixel(x, y + 1).B * dizi3[7]
                           + GirisResmi.GetPixel(x + 1, y + 1).B * dizi3[8];

                            if (toplam1 > 255) toplam1 = 255;
                            if (toplam2 > 255) toplam2 = 255;
                            if (toplam3 > 255) toplam3 = 255;

                            if (toplam1 < 0) toplam1 = 0;
                            if (toplam2 < 0) toplam2 = 0;
                            if (toplam3 < 0) toplam3 = 0;
                            CikisResmi.SetPixel(x, y, Color.FromArgb(toplam1, toplam2, toplam3));
                        }
                    }

                    pictureBox1.Image = CikisResmi;

                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2sec = new Form2(dosyam);
            form2sec.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dosyam = pictureBox1.Image;
            anadosyam = dosyam;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4sec = new Form4(dosyam);
            form4sec.Show();
            this.Hide();
        }
    }
}