using System;
using System.Windows.Forms;

namespace MTFAT
{
    public partial class Message : Form
    {
        public int fk = 0;
        int Timer = new int();
        int f = new int();
        string d = null;

        public Message(String A, String B, String C, String D, String E, String F, String G, int I, int J)
        {
            InitializeComponent();

            Timer = f = J;

            label1.Text = A;
            label2.Text = B;
            label3.Text = C;

            button1.Text = d = D;
            button2.Text = E;
            button3.Text = F;
            button4.Text = G;

            for (int i = I; i > 0; i--)
            {
                (Controls["button" + i.ToString()] as Button).Visible = true;
            }
            for (int i = 4; i != I; i--)
            {
                (Controls["button" + i.ToString()] as Button).Visible = false;
            }
            if (Timer > 0)
            {
                button1.Text += " (" + f.ToString() + ")";
                f--;
                timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Timer > 0)
            {
                if (f != 0)
                {
                    button1.Text = d + " (" + f.ToString() + ")";
                    f--;
                }
                else
                {
                    timer1.Stop();
                    fk = 1;
                    Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fk = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fk = 2;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fk = 3;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fk = 4;
            Close();
        }
    }
}
