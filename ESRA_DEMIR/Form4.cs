using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _151213117_ESRA_DEMIR
{
    public partial class Form4 : Form
    {
        public Image anadosyam, dosyam;

        public Form4(Image DosyaYolu)
        {
            InitializeComponent();
            pictureBox1.Image = DosyaYolu;
            dosyam = pictureBox1.Image;
            anadosyam = pictureBox1.Image;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3sec = new Form3(dosyam);
            form3sec.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dosyam = pictureBox1.Image;
            anadosyam = dosyam;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
                saveFileDialog1.Title = "Resmi Kaydet";
                saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "") //Dosya adı boş değilse kaydedecek. 
            { // FileStream nesnesi ile kayıtı gerçekleştirecek. FileStream DosyaAkisi = (FileStream)saveFileDialog1.OpenFile();
                using (FileStream DosyaAkisi = (FileStream)saveFileDialog1.OpenFile())
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1: pictureBox1.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case 2: pictureBox1.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp); break;
                        case 3: pictureBox1.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Gif); break;
                    }
                    DosyaAkisi.Close();
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap GirisResmi, CikisResmi,SiyahBeyaz;
            int ResimGenisligi, ResimYuksekligi;
            int SablonBoyutu, ElemanSayisi;
            int x, y;
            pictureBox1.Image = anadosyam;
            GirisResmi = new Bitmap(pictureBox1.Image);
            ResimGenisligi = GirisResmi.Width;
            ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int toplam1 = 0, toplam2 = 0, toplam3;
            //int dizi[1,1,1,1,1,1,1,1];
            for (x = 1; x < GirisResmi.Width - 1; x++)
            {
                for (y = 1; y < GirisResmi.Height - 1; y++)
                {
                     toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                     + GirisResmi.GetPixel(x, y - 1).R
                     + GirisResmi.GetPixel(x + 1, y - 1).R
                     + GirisResmi.GetPixel(x - 1, y).R
                     + GirisResmi.GetPixel(x, y).R
                     + GirisResmi.GetPixel(x + 1, y).R
                     + GirisResmi.GetPixel(x - 1, y + 1).R
                     + GirisResmi.GetPixel(x, y + 1).R
                     + GirisResmi.GetPixel(x + 1, y + 1).R;

                      toplam2 = GirisResmi.GetPixel(x - 1, y - 1).G
                     + GirisResmi.GetPixel(x, y - 1).G
                     + GirisResmi.GetPixel(x + 1, y - 1).G
                     + GirisResmi.GetPixel(x - 1, y).G
                     + GirisResmi.GetPixel(x, y).G
                     + GirisResmi.GetPixel(x + 1, y).G
                     + GirisResmi.GetPixel(x - 1, y + 1).G
                     + GirisResmi.GetPixel(x, y + 1).G
                     + GirisResmi.GetPixel(x + 1, y + 1).G;

                      toplam3 = GirisResmi.GetPixel(x - 1, y - 1).B
                     + GirisResmi.GetPixel(x, y - 1).B
                     + GirisResmi.GetPixel(x + 1, y - 1).B
                     + GirisResmi.GetPixel(x - 1, y).B
                     + GirisResmi.GetPixel(x, y).B
                     + GirisResmi.GetPixel(x + 1, y).B
                     + GirisResmi.GetPixel(x - 1, y + 1).B
                     + GirisResmi.GetPixel(x, y + 1).B
                     + GirisResmi.GetPixel(x + 1, y + 1).B;
                    
                   
                    if (GirisResmi.GetPixel(x, y).R >=135)
                    {
                        CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = CikisResmi;
            SiyahBeyaz = new Bitmap(pictureBox1.Image);

            switch (comboBox1.SelectedIndex)
            {
                 
                case 0:
                    GirisResmi = new Bitmap(pictureBox1.Image);
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                    SablonBoyutu = 3;
                    toplam1 = 0; toplam2 = 0; toplam3 = 0;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;
                    //  int dizi[];
                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {
                            toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                             + GirisResmi.GetPixel(x, y - 1).R
                             + GirisResmi.GetPixel(x + 1, y - 1).R
                             + GirisResmi.GetPixel(x - 1, y).R
                             + GirisResmi.GetPixel(x, y).R
                             + GirisResmi.GetPixel(x + 1, y).R
                             + GirisResmi.GetPixel(x - 1, y + 1).R
                             + GirisResmi.GetPixel(x, y + 1).R
                             + GirisResmi.GetPixel(x + 1, y + 1).R;


                            if (GirisResmi.GetPixel(x, y).R == 255)
                            {
                                CikisResmi.SetPixel(x, y - 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x + 1, y - 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x - 1, y, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x + 1, y, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x - 1, y + 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x, y + 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x + 1, y + 1, Color.FromArgb(255, 255, 255));
                            }
                            else
                            {
                                
                                CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                           
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
                    toplam1 = 0; toplam2 = 0; toplam3 = 0;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;
                    
                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {
                             toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                             + GirisResmi.GetPixel(x, y - 1).R
                             + GirisResmi.GetPixel(x + 1, y - 1).R
                             + GirisResmi.GetPixel(x - 1, y).R
                             + GirisResmi.GetPixel(x, y).R
                             + GirisResmi.GetPixel(x + 1, y).R
                             + GirisResmi.GetPixel(x - 1, y + 1).R
                             + GirisResmi.GetPixel(x, y + 1).R
                             + GirisResmi.GetPixel(x + 1, y + 1).R;


                            if (GirisResmi.GetPixel(x, y).R == 255 && GirisResmi.GetPixel(x - 1, y - 1).R==255 &&
                                GirisResmi.GetPixel(x, y - 1).R==255 && GirisResmi.GetPixel(x + 1, y - 1).R==255 && 
                                GirisResmi.GetPixel(x - 1, y). R==255 && GirisResmi.GetPixel(x + 1, y).R==255 &&
                                GirisResmi.GetPixel(x - 1, y + 1).R==255 &&GirisResmi.GetPixel(x, y + 1).R==255 &&
                                GirisResmi.GetPixel(x + 1, y + 1).R==255)
                            {
                                CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                                
                            }
                            else
                            {
                                CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
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
                     toplam1 = 0; toplam2 = 0; toplam3 = 0;
                     ElemanSayisi = SablonBoyutu * SablonBoyutu;
                     for (x = 1; x < GirisResmi.Width - 1; x++)
                     {
                         for (y = 1; y < GirisResmi.Height - 1; y++)
                         {
                             toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                              + GirisResmi.GetPixel(x, y - 1).R
                              + GirisResmi.GetPixel(x + 1, y - 1).R
                              + GirisResmi.GetPixel(x - 1, y).R
                              + GirisResmi.GetPixel(x, y).R
                              + GirisResmi.GetPixel(x + 1, y).R
                              + GirisResmi.GetPixel(x - 1, y + 1).R
                              + GirisResmi.GetPixel(x, y + 1).R
                              + GirisResmi.GetPixel(x + 1, y + 1).R;


                             if (GirisResmi.GetPixel(x, y).R == 255)
                             {
                                 CikisResmi.SetPixel(x, y - 1, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x + 1, y - 1, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x - 1, y, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x + 1, y, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x - 1, y + 1, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x, y + 1, Color.FromArgb(255, 255, 255));
                                 CikisResmi.SetPixel(x + 1, y + 1, Color.FromArgb(255, 255, 255));
                             }
                             else
                             {

                                 CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                             }

                         }
                     }


                     for (x = 1; x < GirisResmi.Width - 1; x++)
                     {
                         for (y = 1; y < GirisResmi.Height - 1; y++)
                         {


                             toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                              + GirisResmi.GetPixel(x, y - 1).R
                              + GirisResmi.GetPixel(x + 1, y - 1).R
                              + GirisResmi.GetPixel(x - 1, y).R
                              + GirisResmi.GetPixel(x, y).R
                              + GirisResmi.GetPixel(x + 1, y).R
                              + GirisResmi.GetPixel(x - 1, y + 1).R
                              + GirisResmi.GetPixel(x, y + 1).R
                              + GirisResmi.GetPixel(x + 1, y + 1).R;


                             if (GirisResmi.GetPixel(x, y).R == 255 && GirisResmi.GetPixel(x - 1, y - 1).R == 255 &&
                                 GirisResmi.GetPixel(x, y - 1).R == 255 && GirisResmi.GetPixel(x + 1, y - 1).R == 255 && GirisResmi.GetPixel(x - 1, y).R == 255
                                 && GirisResmi.GetPixel(x + 1, y).R == 255 && GirisResmi.GetPixel(x - 1, y + 1).R == 255 && GirisResmi.GetPixel(x, y + 1).R == 255 && GirisResmi.GetPixel(x + 1, y + 1).R == 255)
                             {

                                 CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));

                             }
                             else
                             {

                                 CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                             }
                         }
                     }
                     pictureBox1.Image = CikisResmi;
                    break;
                case 3:
                    GirisResmi = SiyahBeyaz;
                    ResimGenisligi = GirisResmi.Width;
                    ResimYuksekligi = GirisResmi.Height;
                    CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
                    SablonBoyutu = 3;
                    toplam1 = 0; toplam2 = 0; toplam3 = 0;
                    ElemanSayisi = SablonBoyutu * SablonBoyutu;

                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {


                            toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                             + GirisResmi.GetPixel(x, y - 1).R
                             + GirisResmi.GetPixel(x + 1, y - 1).R
                             + GirisResmi.GetPixel(x - 1, y).R
                             + GirisResmi.GetPixel(x, y).R
                             + GirisResmi.GetPixel(x + 1, y).R
                             + GirisResmi.GetPixel(x - 1, y + 1).R
                             + GirisResmi.GetPixel(x, y + 1).R
                             + GirisResmi.GetPixel(x + 1, y + 1).R;


                            if (GirisResmi.GetPixel(x, y).R == 255 && GirisResmi.GetPixel(x - 1, y - 1).R == 255 &&
                                GirisResmi.GetPixel(x, y - 1).R == 255 && GirisResmi.GetPixel(x + 1, y - 1).R == 255 && GirisResmi.GetPixel(x - 1, y).R == 255
                                && GirisResmi.GetPixel(x + 1, y).R == 255 && GirisResmi.GetPixel(x - 1, y + 1).R == 255 && GirisResmi.GetPixel(x, y + 1).R == 255 && GirisResmi.GetPixel(x + 1, y + 1).R == 255)
                            {

                                CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));

                            }
                            else
                            {

                                CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                        }
                    }
                    for (x = 1; x < GirisResmi.Width - 1; x++)
                    {
                        for (y = 1; y < GirisResmi.Height - 1; y++)
                        {
                            toplam1 = GirisResmi.GetPixel(x - 1, y - 1).R
                             + GirisResmi.GetPixel(x, y - 1).R
                             + GirisResmi.GetPixel(x + 1, y - 1).R
                             + GirisResmi.GetPixel(x - 1, y).R
                             + GirisResmi.GetPixel(x, y).R
                             + GirisResmi.GetPixel(x + 1, y).R
                             + GirisResmi.GetPixel(x - 1, y + 1).R
                             + GirisResmi.GetPixel(x, y + 1).R
                             + GirisResmi.GetPixel(x + 1, y + 1).R;


                            if (GirisResmi.GetPixel(x, y).R == 255)
                            {
                                CikisResmi.SetPixel(x, y - 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x + 1, y - 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x - 1, y, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x + 1, y, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x - 1, y + 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x, y + 1, Color.FromArgb(255, 255, 255));
                                CikisResmi.SetPixel(x + 1, y + 1, Color.FromArgb(255, 255, 255));
                            }
                            else
                            {
                                CikisResmi.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }

                        }
                    }
                    pictureBox1.Image = CikisResmi;
                   
                    break;

            }
        }
        
    }
}
