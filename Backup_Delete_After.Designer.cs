namespace WBNET_Updater
{
	partial class Backup_Delete_After
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
			this.label1 = new System.Windows.Forms.Label();
			this.Backups_To_Keep = new System.Windows.Forms.NumericUpDown();
			this.Accept = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Backups_To_Keep)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Only keep              backups.";
			// 
			// Backups_To_Keep
			// 
			this.Backups_To_Keep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Backups_To_Keep.Location = new System.Drawing.Point(73, 8);
			this.Backups_To_Keep.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.Backups_To_Keep.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.Backups_To_Keep.Name = "Backups_To_Keep";
			this.Backups_To_Keep.Size = new System.Drawing.Size(33, 20);
			this.Backups_To_Keep.TabIndex = 1;
			this.Backups_To_Keep.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// Accept
			// 
			this.Accept.Location = new System.Drawing.Point(93, 36);
			this.Accept.Name = "Accept";
			this.Accept.Size = new System.Drawing.Size(75, 23);
			this.Accept.TabIndex = 2;
			this.Accept.Text = "Accept";
			this.Accept.UseVisualStyleBackColor = true;
			this.Accept.Click += new System.EventHandler(this.Accept_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(12, 36);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// Backup_Delete_After
			// 
			this.AcceptButton = this.Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(183, 76);
			this.ControlBox = false;
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Accept);
			this.Controls.Add(this.Backups_To_Keep);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Backup_Delete_After";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Delete Backups after...";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.Backups_To_Keep)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown Backups_To_Keep;
		private System.Windows.Forms.Button Accept;
		private System.Windows.Forms.Button Cancel;
	}
}