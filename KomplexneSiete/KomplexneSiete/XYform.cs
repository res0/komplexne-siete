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
    /// <summary>
    /// zabezpečuje vykreslenie xy grafu
    /// </summary>
    public partial class XYform : Form
    {
        // pamätá si či sa zobrazuje log škála grafu true znamená ,že sa nezobrazuje
        Boolean tlacidlo = true;
        // pamätá si vrcholi grafu ktorý analizuje
        List<Node> nodes;
        // pamätá si počet vrcholov z dsaním stupňom
        Dictionary<int,int> d;
        /// <summary>
        /// konštruktor , nepoužíva sa
        /// </summary>
        public XYform()
        {
            InitializeComponent();
        }
        /// <summary>
        /// konsštruktor , incializuje form a do d spočíta početnošt stuňov vrcholov
        /// </summary>
        /// <param name="nd">údaje o grafe ktorý sa má analizovať</param>
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
        /// <summary>
        /// vykreslí graf bez log škáli
        /// </summary>
        /// <param name="sender">nepožíva sa</param>
        /// <param name="e">nepožíva sa</param>
        private void XYform_Load(object sender, EventArgs e)
        {

            List<int> k = new List<int>(d.Keys);
            for (int i = 0; i < k.Count; i++)
            {

                chart1.Series["Vrcholy"].Points.AddXY(d[k[i]], k[i]);
            }
        }
        /// <summary>
        /// na základe hotnoty premennej tlacidlo zobrazí log alebo nolog graf a zmení hodnotu tlacidlo
        /// </summary>
        /// <param name="sender">nepožíva sa</param>
        /// <param name="e">nepožíva sa</param>
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
