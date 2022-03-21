using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using FileSearch;

namespace WindowsFormsApp
{
	public class Window : Form
	{
		private Button button1;
		private Button button2;
		private FolderBrowserDialog folderBrowserDialog1;
		private Label label1;
		private Label labelFolder;
		private Label label2;

		private TextBox textBox1;

        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Label label3;
        private Label Input;
        private Label label4;
        private Label label5;

        private Microsoft.Msagl.Drawing.Graph graph;
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();


        // Inputs
        public string RootFolder = "";
        public string FileName = "";
        public Boolean AllOccurance;
        private Label label6;
        private Label label7;
        private LinkLabel linkLabel1;
        private Label label8;
        public string SearchType;

		public Window()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Location = new System.Drawing.Point(46, 205);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cari";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Choose Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pilih Folder Root:";
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(175, 134);
            this.labelFolder.MaximumSize = new System.Drawing.Size(200, 100);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(111, 17);
            this.labelFolder.TabIndex = 7;
            this.labelFolder.Text = "No File Selected";
            this.labelFolder.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nama File Target:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(46, 249);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(181, 21);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Cari Semua Kemunculan";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DFS",
            "BFS"});
            this.comboBox1.Location = new System.Drawing.Point(46, 311);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(400, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 6000);
            this.label3.TabIndex = 0;
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // Input
            // 
            this.Input.AutoSize = true;
            this.Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input.Location = new System.Drawing.Point(41, 43);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(70, 29);
            this.Input.TabIndex = 11;
            this.Input.Text = "Input";
            this.Input.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Metode Pencarian:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(422, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Output";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(424, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 15;
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(424, 361);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 17);
            this.linkLabel1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(424, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 17;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Window
            // 
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1185, 565);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Window";
            this.Text = "File Crawler";
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Draw_Graph(List<Tuple<string, List<string>>> adj, List<string> blue, List<string> black)
        {
            this.SuspendLayout();
            this.graph = new Microsoft.Msagl.Drawing.Graph("graph");
            if (this.Controls.Contains(viewer)) this.Controls.Remove(viewer);
            this.viewer.Location = new System.Drawing.Point(460, 100);
            this.viewer.Size = new System.Drawing.Size(700, 200);
            this.viewer.ToolBarIsVisible = false;
            foreach (Tuple<string, List<string>> p in adj)
            {
                foreach(string s in p.Item2)
                {
                    if(blue.Contains(p.Item1) &&  blue.Contains(s)) this.graph.AddEdge(p.Item1, s).Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                    else if (black.Contains(s)) this.graph.AddEdge(p.Item1, s).Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                    else this.graph.AddEdge(p.Item1, s).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;

                    this.graph.FindNode(p.Item1).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    if (blue.Contains(p.Item1)) this.graph.FindNode(p.Item1).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
                    if (black.Contains(p.Item1)) this.graph.FindNode(p.Item1).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                    this.graph.FindNode(s).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                    if (blue.Contains(s)) this.graph.FindNode(s).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
                    if (black.Contains(s)) this.graph.FindNode(s).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                }
            }
            viewer.Graph = graph;
            
            this.Controls.Add(viewer);
            this.ResumeLayout();

        }

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
            TextBox objTextBox = (TextBox)sender;
            this.FileName = objTextBox.Text;
		}

		private void Program_Load(object sender, EventArgs e)
		{

		}

		private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{

		}

		private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				this.RootFolder = folderBrowserDialog1.SelectedPath;
				labelFolder.Text = this.RootFolder;
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
            this.FileName = this.textBox1.Text;
            if (this.RootFolder.Length == 0) this.label4.Text = "Folder Root Belum Dipilih!";
            else if (this.FileName.Length == 0) this.label4.Text = "File Target Belum Diisi!";
            else if (this.SearchType != "DFS" && this.SearchType != "BFS") this.label4.Text = "Metode Pencarian Belum Dipilih!";
            else
            {
                //CALL FUNCTION
                this.label4.Text = "Processing...";
                var watch = System.Diagnostics.Stopwatch.StartNew();

                this.SuspendLayout();
                this.Controls.Remove(linkLabel1);
                this.linkLabel1 = new System.Windows.Forms.LinkLabel();
                this.linkLabel1.AutoSize = true;
                this.linkLabel1.Location = new System.Drawing.Point(424, 381);
                this.linkLabel1.Name = "linkLabel1";
                this.linkLabel1.Size = new System.Drawing.Size(0, 17);
                this.linkLabel1.TabIndex = 16;
                this.ResumeLayout();


                if (this.SearchType == "DFS")
                {
                    DepthFirstSearch dfs = new DepthFirstSearch();
                    if (this.AllOccurance)
                    {
                        List<string> listPath = new List<string>();
                        dfs.DFSmanyFile(this.RootFolder,this.FileName,listPath);
                        List<Tuple<string, List<string>>> adj = dfs.getPairNode();

                        // Output
                        this.label4.Text = "Done!";
                        Draw_Graph(adj,dfs.getBlue(), new List<string>());

                        this.SuspendLayout();
                        if (listPath.Count == 0) this.label7.Text = "Tidak ada file yang ditemukan! \n";
                        else
                        {
                            this.label7.Text = "Daftar file yang ditemukan: \n";
                            int cur = 0;
                            foreach (string path in listPath)
                            {
                                this.linkLabel1.Text += path;
                                this.linkLabel1.Links.Add(cur, path.Length, path);
                                this.linkLabel1.Text += "\n";
                                cur += path.Length + 1;
                            }
                            this.linkLabel1.LinkClicked += (a, b) => this.linkLabel1_LinkClicked(a, b);
                        }
                        this.ResumeLayout();
                        
                    }
                    else
                    {
                        string s = dfs.DFSoneFile(this.RootFolder, this.FileName);
                        List<Tuple<string, List<string>>> adj = dfs.getPairNode();

                        // Output
                        this.label4.Text = "Done!";
                        Draw_Graph(adj, dfs.getBlue(), dfs.getBlack());

                        this.SuspendLayout();
                        if (s=="File tidak ditemukan")
                        {
                            this.label7.Text = s;
                        }
                        else
                        {
                            this.label7.Text = "Path File:";
                            this.linkLabel1.Text = s;
                            this.linkLabel1.Links.Add(0, s.Length, s);
                            this.linkLabel1.LinkClicked += (a, b) => this.linkLabel1_LinkClicked(a, b);
                        }
                        this.ResumeLayout();
                    }
                }
                else if (this.SearchType == "BFS")
                {
                    BreadthFirstSearch bfs = new BreadthFirstSearch();
                    if (this.AllOccurance)
                    {
                        List<string> listPath = new List<string>();
                        this.label4.Text = "Done!";
                        bfs.BFSmanyFile(this.RootFolder, this.FileName, listPath);

                        Draw_Graph(bfs.getPairNode(), bfs.getBlue(), bfs.getBlack());

                        this.SuspendLayout();
                        if (listPath.Count == 0) this.label7.Text = "Tidak ada file yang ditemukan! \n";
                        else
                        {
                            this.label7.Text = "Daftar file yang ditemukan: \n";
                            int cur = 0;
                            foreach (string path in listPath)
                            {
                                this.linkLabel1.Text += path;
                                this.linkLabel1.Links.Add(cur, path.Length, path);
                                this.linkLabel1.Text += "\n";
                                cur += path.Length + 1;
                            }
                            this.linkLabel1.LinkClicked += (a, b) => this.linkLabel1_LinkClicked(a, b);
                        }
                        this.ResumeLayout();
                    }
                    else
                    {
                        string s = bfs.BFSoneFile(this.RootFolder, this.FileName);
                        this.label4.Text = "Done!";
                        this.Draw_Graph(bfs.getPairNode(), bfs.getBlue(), bfs.getBlack());

                        this.SuspendLayout();
                        if (s == "File tidak ditemukan")
                        {
                            this.label7.Text = s;
                        }
                        else
                        { 
                            this.label7.Text = "Path File:";
                            this.linkLabel1.Text = s;
                            this.linkLabel1.Links.Add(0, s.Length, s);
                            this.linkLabel1.LinkClicked += (a, b) => this.linkLabel1_LinkClicked(a, b);
                        }
                        this.ResumeLayout();
                    }
                }

                this.SuspendLayout();
                this.Controls.Add(linkLabel1);
                this.ResumeLayout();
                watch.Stop();
                this.label8.Text = "Processing time: " + watch.ElapsedMilliseconds + " ms";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            this.SearchType = objComboBox.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objCheckBox = (CheckBox)sender;
            this.AllOccurance = objCheckBox.Checked;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string dir = (string)e.Link.LinkData;
            int l = dir.Length;
            while (dir[l - 1] != '/' && dir[l - 1] != '\\') l--;
            dir = dir.Substring(0, l-1);
            System.Diagnostics.Process.Start("explorer.exe", dir);
            Console.WriteLine(dir);
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
