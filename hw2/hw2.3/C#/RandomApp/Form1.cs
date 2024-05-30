using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Width = 200;
            textBox3.Height = 200;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text, out int N) && int.TryParse(textBox2.Text, out int k) && k > 0 && N > 0)
            {
                // random values
                double[] variates = GenerateRandom(N);

                //stampa per verifica
                for (int i = 0; i < variates.Length; i++)
                {
                    Console.WriteLine(variates[i]);
                }

                //Qui fai una conta dei valori che si trovano in ognuno degli intervalli (da qui la conversione in int)

                int[] contatore = new int[k];
                foreach (var value in variates)
                {
                    int index = (int)(value * k);
                    contatore[index]++;
                }
               
                //stampa per verifica
                for (int i = 0; i < contatore.Length; i++)
                {
                    Console.WriteLine(contatore[i]);
                }

                Console.WriteLine($"Distribuzione con k = {k}:");
                for (int i = 0; i < k; i++)
                {
                    double lowerBound = (double)i / k;
                    double upperBound = (double)(i + 1) / k;
                    textBox3.Text += $"[{lowerBound} - {upperBound}): {contatore[i]}";
                }

            }
            else
            {
                MessageBox.Show("Invalid input. Please enter positive integers for N and k.");
            }
        }
        private double[] GenerateRandom(int N)
        {
            Random random = new Random();
            double[] variates = new double[N];
            for (int i = 0; i < N; i++)
            {
                variates[i] = random.NextDouble();
            }
            return variates;
        }

        
    }
}
