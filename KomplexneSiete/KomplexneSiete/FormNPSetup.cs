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
    /// zistí parametre s akými sa má vygenerovať NP model
    /// </summary>
    public partial class FormNPSetup : Form
    {
        /// <summary>
        /// pravdepodobnosť vytvorenia hrany (0-1)
        /// </summary>
        public double p { get; set; }
        /// <summary>
        /// počet vrcholov grafu
        /// </summary>
        public int n { get; set; }
        /// <summary>
        /// konštruktor
        /// </summary>
        public FormNPSetup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// neudje sa nič
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// po kliknutí na button1 skontroluje zadané hodnoty ak sú správne uloží ich a ukončí form inak ho len ukončí
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var text1 = textBox1.Text;
            var text2 = textBox2.Text.Replace('.',',');
            
            double dabl;
            if (text1.Length > 0 && text2.Length > 0)
            {
                if (Regex.IsMatch(text1, @"^\d+$") && double.TryParse(text2,out dabl))
                {
                    this.p = dabl;
                    this.n = int.Parse(text1);
                    if (p >= 0 && p <= 1)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        ShowMesssage("Pravdepodobnosť musí byť desatinné číslo medzi 0 a 1.");
                    }
                }
                else
                {
                    ShowMesssage("Počet vrcholov musí byť kladné celé číslo.");
                }
            }
            else
            {
                ShowMesssage("Zadajte parametre.");
            }
        }
        /// <summary>
        /// vypíše zadaný text
        /// </summary>
        /// <param name="text">text ktorý sa má vypísať</param>
        public void ShowMesssage(string text)
        {
            MessageBox.Show(text,"Chyba");
        }

        private void FormNPSetup_Load(object sender, EventArgs e)
        {

        }
    }
}
