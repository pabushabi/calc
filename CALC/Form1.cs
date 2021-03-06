﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CALC1;
using CALCULATOR;

namespace CALC
{
    public partial class Form1 : Form
    {
        private bool extra = false;
        private bool sig = false;
        private bool po = false;
        private bool eq = false;
        private bool ky = true;
        private int num_s = 0;
        readonly Form2 his = new Form2();
        public string path = @"his.txt";
        private string clpbrd = "";

        readonly calculator cal = new calculator();
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
                if (!sig || !ky) textBox1.Text += @"(";
                sig = true;
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
                if (true) textBox1.Text += @")";
                sig = true;
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
                if (!sig || !ky) textBox1.Text += @"%";
                sig = true;
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
                if (!sig || !ky) textBox1.Text += @"sin(";
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
                if (!sig || !ky) textBox1.Text += @"cos(";
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
                if (!sig || !ky) textBox1.Text += @"tan(";
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
                if (!sig || !ky) textBox1.Text += @"!";
                sig = true;
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
                if (!sig || !ky) textBox1.Text += @"^";
                sig = true;
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
                if (!sig || !ky) textBox1.Text += @"sqrt(";
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
                if (!sig || !ky) textBox1.Text += @"ln(";
                sig = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)  //operator +
        {
            if (!sig) textBox1.Text += @"+";
            sig = true;
        }

        private void button13_Click(object sender, EventArgs e)  //operator -
        {
            if (num_s >= 3) return;
            textBox1.Text += @"-";
            //sig = true;
            num_s++;
        }

        private void button14_Click(object sender, EventArgs e)  //operator *
        {
            if (!sig) textBox1.Text += @"*";
            sig = true;
        }

