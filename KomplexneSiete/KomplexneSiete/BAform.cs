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
    public partial class BAform : Form
    {
        List<Node> graf;
        int steps;
        List<Point> points;
        int d = 75;
        int r = 8;
        private System.Drawing.Graphics g;
        private System.Drawing.Pen penEdge = new System.Drawing.Pen(Color.Blue, 2F);
        private System.Drawing.Pen penNode = new System.Drawing.Pen(Color.Yellow, 10);
        private System.Drawing.Pen penNNode = new System.Drawing.Pen(Color.Red, 10);
        Random rnd = new Random();
        int skok = 0;
        Thread t;
        Boolean paused;
        public BAform()
        {
            InitializeComponent();
            points = new List<Point>();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Visible = true;
            pictureBox1.Show();
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            pictureBox1.Show();
        
        }
        public BAform(List<Node> ngraf , int csteps)
        {
            InitializeComponent();
            points = new List<Point>();
            graf = ngraf;
            steps = csteps;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            pictureBox1.Visible = true;
            pictureBox1.Show();
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            pictureBox1.Show();
        }
        public void drawFund() {
            points.Add(new Point(pictureBox1.Width / 2,pictureBox1.Height/2));
            g.DrawEllipse(penNode, pictureBox1.Width / 2, pictureBox1.Height/2 ,r,r);
            points.Add(new Point(pictureBox1.Width / 2 + d , pictureBox1.Height / 2));
            g.DrawEllipse(penNode, pictureBox1.Width / 2 + d, pictureBox1.Height / 2, r, r);
            points.Add(new Point(pictureBox1.Width / 2, pictureBox1.Height / 2 - d));
            g.DrawEllipse(penNode, pictureBox1.Width / 2, pictureBox1.Height / 2 - d, r, r);
            for (int i = 0; i < 3; i++) 
            {
                Node n = graf[i];
                if (n.GetEdges() != null)
                {
                    for (int j = 0; j < n.GetEdges().Count; j++)
                    {
                        g.DrawLine(penEdge, points[i].X + r / 2, points[i].Y + r / 2, points[n.GetEdges()[j]].X + r / 2, points[n.GetEdges()[j]].Y + r / 2);
                    }
                }
            }
                pictureBox1.Invalidate();
        }
        public void drawStep(int x)
        {
            Node n = graf[x];
            switch (skok)
            {
                case 0:
                    points.Add(new Point(points[points.Count - 1].X - rnd.Next(d, d * 2), points[points.Count - 1].Y));
                    break;
                case 1:
                    points.Add(new Point(points[points.Count - 2].X , points[points.Count - 2].Y + rnd.Next(d, d * 2)));
                    break;
                case 2:
                    points.Add(new Point(points[points.Count - 3].X + rnd.Next(d, d * 2), points[points.Count - 3].Y ));
                    break;
                case 3:
                    points.Add(new Point(points[points.Count - 4].X, points[points.Count - 4].Y - rnd.Next(d, d * 2)));
                    break;
                case 4:
                    points.Add(new Point(points[points.Count - 5].X - rnd.Next(d, d * 2), points[points.Count -5].Y + rnd.Next(d, d * 2)));
                    break;
                case 5:
                    points.Add(new Point(points[points.Count - 6].X + rnd.Next(d, d * 2), points[points.Count  -6].Y - rnd.Next(d, d * 2)));
                    break;

                default:
                    break;
            }
            g.DrawEllipse(penNode, points[points.Count - 2].X, points[points.Count - 2].Y, r, r);
            g.DrawEllipse(penNNode, points[points.Count - 1].X, points[points.Count - 1].Y, r, r);
            pictureBox1.Invalidate();
            Thread.Sleep(700);
            skok++;
            if (skok > 5)
            {
                skok = 0;
            }
            for (int i = 0; i < n.GetEdges().Count; i++) 
            {
                g.DrawLine(penEdge, points[i].X + r / 2, points[i].Y + r / 2, points[x].X + r / 2, points[x].Y + r / 2);
                pictureBox1.Invalidate();
                Thread.Sleep(700);
            }
        }
        public void draw()
        {
            int step = 0;
            skok = 0;
            g.Clear(Color.White);
            points = new List<Point>();
            pictureBox1.Invalidate();
            if (graf.Count > 2)
            {
                drawFund();
                step += 3;
                while (step <= steps && step < graf.Count)
                {
                    drawStep(step);
                    step++;
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
                if (t.IsAlive && ! paused) 
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
