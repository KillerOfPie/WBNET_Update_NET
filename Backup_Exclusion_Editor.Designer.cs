using System.Windows.Forms;

namespace WBNET_Updater
{
	partial class Backup_Exclusion_Editor
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
			this.Exclusion_List = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.List_Label = new System.Windows.Forms.Label();
			this.Text_To_Add = new System.Windows.Forms.TextBox();
			this.Add_To_List = new System.Windows.Forms.Button();
			this.Accept = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Select_All = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Exclusion_List
			// 
			this.Exclusion_List.CheckOnClick = true;
			this.Exclusion_List.Location = new System.Drawing.Point(23, 68);
			this.Exclusion_List.Name = "Exclusion_List";
			this.Exclusion_List.Size = new System.Drawing.Size(231, 199);
			this.Exclusion_List.TabIndex = 0;
			this.toolTip1.SetToolTip(this.Exclusion_List, "Unchecked items will be removed from the list.");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Add new items here, any \" or spaces will be removed";
			// 
			// List_Label
			// 
			this.List_Label.AutoSize = true;
			this.List_Label.Location = new System.Drawing.Point(12, 52);
			this.List_Label.Name = "List_Label";
			this.List_Label.Size = new System.Drawing.Size(177, 13);
			this.List_Label.TabIndex = 2;
			this.List_Label.Text = "Items to be exluded from {list-name}.";
			// 
			// Text_To_Add
			// 
			this.Text_To_Add.Location = new System.Drawing.Point(23, 25);
			this.Text_To_Add.Name = "Text_To_Add";
			this.Text_To_Add.Size = new System.Drawing.Size(158, 20);
			this.Text_To_Add.TabIndex = 3;
			this.Text_To_Add.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_To_Add_Enter);
			// 
			// Add_To_List
			// 
			this.Add_To_List.Location = new System.Drawing.Point(187, 24);
			this.Add_To_List.Name = "Add_To_List";
			this.Add_To_List.Size = new System.Drawing.Size(67, 20);
			this.Add_To_List.TabIndex = 4;
			this.Add_To_List.Text = "Add to List";
			this.Add_To_List.UseVisualStyleBackColor = true;
			this.Add_To_List.Click += new System.EventHandler(this.Add_To_List_Click);
			// 
			// Accept
			// 
			this.Accept.Location = new System.Drawing.Point(193, 301);
			this.Accept.Name = "Accept";
			this.Accept.Size = new System.Drawing.Size(75, 23);
			this.Accept.TabIndex = 5;
			this.Accept.Text = "Accept";
			this.Accept.UseVisualStyleBackColor = true;
			this.Accept.Click += new System.EventHandler(this.Accept_Click);
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(112, 301);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// Select_All
			// 
			this.Select_All.Location = new System.Drawing.Point(23, 274);
			this.Select_All.Name = "Select_All";
			this.Select_All.Size = new System.Drawing.Size(70, 22);
			this.Select_All.TabIndex = 7;
			this.Select_All.Text = "Select All";
			this.Select_All.UseVisualStyleBackColor = true;
			this.Select_All.Click += new System.EventHandler(this.Select_All_Click);
			// 
			// Backup_Exclusion_Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(281, 337);
			this.ControlBox = false;
			this.Controls.Add(this.Select_All);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Accept);
			this.Controls.Add(this.Add_To_List);
			this.Controls.Add(this.Text_To_Add);
			this.Controls.Add(this.List_Label);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Exclusion_List);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Backup_Exclusion_Editor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Backup_Exclusion_Editor";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox Exclusion_List;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label List_Label;
		private System.Windows.Forms.TextBox Text_To_Add;
		private System.Windows.Forms.Button Add_To_List;
		private System.Windows.Forms.Button Accept;
		private System.Windows.Forms.Button Cancel;
		private Button Select_All;
	}
}