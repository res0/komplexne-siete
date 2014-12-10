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
    public partial class Form1 : Form
    {

        BAform b;

        Dictionary<int,GraphItem> graphs;
        public Form1()
        {
            InitializeComponent();
        }

        class GraphItem
        {
            public static int BA = 1;
            public static int NM = 2;
            public static int NP = 3;
            public Graph graph { get; set; }
            public int type;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*SizeLastColumn(listView1);
            graphs = new Dictionary<int, GraphItem>();

            GraphNP graf = new GraphNP();
            graf.Generate(20, 0.5);
            graf.Text();
            
            NP_NMform asd = new NP_NMform(graf.GetNodes(), 10);
            asd.ShowDialog();
            Console.Write("asdffdg");*/
            //XYform asd = new XYform();
            //asd.ShowDialog();
        }



        private void nPGrafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void barabasiAlbertGrafToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
            FormBASetup fba = new FormBASetup();
            if (fba.ShowDialog() == DialogResult.OK)
            {
                ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
                "Graf Barabási-Albert (n="+fba.n.ToString()+", m="+fba.m.ToString()+")",
                "",
                "Generuje sa..."}, -1);
                
                listView1.Items.Add(listViewItem1);
                //MessageBox.Show("Supeer! " + fba.m.ToString()+" / "+fba.n.ToString());

                /**Thread t = new Thread(() => generateBA(fba.n,fba.m,listView1.Items.Count-1));
                t.Start();*/

                ba_TestObject data = new ba_TestObject();
                data.n = fba.n;
                data.m = fba.m;
                data.index = listView1.Items.Count - 1;
                BackgroundWorker t = new BackgroundWorker();
                t.DoWork += ba_DoWork;
                t.RunWorkerCompleted += ba_RunWorkerCompleted;
                t.RunWorkerAsync(data);

            }
        }

        private void ba_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ba_TestObject data = e.Result as ba_TestObject;

            DateTime date = DateTime.Now;

            listView1.Items[data.index].SubItems[2].Text = "Hotovo.";
            listView1.Items[data.index].SubItems[1].Text = date.ToString("dd. MM. yyyy hh:mm:ss");
            //MessageBox.Show("HAHA");

            GraphItem item = new GraphItem();
            item.graph = (Graph)data.graf;
            item.type = GraphItem.BA;

            graphs.Add(data.index, item);
            
        }
        class ba_TestObject
        {
            public int n { get; set; }
            public int m { get; set; }
            public int index { get; set; }

            public GraphBarabasiAlbert graf { get; set; }
        }
        private void ba_DoWork(object sender, DoWorkEventArgs e)
        {
            ba_TestObject data = e.Argument as ba_TestObject;

            GraphBarabasiAlbert graf = new GraphBarabasiAlbert();
            graf.Generate(data.n, data.m);

            data.graf = graf;
            e.Result = data;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            SizeLastColumn(listView1);
        }
        private void SizeLastColumn(ListView lv)
        {
            lv.Columns[lv.Columns.Count - 1].Width = -2;
        }

        

        

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            } 
        }

        private void vizualizovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            int index = listView1.FocusedItem.Index;
            if (graphs.ContainsKey(index))
            {

                FormVizSetup fviz = new FormVizSetup();
                if (fviz.ShowDialog() == DialogResult.OK)
                {
                    var g = graphs[index];
                    if (g.type == GraphItem.BA)
                    {
                        b = new BAform(g.graph.GetNodes(), fviz.steps,g.graph.m);
                        b.ShowDialog();
                    }
                    else if (g.type == GraphItem.NM)
                    {
                        var b = new NP_NMform(g.graph.GetNodes(), fviz.steps, g.graph.dict);
                        b.ShowDialog();
                    }
                    else if (g.type == GraphItem.NP)
                    {
                        var b = new NP_NMform(g.graph.GetNodes(), fviz.steps, g.graph.dict);
                        b.ShowDialog();
                    }

                }


            }
            else
            {
                MessageBox.Show("Vizualizáciu je možné zrealizovať až po dokončení generovania.","Nemožno vizualizovať");
            }
        }
        class nm_TestObject
        {
            public int n { get; set; }
            public int m { get; set; }
            public int index { get; set; }

            public GraphNM graf { get; set; }
        }
        private void nMGrafToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormNMSetup fnm = new FormNMSetup();

            if (fnm.ShowDialog() == DialogResult.OK)
            {
                ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
                "Graf NM (n="+fnm.n.ToString()+", m="+fnm.m.ToString()+")",
                "",
                "Generuje sa..."}, -1);
                listView1.Items.Add(listViewItem1);
                BackgroundWorker t = new BackgroundWorker();
                nm_TestObject data = new nm_TestObject();
                data.index = listView1.Items.Count - 1;
                data.n = fnm.n;
                data.m = fnm.m;
                t.DoWork += nm_DoWork;
                t.RunWorkerCompleted += nm_RunWorkerCompleted;
                t.RunWorkerAsync(data);
            }
        }

        

        private void nm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            nm_TestObject data = e.Result as nm_TestObject;

            DateTime date = DateTime.Now;

            listView1.Items[data.index].SubItems[2].Text = "Hotovo.";
            listView1.Items[data.index].SubItems[1].Text = date.ToString("dd. MM. yyyy hh:mm:ss");

            GraphItem item = new GraphItem();
            item.graph = (Graph)data.graf;
            item.type = GraphItem.NM;

            graphs.Add(data.index, item);
        }

        private void nm_DoWork(object sender, DoWorkEventArgs e)
        {
            nm_TestObject data = e.Argument as nm_TestObject;

            GraphNM graf = new GraphNM();
            graf.Generate(data.n, data.m);

            data.graf = graf;

            e.Result = data;
        }


        class np_TestObject
        {
            public int n { get; set; }
            public double p { get; set; }
            public int index { get; set; }

            public GraphNP graf { get; set; }
        }
        private void nPGrafToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormNPSetup fnp = new FormNPSetup();

            if (fnp.ShowDialog() == DialogResult.OK)
            {
                ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
                "Graf NP (n="+fnp.n.ToString()+", p="+fnp.p.ToString()+")",
                "",
                "Generuje sa..."}, -1);
                listView1.Items.Add(listViewItem1);
                BackgroundWorker t = new BackgroundWorker();
                np_TestObject data = new np_TestObject();
                data.index = listView1.Items.Count - 1;
                data.n = fnp.n;
                data.p = fnp.p;
                t.DoWork += np_DoWork;
                t.RunWorkerCompleted += np_RunWorkerCompleted;
                t.RunWorkerAsync(data);
            }
        }

        private void np_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            np_TestObject data = e.Result as np_TestObject;

            DateTime date = DateTime.Now;

            listView1.Items[data.index].SubItems[2].Text = "Hotovo.";
            listView1.Items[data.index].SubItems[1].Text = date.ToString("dd. MM. yyyy hh:mm:ss");

            GraphItem item = new GraphItem();
            item.graph = (Graph)data.graf;
            item.type = GraphItem.NP;

            graphs.Add(data.index, item);
        }

        private void np_DoWork(object sender, DoWorkEventArgs e)
        {
            np_TestObject data = e.Argument as np_TestObject;

            GraphNP graf = new GraphNP();
            graf.Generate(data.n, data.p);

            data.graf = graf;

            e.Result = data;
        }

        private void exportovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            if (graphs.ContainsKey(index))
            {
                //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
                saveFileDialog1.Title = "Uložiť Graf";
                saveFileDialog1.ShowDialog();
                var g = graphs[index];
                Export ex = new Export();
                ex.make_XML_file(saveFileDialog1.FileName, g.graph);
            }
        }
    }
}
