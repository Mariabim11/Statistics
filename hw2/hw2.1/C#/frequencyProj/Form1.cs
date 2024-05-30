using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace frequencyProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Width = 600;
            textBox1.Height = 600;
            textBox1.Multiline = true;

            StreamReader reader = new StreamReader("C:languageFile");
            List<string> lines = new List<string>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            int absoluteFrequency = 0;
            double relativeFrequency = 0;
            double percentage = 0;
            int totCount = 0;
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', '.', ',', ';', '-'); // Split words based on delimiters
                foreach (string word in words)
                {
                    totCount += 1;
                    string cleanedWord = word.Trim().ToLower(); // Clean and convert to lowercase
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }
                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }
                    Console.WriteLine("Word\tAbsolute\tRelative\tPercentage");
                    foreach (var kvp in wordFrequency)
                    {
                        string parola = kvp.Key;
                        absoluteFrequency = kvp.Value;
                        relativeFrequency = (double)absoluteFrequency /totCount;
                        percentage = relativeFrequency * 100;

                        Console.WriteLine($"{parola}\t{absoluteFrequency}\t\t{relativeFrequency:P2}\t\t{percentage:F2}%");
                    }
                }
            }
      

            String result= "\"Word Frequency Distribution:" + Environment.NewLine;

            foreach (var pair in wordFrequency)
            {
                result += $"{pair.Key}: {pair.Value}, Absolute:{absoluteFrequency}, Relative:{relativeFrequency}, Percentage:{percentage}" + Environment.NewLine;

            }

        textBox1.Text = result;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Width = 600;
            textBox2.Height = 600;
            textBox2.Multiline = true;
            StreamReader reader = new StreamReader("C:ageFile.txt");
            List<string> lines = new List<string>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            int totCount = 0;
            int absoluteFrequency = 0;
            double relativeFrequency = 0;
            double percentage = 0;  
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', '.', ',', ';', '-'); // Split words based on delimiters
                foreach (string word in words)
                {
                    totCount += 1;
                    string cleanedWord = word.Trim().ToLower(); // Clean and convert to lowercase
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }
                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }
                   

                    // Calculate relative frequencies and percentages
                    Console.WriteLine("Word\tAbsolute\tRelative\tPercentage");
                    foreach (var kvp in wordFrequency)
                    {
                        string parola = kvp.Key;
                        absoluteFrequency = kvp.Value;
                        relativeFrequency = (double)absoluteFrequency / totCount;
                        percentage = relativeFrequency * 100;

                        Console.WriteLine($"{parola}\t{absoluteFrequency}\t\t{relativeFrequency:P2}\t\t{percentage:F2}%");
                    }
                }
            }

            String result = "Age Frequency Distribution:" + Environment.NewLine;

            foreach (var pair in wordFrequency)
            {
                result += $"{pair.Key}: {pair.Value}, Absolute:{absoluteFrequency}, Relative:{relativeFrequency}, Percentage:{percentage}" + Environment.NewLine;
              
            }

            textBox2.Text = result;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Width = 600;
            textBox3.Height = 600;
            textBox3.Multiline = true;
            StreamReader reader = new StreamReader("C:weight.txt");
            List<string> lines = new List<string>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            int totCount = 0;
            int absoluteFrequency = 0;
            double relativeFrequency = 0;
            double percentage = 0;
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', ',', ';', '-'); // Split words based on delimiters
                foreach (string word in words)
                {
                    totCount += 1;
                    string cleanedWord = word.Trim().ToLower(); // Clean and convert to lowercase
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }
                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }


                    // Calculate relative frequencies and percentages
                    Console.WriteLine("Word\tAbsolute\tRelative\tPercentage");
                    foreach (var kvp in wordFrequency)
                    {
                        string parola = kvp.Key;
                        absoluteFrequency = kvp.Value;
                        relativeFrequency = (double)absoluteFrequency / totCount;
                        percentage = relativeFrequency * 100;

                        Console.WriteLine($"{parola}\t{absoluteFrequency}\t\t{relativeFrequency:P2}\t\t{percentage:F2}%");
                    }
                }
            }

            String result = "Height Frequency Distribution:" + Environment.NewLine;

            foreach (var pair in wordFrequency)
            {
                result += $"{pair.Key}: {pair.Value}, Absolute:{absoluteFrequency}, Relative:{relativeFrequency}, Percentage:{percentage}" + Environment.NewLine;

            }

            textBox3.Text = result;
        }

   

    private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible==false)
            {
                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox4.Visible = false;
                textBox3.Visible = false;   
            }
            else
            {
                textBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Visible == false)
            {
                textBox2.Visible = true;
                textBox1.Visible=false;
                textBox3.Visible = false;
                textBox4.Visible = false;

            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Visible == false)
            {
                textBox3.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                textBox3.Visible = false;
            }
        }


        private void OpenSecondFormButton_Click(object sender, EventArgs e)
        {
            
        }

        String remember;
        String[] splitted;
        private void button4_Click(object sender, EventArgs e)
        {

            using (Form2 secondForm = new Form2())
            {
                if (secondForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve values from SecondForm
                    string textBoxValue = secondForm.TextBoxValue;
                    List<string> checkedListBoxItems = secondForm.CheckedListBoxItems;

                    // Do something with the values from SecondForm
                    MessageBox.Show($"TextBox Value: {textBoxValue}\nCheckedListBox Items: {string.Join(", ", checkedListBoxItems)}");
                    remember = $"{textBoxValue},{string.Join(", ", checkedListBoxItems)}";
                    splitted = remember.Split(',');

                    //Console.WriteLine(splitted[0]);
                    //Console.WriteLine(splitted[1]);
                    
                }
            }

            if (textBox4.Visible == false)
            {
                textBox4.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible=false;
            }
            else
            {
                textBox4.Visible = false;
            
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            textBox4.Width = 300;
            textBox4.Height = 300;
            textBox4.Multiline = true;
            textBox4.ScrollBars = ScrollBars.Both;

            string[] lines = File.ReadAllLines("C:bivariate.txt");
            List<Tuple<string, string>> dataPairs = new List<Tuple<string, string>>();

            foreach (string line in lines)
            {
                string[] values = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length >= 2)
                {
                    dataPairs.Add(new Tuple<string, string>(values[0], values[1]));
                }
            }

            Dictionary<Tuple<string, string>, int> frequencyDict = new Dictionary<Tuple<string, string>, int>();
            foreach (var pair in dataPairs)
            {
                if (frequencyDict.ContainsKey(pair))
                {
                    frequencyDict[pair]++;
                }
                else
                {
                    frequencyDict[pair] = 1;
                }
            }
            Dictionary<string, int> absoluteFrequencyDict = new Dictionary<string, int>();
            foreach (var pair in frequencyDict)
            {
                string key = $"{pair.Key.Item1}, {pair.Key.Item2}";
                absoluteFrequencyDict[key] = pair.Value;
            }
            int totalPairs = dataPairs.Count;

            Dictionary<string, double> relativeFrequencyDict = new Dictionary<string, double>();
            foreach (var pair in absoluteFrequencyDict)
            {
                relativeFrequencyDict[pair.Key] = (double)pair.Value / totalPairs;
            }

            Dictionary<string, double> percentageFrequencyDict = new Dictionary<string, double>();
            foreach (var pair in relativeFrequencyDict)
            {
                percentageFrequencyDict[pair.Key] = pair.Value * 100;
            }

      
                    StringBuilder result = new StringBuilder();
                    foreach (var pair in frequencyDict)
                    {

                        string key = $"{pair.Key.Item1}, {pair.Key.Item2}";
                       if (pair.Key.Item1.Equals(splitted[1]) && (pair.Key.Item2.Equals(splitted[0]))){
                            result.AppendLine($"{pair.Key.Item1} with and age that is equal to {pair.Key.Item2} are");
                            result.AppendLine($"Absolute Frequency: {absoluteFrequencyDict[key]},Relative Frequency: {relativeFrequencyDict[key]:F4}, Percentage Frequency: {percentageFrequencyDict[key]:F2}%");
                            result.AppendLine();
                       }
                       else
                       {
                           continue;
                       }
                        
                    }

                    textBox4.Text = result.ToString();
        }

            

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
