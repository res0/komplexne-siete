using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KomplexneSiete
{
    public partial class NP_NMform : Form
    {
        List<Node> graf;
        int steps;
        List<Point> points;
        private System.Drawing.Graphics g;
        private System.Drawing.Pen penEdge = new System.Drawing.Pen(Color.Blue, 2F);
        private System.Drawing.Pen penNode = new System.Drawing.Pen(Color.Yellow, 10);
        private System.Drawing.Pen penNNode = new System.Drawing.Pen(Color.Red, 10);
        private Thread t;
        private Boolean paused;
        public NP_NMform()
        {
            InitializeComponent();
        }
        public NP_NMform(List<Node> ngraf, int csteps) 
        {
            InitializeComponent();
            points = new List<Point>();
            graf = ngraf;
            steps = csteps;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Visible = true;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            pictureBox1.Show();
            generovanie();
        }
        public void generovanie()
        {
            Point centre = new Point(pictureBox1.Width/2,pictureBox1.Height/2);
            int radius = pictureBox1.Height / 2 - 20;
            double cn = 360 / graf.Count;
            points = new List<Point>();
            for (int i = 0; i < graf.Count; i++)
			{
                double x = centre.X + radius * Math.Cos(2 * Math.PI / 360 * i * cn);
                double y = centre.Y + radius * Math.Sin(2 * Math.PI / 360 * i *  cn);
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                g.DrawEllipse(penNode, points[points.Count - 1].X, points[points.Count - 1].Y, 3, 3);
			}
            pictureBox1.Invalidate();
        }

        public void spracuj_hranu(int n1 , int n2)
        {
            g.DrawEllipse(penNNode, points[n1].X, points[n1].Y, 2  , 2);
            g.DrawEllipse(penNNode, points[n2].X, points[n2].Y, 2, 2);
            pictureBox1.Invalidate();
            Thread.Sleep(700);
            for (int i = 0; i < graf[n1].GetEdges().Count ; i++)
            {
                if (n2 == graf[n1].GetEdges()[i])
                {
                    g.DrawLine(penEdge, points[n1].X - 1, points[n1].Y - 1, points[n2].X - 1, points[n2].Y - 1);
                    pictureBox1.Invalidate();
                    break;
                }
            }
            Thread.Sleep(700);
            g.DrawEllipse(penNode, points[n1].X, points[n1].Y, 2, 2);
            g.DrawEllipse(penNode, points[n2].X, points[n2].Y, 2, 2);
            pictureBox1.Invalidate();

        }
        public void draw()
        {
            int pocet = 0;
                for (int i = 0; i < graf.Count; i++)
                {
                    if (pocet > steps)
                    {
                        break;
                    }
                    for (int j = i + 1; j < graf.Count; j++)
                    {
                        spracuj_hranu(i, j);
                        pocet++;
                        if (pocet > steps)
                        {
                            break;
                        }
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t != null && t.IsAlive)
            {
                if (paused)
                {
                    t.Resume();
                }
                t.Abort();
            }
            t = new Thread(new ThreadStart(draw));
            paused = false;
            t.Start(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (t != null)
            {
                if (t.IsAlive && !paused)
                {
                    t.Suspend();
                    button2.Text = "Pokačovať";
                    paused = true;
                }
                else
                {
                    t.Resume();
                    button2.Text = "Pozastaviť";
                    paused = false;
                }
            }

        }

    }
}
