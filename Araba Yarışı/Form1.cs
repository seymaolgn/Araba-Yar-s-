using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Araba_Yarışı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int kazanılanPuan = 0;
        int yolHizi = 5;
        int arabaHizi = 5;

        bool solYon = false;
        bool sagYon = false;
        int digerArabaHizi = 5;
        Random rnd = new Random();

        public void oyunubaslat()
        {
            btn_oyunuBaşlat.Enabled = false;
            picture_boxcarpma.Visible = false;
            lbl_yusekskor.Text = Settings1.Default.yüksekSkor.ToString();
            kazanılanPuan = 0;
            yolHizi = 5;
            arabaHizi = 5;
            bizimaraba.Left = 160;
            bizimaraba.Top = 300;
            araba1.Left = 30;
            araba1.Top = 50;
            araba2.Left = 320;
            araba2.Top = 50;
            solYon = false;
            sagYon = false;
            picture_boxcarpma.Left = 165;
            picture_boxcarpma.Top = 294;
            sesAc();
            timer1.Start();
        }
        SoundPlayer player = new SoundPlayer();
        private void sesAc()
        {
            

            player.SoundLocation = @"C:\Users\Şeyma\source\repos\Araba Yarışı\LostSky.wav.wav";
            player.Play();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_oyunuBaşlat_Click(object sender, EventArgs e)
        {
            oyunubaslat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oyunubaslat();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kazanılanPuan++;
            lbl_puan.Text = kazanılanPuan.ToString();
            yol.Top += yolHizi;
            if (yol.Top > 400) { yol.Top = -100; }

            if (solYon) { bizimaraba.Left -= arabaHizi; }
            if (sagYon) { bizimaraba.Left += arabaHizi; }
            if (bizimaraba.Left < 1) { solYon = false; }
            else if (bizimaraba.Left + bizimaraba.Width > panel1.Width) { sagYon = false; }

            araba1.Top += arabaHizi;
            araba2.Top += arabaHizi;
            if (araba1.Top > panel1.Height)
            {
                araba1Degiştir();
                araba1.Left = rnd.Next(20, 150);
                araba1.Top = rnd.Next(40, 100) * -1;
            }
            if (araba2.Top > panel1.Height)
            {
                araba2Degiştir();
                araba2.Left = rnd.Next(200, 300);
                araba2.Top = rnd.Next(10, 50);  
            }
            if (bizimaraba.Bounds.IntersectsWith(araba1.Bounds) || bizimaraba.Bounds.IntersectsWith(araba2.Bounds)) 
            {
                oyunbitti();
            }
        }
        private void araba1Degiştir()
        {
            int sayı = rnd.Next(1, 7);
            switch (sayı)
            {
                case 1:
                    araba1.Image = Resource1.araba9;
                    break;
                case 2:
                    araba1.Image = Resource1.araba8;
                    break;
                case 3:
                    araba1.Image = Resource1.araba3;
                    break;
                case 4:
                    araba1.Image = Resource1.araba4;
                    break;
                case 5:
                    araba1.Image = Resource1.araba5;
                    break;
                case 6:
                    araba1.Image = Resource1.araba6;
                    break;
                case 7:
                    araba1.Image = Resource1.araba7;
                    break;
            }



        }
        private void araba2Degiştir()
        {
            int sayı = rnd.Next(1, 7);
            switch (sayı)
            {
                case 1:
                    araba2.Image = Resource1.araba9;
                    break;
                case 2:
                    araba2.Image = Resource1.araba8;
                    break;
                case 3:
                    araba2.Image = Resource1.araba3;
                    break;
                case 4:
                    araba2.Image = Resource1.araba4;
                    break;
                case 5:
                    araba2.Image = Resource1.araba5;
                    break;
                case 6:
                    araba2.Image = Resource1.araba6;
                    break;
                case 7:
                    araba2.Image = Resource1.araba7;
                    break;
            }

        }
        private void oyunbitti()
        {
            timer1.Stop();
            if (Convert.ToInt32(lbl_puan.Text) > Convert.ToInt32(Settings1.Default.yüksekSkor.ToString()))

            {
                Settings1.Default.yüksekSkor = lbl_puan.Text;
            }
            btn_oyunuBaşlat.Enabled = true;
            picture_boxcarpma.Visible = true;
            bizimaraba.Controls.Add(picture_boxcarpma);
            picture_boxcarpma.Location = new Point(7, -5);
            picture_boxcarpma.BringToFront();
            picture_boxcarpma.BackColor = Color.Transparent;
            player.Stop();
            
            MessageBox.Show("Oyun bitti puanınız :" + lbl_puan.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left && bizimaraba.Left > 0) { solYon = true; }
            if(e.KeyCode==Keys.Right&& bizimaraba.Left + bizimaraba.Width < panel1.Width) { sagYon = true; }
        }

        private void yol_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { solYon = false; }
            if (e.KeyCode == Keys.Right) { sagYon = false; }
        }
    }
}