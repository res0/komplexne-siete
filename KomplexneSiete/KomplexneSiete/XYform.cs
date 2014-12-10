using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KomplexneSiete
{
    public partial class XYform : Form
    {
        public XYform()
        {
            InitializeComponent();
        }

        private void XYform_Load(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            List<int> vrcholy = new List<int>();
            List<int> hrany = new List<int>();
            Series body = chart.Series.Add("body");
            GraphNP graf = new GraphNP();
            graf.Generate(20, 0.58);
            var g = graf.GetNodes();
            for (int i = 0; i < g.Count; i++)
            {
                vrcholy.Add(i);
                hrany.Add(g[i].GetDegree());
            }
            body.Points.DataBindXY(vrcholy, hrany);
            chart.Show();
        }
    }
}
