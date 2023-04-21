using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer
{
    public partial class Form2 : Form
    {
        int sayac = 0;
        bool oyun = true;
        int skor = 0;
        int kazanmaskoru=0;
        Random sayı;
        string seçilikelime;
        List<TextBox> textBoxes;
        List<string> kelimeler;
        string url = "C:\\Users\\Lenovo\\OneDrive\\Masaüstü\\Yeni klasör\\kelimeler.txt";
        public Form2()
        {
            InitializeComponent();
            kelimeler = new List<string>();
            sayı = new Random();
            dosyaoku();
            textBoxes = new List<TextBox>();
            oyunsonulbl.Visible = false;
            skorlbl.Text = kazanmaskoru.ToString();
            oyunbitirbtn.Visible = false;
            restartbtn.Visible = false;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            gövdelbl.Text = "";

            temizleme();

            int s = sayı.Next(0, kelimeler.Count);
            for (int i = 0; i < kelimeler[s].Length; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Location = new Point(10 + (i * 80), 300);
                textBox.Size = new Size(70, 20);
                textBox.Name = i.ToString();
                Font font = new Font("Arial", 14, FontStyle.Bold);
                textBox.Font = font;
                //  textBox.Text = "";
                textBox.ReadOnly = true;
                this.panel1.Controls.Add(textBox);

                this.textBoxes.Add(textBox);



            }
            seçilikelime = kelimeler[s];
            ipucu(seçilikelime);

        }
        private void temizleme()
        {
            List<Control> textBoxesToRemove = new List<Control>();

            foreach (Control control in panel1.Controls.OfType<TextBox>())
            {
                if (control.Name != "harftxt")
                {
                    textBoxesToRemove.Add(control);
                }
            }

            foreach (Control control in textBoxesToRemove)
            {
                control.Text = "";
                panel1.Controls.Remove(control);
                control.Dispose();
            }
            textBoxes.Clear();

        }
        private void ipucu(string seçilikelime)
        {
            int uzunluk = seçilikelime.Length / 2;
            if (uzunluk <= 0)
            {
                uzunluk = 2;
            }

            for (int i = 0; i < uzunluk; i++)
            {
                int index = sayı.Next(0, seçilikelime.Length);

                string harf = seçilikelime[index].ToString()
                    ;

                textBoxes[index].Text = harf;

            }



        }
        void dosyaoku()
        {

            StreamReader stream = new StreamReader(url);
            using (stream)
            {
                while (!stream.EndOfStream)
                {

                    kelimeler.Add(stream.ReadLine());
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (harftxt.Text != "")
            {
                if (seçilikelime.Contains(harftxt.Text))
                {
                    for (int i = 0; i < seçilikelime.Length; i++)
                    {
                        if (harftxt.Text == seçilikelime[i].ToString())
                        {
                            int index = i;
                            textBoxes[i].Text = harftxt.Text;

                        }
                        else { }


                    }
                    bool kontrol = true; int h = 0;
                    while (h < textBoxes.Count)
                    {
                        if (textBoxes[h].Text == "") { kontrol = false; break; }
                        else { h++; }
                    }
                    if (kontrol) {
                        gövdelbl.Text = "Kazandın";
                        gövdelbl.Font = new Font("Arial", 12, FontStyle.Bold);

                        gövdelbl.ForeColor = Color.White;
                        temizleme();
                        restartbtn.Visible = true;
                        oyunbitirbtn.Visible = true;
                        oyunsonulbl.Visible = true;
                        kazanmaskoru++;
                        skorlbl.Text = kazanmaskoru.ToString();
                    
                    }





                }

                else
                {
                    skor--;
                    validateharf(skor);
                   


                }


            }
            else
            {

                MessageBox.Show("text alanı boş ", "hata", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }










        private void validateharf(int skor)
        {
            switch (skor)
            {
                case -1: bacak1lbl.Visible = false; break;
                case -2: bacak1lbl.Visible = false; bacak2lbl.Visible = false; break;
                case -3: bacak1lbl.Visible = false; bacak2lbl.Visible = false; kol1lbl.Visible = false; break;
                case -4: bacak1lbl.Visible = false; bacak2lbl.Visible = false; kol1lbl.Visible = false; kol2lbl.Visible = false; break;
                case -5:
                    bacak1lbl.Visible = false;
                    bacak2lbl.Visible = false; kol1lbl.Visible = false;
                    kol2lbl.Visible = false; headlbl.Visible = false; break;
                default: break;
            }
            if (skor == -5) {
                gövdelbl.Text = "Kaybettin";
                gövdelbl.Font = new Font("Arial", 12, FontStyle.Bold); 
                gövdelbl.ForeColor = Color.White;
                restartbtn.Visible = true;
                oyunbitirbtn.Visible = true;
                oyunsonulbl.Visible = true;
                kazanmaskoru = 0;
                this.skor = 0;
                skorlbl.Text = kazanmaskoru.ToString();
              temizleme();
            }
        }





        private void harftxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSymbol(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void harfal_Click(object sender, EventArgs e)
        {


            if (sayac < 1)
            {
                int index = sayı.Next(0, seçilikelime.Length);
                if (textBoxes[index].Text == "")
                {
                    string harf = seçilikelime[index].ToString()
                        ;

                    textBoxes[index].Text = harf;
                    sayac++;
                }
                else
                {
                    int tut = 0;
                    for (int i = 0; i < textBoxes.Count; i++)
                    {
                        if (textBoxes[i].Text == "") { tut = i; break; }

                    }
                    string harf = seçilikelime[tut].ToString()
                        ;

                    textBoxes[tut].Text = harf; sayac++;




                }
            }
            else { MessageBox.Show("hakkınız doldu"); }



        }

        private void oyunbitirbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void restartbtn_Click(object sender, EventArgs e)
        {
            gövdelbl.ForeColor = Color.Black;
            gövdelbl.Font = new Font("Arial", 12, FontStyle.Bold);

            restartbtn.Visible = false;
            oyunbitirbtn.Visible = false;
            oyunsonulbl.Visible = false;
            temizleme();
            bacak1lbl.Visible =true;
            bacak2lbl.Visible = true; kol1lbl.Visible = true;
            kol2lbl.Visible = true; headlbl.Visible = true;
        }
    }
}
