using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1;

namespace CALC
{
    public partial class Form1 : Form
    {
        private bool extra = false;
        private bool sig = false;

        calculator cal = new calculator();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)  //number 1
        {
            if (!extra)
            {
                textBox1.Text += button1.Text;
            }
            else
            {
                textBox1.Text += button1.Text;
            }
        }
        private void button2_Click(object sender, EventArgs e)  //number 2
        {
            if (!extra)
            {
                textBox1.Text += button2.Text;
            }
            else
            {
                textBox1.Text += button2.Text;
            }

        }

        private void button3_Click(object sender, EventArgs e)  //number 3
        {
            if (!extra)
            {
                textBox1.Text += button3.Text;
            }
            else
            {
                textBox1.Text += button3.Text;
            }

        }

        private void button4_Click(object sender, EventArgs e)  //number 4
        {
            if (!extra)
            {
                textBox1.Text += button4.Text;
            }
            else
            {
                textBox1.Text += button4.Text + "(";
            }

        }

        private void button5_Click(object sender, EventArgs e)  //number 5
        {
            if (!extra)
            {
                textBox1.Text += button5.Text;
            }
            else
            {
                textBox1.Text += button5.Text + "(";
            }

        }

        private void button6_Click(object sender, EventArgs e)  //number 6
        {
            if (!extra)
            {
                textBox1.Text += button6.Text;
            }
            else
            {
                textBox1.Text += button6.Text + "(";
            }

        }

        private void button7_Click(object sender, EventArgs e)  //number 7
        {
            if (!extra)
            {
                textBox1.Text += button7.Text;
            }
            else
            {
                textBox1.Text += button7.Text;
            }

        }

        private void button8_Click(object sender, EventArgs e)  //number 8
        {
            if (!extra)
            {
                textBox1.Text += button8.Text;
            }
            else
            {
                textBox1.Text += button8.Text;
            }

        }

        private void button9_Click(object sender, EventArgs e)  //number 9
        {
            if (!extra)
            {
                textBox1.Text += button9.Text;
            }
            else
            {
                textBox1.Text += button9.Text + "(";
            }

        }

        private void button10_Click(object sender, EventArgs e)  //number 0
        {
            if (!extra)
            {
                textBox1.Text += button10.Text;
            }
            else
            {
                textBox1.Text += button10.Text;
            }

        }

        private void button12_Click(object sender, EventArgs e)  //operator +
        {
//            num1 = int.Parse(str);
            if (!sig) textBox1.Text += "+";
            sig = true;
        }

        private void button13_Click(object sender, EventArgs e)  //operator -
        {
//            num1 = int.Parse(str);
            if (!sig) textBox1.Text += "-";
            sig = true;
        }

        private void button14_Click(object sender, EventArgs e)  //operator *
        {
//            num1 = int.Parse(str);
            if (!sig) textBox1.Text += "*";
            sig = true;
        }

        private void button15_Click(object sender, EventArgs e)  //operator /
        {
//            num1 = int.Parse(str);
            if (!sig) textBox1.Text += "/";
            sig = true;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += button11.Text;
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
            sig = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            float res = 0;

            for (int i = 0; i < textBox1.TextLength; i++)
            {
                if (textBox1.Text[i].Equals('+') || textBox1.Text[i].Equals('-') || 
                    textBox1.Text[i].Equals('*') || textBox1.Text[i].Equals('/'))
                {
                    char sign = textBox1.Text[i];
                    string num1 = "", num2 = "";
                    for (int j = 0; j < i; j++)
                    {
                        num1 += textBox1.Text[j];
                    }

                    for (int k = i+1; k < textBox1.TextLength; k++)
                    {
                        num2 += textBox1.Text[k];
                    }

                    float num_1 = float.Parse(num1);
                    float num_2 = float.Parse(num2);
                    switch (sign)
                    {
                        case '+':
                        {
                            res = cal.add(ref num_1, ref num_2);
                            break;
                        }
                        case '-':
                        {
                            res = cal.sub(ref num_1, ref num_2);
                            break;
                        }
                        case '*':
                        {
                            res = cal.mul(ref num_1, ref num_2);
                            break;
                        }
                        case '/':
                        {
                            res = cal.div(ref num_1, ref num_2);
                            break;
                        }
                    }
                    
                }
            }

            textBox1.Text += "=" + res;
        }

    }
}
