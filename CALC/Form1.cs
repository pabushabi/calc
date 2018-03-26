using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALC
{
    public partial class Form1 : Form
    {
        private int num1;
        private int num2;
        private string str;
        private bool extra = false;
    
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)  //number 1
        {
            if (!extra)
            {
                textBox1.Text += "1";
                str += "1";
            }
            else
            {
                textBox1.Text += "(";
            }
        }
        private void button2_Click(object sender, EventArgs e)  //number 2
        {
            if (!extra)
            {
                textBox1.Text += "2";
                str += "2";
            }
            else
            {
                textBox1.Text += ")";
            }

        }

        private void button3_Click(object sender, EventArgs e)  //number 3
        {
            if (!extra)
            {
                textBox1.Text += "3";
                str += "3";
            }
            else
            {
                textBox1.Text += "%";
            }

        }

        private void button4_Click(object sender, EventArgs e)  //number 4
        {
            if (!extra)
            {
                textBox1.Text += "4";
                str += "4";
            }
            else
            {
                textBox1.Text += "sin(";
            }

        }

        private void button5_Click(object sender, EventArgs e)  //number 5
        {
            if (!extra)
            {
                textBox1.Text += "5";
                str += "5";
            }
            else
            {
                textBox1.Text += "cos(";
            }

        }

        private void button6_Click(object sender, EventArgs e)  //number 6
        {
            if (!extra)
            {
                textBox1.Text += "6";
                str += "6";
            }
            else
            {
                textBox1.Text += "tan(";
            }

        }

        private void button7_Click(object sender, EventArgs e)  //number 7
        {
            if (!extra)
            {
                textBox1.Text += "7";
                str += "7";
            }
            else
            {
                textBox1.Text += "!";
            }

        }

        private void button8_Click(object sender, EventArgs e)  //number 8
        {
            if (!extra)
            {
                textBox1.Text += "8";
                str += "8";
            }
            else
            {
                textBox1.Text += "^";
            }

        }

        private void button9_Click(object sender, EventArgs e)  //number 9
        {
            if (!extra)
            {
                textBox1.Text += "9";
                str += "9";
            }
            else
            {
                textBox1.Text += "sqrt(";
            }

        }

        private void button10_Click(object sender, EventArgs e)  //number 0
        {
            if (!extra)
            {
                textBox1.Text += "0";
                str += "0";
            }
            else
            {
                textBox1.Text += "e";
            }

        }

        private void button12_Click(object sender, EventArgs e)  //operator +
        {
            num1 = int.Parse(str);
            textBox1.Text += "+";
        }

        private void button13_Click(object sender, EventArgs e)  //operator -
        {
            num1 = int.Parse(str);
            textBox1.Text += "-";
        }

        private void button14_Click(object sender, EventArgs e)  //operator *
        {
            num1 = int.Parse(str);
            textBox1.Text += "*";
        }

        private void button15_Click(object sender, EventArgs e)  //operator /
        {
            num1 = int.Parse(str);
            textBox1.Text += "/";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!extra) extra = true;
            else extra = false;
            
            if (extra) {   
                button1.Text = "(";
                button2.Text = ")";
                button3.Text = "%";
                button4.Text = "sin";
                button5.Text = "cos";
                button6.Text = "tan";
                button7.Text = "!";
                button8.Text = "^";
                button9.Text = "sqrt";
                button10.Text = "ln";
                button11.Text = "e";
                button18.BackColor = Color.Gray;
            }
            if (!extra)
            {
                button1.Text = "1";
                button2.Text = "2";
                button3.Text = "3";
                button4.Text = "4";
                button5.Text = "5";
                button6.Text = "6";
                button7.Text = "7";
                button8.Text = "8";
                button9.Text = "9";
                button10.Text = "0";
                button11.Text = ".";
                button18.BackColor = Color.DarkGray;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string exp = "";
            exp = textBox1.Text;
            //foreach (var i in exp)
            //{
            //    int res = exp[i].GetHashCode();
            //}
        }
    }
}
