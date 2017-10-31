namespace PlugDynamo
{
	partial class MainForm
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
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.GroupBox groupBox3;
			System.Windows.Forms.Label label3;
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnDynLocal = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnDynReflection = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.btnDynCompile = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label2 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			label3 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			groupBox2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			groupBox3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(this.tableLayoutPanel2);
			groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBox1.Location = new System.Drawing.Point(3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(673, 147);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Option 1: Local References";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.Controls.Add(label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnDynLocal, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(667, 128);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// label1
			// 
			label1.Dock = System.Windows.Forms.DockStyle.Fill;
			label1.Location = new System.Drawing.Point(3, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(561, 98);
			label1.TabIndex = 0;
			label1.Text = resources.GetString("label1.Text");
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDynLocal
			// 
			this.btnDynLocal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDynLocal.Location = new System.Drawing.Point(570, 101);
			this.btnDynLocal.Name = "btnDynLocal";
			this.btnDynLocal.Size = new System.Drawing.Size(94, 24);
			this.btnDynLocal.TabIndex = 1;
			this.btnDynLocal.Text = "Start Dynamo";
			this.btnDynLocal.UseVisualStyleBackColor = true;
			this.btnDynLocal.Click += new System.EventHandler(this.btnDynLocal_Click);
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this.tableLayoutPanel3);
			groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBox2.Location = new System.Drawing.Point(3, 156);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(673, 147);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Option 2: Reflection";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel3.Controls.Add(label2, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnDynReflection, 1, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(667, 128);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// label2
			// 
			label2.Dock = System.Windows.Forms.DockStyle.Fill;
			label2.Location = new System.Drawing.Point(3, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(561, 98);
			label2.TabIndex = 0;
			label2.Text = resources.GetString("label2.Text");
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDynReflection
			// 
			this.btnDynReflection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDynReflection.Location = new System.Drawing.Point(570, 101);
			this.btnDynReflection.Name = "btnDynReflection";
			this.btnDynReflection.Size = new System.Drawing.Size(94, 24);
			this.btnDynReflection.TabIndex = 1;
			this.btnDynReflection.Text = "Start Dynamo";
			this.btnDynReflection.UseVisualStyleBackColor = true;
			this.btnDynReflection.Click += new System.EventHandler(this.btnDynReflection_Click);
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(this.tableLayoutPanel4);
			groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBox3.Location = new System.Drawing.Point(3, 309);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(673, 147);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "Option 3: Compile at Runtime";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel4.Controls.Add(label3, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.btnDynCompile, 1, 1);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(667, 128);
			this.tableLayoutPanel4.TabIndex = 1;
			// 
			// label3
			// 
			label3.Dock = System.Windows.Forms.DockStyle.Fill;
			label3.Location = new System.Drawing.Point(3, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(561, 98);
			label3.TabIndex = 0;
			label3.Text = resources.GetString("label3.Text");
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDynCompile
			// 
			this.btnDynCompile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDynCompile.Location = new System.Drawing.Point(570, 101);
			this.btnDynCompile.Name = "btnDynCompile";
			this.btnDynCompile.Size = new System.Drawing.Size(94, 24);
			this.btnDynCompile.TabIndex = 1;
			this.btnDynCompile.Text = "Start Dynamo";
			this.btnDynCompile.UseVisualStyleBackColor = true;
			this.btnDynCompile.Click += new System.EventHandler(this.btnDynCompile_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(groupBox3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 459);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 459);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Plug Dynamo";
			this.Load += new System.EventHandler(this.MainForm_Load);
			groupBox1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnDynLocal;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Button btnDynCompile;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnDynReflection;
	}
}

