using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			if(listDir)
			{
				string list = ConfigurationManager.AppSettings.Get("Backup-Ignore-Dir");
				foreach (string s in list.Split(' ')) 
				{
					Exclusion_List.Items.Add(s.Trim('"'), true);
				}
			} 
			else
			{
				string list = ConfigurationManager.AppSettings.Get("Backup-Ignore-File");
				foreach (string s in list.Split(' '))
				{
					Exclusion_List.Items.Add(s.Trim('"'), true);
				}
			}
		}

		private void Add_To_List_Click(object sender, EventArgs e)
		{
			Add_Text_To_List();
		}

		private void Add_Text_To_List()
		{
			string to_Add = Text_To_Add.Text.Replace("\"", "").Replace(" ", "");
			if (!Exclusion_List.Items.Contains(to_Add) && to_Add.Length > 0)
			{
				Exclusion_List.Items.Add(to_Add, true);
			}

			Text_To_Add.Clear();
		}

		private void Accept_Click(object sender, EventArgs e)
		{
			if (listDir)
			{
				string to_set = "";
				foreach (string s in Exclusion_List.Items)
				{
					to_set = to_set + "\"" + s + "\" ";
				}
				ConfigurationManager.AppSettings.Set("Backup-Ignore-Dir", to_set.TrimEnd(' '));
			}
			else
			{
				string to_set = "";
				foreach (string s in Exclusion_List.Items)
				{
					to_set = to_set + "\"" + s + "\" ";
				}
				ConfigurationManager.AppSettings.Set("Backup-Ignore-File", to_set.TrimEnd(' '));
			}

			this.Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Text_To_Add_Enter(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
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
	}
}
