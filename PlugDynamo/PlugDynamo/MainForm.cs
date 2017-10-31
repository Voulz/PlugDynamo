using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlugDynamo
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public string DynamoCorePath { get; private set; }

		private void MainForm_Load(object sender, EventArgs e)
		{
			var path = Helper.GetDynamoCoreLocations();
			DynamoCorePath = path.LastOrDefault();
			Console.WriteLine($@"Dynamo Core Path: {DynamoCorePath}");


			if (!string.IsNullOrEmpty(DynamoCorePath)) return;

			btnDynLocal.Enabled = false; btnDynReflection.Enabled = false; btnDynCompile.Enabled = false;
			MessageBox.Show(
				@"No installation of Dynamo Found. Please download and install Dynamo from http://dynamobim.org/download/");
		}

		private void btnDynLocal_Click(object sender, EventArgs e)
		{
			DynReference.DynamoCore.Show(DynamoCorePath);
		}

		private void btnDynReflection_Click(object sender, EventArgs e)
		{
			DynReflection.DynamoCore.Show(DynamoCorePath);
		}

		private void btnDynCompile_Click(object sender, EventArgs e)
		{
			DynCompile.DynamoCore.Show(DynamoCorePath);
		}
	}
}
