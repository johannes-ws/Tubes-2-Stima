using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public class Program: Form
	{
		private Button button1;
		private Button button2;
		private FolderBrowserDialog folderBrowserDialog1;
		private Label label1;
		private Label labelFolder;
		private Label label2;

		private TextBox textBox1;

		private string RootFolder;
		private string FileName;

        public Program()
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
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AcceptsTab = true;
			this.textBox1.Location = new System.Drawing.Point(43, 137);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(214, 31);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(46, 188);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Submit";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(43, 70);
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
			this.label1.Location = new System.Drawing.Point(43, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Pilih Folder Root:";
			// 
			// labelFolder
			// 
			this.labelFolder.AutoSize = true;
			this.labelFolder.Location = new System.Drawing.Point(172, 73);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(111, 17);
			this.labelFolder.TabIndex = 7;
			this.labelFolder.Text = "No File Selected";
			this.labelFolder.Click += new System.EventHandler(this.label2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Nama File Target:";
			// 
			// Program
			// 
			this.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ClientSize = new System.Drawing.Size(800, 451);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Name = "Program";
			this.Text = "File Crawler";
			this.Load += new System.EventHandler(this.Program_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        [STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Program());
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

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
	}
}
