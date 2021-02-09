using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int[,] sayilar = new int[10, 10];
        Random rastgele = new Random();
        int skor = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = skor.ToString();
            Button[,] buttons = new Button[10, 10];
            dagit();
            for (int i = 0; i < buttons.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < buttons.GetUpperBound(1) + 1; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Height = 50;
                    buttons[i, j].Name = i.ToString() + j.ToString();
                    buttons[i, j].Width = 50;
                    buttons[i, j].Left = (i * 50);
                    buttons[i, j].Top = (j * 50);
                    //buttons[i, j].Text = sayilar[i,j].ToString();
                    this.Controls.Add(buttons[i, j]);
                    buttons[i, j].Click += new EventHandler(this.button_Click);
                }

            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (skor == 890)
            {
                MessageBox.Show("Tebrikler oyunu tamamladınız");
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            else
            {
                Button BasılanButon = (Button)sender;
                if (BasılanButon.Text == "")
                {
                    int i = 0, j = 0;
                    string deger = BasılanButon.Name;
                    i = int.Parse(deger.Substring(0, 1));
                    j = int.Parse(deger.Substring(1, 1));
                    if (sayilar[i, j] != 10)
                    {
                        BasılanButon.Text = sayilar[i, j].ToString();
                        skor = skor + 10;
                        label2.Text = skor.ToString();
                    }
                    else
                    {
                        BasılanButon.Text = ("X");
                        MessageBox.Show("Bomba patladı oyunu kaybettiniz!!!!!!!");
                        Form1 frm1 = new Form1();
                        frm1.Show();
                        this.Hide();
                    }
                }
            }
        }
        void dagit()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sayilar[i, j] = 0;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                int x, y;
                x = rastgele.Next(10);
                y = rastgele.Next(10);
                if (sayilar[x, y] == 0)
                {
                    sayilar[x, y] = 10;
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (sayilar[i, j] != 10)
                    {
                        kontrol(i, j);
                    }
                }
            }
        }
        void kontrol(int i, int j)
        {
            int deger = 0;
            if (i > 0)
            {
                if (sayilar[i - 1, j] == 10)
                {
                    deger += 1;
                }
            }
            if (i < 9)
            {
                if (sayilar[i + 1, j] == 10)
                {
                    deger += 1;
                }
            }
            if (j > 0)
            {
                if (sayilar[i, j - 1] == 10)
                {
                    deger += 1;
                }
            }
            if (j < 9)
            {
                if (sayilar[i, j + 1] == 10)
                {
                    deger += 1;
                }
            }
            sayilar[i, j] = deger;
        }
    }
}
