using System;
using System.Configuration;
using System.Windows.Forms;

namespace WBNET_Updater
{
	public partial class Path_Update_Dialog : Form
	{
		private string wbNetPath = "",
				backUpPath = "",
				sourcePath = "";

		public Path_Update_Dialog()
		{
			InitializeComponent();
		}

		private void PathUpdateDialog_Load(object sender, EventArgs e)
		{
			Change_Edit_Mode(false);
			Update_Directories();
		}

		private void Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			Change_Edit_Mode(true);
		}

		private void Change_Edit_Mode(bool state)
		{
			WB_Dir_Group.Enabled = state;
			Backup_Dir_Group.Enabled = state;
			Source_Dir_Group.Enabled = state;
			Update_Paths.Enabled = state;
			Cancel.Enabled = state;
		}

		private void WB_Net_Path_Browse_Click(object sender, EventArgs e)
		{
			WB_Net_Path.Text = /*Set_Dir_To_Relative*/(Open_Browse_Dialog("Select WinBill.Net Install Directory", wbNetPath));
		}

		private string Open_Browse_Dialog(string title, string initialPath)
		{
			FolderSelectDialog folderBrowser = new FolderSelectDialog
			{
				Title = title
			};

			if (wbNetPath.Length == 0)
			{
				folderBrowser.InitialDirectory = Application.StartupPath;
			}
			else
			{
				folderBrowser.InitialDirectory = initialPath;
			}

			if (folderBrowser.ShowDialog())
			{
				return folderBrowser.FileName;
			}

			return "";
		}

		private void Update_Directories()
		{
			wbNetPath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir"));
			backUpPath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir"));
			sourcePath = Fix_Dir(ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir"));
			WB_Net_Path.Text = wbNetPath;
			Backup_Path.Text = backUpPath;
			Source_Path.Text = sourcePath;
		}

		private void Set_Directories()
		{
			SetAppSetting("WinBill-Net-Install-Dir", Set_Dir_To_Relative(WB_Net_Path.Text));
			SetAppSetting("WinBill-Net-Backup-Dir", Set_Dir_To_Relative(Backup_Path.Text));
			SetAppSetting("WinBill-Net-Source-Dir", Set_Dir_To_Relative(Source_Path.Text));
			
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
			Set_Directories();
			Change_Edit_Mode(false);
			Update_Directories();
		}

		private void Backup_Path_Browse_Click(object sender, EventArgs e)
		{
			Backup_Path.Text = /*Set_Dir_To_Relative*/(Open_Browse_Dialog("Select WinBill.Net Backup Directory", backUpPath));
		}

		private void Source_Path_Browse_Click(object sender, EventArgs e)
		{
			Source_Path.Text = /*Set_Dir_To_Relative*/(Open_Browse_Dialog("Select WinBill.Net Update Source Directory", sourcePath));
		}

		public string Set_Dir_To_Relative(string dir)
		{
			if (dir == Application.StartupPath)
			{
				dir = dir.Replace(Application.StartupPath, ".");
			}
			else if (dir.Contains(Application.StartupPath))
			{
				dir = dir.Replace(Application.StartupPath, "");
			}

			return dir;
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			Change_Edit_Mode(false);
			Update_Directories();
		}
	}
}
