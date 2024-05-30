using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace frequencyProj
{
    public partial class Form2 : Form
    {
        public string TextBoxValue { get; private set; }
        public List<string> CheckedListBoxItems { get; private set; }

        public Form2()
        {


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
  
        {
            // Get values from TextBox and CheckedListBox
            TextBoxValue = textBox1.Text;
            CheckedListBoxItems = checkedListBox1.CheckedItems.Cast<string>().ToList();

            // Close the SecondForm
            DialogResult = DialogResult.OK;
            Close();
        }
        }
}
