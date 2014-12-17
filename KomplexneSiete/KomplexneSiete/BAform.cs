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
    /// <summary>
    /// form zabezpečujúci vyzualizáciu BA modelu
    /// </summary>
    public partial class BAform : Form
    {
        /// <summary>
        /// zoznam vrcholov grafu ktorý sa má vizualizovať
        /// </summary>
        List<Node> graf;
        /// <summary>
        /// počet krokov ktoré sa majú vizualizovať
        /// </summary>
        int steps;
        /// <summary>
        /// zoznam súradnic vrchlov pre vykreslenie
        /// </summary>
        List<Point> points;
        /// <summary>
        /// polomer vykreslovaného kruhu
        /// </summary>
        int r = 7;
        /// <summary>
        /// počet milisekúnd ktoré program čaká medzi vizualizáciuou jednotlivýcj krokov
        /// </summary>
        int sleep = 700;
        /// <summary>
        /// Graphics používaný na vykresľovanie
        /// </summary>
        private System.Drawing.Graphics g;
        /// <summary>
        /// červené pero
        /// </summary>
        private System.Drawing.Pen penEdge = new System.Drawing.Pen(Color.Red, 1);
        /// <summary>
        /// červený štetec
        /// </summary>
        private SolidBrush RedBrush = new SolidBrush(Color.Red);
        /// <summary>
        /// modrý štretec
        /// </summary>
        private SolidBrush BlueBrush = new SolidBrush(Color.Blue);
        /// <summary>
        /// generátor náhodných čísel
        /// </summary>
        Random rnd = new Random();
        /// <summary>
        /// koľko vrcholov grafu sa má vykresliť hneď
        /// </summary>
        int fund = 0;
        /// <summary>
        /// thread zabezpečujúci vyzualizáciu
        /// </summary>
        Thread t;
        /// <summary>
        /// informácia o tom či je t suspended alebo nie
        /// </summary>
        Boolean paused;
        /// <summary>
        /// konštruktor, nepoužíva sa
        /// </summary>
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
        /// <summary>
        /// konštruktor, inicializuje vizualizáciu
        /// </summary>
        /// <param name="ngraf">graf ktorý sa má vizualizovať</param>
        /// <param name="csteps">počet krokov ktoré sa majú vizualizovať</param>
        /// <param name="start">počet vrcholov ktoré sa majú vkresliť rovno</param>
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
        /// <summary>
        /// vykresí základ grafu
        /// </summary>
        public void drawFund() {
            g.Clear(Color.White);
            for (int i = 0; i <= fund ; i++)
            {
                g.FillEllipse(BlueBrush, points[i].X, points[i].Y, r, r);
                if (graf[i].GetEdges() != null)
                {
                    for (int j = 0; j < graf[i].GetEdges().Count; j++)
                    {
                        g.DrawLine(penEdge, points[i].X + r / 2, points[i].Y + r / 2, points[graf[i].GetEdges()[j]].X + r / 2, points[graf[i].GetEdges()[j]].Y + r / 2);
                    }
                }
            }
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// vizualizuje jeden krok generoania grafu
        /// </summary>
        /// <param name="x"></param>
        public void drawStep(int x)
        {
            g.FillEllipse(RedBrush, points[x].X, points[x].Y, r, r);
            pictureBox1.Invalidate();
            Thread.Sleep(sleep);
            if (graf[x].GetEdges() != null)
            {
                for (int i = 0; i < graf[x].GetEdges().Count; i++)
                {
                    g.DrawLine(penEdge, points[x].X + r / 2, points[x].Y + r / 2, points[graf[x].GetEdges()[i]].X + r / 2, points[graf[x].GetEdges()[i]].Y + r / 2);
                    pictureBox1.Invalidate();
                    Thread.Sleep(sleep);
                }
            }
            g.FillEllipse(BlueBrush, points[x].X, points[x].Y, r, r);
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// postupne vyzualizuje prých x krokov geerovania BA modelu , x = steps
        /// </summary>
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
        /// <summary>
        /// spustí vyzualizáci od začiatku za pomoci t a metód draw() a drawFund()
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
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
            button2.Text = "Pozastaviť";
            t = new Thread(new ThreadStart(draw));
            paused = false;
            t.Start(); 
        }
        /// <summary>
        /// ak t.isAlive je true tak na zálade premmenej paused suspendne alebo resumne t
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (t != null)
            {
                if (t.IsAlive && ! paused) 
                {
                    t.Suspend();
                    button2.Text = "Pokračovať";
                    paused = true;
                }
                else
                {
                    if (t.IsAlive)
                    {
                        t.Resume();
                    }
                    button2.Text = "Pozastaviť";
                    paused = false;
                }
            }
        }
        /// <summary>
        /// vygeneruje súradnice vrcholov grafu pre vykreslovanie
        /// </summary>
        private void generovanie()
        {
            Point centre = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            int radius = pictureBox1.Height / 2 - 35;
            int radius1 = pictureBox1.Width / 2 - 35;
            double cn = 360 / (double) steps;
            points = new List<Point>();
            for (int i = 0; i < graf.Count; i++)
            {
                double x = centre.X + radius1 * Math.Cos(2 * Math.PI / 360 * i * cn);
                double y = centre.Y + radius * Math.Sin(2 * Math.PI / 360 * i * cn);
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
            }
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// pri zmene stavu vScrollBar1 nastavý hodnotu sleep na vScrollBar1.Value
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            sleep = vScrollBar1.Value;
        }
        /// <summary>
        ///  neudeje sa nič
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void BAform_Load(object sender, EventArgs e)
        {

        }
    }
}
