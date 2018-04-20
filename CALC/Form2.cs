using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CALC;

namespace CALC1
{
    public partial class Form2 : Form
    {
        public string history = "";
        public string path = @"..\..\his.txt";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    textBox1.Text += line + " ";
                    textBox1.Text += '\r';
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    textBox1.Text += line + " ";
                    textBox1.Text += '\r';
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Create(path);
            //File.
            textBox1.ResetText();
        }
    }
}
