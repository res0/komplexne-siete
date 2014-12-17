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
    /// <summary>
    /// from ktorý ziskava paramtre pre generovanie BA modelu
    /// </summary>
    public partial class FormBASetup : Form
    {
        /// <summary>
        /// začiatočný počet vrcholov
        /// </summary>
        public int m { get; set; }
        /// <summary>
        /// počet vrcholov
        /// </summary>
        public int n { get; set; }
        /// <summary>
        /// konštruktor
        /// </summary>
        public FormBASetup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// po klinutí na button1 skotroluje zadané parametre a ak sú v poriadku uloží ich a ukončí sa
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var text1 = textBox1.Text;
            var text2 = textBox2.Text;
            if (text1.Length > 0 && text2.Length > 0)
            {
                if (Regex.IsMatch(text1 + text2, @"^\d+$"))
                {
                    this.m = int.Parse(text2);
                    this.n = int.Parse(text1);
                    if (this.n > this.m)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        ShowMesssage("Počet vrcholov musí byť väčší ako počet hrán.");
                    }
                    
                }
                else
                {
                    ShowMesssage("Vstupné parametre musia byť len kladné celé čísla.");
                }
            }
            else
            {
                ShowMesssage("Zadajte parametre.");
            }
        }
        public void ShowMesssage(string text, string caption="")
        {
            MessageBox.Show(text,caption);
        }

        private void FormBASetup_Load(object sender, EventArgs e)
        {

        }
    }
}
