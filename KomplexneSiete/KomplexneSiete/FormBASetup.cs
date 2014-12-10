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
    public partial class FormBASetup : Form
    {

        public int m { get; set; }
        public int n { get; set; }
        public FormBASetup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
    }
}
