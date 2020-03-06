using System;
using System.Configuration;
using System.Windows.Forms;

namespace WBNET_Updater
{
	public partial class Backup_Delete_After : Form
	{
		public Backup_Delete_After()
		{
			InitializeComponent();
			Backups_To_Keep.Value = Decimal.Parse(ConfigurationManager.AppSettings.Get("Backups-To-Keep"));
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Accept_Click(object sender, EventArgs e)
		{
			SetAppSetting("Backups-To-Keep", Backups_To_Keep.Value.ToString());
			this.Close();
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
	}
}
