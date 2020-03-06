using System;
using System.Configuration;
using System.Windows.Forms;

namespace WBNET_Updater
{
	public partial class Backup_Exclusion_Editor : Form
	{
		private bool listDir;

		public Backup_Exclusion_Editor(bool listDir)
		{
			InitializeComponent();
			this.listDir = listDir;
			if (listDir)
			{
				this.Text = "Directory List for Backup to Ignore...";
				List_Label.Text = "Directories " + List_Label.Text;

				string list = ConfigurationManager.AppSettings.Get("Backup-Ignore-Dir");
				foreach (string s in list.Split(new String[]{ "|" }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (s != " ")
					{
						Exclusion_List.Items.Add(s.Trim(' '), true);
					}
				}
			}
			else
			{
				this.Text = "File List for Backup to Ignore...";
				List_Label.Text = "Files " + List_Label.Text;

				string list = ConfigurationManager.AppSettings.Get("Backup-Ignore-File");
				foreach (string s in list.Split(new String[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
				{
					if (s != " ")
					{
						Exclusion_List.Items.Add(s.Trim(' '), true);
					}
				}
			}
		}

		private void Add_To_List_Click(object sender, EventArgs e)
		{
			Add_Text_To_List();
		}

		private void Add_Text_To_List()
		{
			string to_Add = Text_To_Add.Text.Replace("|", "");
			if (!Exclusion_List.Items.Contains(to_Add) && to_Add.Length > 0)
			{
				Exclusion_List.Items.Add(to_Add.Trim(' '), true);
			}

			Text_To_Add.Clear();
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

		private void Accept_Click(object sender, EventArgs e)
		{
			if (listDir)
			{
				string to_set = "";
				foreach (string s in Exclusion_List.CheckedItems)
				{
					to_set = to_set + "|" + s + "| ";
				}
				SetAppSetting("Backup-Ignore-Dir", to_set.TrimEnd(' '));
			}
			else
			{
				string to_set = "";
				foreach (string s in Exclusion_List.CheckedItems)
				{
					to_set = to_set + "|" + s + "| ";
				}
				SetAppSetting("Backup-Ignore-File", to_set.TrimEnd(' '));
			}

			
			this.Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Text_To_Add_Enter(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Add_Text_To_List();
			}
		}

		private void Select_All_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Exclusion_List.Items.Count; i++)
			{
				Exclusion_List.SetItemChecked(i, true);
			}
		}

		private void Deselect_All_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Exclusion_List.Items.Count; i++)
			{
				Exclusion_List.SetItemChecked(i, false);
			}
		}
	}
}
