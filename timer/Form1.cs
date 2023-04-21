using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayaç = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayaç > 0)
            {
                sayaç--;
                sayıcı.Text = sayaç.ToString() + " saniye kaldı";
                progressBar2.Value++;

            }
            else {
                timer1.Enabled = false;
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Close();
            }
        }

        private void playbtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
