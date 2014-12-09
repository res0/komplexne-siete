using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KomplexneSiete
{
    public partial class FormVizSetup : Form
    {
        public int steps { get; set; }
        public FormVizSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text1 = textBox1.Text;
            
            if (text1.Length > 0)
            {
                if (Regex.IsMatch(text1, @"^\d+$"))
                {
                    this.steps = int.Parse(text1);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    ShowMesssage("Počet krokov musí byť len kladné celé číslo.");
                }
            }
            else
            {
                ShowMesssage("Zadajte počet krokov.");
            }
        }
        public void ShowMesssage(string text)
        {
            MessageBox.Show(text);
        }

        private void FormVizSetup_Load(object sender, EventArgs e)
        {
            textBox1.Text = "20";
        }
    }
}
