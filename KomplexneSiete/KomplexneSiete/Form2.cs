using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomplexneSiete
{
    public partial class Form2 : Form
    {
        public string meno = "novy_graf";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            meno = textBox1.Text.ToString();
            this.Close();
        }
    }
}
