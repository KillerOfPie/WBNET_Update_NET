using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WBNET_Updater
{
	public partial class MainScreen : Form
	{
		String dateTime = "";

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
			dateTime = DateTime.Now.ToString("MMddyyyyTHHmm");
			bool shouldUpdate = Update_CheckBox.Checked,
				shouldBackup = Backup_CheckBox.Checked,
				run = true,
				backupComplete,
				updateComplete;

			string wbNetPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir"),
				backUpPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir") + Path.DirectorySeparatorChar + dateTime,
				sourcePath = ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir"),
				message = "";

			if (!(Directory.Exists(wbNetPath) || Directory.Exists(sourcePath)))
			{
				MessageBox.Show("One or multiple paths invalid, please restart the program and select valid paths!", "WB.Net Updater Error 5", MessageBoxButtons.OK, MessageBoxIcon.Error);
				run = false;
			}

			if (!Directory.Exists(backUpPath) && shouldBackup && run)
			{
				Directory.CreateDirectory(backUpPath);
			}
			else
			{
				MessageBox.Show("You can only create 1 backup every minute!", "WB.Net Updater Backup Already created", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				run = false;
			}

			if (!(shouldBackup || shouldUpdate))
			{
				MessageBox.Show("You have not selected any actions to take place.", "WB.Net Updater No Actions Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (run)
			{
				WriteToLog("-- WBNET Updater --");
				WriteToLog("Start Time: " + dateTime);
				WriteToLog("Backup Dir: " + backUpPath);
				WriteToLog("WinBill Dir: " + wbNetPath);
				WriteToLog("Source Dir: " + sourcePath);
				if (shouldBackup)
				{
					backupComplete = BackupFilesWithProgress(wbNetPath, backUpPath, ConfigurationManager.AppSettings.Get("Backup-Ignore-Dir") + " " + ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir"), ConfigurationManager.AppSettings.Get("Backup-Ignore-File"));
					message += "Backup Complete: " + backupComplete + "\n";
					message += "Backups Deleted: " + DeleteExpiredBackups() + "\n";

				}

				if (shouldUpdate)
				{
					updateComplete = UpdateFilesWithProgress(sourcePath, wbNetPath);
					message += "Update Complete: " + updateComplete;
				}

				WriteToLog("End Time: " + DateTime.Now.ToString("MMddyyyyTHHmm"));

				MessageBox.Show(message, "WB.Net Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			Start_Update.Enabled = true;
		}

		private int DeleteExpiredBackups()
		{
			DirectoryInfo backupDir = new DirectoryInfo(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir"));
			int backupsToKeep = int.Parse(ConfigurationManager.AppSettings.Get("Backups-To-Keep")), numberDeleted = 0;

			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog("Deleting excess backups...");

			if (backupsToKeep < 3)
			{
				backupsToKeep = 3;
			}

			foreach (DirectoryInfo backupSubDir in backupDir.GetDirectories().OrderByDescending(di => di.Name).Skip(backupsToKeep))
			{
				numberDeleted++;
				WriteToLog("[" + numberDeleted + "] Deleting: " + backupSubDir.FullName);
				backupSubDir.Delete(true);
			}

			WriteToLog("Finished deleting " + numberDeleted + " old backups.");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");

			return numberDeleted;
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
			string wbNetPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir"),
				backUpPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir"),
				sourcePath = ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir");

			Save_As_Default.Enabled = diff;
			saveCurrentSettingsAsDefaultToolStripMenuItem.Enabled = diff;

			if (diff)
			{
				toolTip1.SetToolTip(Start_Update, "Save Backup & Update preferences to config");
			}
			else
			{
				toolTip1.SetToolTip(Start_Update, "Backup & Update preferences are the same as the config");
			}


			if (wbNetPath.Length == 0 || backUpPath.Length == 0 || sourcePath.Length == 0)
			{
				Start_Update.Enabled = false;
				toolTip1.SetToolTip(Start_Update, "All paths must be set before updating or backing up.");
			}
			else
			{
				Start_Update.Enabled = true;
				toolTip1.SetToolTip(Start_Update, "Start selected operations.");
			}
		}

		public bool BackupFilesWithProgress(string source, string destination, string excludedDir, string excludedFile)
		{
			long sourceSize = DirSize(source, destination, excludedDir, excludedFile);
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "Robocopy.exe",
					Arguments = String.Format("{0} {1} *.* /E /XD {2} /XF {3} /BYTES /FP", source, destination, excludedDir, excludedFile),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true

				}
			};

			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog("Backing up current files...");
			proc.Start();
			long size = 0;
			while (!proc.StandardOutput.EndOfStream)
			{
				string line = proc.StandardOutput.ReadLine();
				WriteToLog(line);
				if (line.Contains("New Dir") || line.Contains("New File"))
				{
					line = Regex.Replace(line, "[A-Za-z \t]", "");
					size += long.Parse(line.Split(':')[0]);
				}
				Update_BackupProgress(((int)size) + 1, ((int)sourceSize) + 1);
			}
			proc.Close();

			WriteToLog("Finished backing up " + size + " Bytes of files.");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");

			if (sourceSize == size)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool UpdateFilesWithProgress(string source, string destination)
		{
			long sourceSize = DirSize(source, destination, "", "");
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "Robocopy.exe",
					Arguments = String.Format("{0} {1} *.* /E /BYTES /FP", source, destination),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true

				}
			};

			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog("Updating current files...");
			proc.Start();
			long size = 0;
			while (!proc.StandardOutput.EndOfStream)
			{
				string line = proc.StandardOutput.ReadLine();
				WriteToLog(line);
				if (line.Contains("New Dir") || line.Contains("New File") || line.Contains("Newer"))
				{
					line = Regex.Replace(line, "[A-Za-z \t]", "");
					size += long.Parse(line.Split(':')[0]);
				}
				Update_UpdateProgress(((int)size) + 1, ((int)sourceSize) + 1);
			}
			proc.Close();

			WriteToLog("Finished updating up " + size + " Bytes of files.");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");

			if (sourceSize == size)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public long DirSize(string source, string destination, string excludedDir, string excludedFile)
		{
			long size = 0;
			long items = 0;

			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog("Detecting directory size...");

			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "Robocopy.exe",
					Arguments = String.Format("{0} {1} *.* /E /XD {2} /XF {3} /BYTES /L /FP", source, destination, excludedDir, excludedFile),
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true

				}
			};

			proc.Start();
			while (!proc.StandardOutput.EndOfStream)
			{
				string line = proc.StandardOutput.ReadLine();
				WriteToLog(line);
				items++;
				if (line.Contains("New Dir") || line.Contains("New File") || line.Contains("Newer"))
				{
					line = Regex.Replace(line, "[A-Za-z \t]", "");
					size += long.Parse(line.Split(':')[0]);
				}

			}
			proc.Close();

			WriteToLog("...Finished detecting directory size.");
			WriteToLog(" ");
			WriteToLog(" ");
			WriteToLog(" ");

			return size;
		}

		private void WriteToLog(string message)
		{
			using (StreamWriter w = File.AppendText(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir") + Path.DirectorySeparatorChar + dateTime + Path.DirectorySeparatorChar + "log.log"))
			{
				w.WriteLine(message);
				w.Flush();
				w.Close();
			}
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
			using (Form deleteAfter = new Backup_Delete_After())
				deleteAfter.ShowDialog();
		}

		private void ignoredDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form exclusionEditor = new Backup_Exclusion_Editor(true))
				exclusionEditor.ShowDialog();
		}

		private void ignoredFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form exclusionEditor = new Backup_Exclusion_Editor(false))
				exclusionEditor.ShowDialog();
		}

		private void pathsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form pathUpdateDialog = new Path_Update_Dialog())
				pathUpdateDialog.ShowDialog();
		}
	}
}
