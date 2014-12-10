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
        public XYform()
        {
            InitializeComponent();
        }

        private void XYform_Load(object sender, EventArgs e)
        {
            GraphNP graf = new GraphNP();
            graf.Generate(100, 0.2);
            var g = graf.GetNodes();
            for (int i = 0; i < g.Count; i++)
            {
                chart1.Series["Vrcholy"].Points.AddXY(i+1, g[i].GetDegree());
            }
        }

    }
}
