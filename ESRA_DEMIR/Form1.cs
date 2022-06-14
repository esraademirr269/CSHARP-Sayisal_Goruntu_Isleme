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
    public partial class Form1 : Form
    {
        public string DosyaYolu;
        public Image dosyam;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "";
            dosya.ShowDialog();
            DosyaYolu = dosya.FileName;
            pictureBox1.ImageLocation = DosyaYolu;
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dosyam = pictureBox1.Image;
            Form2 form2sec = new Form2(dosyam);
                        form2sec.Show();
                       this.Hide();
        }

      
    }
}

    