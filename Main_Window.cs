using System;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WBNET_Updater
{
	public partial class MainScreen : Form
	{
		String dateTime = "", log = "";

		public MainScreen()
		{
			UpdateSettings();

			InitializeComponent();
			VersionDisplay.Text = "Version: " + Application.ProductVersion;
			Backup_CheckBox.Checked = Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Backup-Enabled"));
			Update_CheckBox.Checked = Boolean.Parse(ConfigurationManager.AppSettings.Get("Default-Update-Enabled"));
			UpdateLockedButtons();
		}

		private void UpdateSettings()
		{
			SetDefaultAppSetting("WinBill-Net-Install-Dir", ".");
			SetDefaultAppSetting("WinBill-Net-Backup-Dir", "\\Backups");
			SetDefaultAppSetting("WinBill-Net-Source-Dir", "\\\\10.1.1.2\\LatestCode\\WinbillNET");
			SetDefaultAppSetting("Default-Backup-Enabled", "true");
			SetDefaultAppSetting("Default-Update-Enabled", "true");
			SetDefaultAppSetting("Backup-Ignore-Dir", "|Backups|Log Files|Exports|");
			SetDefaultAppSetting("Backup-Ignore-File", "|*.bat|");
			SetDefaultAppSetting("Backups - To - Keep", "3");
			SetDefaultAppSetting("Close-After-Update", "True");
			SetDefaultAppSetting("Launch-After-Update", "True");
		}

		public void SetDefaultAppSetting(string key, string value)
		{
			try
			{
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				var settings = configFile.AppSettings.Settings;
				if (settings[key] == null)
				{
					settings.Add(key, value);
				}
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			}
			catch (ConfigurationErrorsException)
			{
				//Do Nothing
			}
		}

		public void SetAppSetting(string key, string value)
		{
			try
			{
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				var settings = configFile.AppSettings.Settings;
				if (settings[key] == null)
				{
					settings.Add(key, value);
				}
				else
				{
					settings[key].Value = value;
				}
				configFile.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			}
			catch (ConfigurationErrorsException)
			{
				//Do Nothing
			}
		}

		private string Fix_Dir(string dir)
		{
			if (dir.StartsWith("\\") && !dir.StartsWith("\\\\"))
			{
				dir = Application.StartupPath + dir;
			}
			else if (dir == ".")
			{
				dir = Application.StartupPath;
			}

			return dir;
		}

		private void Update_Click(object sender, EventArgs e)
		{
			Start_Update.Enabled = false;
			Update_CheckBox.Enabled = false;
			Backup_CheckBox.Enabled = false;
			this.UseWaitCursor = true;

			dateTime = DateTime.Now.ToString("MMddyyyyTHHmm");
			bool shouldUpdate = Update_CheckBox.Checked,
				shouldBackup = Backup_CheckBox.Checked,
				run = true,
				backupComplete,
				updateComplete;

			string wbNetPath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir")),
				backUpPath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir")),
				sourcePath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir")),
				message = "";

			if (!(Directory.Exists(wbNetPath) || Directory.Exists(sourcePath) || Directory.Exists(backUpPath)))
			{
				MessageBox.Show("One or multiple paths invalid, please use File > Configure > Paths and make sure all paths are valid!", "WB.Net Updater Error 5", MessageBoxButtons.OK, MessageBoxIcon.Error);
				run = false;
			}

			backUpPath += Path.DirectorySeparatorChar + dateTime;


			if (shouldBackup && run)
			{
				log = backUpPath + Path.DirectorySeparatorChar + "backup.log";

				if (!Directory.Exists(backUpPath))
				{
					Directory.CreateDirectory(backUpPath);
				}
				else
				{
					MessageBox.Show("You can only create 1 backup every minute!", "WB.Net Updater Backup Already created", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					run = false;
				} 
			}
			else
			{
				Directory.CreateDirectory(wbNetPath + Path.DirectorySeparatorChar + "WBU No-Backup Logs");
				log = wbNetPath + Path.DirectorySeparatorChar + "WBU No-Backup Logs" + Path.DirectorySeparatorChar + "update " + dateTime + ".log";
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
					backupComplete = BackupFilesWithProgress(wbNetPath, backUpPath, ConfigurationManager.AppSettings.Get("Backup-Ignore-Dir").Replace("|", "\"") + " \"" + Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir")) + "\"", ConfigurationManager.AppSettings.Get("Backup-Ignore-File").Replace("|", "\"") + " \"" + Application.ExecutablePath + "\"" + " \"" + Application.ExecutablePath + ".config\"");
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

				if (Boolean.Parse(ConfigurationManager.AppSettings.Get("Launch-After-Update")))
				{
					Process.Start(Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir")) + "\\WinBill.exe");
				}

				if (Boolean.Parse(ConfigurationManager.AppSettings.Get("Close-After-Update")))
				{
					Environment.Exit(0);
				}
			}

			this.UseWaitCursor = false;
			Start_Update.Enabled = true;
			Update_CheckBox.Enabled = true;
			Backup_CheckBox.Enabled = true;
		}

		private int DeleteExpiredBackups()
		{
			DirectoryInfo backupDir = new DirectoryInfo(Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir")));
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
			SetAppSetting("Default-Backup-Enabled", Backup_CheckBox.Checked.ToString());
			SetAppSetting("Default-Update-Enabled", Update_CheckBox.Checked.ToString());
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
			string wbNetPath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir")),
				backUpPath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir")),
				sourcePath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir"));

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

					if (line.Contains(":"))
						size += long.Parse(line.Split(':')[0]);
					else if (line.Contains("\\\\"))
						size += long.Parse(line.Split(new String[] { "\\\\" }, StringSplitOptions.RemoveEmptyEntries)[0]);
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

					if (line.Contains(":"))
						size += long.Parse(line.Split(':')[0]);
					else if (line.Contains("\\\\"))
						size += long.Parse(line.Split(new String[] { "\\\\" }, StringSplitOptions.RemoveEmptyEntries)[0]);
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
					if (line.Contains(":"))
						size += long.Parse(line.Split(':')[0]);
					else if (line.Contains("\\\\"))
						size += long.Parse(line.Split(new String[] { "\\\\" }, StringSplitOptions.RemoveEmptyEntries)[0]);
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
			using (StreamWriter w = File.AppendText(log))
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

		private void closeAfterUpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result;
			result = MessageBox.Show("Would you like the program to close once it completes the update?", "WB Updater Close After Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			bool value = Boolean.Parse(ConfigurationManager.AppSettings.Get("Close-After-Update"));

			switch (result)
			{
				case DialogResult.Yes:
					value = true;
					break;
				case DialogResult.No:
					value = false;
					break;
				case DialogResult.Cancel:
					//do nothing
					break;
			}

			SetAppSetting("Close-After-Update", value.ToString());
			

		}

		private void launchAfterUpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result;
			result = MessageBox.Show("Would you like the program to launch WinBill once it completes the update?", "WB Updater Launch After Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			bool value = Boolean.Parse(ConfigurationManager.AppSettings.Get("Launch-After-Update"));

			switch (result)
			{
				case DialogResult.Yes:
					value = true;
					break;
				case DialogResult.No:
					value = false;
					break;
				case DialogResult.Cancel:
					//do nothing
					break;
			}

			SetAppSetting("Launch-After-Update", value.ToString());
			
		}

		private void pathsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form pathUpdateDialog = new Path_Update_Dialog())
				pathUpdateDialog.ShowDialog();
		}
	}
}
