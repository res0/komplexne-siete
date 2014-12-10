﻿using System;
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
    public partial class FormNPSetup : Form
    {
        public double p { get; set; }
        public int n { get; set; }
        public FormNPSetup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
        public void ShowMesssage(string text)
        {
            MessageBox.Show(text,"Chyba");
        }
    }
}
