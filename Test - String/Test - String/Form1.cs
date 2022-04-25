using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test___String
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vstup = textBox1.Text;
            string abc = "abcdefghijklmnopqrstuvwxyz";
            vstup = vstup.ToLower();

            vstup = vstup.Trim();
            while (vstup.Contains("  "))
                vstup = vstup.Replace("  ", " ");

            label1.Text = vstup;

            string[] slova = vstup.Split(' ');

            int max = 0;
            char maxC = ' ';
            string nevyskyt = "";
            foreach(string slovo in slova)
            {
                foreach(char pismeno in slovo)
                {
                    int pomocna = pocet(pismeno, vstup);
                    if (max < pomocna && abc.Contains(pismeno))
                    {
                        max = pomocna;
                        maxC = pismeno;
                    }
                }
            }

            flowLayoutPanel1.Controls.Clear();
            foreach (char c in abc)
            {
                int pomocna = pocet(c, vstup);
                if (pomocna == 0)
                {
                    nevyskyt += c + " ";
                    Button b = new Button();
                    b.Width = 50;
                    b.Height = 50;
                    b.BackColor = Color.Gray;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderColor = Color.DarkGray;
                    b.FlatAppearance.BorderSize = 1;
                    b.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
                    b.ForeColor = Color.Gold;
                    b.Text = c.ToString();
                    b.Click += abcClick;
                    flowLayoutPanel1.Controls.Add(b);
                }
                else
                {
                    Button b = new Button();
                    b.Width = 50;
                    b.Height = 50;
                    b.BackColor = Color.Gray;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
                    b.ForeColor = Color.Gold;
                    b.Text = c.ToString();
                    b.Click += abcClick;
                    flowLayoutPanel1.Controls.Add(b);
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.Add("Nejčastěji vyskytující se písmeno je ---> " + maxC);
            listBox1.Items.Add("Na výběr máte ---> " + nevyskyt);
        }

        void abcClick(object sender, EventArgs e)
        {
            string spravne = "jak nam zabili Ferdinanda." +
                "Prazdny retezec ma hodnotu ““ nebo string.Empty ." +
                "Instance String je nemenna." +
                "Halda je prakticky neomezena pamet.";
            StringBuilder sb =new StringBuilder(label1.Text);
            if (label1.Text.IndexOf('_') != -1)
            {
                sb[label1.Text.IndexOf('_')] = Convert.ToChar((sender as Button).Text);
                label1.Text = sb.ToString();

                string abc = "abcdefghijklmnopqrstuvwxyz";
                flowLayoutPanel1.Controls.Clear();
                foreach (char c in abc)
                {
                    int pomocna = pocet(c, label1.Text);
                    if (pomocna == 0)
                    {
                        Button b = new Button();
                        b.Width = 50;
                        b.Height = 50;
                        b.BackColor = Color.Gray;
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderColor = Color.DarkGray;
                        b.FlatAppearance.BorderSize = 1;
                        b.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
                        b.ForeColor = Color.Gold;
                        b.Text = c.ToString();
                        b.Click += abcClick;
                        flowLayoutPanel1.Controls.Add(b);
                    }
                    else
                    {
                        Button b = new Button();
                        b.Width = 50;
                        b.Height = 50;
                        b.BackColor = Color.Gray;
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
                        b.ForeColor = Color.Gold;
                        b.Text = c.ToString();
                        b.Click += abcClick;
                        flowLayoutPanel1.Controls.Add(b);
                    }
                }
                if (label1.Text.IndexOf('_') == -1)
                    label1.Text = "Vyhrál jsi!!!";
                label2.Text = "";
            }
            else
                label1.Text = "Vyhrál jsi!!!";
        }

        int pocet(char hledane, string vCem)
        {
            if (vCem.Contains(hledane))
            {
                string[] pole = vCem.Split(' ');
                int pocetPrvku = 0;

                foreach (string slovo in pole)
                {
                    foreach (char p in slovo)
                    {
                        if (p == hledane)
                            pocetPrvku++;
                    }
                }

                return pocetPrvku;
            }
            else
                return 0;
        }
    }
}
