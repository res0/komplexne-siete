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
    /// form ktorý zisťuje počet krokov ktoré chce používateľ vizualizovať
    /// </summary>
    public partial class FormVizSetup : Form
    {
        /// <summary>
        /// počet krokov ktoré chce používateľ vizualizovať
        /// </summary>
        public int steps { get; set; }
        /// <summary>
        /// konštruktor
        /// </summary>
        public FormVizSetup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// po kliknutí na button1 skontroluje či zadané číslo je správne ak je tak steps nastaví naň a zavrie form inak zobrazí dialóg
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
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
        /// <summary>
        /// zobrazí správu text
        /// </summary>
        /// <param name="text">teˇxt ktorý sa má zobraziť</param>
        public void ShowMesssage(string text)
        {
            MessageBox.Show(text);
        }
        /// <summary>
        ///  nastvý pôvodný počet ktokov na 20
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void FormVizSetup_Load(object sender, EventArgs e)
        {
            textBox1.Text = "20";
        }
    }
}
