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
    public partial class BAform : Form
    {
        Graph graf;
        int steps;
        List<Point> points;
        int d = 75;
        int r = 10;
        private System.Drawing.Graphics g;
        private System.Drawing.Pen penEdge = new System.Drawing.Pen(Color.Blue, 2F);
        private System.Drawing.Pen penNode = new System.Drawing.Pen(Color.Red, 10);
        Random rnd = new Random();
        int skok = 0;
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
        public BAform(Graph ngraf , int csteps)
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
            draw();
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
                Node n = graf.GetNodes()[i];
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
            Node n = graf.GetNodes()[x];
            switch (skok)
            {
                case 0:
                    points.Add(new Point(points[points.Count-1].X - d, points[points.Count-1].Y));
                    break;
                case 1:
                    points.Add(new Point(points[points.Count-1].X, points[points.Count-1].X + d ));
                    break;
                case 2:
                    points.Add(new Point(points[points.Count - 1].X + d, points[points.Count - 1].X));
                    break;
                case 3:
                    points.Add(new Point(points[points.Count - 1].X, points[points.Count - 1].X - d));
                    break;
                default:
                    break;
            }
            g.DrawEllipse(penNode, points[points.Count - 1].X, points[points.Count - 1].Y, r, r);
            skok++;
            if (skok > 3)
            {
                skok = 0;
            }
            for (int i = 0; i < n.GetEdges().Count; i++) 
            {
                g.DrawLine(penEdge, points[i].X + r / 2, points[i].Y + r / 2, points[x].X + r / 2, points[x].Y + r / 2);
                //System.Threading.Thread.Sleep(500);
            }
        }
        public void draw()
        {
            int step = 0;
            if (graf.GetNodes().Count > 2)
            {
                drawFund();
                step += 3;
                while (step <= steps && step < graf.GetNodes().Count)
                {
                    drawStep(step);
                    step++;
                }

            }
        }
    }
}
