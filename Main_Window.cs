using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WBNET_Updater
{
	public partial class MainScreen : Form
	{
		public MainScreen()
		{
			InitializeComponent();
			Backup_CheckBox.Checked = Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Backup-Enabled"));
			Update_CheckBox.Checked = Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Update-Enabled"));
			UpdateLockedButtons();
		}

		private void Update_Click(object sender, EventArgs e)
		{
			Start_Update.Enabled = false;
			Boolean shouldUpdate = Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Update-Enabled")),
				shouldBackup = Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Backup-Enabled"));

			string wbNetPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir"),
				backUpPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir"),
				sourcePath = ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir");

			if (!(Directory.Exists(wbNetPath) || Directory.Exists(backUpPath) || Directory.Exists(sourcePath)))
			{
				MessageBox.Show("One or multiple paths invalid, please restart the program and select valid paths!", "WB.Net Updater Error 5", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(5);
			}

			if(!(shouldBackup || shouldUpdate))
			{
				MessageBox.Show("You have not selected any actions to take place.", "WB.Net Updater No Actions Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			} 
			else
			{
				if (shouldBackup)
				{
					BackupFilesWithProgress(wbNetPath, backUpPath, ConfigurationManager.AppSettings.Get("Backup-Ignore-Dir"), ConfigurationManager.AppSettings.Get("Backup-Ignore-File"));
				}
			}

			Start_Update.Enabled = true;
		}

		private void Save_As_Default_Click(object sender, EventArgs e)
		{
			SaveAsDefault();
			UpdateLockedButtons();
		}

		private void SaveAsDefault()
		{
			ConfigurationManager.AppSettings.Set("Default-Backup-Enabled", Backup_CheckBox.Checked.ToString());
			ConfigurationManager.AppSettings.Set("Default-Update-Enabled", Update_CheckBox.Checked.ToString());
			MessageBox.Show("Application defaults have been set to currrent settings.", "WB.Net Updater Defaults Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Backup_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateLockedButtons();
		}

		private void Update_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateLockedButtons();
		}

		private Boolean DifferentThanStored()
		{
			return Update_CheckBox.Checked != Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Update-Enabled")) ||
				Backup_CheckBox.Checked != Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Backup-Enabled"));
		}

		private void UpdateLockedButtons()
		{
			bool diff = DifferentThanStored();
			Save_As_Default.Enabled = diff;
			saveCurrentSettingsAsDefaultToolStripMenuItem.Enabled = diff;
		}

		public void BackupFilesWithProgress(string source, string destination, string excludedDir, string excludedFile)
		{
			long sourceSize = DirSize(new DirectoryInfo(source));
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "robocopy.exe",
					Arguments = String.Format("'{0}' '{1}' *.* /E /XD '{2}' /XF '{3}'", source, destination, excludedDir, excludedFile),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true

				}
			};

			proc.Start();
			while (!proc.StandardOutput.EndOfStream)
			{
				string line = proc.StandardOutput.ReadLine();
				using (StreamWriter w = File.AppendText(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir") + "\\log.log"))
				{
					w.WriteLine(line);
				}

				Update_BackupProgress(1, int.Parse(sourceSize.ToString()));
			}
		}

		public static long DirSize(DirectoryInfo d)
		{
			long size = 0;
			long items = 0;
			// Add file sizes.
			FileInfo[] fis = d.GetFiles();
			foreach (FileInfo fi in fis)
			{
				size += fi.Length;
				items++;
			}
			// Add subdirectory sizes.
			DirectoryInfo[] dis = d.GetDirectories();
			foreach (DirectoryInfo di in dis)
			{
				size += DirSize(di);
				items++;
			}
			//return size;
			return items;
		}

		public void Update_BackupProgress(int copiedAmount, int totalAmount)
		{
			BackupProgression.Maximum = totalAmount;
			BackupProgression.Value = copiedAmount;
		}

		public void Update_UpdateProgress(int copiedAmount, int totalAmount)
		{
			UpdateProgression.Maximum = totalAmount;
			UpdateProgression.Value = copiedAmount;
		}

		private void saveCurrentSettingsAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveAsDefault(); 
			UpdateLockedButtons();
		}

		private void deleteAfterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form deleteAfter = new Backup_Delete_After();
			deleteAfter.ShowDialog();
		}

		private void ignoredDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form exclusionEditor = new Backup_Exclusion_Editor(true);
			exclusionEditor.ShowDialog();
		}

		private void ignoredFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form exclusionEditor = new Backup_Exclusion_Editor(false);
			exclusionEditor.ShowDialog();
		}
	}
}
