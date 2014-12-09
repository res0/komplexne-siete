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
        List<int> degs;
        int steps;
        List<Point> points;
        int r = 7;
        int sleep = 700;
        private System.Drawing.Graphics g;
        private System.Drawing.Pen penEdge = new System.Drawing.Pen(Color.Red, 1);
        private SolidBrush RedBrush = new SolidBrush(Color.Red);
        private SolidBrush BlueBrush = new SolidBrush(Color.Blue);
        Random rnd = new Random();
        int fund = 0;
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
        public BAform(List<Node> ngraf , int csteps , int start)
        {
            InitializeComponent();
            fund = start;
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
            generovanie();
            drawFund();
        }
        public void drawFund() {
            g.Clear(Color.White);
            for (int i = 0; i < steps; i++)
            {
                degs[i] = 0;
            }
                for (int i = 0; i <= fund; i++)
                {
                    g.FillEllipse(BlueBrush, points[i].X, points[i].Y, r, r);
                    if (graf[i].GetEdges() != null)
                    {
                        for (int j = 0; j < graf[i].GetEdges().Count; j++)
                        {
                            g.DrawLine(penEdge, points[i].X + (r + degs[i]) / 2, points[i].Y + (r + degs[i]) / 2,
                                points[graf[i].GetEdges()[j]].X + (r + degs[graf[i].GetEdges()[j]]) / 2, points[graf[i].GetEdges()[j]].Y + (r + degs[graf[i].GetEdges()[j]]) / 2);
                            degs[i]++;
                            degs[graf[i].GetEdges()[j]]++;
                            g.FillEllipse(BlueBrush, points[i].X - degs[i]/2, points[i].Y - degs[i]/2, r + degs[i], r + degs[i]);
                            g.FillEllipse(BlueBrush, points[degs[graf[i].GetEdges()[j]]].X - degs[degs[graf[i].GetEdges()[j]]]/2, points[degs[graf[i].GetEdges()[j]]].Y - degs[degs[graf[i].GetEdges()[j]]]/2,
                                r + degs[degs[graf[i].GetEdges()[j]]], r + degs[degs[graf[i].GetEdges()[j]]]);
                        }
                    }
                }
            pictureBox1.Invalidate();
        }
        public void drawStep(int x)
        {
            g.FillEllipse(RedBrush, points[x].X - degs[x]/2, points[x].Y - degs[x]/2, r + degs[x], r + degs[x]);
            pictureBox1.Invalidate();
            Thread.Sleep(sleep);
            if (graf[x].GetEdges() != null)
            {
                for (int i = 0; i < graf[x].GetEdges().Count; i++)
                {
                    g.DrawLine(penEdge, points[x].X + (r + degs[x]) / 2, points[x].Y + (r + degs[x]) / 2,
                        points[graf[x].GetEdges()[i]].X + (r + degs[graf[x].GetEdges()[i]]) / 2, points[graf[x].GetEdges()[i]].Y + (r + degs[graf[x].GetEdges()[i]]) / 2);
                    degs[x]++;
                    degs[graf[x].GetEdges()[i]]++;
                    g.FillEllipse(RedBrush, points[x].X - degs[x]/2, points[x].Y - degs[x]/2, r + degs[x], r + degs[x]);
                    g.FillEllipse(BlueBrush, points[graf[x].GetEdges()[i]].X - degs[graf[x].GetEdges()[i]]/2, points[graf[x].GetEdges()[i]].Y - degs[graf[x].GetEdges()[i]]/2,
                        r + degs[graf[x].GetEdges()[i]], r + degs[graf[x].GetEdges()[i]]);
                    pictureBox1.Invalidate();
                    Thread.Sleep(sleep);
                }
            }
            g.FillEllipse(BlueBrush, points[x].X - degs[x]/2, points[x].Y - degs[x]/2, r + degs[x], r + degs[x]);
            pictureBox1.Invalidate();
        }
        public void draw()
        {
            int step = fund + 1;
            drawFund();
            while (step < steps && step < graf.Count)
            {
                drawStep(step);
                step++;
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
                    if (t.IsAlive)
                    {
                        t.Resume();
                        button2.Text = "Pozastaviť";
                        paused = false;
                    }
                }
            }
        }
        private void generovanie()
        {
            degs = new List<int>();
            Point centre = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            int radius = pictureBox1.Height / 2 - 20;
            int radius1 = pictureBox1.Width / 2 - 20;
            double cn = 360 / steps;
            points = new List<Point>();
            for (int i = 0; i < steps; i++)
            {
                double x = centre.X + radius1 * Math.Cos(2 * Math.PI / 360 * i * cn);
                double y = centre.Y + radius * Math.Sin(2 * Math.PI / 360 * i * cn);
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                degs.Add(0);
            }
            pictureBox1.Invalidate();
        }
    }
}
