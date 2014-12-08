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

        Dictionary<int,Graph> graphs;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SizeLastColumn(listView1);
            graphs = new Dictionary<int, Graph>();
            GraphNM graff = new GraphNM();
            graff.Generate(8, 28);
            graff.Text();

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
            //Thread t = new Thread(new ThreadStart(generateBA));
            //t.Start();
            /*b = new BAform(graf.GetNodes(), 20);
            b.ShowDialog();*/
        }

        private void ba_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ba_TestObject data = e.Result as ba_TestObject;

            DateTime date = DateTime.Now;

            listView1.Items[data.index].SubItems[2].Text = "Hotovo.";
            listView1.Items[data.index].SubItems[1].Text = date.ToString("dd. MM. yyyy hh:mm:ss");
            //MessageBox.Show("HAHA");
            graphs.Add(data.index, (Graph)data.graf);
            
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

            Thread.Sleep(2000);
            

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
                b = new BAform(graphs[index].GetNodes(), 20);
                b.ShowDialog();
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
            ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
                "Graf NM",
                "",
                "Generuje sa..."}, -1);
            listView1.Items.Add(listViewItem1);
            BackgroundWorker t = new BackgroundWorker();
            nm_TestObject data = new nm_TestObject();
            data.index = listView1.Items.Count - 1;
            data.n = 100;
            data.m = 50;
            t.DoWork += nm_DoWork;
            t.RunWorkerCompleted += nm_RunWorkerCompleted;
            t.RunWorkerAsync(data);
        }

        private void nm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            nm_TestObject data = e.Result as nm_TestObject;

            DateTime date = DateTime.Now;

            listView1.Items[data.index].SubItems[2].Text = "Hotovo.";
            listView1.Items[data.index].SubItems[1].Text = date.ToString("dd. MM. yyyy hh:mm:ss");
            //MessageBox.Show("HAHA");
            graphs.Add(data.index, (Graph)data.graf);
        }

        private void nm_DoWork(object sender, DoWorkEventArgs e)
        {
            nm_TestObject data = e.Argument as nm_TestObject;

            GraphNM graf = new GraphNM();
            graf.Generate(data.n, data.m);

            data.graf = graf;

            


            e.Result = data;
        }
    }
}
