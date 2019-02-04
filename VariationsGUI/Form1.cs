using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VariationsGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int n = int.Parse(textBox1.Text.ToString());
            int k = int.Parse(textBox2.Text.ToString());

            if (1 <= k && k <= n)
            {
                int variations = 1;
                for (int i = n; i > n - k; i--)
                {
                    variations *= i;
                }
          

                for (int i = 0; i < variations; i++)
                {
                    // isNotAvailable е "грешната" стойност i.e. isAvailable е "правилната"
                    bool[] isNotAvailable = new bool[n];

                    int numberOfAvailElems = n;
                    int variationsOfAvailElems = variations;

                    for (int j = 0; j < k; j++)
                    {
                        numberOfAvailElems--;

                       
                        if (numberOfAvailElems + 1 > 0)
                        {
                            variationsOfAvailElems /= (numberOfAvailElems + 1);
                        }
                        else
                        {
                            variationsOfAvailElems = 1;
                        }

                        int lotId = i / variationsOfAvailElems;

                        int indexInListOfAvailElems =
                           lotId % (numberOfAvailElems + 1);

                        int x = 0;
                        int counterOfAvailElems =
                           indexInListOfAvailElems + 1;
                        while (x < n && counterOfAvailElems > 0)
                        {
                            if (!isNotAvailable[x])
                            {
                                counterOfAvailElems--;
                            }
                            x++;
                        }
                        isNotAvailable[x - 1] = true;

                        textBox3.Text = ("Вариациите са = " + variations);
                        textBox4.Text += string.Join("  ", x);
                    }
                    textBox4.Text += ("\r\n");
                }
            }
            else 
            {
                textBox3.Text=("Грешен вход! Допустимите стойности са: 1 <= k <= n.");
                textBox4.Text = String.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
        }

   
    }
}
