using System;
using System.IO;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e) // Reload
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

        private void button2_Click(object sender, EventArgs e) // Clear
        {
            using (StreamWriter s = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                s.WriteLine("");
            }
            textBox1.ResetText();
        }

        private void Key(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.R)
            {
                button1_Click(sender, e);
            }

            if (e.KeyCode == Keys.C)
            {
                button2_Click(sender, e);
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            Key(sender, e);
        }
    }
}
