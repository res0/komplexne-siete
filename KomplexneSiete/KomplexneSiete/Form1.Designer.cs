namespace KomplexneSiete
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafBarabásiAlbertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barabásiAlbertGrafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nPGrafToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nMGrafToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vizualizovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xYGrafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generujToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(597, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generujToolStripMenuItem
            // 
            this.generujToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grafBarabásiAlbertToolStripMenuItem});
            this.generujToolStripMenuItem.Name = "generujToolStripMenuItem";
            this.generujToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.generujToolStripMenuItem.Text = "Súbor";
            // 
            // grafBarabásiAlbertToolStripMenuItem
            // 
            this.grafBarabásiAlbertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barabásiAlbertGrafToolStripMenuItem,
            this.nPGrafToolStripMenuItem1,
            this.nMGrafToolStripMenuItem1});
            this.grafBarabásiAlbertToolStripMenuItem.Name = "grafBarabásiAlbertToolStripMenuItem";
            this.grafBarabásiAlbertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grafBarabásiAlbertToolStripMenuItem.Text = "Generuj nový";
            // 
            // barabásiAlbertGrafToolStripMenuItem
            // 
            this.barabásiAlbertGrafToolStripMenuItem.Name = "barabásiAlbertGrafToolStripMenuItem";
            this.barabásiAlbertGrafToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.barabásiAlbertGrafToolStripMenuItem.Text = "Barabási-Albert graf";
            this.barabásiAlbertGrafToolStripMenuItem.Click += new System.EventHandler(this.barabasiAlbertGrafToolStripMenuItem_Click);
            // 
            // nPGrafToolStripMenuItem1
            // 
            this.nPGrafToolStripMenuItem1.Name = "nPGrafToolStripMenuItem1";
            this.nPGrafToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.nPGrafToolStripMenuItem1.Text = "NP Graf";
            this.nPGrafToolStripMenuItem1.Click += new System.EventHandler(this.nPGrafToolStripMenuItem1_Click);
            // 
            // nMGrafToolStripMenuItem1
            // 
            this.nMGrafToolStripMenuItem1.Name = "nMGrafToolStripMenuItem1";
            this.nMGrafToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.nMGrafToolStripMenuItem1.Text = "NM Graf";
            this.nMGrafToolStripMenuItem1.Click += new System.EventHandler(this.nMGrafToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgrameToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.helpToolStripMenuItem.Text = "Pomoc";
            // 
            // oProgrameToolStripMenuItem
            // 
            this.oProgrameToolStripMenuItem.Name = "oProgrameToolStripMenuItem";
            this.oProgrameToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.oProgrameToolStripMenuItem.Text = "O programe";
            this.oProgrameToolStripMenuItem.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(597, 168);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Graf";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Čas vygenerovania";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stav";
            this.columnHeader3.Width = 160;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vizualizovatToolStripMenuItem,
            this.xYGrafToolStripMenuItem,
            this.exportovatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // vizualizovatToolStripMenuItem
            // 
            this.vizualizovatToolStripMenuItem.Name = "vizualizovatToolStripMenuItem";
            this.vizualizovatToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.vizualizovatToolStripMenuItem.Text = "Vizualizovat";
            this.vizualizovatToolStripMenuItem.Click += new System.EventHandler(this.vizualizovatToolStripMenuItem_Click);
            // 
            // xYGrafToolStripMenuItem
            // 
            this.xYGrafToolStripMenuItem.Name = "xYGrafToolStripMenuItem";
            this.xYGrafToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.xYGrafToolStripMenuItem.Text = "XY graf";
            this.xYGrafToolStripMenuItem.Click += new System.EventHandler(this.xYGrafToolStripMenuItem_Click);
            // 
            // exportovatToolStripMenuItem
            // 
            this.exportovatToolStripMenuItem.Name = "exportovatToolStripMenuItem";
            this.exportovatToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportovatToolStripMenuItem.Text = "Exportovat";
            this.exportovatToolStripMenuItem.Click += new System.EventHandler(this.exportovatToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 192);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Komplexné siete";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grafBarabásiAlbertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barabásiAlbertGrafToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nPGrafToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nMGrafToolStripMenuItem1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vizualizovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportovatToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem xYGrafToolStripMenuItem;
    }
}

