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
    public partial class XYform : Form
    {
        Boolean tlacidlo = true;
        List<Node> nodes;
        //Dictionary<int,int> d;
        public XYform()
        {
            InitializeComponent();
        }

        public XYform(List<Node> nd)
        {
            InitializeComponent();
            nodes = new List<Node>();
            nodes = nd;
        }

        private void XYform_Load(object sender, EventArgs e)
        {
            var g = nodes;
            for (int i = 0; i < g.Count; i++)
            {
                chart1.Series["Vrcholy"].Points.AddXY(i + 1, g[i].GetDegree());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tlacidlo)
            {
                tlacidlo = false;
                button1.Text = "X/Y";
                chart1.Series["Vrcholy"].Points.Clear();
                var g = nodes;
                for (int i = 0; i < g.Count; i++)
                {
                    if (g[i].GetDegree() != 0)
                    {
                        chart1.Series["Vrcholy"].Points.AddXY(Math.Log(i + 1), Math.Log(g[i].GetDegree()));
                    }
                    else
                    {
                        chart1.Series["Vrcholy"].Points.AddXY(Math.Log(i + 1), Math.Log(0.00000001));
                    }
                }
                chart1.Invalidate();
            }
            else
            {
                var g = nodes;
                button1.Text = "Log X/Y";
                chart1.Series["Vrcholy"].Points.Clear();
                for (int i = 0; i < g.Count; i++)
                {
                    chart1.Series["Vrcholy"].Points.AddXY(i + 1, g[i].GetDegree());
                }
                tlacidlo = true;
            }
        }

    }
}
