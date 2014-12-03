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
    public partial class Form1 : Form
    {

        BAform b;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SizeLastColumn(listView1);
            
            //GraphBarabasiAlbert graf = new GraphBarabasiAlbert();
            //graf.Generate(30, 3);
            //graf.Text();
            //GraphBarabasiAlbert graf = new GraphBarabasiAlbert();
            //graf.Generate(30, 3);
            //graf.Text();
            GraphNP grafff = new GraphNP();
            grafff.Generate(10, 0.5);
            grafff.Text();
            //GraphNM graff = new GraphNM();
            //graff.Generate(50, 50);

            

        }



        private void nPGrafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void barabasiAlbertGrafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Graf Barabási-Albert",
            "",
            "Generuje sa..."}, -1);
            listView1.Items.Add(listViewItem1);
            GraphBarabasiAlbert graf = new GraphBarabasiAlbert();
            graf.Generate(30, 3);
            b = new BAform(graf,20);
            b.ShowDialog();
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
    }
}
