using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoubleGlazedWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
                
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("pricelist.txt"))
            {
                string str;
                while ((str = sr.ReadLine()) != null) 
                {
                    string[] s = str.Split(';');

                    if (s[0] == comboBox1.Text)
                    {
                        double width = double.Parse(textBox1.Text);
                        double height = double.Parse(textBox2.Text);
                        double one = double.Parse(s[1]);
                        double two = double.Parse(s[2]);
                        double windowsill = double.Parse(s[3]);
                        double sum = 0;

                        if (radioButton1.Checked)
                        {
                            sum = (one * height) + (one * width);
                        }
                        else if (radioButton2.Checked)
                        {
                            sum = (two * height) + (two * width);
                        }

                        if (checkBox1.Checked && sum > 0)
                        {
                            sum = sum + width * windowsill;
                        }

                        label7.Text = sum.ToString() + " руб.";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
