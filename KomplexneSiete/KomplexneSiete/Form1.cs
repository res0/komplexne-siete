﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomplexneSiete
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Export ce = new Export();
            ce.make_XML_file("test2", new Graph());
            Console.WriteLine("som tu");
            GraphBarabasiAlbert graf = new GraphBarabasiAlbert();
            graf.Generate(30, 5);
            graf.Text();
        }
    }
}
