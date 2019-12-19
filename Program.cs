using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace WBNET_Updater
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string wbNetPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Install-Dir"),
				backUpPath = ConfigurationManager.AppSettings.Get("WinBill-Net-Backup-Dir"),
				sourcePath = ConfigurationManager.AppSettings.Get("WinBill-Net-Source-Dir");
			FolderSelectDialog folderBrowser = new FolderSelectDialog();


			if (!Directory.Exists(wbNetPath))
			{
				folderBrowser.Title = "Select WinBill.Net Install Directory";
				folderBrowser.InitialDirectory = Application.StartupPath;
				if (folderBrowser.ShowDialog())
				{
					if(folderBrowser.FileName.Contains(Application.StartupPath))
					{
						wbNetPath = folderBrowser.FileName.Replace(Application.StartupPath, "");
					}
					else
					{
						wbNetPath = folderBrowser.FileName;
					}

				}
			}

			if (!Directory.Exists(backUpPath))
			{
				folderBrowser.Title = "Select WinBill.Net Backup Directory";
				folderBrowser.InitialDirectory = wbNetPath;
				if (folderBrowser.ShowDialog())
				{
					if (folderBrowser.FileName.Contains(Application.StartupPath))
					{
						backUpPath = folderBrowser.FileName.Replace(Application.StartupPath, "");
					}
					else
					{
						backUpPath = folderBrowser.FileName;
					}
				}
			}

			if (!Directory.Exists(sourcePath))
			{
				folderBrowser.Title = "Select WinBill.Net Update Source Directory";
				folderBrowser.InitialDirectory = wbNetPath;
				if (folderBrowser.ShowDialog())
				{
					if (folderBrowser.FileName.Contains(Application.StartupPath))
					{
						sourcePath = folderBrowser.FileName.Replace(Application.StartupPath, "");
					}
					else
					{
						sourcePath = folderBrowser.FileName;
					}
				}
			}

			ConfigurationManager.AppSettings.Set("WinBill-Net-Install-Dir", wbNetPath);
			ConfigurationManager.AppSettings.Set("WinBill-Net-Backup-Dir", backUpPath);
			ConfigurationManager.AppSettings.Set("WinBill-Net-Source-Dir", sourcePath);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainScreen());
		}
	}
}
