using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CALC1;
using CALCULATOR;

namespace CALC
{
    public partial class Form1 : Form
    {
        private bool extra = false;
        private bool sig = false;
        private bool eq = false;
        Form2 his = new Form2();
        public string path = @"..\..\his.txt";

        calculator cal = new calculator();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)  //number 1 / (
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
        private void button2_Click(object sender, EventArgs e)  //number 2 / )
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

        private void button3_Click(object sender, EventArgs e)  //number 3 / %
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

        private void button4_Click(object sender, EventArgs e)  //number 4 / sin
        {
            if (!extra)
            {
                textBox1.Text += button4.Text;
            }
            else
            {
                textBox1.Text += button4.Text + "(";
                sig = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)  //number 5 / cos
        {
            if (!extra)
            {
                textBox1.Text += button5.Text;
            }
            else
            {
                textBox1.Text += button5.Text + "(";
                sig = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)  //number 6 / tan
        {
            if (!extra)
            {
                textBox1.Text += button6.Text;
            }
            else
            {
                textBox1.Text += button6.Text + "(";
                sig = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)  //number 7 / !
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

        private void button8_Click(object sender, EventArgs e)  //number 8 / ^
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

        private void button9_Click(object sender, EventArgs e)  //number 9 / sqrt
        {
            if (!extra)
            {
                textBox1.Text += button9.Text;
            }
            else
            {
                textBox1.Text += button9.Text + "(";
                sig = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)  //number 0 / ln
        {
            if (!extra)
            {
                textBox1.Text += button10.Text;
            }
            else
            {
                textBox1.Text += button10.Text + "(";
                sig = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)  //operator +
        {
            if (!sig) textBox1.Text += "+";
            sig = true;
        }

        private void button13_Click(object sender, EventArgs e)  //operator -
        {
            if (!sig) textBox1.Text += "-";
            sig = true;
        }

        private void button14_Click(object sender, EventArgs e)  //operator *
        {
            if (!sig) textBox1.Text += "*";
            sig = true;
        }

        private void button15_Click(object sender, EventArgs e)  //operator /
        {
            if (!sig) textBox1.Text += "/";
            sig = true;
        }
        private void button11_Click(object sender, EventArgs e) // , / e
        {
            textBox1.Text += button11.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!extra) extra = true;
            else extra = false;
            
            if (extra)
            {   
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
                button11.Text = ",";
                button18.BackColor = Color.DarkGray;
            }
        }

        private void button17_Click(object sender, EventArgs e) // C
        {
            textBox1.ResetText();
            sig = false;
            eq = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!eq)
            {
                Calculating();
                eq = true;
            }
        }

        void Calculating()
        {
            double res = 0;

            for (int i = 0; i < textBox1.TextLength; i++)
            {
                //===== Binary operators
                if (textBox1.Text[i].Equals('+') || textBox1.Text[i].Equals('-') ||
                    textBox1.Text[i].Equals('*') || textBox1.Text[i].Equals('/') ||
                    textBox1.Text[i].Equals('^'))
                {
                    char sign = textBox1.Text[i];
                    string num1 = "", num2 = "";
                    double tmp1 = 0, tmp2 = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (isNum(ref j))
                        {
                            num1 += textBox1.Text[j];
                        }

                        if (textBox1.Text[j].Equals('e'))
                        {
                            tmp1 = cal.e;
                        }
                    }

                    
                    for (int k = i + 1; k < textBox1.TextLength; k++)
                    {
                        if (isNum(ref k))
                        {
                            num2 += textBox1.Text[k];
                        }

                        if (textBox1.Text[k].Equals('e'))
                        {
                            tmp2 = cal.e;
                        }
                    }

                    double num_1 = 0;
                    double num_2 = 0;
                    if (tmp1 != 0)
                    {
                        num_1 = tmp1;
                    }
                    else
                    {
                        num_1 = double.Parse(num1);
                    }

                    if (tmp2 != 0)
                    {
                        num_2 = tmp2;
                    }
                    else
                    {
                        num_2 = double.Parse(num2);
                    }

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
                        case '^':
                            {
                                //double num_2_ = double.Parse(num2);
                                res = cal.powu(ref num_1, ref num_2);
                                break;
                            }
                    }
                    break;
                }
                //===== Unary operators
                if (textBox1.Text[i].Equals('!') || textBox1.Text[i].Equals('%'))
                {
                    char sign = textBox1.Text[i];
                    string num1 = "";
                    for (int j = 0; j < i; j++)
                    {
                        if (isNum(ref j))
                        {
                            num1 += textBox1.Text[j];
                        }
                    }

                    double num_1 = double.Parse(num1);

                    switch (sign)
                    {
                        case '!':
                            {
                                int num_1_ = int.Parse(num1);
                                res = cal.fac(ref num_1_);
                                break;
                            }
                        case '%':
                            {
                                res = cal.per(ref num_1);
                                break;
                            }
                    }
                    break;
                }
                //===== sin
                if (textBox1.Text[i].Equals('s') && textBox1.Text[i + 1].Equals('i') &&
                    textBox1.Text[i + 2].Equals('n') && textBox1.Text[i + 3].Equals('('))
                {
                    string num1 = "";
                    for (int k = i + 4; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    double num_1 = double.Parse(num1);
                    res = cal.sinx(ref num_1);
                    break;
                }

                //===== cos
                if (textBox1.Text[i].Equals('c') && textBox1.Text[i + 1].Equals('o') &&
                    textBox1.Text[i + 2].Equals('s') && textBox1.Text[i + 3].Equals('('))
                {
                    string num1 = "";
                    for (int k = i + 4; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    double num_1 = double.Parse(num1);
                    res = cal.cosx(ref num_1);
                    break;
                }

                //===== tg
                if (textBox1.Text[i].Equals('t') && textBox1.Text[i + 1].Equals('a') &&
                    textBox1.Text[i + 2].Equals('n') && textBox1.Text[i + 3].Equals('('))
                {
                    string num1 = "";
                    for (int k = i + 4; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    double num_1 = double.Parse(num1);
                    res = cal.tanx(ref num_1);
                    break;
                }

                //===== sqrt
                if (textBox1.Text[i].Equals('s') && textBox1.Text[i + 1].Equals('q') &&
                    textBox1.Text[i + 2].Equals('r') && textBox1.Text[i + 3].Equals('t') && 
                    textBox1.Text[i + 4].Equals('('))
                {
                    string num1 = "";
                    for (int k = i + 5; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                        
                    }

                    double num_1 = double.Parse(num1);
                    res = cal.sqrtu(ref num_1);
                    break;
                }

                //=====ln
                if (textBox1.Text[i].Equals('l') && textBox1.Text[i + 1].Equals('n') &&
                    textBox1.Text[i + 2].Equals('('))
                {
                    string num1 = "";
                    for (int k = i + 3; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    double num_1 = double.Parse(num1);
                    res = cal.ln(ref num_1);
                    break;
                }

                //=====e
                //if (textBox1.Text[0].Equals('e'))
                //{
                //    res = cal.e;
                //    break;
                //}

            }

            res = Math.Round(res, 4);
            textBox1.Text += "=" + res;
            //textBox2.Text += res;
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(textBox1.Text);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void Key(object sender, KeyEventArgs e)
        {
            if (!(Control.ModifierKeys == Keys.Shift))
            {
                if (e.KeyCode == Keys.D1)
                {
                    textBox1.Text += "1";
                }

                if (e.KeyCode == Keys.D2)
                {
                    textBox1.Text += "2";
                }

                if (e.KeyCode == Keys.D3)
                {
                    textBox1.Text += "3";
                }

                if (e.KeyCode == Keys.D4)
                {
                    textBox1.Text += "4";
                }

                if (e.KeyCode == Keys.D5)
                {
                    textBox1.Text += "5";
                }

                if (e.KeyCode == Keys.D6)
                {
                    textBox1.Text += "6";
                }

                if (e.KeyCode == Keys.D7)
                {
                    textBox1.Text += "7";
                }

                if (e.KeyCode == Keys.D8)
                {
                    textBox1.Text += "8";
                }

                if (e.KeyCode == Keys.D9)
                {
                    textBox1.Text += "9";
                }

                if (e.KeyCode == Keys.D0)
                {
                    textBox1.Text += "0";
                }
            }

            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.D8)
            {
                textBox1.Text += "*";
            }

            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.D6)
            {
                textBox1.Text += "^";
            }

            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.D5)
            {
                textBox1.Text += "%";
            }

//            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Divide)
//            {
//                textBox1.Text += "/";
//            }

            if (e.KeyCode == Keys.Back)
            {
                //textBox1.ResetText();
                //sig = false;
                button17_Click(sender, e);
            }

            if (e.KeyCode == Keys.Tab)
            {
                //Calculating();
                button16_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.Subtract)
            {
                textBox1.Text += "-";
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button7_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button8_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button9_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button11_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button10_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button16_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button17_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button15_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button14_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button13_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button12_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button18_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!his.IsDisposed)
            {
                his.Show();
            }
            else if (!his.Created)
            {
                Form2 his = new Form2();
                his.Show();
            }
        }

        private void button19_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }

        private bool isNum(ref int j)
        {
            if (textBox1.Text[j].Equals('0') || textBox1.Text[j].Equals('1') ||
                textBox1.Text[j].Equals('2') || textBox1.Text[j].Equals('3') ||
                textBox1.Text[j].Equals('4') || textBox1.Text[j].Equals('5') ||
                textBox1.Text[j].Equals('6') || textBox1.Text[j].Equals('7') ||
                textBox1.Text[j].Equals('8') || textBox1.Text[j].Equals('9') ||
                textBox1.Text[j].Equals(','))
            {
                return true;
            }

            return false;
        }
    }
}
