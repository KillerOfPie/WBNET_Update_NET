namespace WBNET_Updater
{
	partial class Path_Update_Dialog
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
			this.WB_Net_Path = new System.Windows.Forms.TextBox();
			this.WB_Net_Path_Browse = new System.Windows.Forms.Button();
			this.WB_Dir_Group = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Edit = new System.Windows.Forms.Button();
			this.Update_Paths = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.Close_Screen = new System.Windows.Forms.Button();
			this.Source_Dir_Group = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Source_Path_Browse = new System.Windows.Forms.Button();
			this.Source_Path = new System.Windows.Forms.TextBox();
			this.Backup_Dir_Group = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Backup_Path_Browse = new System.Windows.Forms.Button();
			this.Backup_Path = new System.Windows.Forms.TextBox();
			this.WB_Dir_Group.SuspendLayout();
			this.Source_Dir_Group.SuspendLayout();
			this.Backup_Dir_Group.SuspendLayout();
			this.SuspendLayout();
			// 
			// WB_Net_Path
			// 
			this.WB_Net_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WB_Net_Path.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.WB_Net_Path.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.WB_Net_Path.Location = new System.Drawing.Point(94, 11);
			this.WB_Net_Path.Name = "WB_Net_Path";
			this.WB_Net_Path.Size = new System.Drawing.Size(418, 20);
			this.WB_Net_Path.TabIndex = 0;
			this.WB_Net_Path.WordWrap = false;
			// 
			// WB_Net_Path_Browse
			// 
			this.WB_Net_Path_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.WB_Net_Path_Browse.Location = new System.Drawing.Point(512, 10);
			this.WB_Net_Path_Browse.Margin = new System.Windows.Forms.Padding(0);
			this.WB_Net_Path_Browse.Name = "WB_Net_Path_Browse";
			this.WB_Net_Path_Browse.Size = new System.Drawing.Size(24, 22);
			this.WB_Net_Path_Browse.TabIndex = 2;
			this.WB_Net_Path_Browse.Text = "...";
			this.WB_Net_Path_Browse.UseVisualStyleBackColor = true;
			this.WB_Net_Path_Browse.Click += new System.EventHandler(this.WB_Net_Path_Browse_Click);
			// 
			// WB_Dir_Group
			// 
			this.WB_Dir_Group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WB_Dir_Group.Controls.Add(this.label1);
			this.WB_Dir_Group.Controls.Add(this.WB_Net_Path_Browse);
			this.WB_Dir_Group.Controls.Add(this.WB_Net_Path);
			this.WB_Dir_Group.Location = new System.Drawing.Point(12, 12);
			this.WB_Dir_Group.Name = "WB_Dir_Group";
			this.WB_Dir_Group.Size = new System.Drawing.Size(541, 37);
			this.WB_Dir_Group.TabIndex = 3;
			this.WB_Dir_Group.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = " WinBill Path Dir";
			// 
			// Edit
			// 
			this.Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Edit.Location = new System.Drawing.Point(237, 153);
			this.Edit.Name = "Edit";
			this.Edit.Size = new System.Drawing.Size(75, 23);
			this.Edit.TabIndex = 4;
			this.Edit.Text = "Edit";
			this.Edit.UseVisualStyleBackColor = true;
			this.Edit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// Update_Paths
			// 
			this.Update_Paths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Update_Paths.Location = new System.Drawing.Point(318, 153);
			this.Update_Paths.Name = "Update_Paths";
			this.Update_Paths.Size = new System.Drawing.Size(75, 23);
			this.Update_Paths.TabIndex = 5;
			this.Update_Paths.Text = "Update";
			this.Update_Paths.UseVisualStyleBackColor = true;
			this.Update_Paths.Click += new System.EventHandler(this.Update_Click);
			// 
			// Cancel
			// 
			this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel.Location = new System.Drawing.Point(399, 153);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// Close_Screen
			// 
			this.Close_Screen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Close_Screen.Location = new System.Drawing.Point(480, 153);
			this.Close_Screen.Name = "Close_Screen";
			this.Close_Screen.Size = new System.Drawing.Size(75, 23);
			this.Close_Screen.TabIndex = 7;
			this.Close_Screen.Text = "Close";
			this.Close_Screen.UseVisualStyleBackColor = true;
			this.Close_Screen.Click += new System.EventHandler(this.Close_Click);
			// 
			// Source_Dir_Group
			// 
			this.Source_Dir_Group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Source_Dir_Group.Controls.Add(this.label2);
			this.Source_Dir_Group.Controls.Add(this.Source_Path_Browse);
			this.Source_Dir_Group.Controls.Add(this.Source_Path);
			this.Source_Dir_Group.Location = new System.Drawing.Point(12, 98);
			this.Source_Dir_Group.Name = "Source_Dir_Group";
			this.Source_Dir_Group.Size = new System.Drawing.Size(541, 37);
			this.Source_Dir_Group.TabIndex = 8;
			this.Source_Dir_Group.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Source Path Dir";
			// 
			// Source_Path_Browse
			// 
			this.Source_Path_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Source_Path_Browse.Location = new System.Drawing.Point(512, 10);
			this.Source_Path_Browse.Margin = new System.Windows.Forms.Padding(0);
			this.Source_Path_Browse.Name = "Source_Path_Browse";
			this.Source_Path_Browse.Size = new System.Drawing.Size(24, 22);
			this.Source_Path_Browse.TabIndex = 2;
			this.Source_Path_Browse.Text = "...";
			this.Source_Path_Browse.UseVisualStyleBackColor = true;
			this.Source_Path_Browse.Click += new System.EventHandler(this.Source_Path_Browse_Click);
			// 
			// Source_Path
			// 
			this.Source_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Source_Path.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.Source_Path.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.Source_Path.Location = new System.Drawing.Point(94, 11);
			this.Source_Path.Name = "Source_Path";
			this.Source_Path.Size = new System.Drawing.Size(418, 20);
			this.Source_Path.TabIndex = 0;
			this.Source_Path.WordWrap = false;
			// 
			// Backup_Dir_Group
			// 
			this.Backup_Dir_Group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Backup_Dir_Group.Controls.Add(this.label3);
			this.Backup_Dir_Group.Controls.Add(this.Backup_Path_Browse);
			this.Backup_Dir_Group.Controls.Add(this.Backup_Path);
			this.Backup_Dir_Group.Location = new System.Drawing.Point(12, 55);
			this.Backup_Dir_Group.Name = "Backup_Dir_Group";
			this.Backup_Dir_Group.Size = new System.Drawing.Size(541, 37);
			this.Backup_Dir_Group.TabIndex = 4;
			this.Backup_Dir_Group.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Backup Path Dir";
			// 
			// Backup_Path_Browse
			// 
			this.Backup_Path_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Backup_Path_Browse.Location = new System.Drawing.Point(512, 10);
			this.Backup_Path_Browse.Margin = new System.Windows.Forms.Padding(0);
			this.Backup_Path_Browse.Name = "Backup_Path_Browse";
			this.Backup_Path_Browse.Size = new System.Drawing.Size(24, 22);
			this.Backup_Path_Browse.TabIndex = 2;
			this.Backup_Path_Browse.Text = "...";
			this.Backup_Path_Browse.UseVisualStyleBackColor = true;
			this.Backup_Path_Browse.Click += new System.EventHandler(this.Backup_Path_Browse_Click);
			// 
			// Backup_Path
			// 
			this.Backup_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Backup_Path.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.Backup_Path.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.Backup_Path.Location = new System.Drawing.Point(94, 11);
			this.Backup_Path.Name = "Backup_Path";
			this.Backup_Path.Size = new System.Drawing.Size(418, 20);
			this.Backup_Path.TabIndex = 0;
			this.Backup_Path.WordWrap = false;
			// 
			// Path_Update_Dialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 188);
			this.ControlBox = false;
			this.Controls.Add(this.Backup_Dir_Group);
			this.Controls.Add(this.Source_Dir_Group);
			this.Controls.Add(this.Close_Screen);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Update_Paths);
			this.Controls.Add(this.Edit);
			this.Controls.Add(this.WB_Dir_Group);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1583, 227);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(583, 227);
			this.Name = "Path_Update_Dialog";
			this.Text = "WB.Net Updater Dir Paths";
			this.Load += new System.EventHandler(this.PathUpdateDialog_Load);
			this.WB_Dir_Group.ResumeLayout(false);
			this.WB_Dir_Group.PerformLayout();
			this.Source_Dir_Group.ResumeLayout(false);
			this.Source_Dir_Group.PerformLayout();
			this.Backup_Dir_Group.ResumeLayout(false);
			this.Backup_Dir_Group.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox WB_Net_Path;
		private System.Windows.Forms.Button WB_Net_Path_Browse;
		private System.Windows.Forms.GroupBox WB_Dir_Group;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Edit;
		private System.Windows.Forms.Button Update_Paths;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button Close_Screen;
		private System.Windows.Forms.GroupBox Source_Dir_Group;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Source_Path_Browse;
		private System.Windows.Forms.TextBox Source_Path;
		private System.Windows.Forms.GroupBox Backup_Dir_Group;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button Backup_Path_Browse;
		private System.Windows.Forms.TextBox Backup_Path;
	}
}