        private void button15_Click(object sender, EventArgs e)  //operator /
        {
            if (!sig) textBox1.Text += @"/";
            sig = true;
        }
        private void button11_Click(object sender, EventArgs e) // , / e
        {
            if (!extra)
            {
                if (!po) textBox1.Text += @",";
                po = true;
            }
            else
            {
                textBox1.Text += @"e";
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            extra = !extra;
            
            if (extra)
            {   
                button1.Text = @"(";
                button2.Text = @")";
                button3.Text = @"%";
                button4.Text = @"sin";
                button5.Text = @"cos";
                button6.Text = @"tan";
                button7.Text = @"!";
                button8.Text = @"^";
                button9.Text = @"sqrt";
                button10.Text = @"ln";
                button11.Text = @"e";
                button13.Text = @"-";
                button18.BackColor = Color.Gray;
            }
            if (!extra)
            {
                button1.Text = @"1";
                button2.Text = @"2";
                button3.Text = @"3";
                button4.Text = @"4";
                button5.Text = @"5";
                button6.Text = @"6";
                button7.Text = @"7";
                button8.Text = @"8";
                button9.Text = @"9";
                button10.Text = @"0";
                button11.Text = @",";
                button13.Text = @"-"; // ˗
                button18.BackColor = Color.DarkGray;
            }
        }

        private void button17_Click(object sender, EventArgs e) // C
        {
            textBox1.ResetText();
            sig = false;
            eq = false;
            po = false;
            num_s = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (eq) return;
            Calculating();
            eq = true;
        }

        private void Calculating()
        {
            double res = 0;

            if (textBox1.TextLength == 0) return;

            if (textBox1.Text[0].Equals('c') || textBox1.Text[0].Equals('s') || textBox1.Text[0].Equals('t')
                || textBox1.Text[0].Equals('l') && !textBox1.Text[textBox1.TextLength - 1].Equals(')'))
            {
                textBox1.Text += ')';
            }

            for (var i = 1; i < textBox1.TextLength; i++)
            {
                //===== Binary operators
                if (textBox1.Text[i].Equals('+') || textBox1.Text[i].Equals('*') || 
                    textBox1.Text[i].Equals('/') || textBox1.Text[i].Equals('^') ||
                    textBox1.Text[i].Equals('-'))
                {
                    var sign = textBox1.Text[i];
                    string num1 = "", num2 = "";
                    double tmp1 = 0, tmp2 = 0;
                    for (var j = 0; j < i; j++)
                    {
                        if (isNum(ref j))
                            num1 += textBox1.Text[j];

                        if (textBox1.Text[j].Equals('e'))
                            tmp1 = cal.e;
                    }
                    
                    for (var k = i + 1; k < textBox1.TextLength; k++)
                    {
                        if (isNum(ref k))
                            num2 += textBox1.Text[k];

                        if (textBox1.Text[k].Equals('e'))
                            tmp2 = cal.e;
                    }

                    double num_1 = 0;
                    double num_2 = 0;
                    try
                    {
                        num_1 = tmp1 != 0 ? tmp1 : double.Parse(num1);
                        num_2 = tmp2 != 0 ? tmp2 : double.Parse(num2);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[0].Equals('-'))
                        num_1 = -num_1;
                    if (textBox1.Text[i + 1].Equals('-') || textBox1.Text[i].Equals('-'))
                    {
                        num_2 = -num_2;
                        res = cal.add(ref num_1, ref num_2);
                    }

                    switch (sign)
                    {
                        case '+':
                                res = cal.add(ref num_1, ref num_2);
                                break;
                        case '*':
                                res = cal.mul(ref num_1, ref num_2);
                                break;
                        case '/':
                                res = cal.div(ref num_1, ref num_2);
                                break;
                        case '^':
                                res = cal.powu(ref num_1, ref num_2);
                                break;
                    }
                    break;
                }
                //===== Unary operators
                if (textBox1.Text[i].Equals('!') || textBox1.Text[i].Equals('%'))
                {
                    var sign = textBox1.Text[i];
                    var num1 = "";
                    for (var j = 0; j < i; j++)
                    {
                        if (isNum(ref j))
                        {
                            num1 += textBox1.Text[j];
                        }
                    }

                    var num_1 = 0.0;
                    try
                    {
                        num_1 = double.Parse(num1);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[0].Equals('˗'))
                        num_1 = -num_1;

                    switch (sign)
                    {
                        case '!':
                        {
                            var num_1_ = 0;
                                try
                                {
                                    num_1_ = int.Parse(num1);
                                }
                                catch (System.FormatException)
                                {
                                    textBox1.Text = @"                   ERR";
                                    return;
                                }
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
                if (textBox1.Text[i - 1].Equals('s') && textBox1.Text[i].Equals('i') &&
                    textBox1.Text[i + 1].Equals('n') && textBox1.Text[i + 2].Equals('('))
                {
                    var num1 = "";
                    for (int k = i + 3; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    var num_1 = 0.0;
                    try
                    {
                        num_1 = double.Parse(num1);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[4].Equals('˗'))
                        num_1 = -num_1;

                    res = cal.sinx(ref num_1);
                    break;
                }

                //===== cos
                if (textBox1.Text[i - 1].Equals('c') && textBox1.Text[i].Equals('o') &&
                    textBox1.Text[i + 1].Equals('s') && textBox1.Text[i + 2].Equals('('))
                {
                    var num1 = "";
                    for (int k = i + 3; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    var num_1 = 0.0;
                    try
                    {
                        num_1 = double.Parse(num1);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[4].Equals('˗'))
                        num_1 = -num_1;

                    res = cal.cosx(ref num_1);
                    break;
                }

                //===== tg
                if (textBox1.Text[i - 1].Equals('t') && textBox1.Text[i].Equals('a') &&
                    textBox1.Text[i + 1].Equals('n') && textBox1.Text[i + 2].Equals('('))
                {
                    var num1 = "";
                    for (int k = i + 3; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    var num_1 = 0.0;
                    try
                    {
                        num_1 = double.Parse(num1);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[4].Equals('˗'))
                        num_1 = -num_1;

                    for (var k = 1; k < 10; k++)
                        if (num_1 == (2 * k - 1) * 90)
                        {
                            textBox1.Text = @"                   ERR";
                            return;
                        }

                    res = cal.tanx(ref num_1);
                    break;
                }

                //===== sqrt
                if (textBox1.Text[i - 1].Equals('s') && textBox1.Text[i].Equals('q') &&
                    textBox1.Text[i + 1].Equals('r') && textBox1.Text[i + 2].Equals('t') && 
                    textBox1.Text[i + 3].Equals('('))
                {
                    var num1 = "";
                    for (var k = i + 4; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                        
                    }

                    var num_1 = 0.0;
                    try
                    {
                        num_1 = double.Parse(num1);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[5].Equals('˗'))
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    res = cal.sqrtu(ref num_1);
                    break;
                }

                //=====ln
                if (textBox1.Text[i - 1].Equals('l') && textBox1.Text[i].Equals('n') &&
                    textBox1.Text[i + 1].Equals('('))
                {
                    var num1 = "";
                    for (var k = i + 3; !textBox1.Text[k].Equals(')'); k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    var num_1 = 0.0;
                    try
                    {
                        num_1 = double.Parse(num1);
                    }

                    catch (System.FormatException)
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    if (textBox1.Text[4].Equals('˗'))
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }

                    res = cal.ln(ref num_1);
                    break;
                }

                if (i == textBox1.TextLength - 1)
                {
                    var num1 = "";
                    for (var k = 0; k < textBox1.TextLength; k++)
                    {
                        if (isNum(ref k))
                        {
                            num1 += textBox1.Text[k];
                        }
                    }

                    if (!num1.Equals("")) res = double.Parse(num1);

                    if (textBox1.Text[0].Equals('˗'))
                        res = -res;

                    if (textBox1.TextLength - 1 == 0)
                        if (textBox1.Text[0].Equals('e')) 
                        {
                            textBox1.Text += @"=" + Math.Round(cal.e, 4);
                            return;
                        }

                    if (textBox1.Text[0].Equals('(') || textBox1.Text[0].Equals(')'))
                    {
                        textBox1.Text = @"                   ERR";
                        return;
                    }
                }

            }

            res = Math.Round(res, 4);
            clpbrd = "";
            clpbrd += res;
            textBox1.Text += @"=" + res;
            using (var sw = new StreamWriter(path, true, System.Text.Encoding.Default))
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

        private void Key(object sender, KeyEventArgs e)
        {
            if (!(ModifierKeys == Keys.Shift || ModifierKeys == Keys.Control))
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        textBox1.Text += @"1";
                        break;
                    case Keys.D2:
                        textBox1.Text += @"2";
                        break;
                    case Keys.D3:
                        textBox1.Text += @"3";
                        break;
                    case Keys.D4:
                        textBox1.Text += @"4";
                        break;
                    case Keys.D5:
                        textBox1.Text += @"5";
                        break;
                    case Keys.D6:
                        textBox1.Text += @"6";
                        break;
                    case Keys.D7:
                        textBox1.Text += @"7";
                        break;
                    case Keys.D8:
                        textBox1.Text += @"8";
                        break;
                    case Keys.D9:
                        textBox1.Text += @"9";
                        break;
                    case Keys.D0:
                        textBox1.Text += @"0";
                        break;
                    case Keys.C:
                        ky = true;
                        extra = true;
                        button5_Click(sender, e);
                        extra = false;
                        break;
                    case Keys.S:
                        ky = true;
                        extra = true;
                        button4_Click(sender, e);
                        extra = false;
                        break;
                    case Keys.T:
                        ky = true;
                        extra = true;
                        button6_Click(sender, e);
                        extra = false;
                        break;
                    case Keys.Q:
                        ky = true;
                        extra = true;
                        button9_Click(sender, e);
                        extra = false;
                        break;
                    case Keys.L:
                        ky = true;
                        extra = true;
                        button10_Click(sender, e);
                        extra = false;
                        break;
                    case Keys.H:
                        button19_Click(sender, e);
                        break;
                    case Keys.E:
                        ky = true;
                        extra = true;
                        button11_Click(sender, e);
                        extra = false;
                        break;
                    case Keys.X:
                        button18_Click(sender, e);
                        break;
                    case Keys.Back:
                        button17_Click(sender, e);
                        break;
                    case Keys.Tab:
                        button16_Click(sender, e);
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.M:
                        extra = false;
                        button11_Click(sender, e);
                        break;
                }
            }

            //if (e.KeyCode == Keys.KeyCode)

            switch (ModifierKeys)
            {
                case Keys.Shift:
                    switch (e.KeyCode)
                    {
                        case Keys.D1:
                            ky = true;
                            extra = true;
                            button7_Click(sender, e);
                            extra = false;
                            break;
                        case Keys.D8:
                            button14_Click(sender, e);
                            break;
                        case Keys.D6:
                            ky = true;
                            extra = true;
                            button8_Click(sender, e);
                            extra = false;
                            break;
                        case Keys.D5:
                            ky = true;
                            extra = true;
                            button3_Click(sender, e);
                            extra = false;
                            break;
                        case Keys.D9:
                            ky = true;
                            extra = true;
                            button1_Click(sender, e);
                            extra = false;
                            break;
                        case Keys.D0:
                            ky = true;
                            extra = true;
                            button2_Click(sender, e);
                            extra = false;
                            break;
                        case Keys.A:
                            button12_Click(sender, e);
                            break;
                        case Keys.S:
                            button13_Click(sender, e);
                            break;
                        case Keys.D:
                            button15_Click(sender, e);
                            break;
                    }

                    break;
                case Keys.Control:
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            Clipboard.SetText(clpbrd);
                            break;
                        case Keys.V:
                            textBox1.Text += Clipboard.GetText();
                            break;
                    }
                    break;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!his.IsDisposed)
            {
                his.Show();
            }
            else if (!his.Created)
            {
                var his = new Form2();
                his.Show();
            }
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
