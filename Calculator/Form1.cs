using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        char[] signs;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this.textBox1.Text += btn.Text;
            }
        }

        private void Calculate(object sender, MouseEventArgs e)
        {
            string text = this.textBox1.Text;
            bool containsAnyLetter = signs.Any(c => this.textBox1.Text.Contains(c));
            if (containsAnyLetter)
            {
                string[] words = text.Split(signs);
                var sum = 0;
                foreach (var word in words)
                {
                    var wordInt = Convert.ToInt32(word);
                    int index = 0;
                    foreach (var sign in signs)
                    {
                        switch (sign)
                        {
                            case '+':
                                sum += wordInt;
                                this.textBox1.Clear();
                                this.textBox1.AppendText(Convert.ToString(sum));
                                break;
                            case '-':
                                if (index + 1 < words.Length)
                                    sum = Convert.ToInt32(words[0]) - Convert.ToInt32(words[index + 1]);
                                this.textBox1.Clear();
                                this.textBox1.AppendText(Convert.ToString(sum));
                                break;
                            case '*':
                                if (index + 1 < words.Length)
                                    sum = Convert.ToInt32(words[0]) * Convert.ToInt32(words[index + 1]);
                                this.textBox1.Clear();
                                this.textBox1.AppendText(Convert.ToString(sum));
                                break;
                            case '/':
                                if (index + 1 < words.Length)
                                    sum = Convert.ToInt32(words[0]) / Convert.ToInt32(words[index + 1]);
                                this.textBox1.Clear();
                                this.textBox1.AppendText(Convert.ToString(sum));
                                break;
                            default:
                                Console.WriteLine($"An unexpected value ({sign})");
                                break;
                        }
                        index++;
                    }
                }
            }
        }

        private void btnClickSign(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this.textBox1.Text += btn.Text;
                signs = (btn.Text).ToCharArray();
            }
        }

        private void btnRemove(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            Button btn = sender as Button;
            if (e.KeyChar == '+')
            {
                Console.WriteLine($"key press is + {btn.Text}");
            }
        }
    }
}
