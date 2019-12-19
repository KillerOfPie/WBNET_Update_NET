namespace WBNET_Updater
{
	partial class MainScreen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
			this.Start_Update = new System.Windows.Forms.Button();
			this.Backup_CheckBox = new System.Windows.Forms.CheckBox();
			this.BackupProgression = new System.Windows.Forms.ProgressBar();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Save_As_Default = new System.Windows.Forms.Button();
			this.UpdateProgression = new System.Windows.Forms.ProgressBar();
			this.Update_CheckBox = new System.Windows.Forms.CheckBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.File_Drop_Down = new System.Windows.Forms.ToolStripDropDownButton();
			this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ignoredDirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ignoredFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCurrentSettingsAsDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Start_Update
			// 
			this.Start_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Start_Update.Location = new System.Drawing.Point(12, 74);
			this.Start_Update.Name = "Start_Update";
			this.Start_Update.Size = new System.Drawing.Size(189, 23);
			this.Start_Update.TabIndex = 0;
			this.Start_Update.Text = "Start";
			this.toolTip1.SetToolTip(this.Start_Update, "Start selected operations");
			this.Start_Update.UseVisualStyleBackColor = true;
			this.Start_Update.Click += new System.EventHandler(this.Update_Click);
			// 
			// Backup_CheckBox
			// 
			this.Backup_CheckBox.AutoSize = true;
			this.Backup_CheckBox.Location = new System.Drawing.Point(12, 51);
			this.Backup_CheckBox.Name = "Backup_CheckBox";
			this.Backup_CheckBox.Size = new System.Drawing.Size(142, 17);
			this.Backup_CheckBox.TabIndex = 1;
			this.Backup_CheckBox.Text = "Backup current version?";
			this.toolTip1.SetToolTip(this.Backup_CheckBox, "Backs up the current version before updating to a newer version");
			this.Backup_CheckBox.UseVisualStyleBackColor = true;
			this.Backup_CheckBox.CheckedChanged += new System.EventHandler(this.Backup_CheckBox_CheckedChanged);
			// 
			// BackupProgression
			// 
			this.BackupProgression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BackupProgression.Location = new System.Drawing.Point(12, 103);
			this.BackupProgression.Name = "BackupProgression";
			this.BackupProgression.Size = new System.Drawing.Size(290, 23);
			this.BackupProgression.TabIndex = 2;
			this.toolTip1.SetToolTip(this.BackupProgression, "Backup progress");
			// 
			// Save_As_Default
			// 
			this.Save_As_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Save_As_Default.Location = new System.Drawing.Point(207, 74);
			this.Save_As_Default.Name = "Save_As_Default";
			this.Save_As_Default.Size = new System.Drawing.Size(95, 23);
			this.Save_As_Default.TabIndex = 4;
			this.Save_As_Default.Text = "Save as Default";
			this.toolTip1.SetToolTip(this.Save_As_Default, "Save Backup & Update preferences to config");
			this.Save_As_Default.UseVisualStyleBackColor = true;
			this.Save_As_Default.Click += new System.EventHandler(this.Save_As_Default_Click);
			// 
			// UpdateProgression
			// 
			this.UpdateProgression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UpdateProgression.Location = new System.Drawing.Point(12, 132);
			this.UpdateProgression.Name = "UpdateProgression";
			this.UpdateProgression.Size = new System.Drawing.Size(290, 23);
			this.UpdateProgression.TabIndex = 5;
			this.toolTip1.SetToolTip(this.UpdateProgression, "Update progress");
			// 
			// Update_CheckBox
			// 
			this.Update_CheckBox.AutoSize = true;
			this.Update_CheckBox.Location = new System.Drawing.Point(160, 51);
			this.Update_CheckBox.Name = "Update_CheckBox";
			this.Update_CheckBox.Size = new System.Drawing.Size(153, 17);
			this.Update_CheckBox.TabIndex = 3;
			this.Update_CheckBox.Text = "Update to newest version?";
			this.toolTip1.SetToolTip(this.Update_CheckBox, "Update the current directory");
			this.Update_CheckBox.UseVisualStyleBackColor = true;
			this.Update_CheckBox.CheckedChanged += new System.EventHandler(this.Update_CheckBox_CheckedChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_Drop_Down});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(314, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// File_Drop_Down
			// 
			this.File_Drop_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.File_Drop_Down.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.saveCurrentSettingsAsDefaultToolStripMenuItem});
			this.File_Drop_Down.Image = ((System.Drawing.Image)(resources.GetObject("File_Drop_Down.Image")));
			this.File_Drop_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.File_Drop_Down.Name = "File_Drop_Down";
			this.File_Drop_Down.Size = new System.Drawing.Size(38, 22);
			this.File_Drop_Down.Text = "File";
			// 
			// configureToolStripMenuItem
			// 
			this.configureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.pathsToolStripMenuItem});
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
			this.configureToolStripMenuItem.Text = "Configure";
			// 
			// backupToolStripMenuItem
			// 
			this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoredDirectoriesToolStripMenuItem,
            this.ignoredFilesToolStripMenuItem,
            this.deleteAfterToolStripMenuItem});
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.backupToolStripMenuItem.Text = "Backup";
			// 
			// ignoredDirectoriesToolStripMenuItem
			// 
			this.ignoredDirectoriesToolStripMenuItem.Name = "ignoredDirectoriesToolStripMenuItem";
			this.ignoredDirectoriesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.ignoredDirectoriesToolStripMenuItem.Text = "Ignored Directories";
			this.ignoredDirectoriesToolStripMenuItem.Click += new System.EventHandler(this.ignoredDirectoriesToolStripMenuItem_Click);
			// 
			// ignoredFilesToolStripMenuItem
			// 
			this.ignoredFilesToolStripMenuItem.Name = "ignoredFilesToolStripMenuItem";
			this.ignoredFilesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.ignoredFilesToolStripMenuItem.Text = "Ignored Files";
			this.ignoredFilesToolStripMenuItem.Click += new System.EventHandler(this.ignoredFilesToolStripMenuItem_Click);
			// 
			// deleteAfterToolStripMenuItem
			// 
			this.deleteAfterToolStripMenuItem.Name = "deleteAfterToolStripMenuItem";
			this.deleteAfterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.deleteAfterToolStripMenuItem.Text = "Delete After";
			this.deleteAfterToolStripMenuItem.Click += new System.EventHandler(this.deleteAfterToolStripMenuItem_Click);
			// 
			// pathsToolStripMenuItem
			// 
			this.pathsToolStripMenuItem.Name = "pathsToolStripMenuItem";
			this.pathsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.pathsToolStripMenuItem.Text = "Paths";
			this.pathsToolStripMenuItem.Click += new System.EventHandler(this.pathsToolStripMenuItem_Click);
			// 
			// saveCurrentSettingsAsDefaultToolStripMenuItem
			// 
			this.saveCurrentSettingsAsDefaultToolStripMenuItem.Name = "saveCurrentSettingsAsDefaultToolStripMenuItem";
			this.saveCurrentSettingsAsDefaultToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
			this.saveCurrentSettingsAsDefaultToolStripMenuItem.Text = "Save Current Settings as Default";
			this.saveCurrentSettingsAsDefaultToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentSettingsAsDefaultToolStripMenuItem_Click);
			// 
			// MainScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 167);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.UpdateProgression);
			this.Controls.Add(this.Save_As_Default);
			this.Controls.Add(this.Update_CheckBox);
			this.Controls.Add(this.BackupProgression);
			this.Controls.Add(this.Backup_CheckBox);
			this.Controls.Add(this.Start_Update);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WinBill .Net Updater";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Start_Update;
		private System.Windows.Forms.CheckBox Backup_CheckBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ProgressBar BackupProgression;
		private System.Windows.Forms.CheckBox Update_CheckBox;
		private System.Windows.Forms.Button Save_As_Default;
		private System.Windows.Forms.ProgressBar UpdateProgression;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton File_Drop_Down;
		private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ignoredDirectoriesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ignoredFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveCurrentSettingsAsDefaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteAfterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pathsToolStripMenuItem;
	}
}

