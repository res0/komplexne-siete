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
    /// for krorý získa základné parametre generovania NM modelu
    /// </summary>
    public partial class FormNMSetup : Form
    {
        /// <summary>
        /// počet hrán grafu
        /// </summary>
        public int m { get; set; }
        /// <summary>
        /// počet vrcholov grafu
        /// </summary>
        public int n { get; set; }
        /// <summary>
        /// konštruktor
        /// </summary>
        public FormNMSetup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// skontroluje zadané paramatre ak ak sú v poriadku uloží ich a ukočí formulár
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
                    if (m > (n * (n - 1)) / 2)
                    {
                        ShowMessage("Zadali ste nesprávne hodnoty parametrov.");
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    ShowMessage("Vstupné parametre musia byť len kladné celé čísla.");
                }
            }
            else
            {
                ShowMessage("Zadajte parametre.");
            }
        }
        /// <summary>
        /// zobrazí text
        /// </summary>
        /// <param name="text">text ktorý sa má zobraziť</param>
        public void ShowMessage(string text)
        {
            MessageBox.Show(text,"Chyba");
        }

        private void FormNMSetup_Load(object sender, EventArgs e)
        {

        }
    }
}
