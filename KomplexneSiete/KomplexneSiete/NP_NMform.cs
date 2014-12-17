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
    /// zabezpečuje vyzualiazáciu NP a NM modelov
    /// </summary>
    public partial class NP_NMform : Form
    {   
        /// <summary>
        /// graf ktorý sa vyzualizovať
        /// </summary>
        List<Node> graf;
        /// <summary>
        /// ak je vyzalizovaný graf NP ma hodnotu null ak je NM tak obsahuje zoznam bodov v poradí ako sa generovali
        /// </summary>
        List<List<int>> NM;
        /// <summary>
        /// počet krokov ktoré majú byť vizualizované
        /// </summary>
        int steps;
        /// <summary>
        /// súradnice vrcholov pre vykreslenie
        /// </summary>
        List<Point> points;
        /// <summary>
        /// počet milisekúnd ktoré aplikaćia čaká mezi jednotlivými krokmi
        /// </summary>
        int sleep = 700;
        /// <summary>
        /// polomer zobrazovaných kruhov
        /// </summary>
        int r = 7;
        /// <summary>
        /// Graphics pomoco ktoré prebieha vizualizácia dát
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
        /// modrý štetec
        /// </summary>
        private SolidBrush BlueBrush = new SolidBrush(Color.Blue);
        /// <summary>
        /// thread zabezpečujúci vizualizácie
        /// </summary>
        private Thread t;
        /// <summary>
        /// zaznamenáva či je t práve suependnuté alebo nie
        /// </summary>
        private Boolean paused;
        /// <summary>
        /// zaznamenáva či sa vizualizuje NP alebo NM graf
        /// </summary>
        private Boolean NP = false;
        /// <summary>
        /// konštruktor, nepoužíva sa
        /// </summary>
        public NP_NMform()
        {
            InitializeComponent();
        }
        /// <summary>
        /// konštruktor , inicializuje form , a vykreslí východiskový bod vizualizácie
        /// </summary>
        /// <param name="ngraf"> údaje o grafe</param>
        /// <param name="csteps"> počet krokov ktoré sa majú vizualizovať</param>
        /// <param name="cisla">pre NP graf null ,pre NM graf obsahuje zoznam dvojíc bodov východiskových pre jeho vizualizácie</param>
        public NP_NMform(List<Node> ngraf, int csteps, List<List<int>> cisla) 
        {
            InitializeComponent();
            NM = cisla;
            if (cisla == null)
            {
                NP = true;
                r = 5;
            }
            else
            {
                r = 12;
            }
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
        /// <summary>
        /// vygeneruje súradnice vrcholov (podľa elipsi) pre vykreslenie grafu
        /// </summary>
        public void generovanie()
        {
            Point centre = new Point(pictureBox1.Width/2,pictureBox1.Height/2);
            int radius = pictureBox1.Height / 2 - 20;
            int radius1 = pictureBox1.Width / 2 - 20;
            double cn = 360 / (double)graf.Count;
            points = new List<Point>();
            for (int i = 0; i < graf.Count; i++)
			{
                double x = centre.X + radius1 * Math.Cos(2 * Math.PI / 360 * i * cn);
                double y = centre.Y + radius * Math.Sin(2 * Math.PI / 360 * i * cn);
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                g.FillEllipse(BlueBrush, points[points.Count - 1].X, points[points.Count - 1].Y, r, r);
			}
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// vičístí plochu a vykreslí východiskový bod vizualizácie
        /// </summary>
        public void draw_nodes() 
        {
            g.Clear(Color.White);
            for (int i = 0; i < points.Count; i++)
            {
                g.FillEllipse(BlueBrush, points[i].X, points[i].Y, r, r);
            }
        }
        /// <summary>
        /// vizualizuje jeden krok generovania grafumedzi vrcholmi n1 n2
        /// </summary>
        /// <param name="n1"> prvy vrchol</param>
        /// <param name="n2"> druhy vrchol</param>
        public void spracuj_hranu(int n1 , int n2)
        {
            g.FillEllipse(RedBrush, points[n1].X, points[n1].Y, r, r);
            g.FillEllipse(RedBrush, points[n2].X, points[n2].Y, r, r);
            pictureBox1.Invalidate();
            Thread.Sleep(sleep);
            for (int i = 0; i < graf[n1].GetEdges().Count ; i++)
            {
                if (n2 == graf[n1].GetEdges()[i])
                {
                    g.DrawLine(penEdge, points[n1].X + r/2, points[n1].Y + r/2, points[n2].X + r/2, points[n2].Y + r/2);
                    Thread.Sleep(sleep);
                    pictureBox1.Invalidate();
                    break;
                }
            }
            Thread.Sleep(sleep);
            g.FillEllipse(BlueBrush, points[n1].X, points[n1].Y, r, r);
            g.FillEllipse(BlueBrush, points[n2].X, points[n2].Y, r, r);
            pictureBox1.Invalidate();

        }
        /// <summary>
        /// zabezpečuje vykreslenie prvých x krokov generovania grafu NP x = steps
        /// </summary>
        public void draw()
        {
            int pocet = 0;
            draw_nodes();
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
        /// <summary>
        /// zabezpečuje vykreslenie prvých x krokov generovania grafu NM x = steps
        /// </summary>
        public void drawNM() 
        {
            int pocet = 0;
            draw_nodes();
            for (int i = 0; i < NM.Count; i++)
            {
                spracuj_hranu(NM[i][0], NM[i][1]);
                pocet++;
                if (pocet > steps)
                {
                   break;
                }
            }

        }
        /// <summary>
        /// po klinutí na button1 som spustí vizualizácia od začaitku
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
            if (NP)
            {
                t = new Thread(new ThreadStart(draw));
            }
            else 
            {
                t = new Thread(new ThreadStart(drawNM));
            }
            button2.Text = "Pozastaviť";
            paused = false;
            t.Start(); 
        }
        /// <summary>
        /// ak t.IsAlive tak na základe hodnoty premennej paused supendne alebo resumne t
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (t != null)
            {
                if (t.IsAlive && !paused)
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
        /// pri zmene vScrollBar1 sa zmení hodnota sleep
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            sleep = vScrollBar1.Value;
        }
        /// <summary>
        ///  automaticky generovaná metóda , neudeje sa nič
        /// </summary>
        /// <param name="sender">nepoužíva sa</param>
        /// <param name="e">nepoužíva sa</param>
        private void NP_NMform_Load(object sender, EventArgs e)
        {

        }

    }
}
