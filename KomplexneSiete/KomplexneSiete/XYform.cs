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
        Dictionary<int,int> d;
        public XYform()
        {
            InitializeComponent();
        }

        public XYform(List<Node> nd)
        {
            InitializeComponent();
            nodes = new List<Node>();
            nodes = nd;
            d = new Dictionary<int, int>();
            for (int i = 0; i < nd.Count; i++) 
            {
                if (d.ContainsKey(nodes[i].GetDegree()))
                {
                    d[nodes[i].GetDegree()]++;
                }
                else
                {
                    d.Add(nodes[i].GetDegree(), 1);
                }
            }
        }

        private void XYform_Load(object sender, EventArgs e)
        {

            List<int> k = new List<int>(d.Keys);
            for (int i = 0; i < k.Count; i++)
            {

                chart1.Series["Vrcholy"].Points.AddXY(d[k[i]], k[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tlacidlo)
            {
                tlacidlo = false;
                button1.Text = "X/Y";
                chart1.Series["Vrcholy"].Points.Clear();
                List<int> k = new List<int>(d.Keys);
                for (int i = 0; i < k.Count; i++)
                {
                    if (k[i] != 0)
                    {
                        chart1.Series["Vrcholy"].Points.AddXY(Math.Log(d[k[i]]), Math.Log(k[i]));
                    }
                    else
                    {
                        chart1.Series["Vrcholy"].Points.AddXY(Math.Log(d[k[i]]), Math.Log(0.00000001));
                    }
                }
                chart1.Invalidate();
            }
            else
            {
                var g = nodes;
                button1.Text = "Log X/Y";
                chart1.Series["Vrcholy"].Points.Clear();
                List<int> k = new List<int>(d.Keys);
                for (int i = 0; i < k.Count; i++)
                {
                    chart1.Series["Vrcholy"].Points.AddXY(d[k[i]], k[i]);
                }
                tlacidlo = true;
            }
        }

    }
}
