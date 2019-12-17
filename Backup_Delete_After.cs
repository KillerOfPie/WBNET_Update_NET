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
			ConfigurationManager.AppSettings.Set("Backups-To-Keep", Backups_To_Keep.Value.ToString());
			this.Close();
		}
	}
}
