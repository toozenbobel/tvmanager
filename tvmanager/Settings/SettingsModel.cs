using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonContracts.Data;
using CommonContracts.Models;

namespace Settings
{
	public class SettingsModel : ISettingsModel
	{
		public SettingsBundle GetSettingsBundle()
		{
			return GenerateBundle();
		}

		public void SetPlayerPath(string path)
		{
			Properties.Settings.Default["PathToPlayer"] = path;
			Properties.Settings.Default.Save();
		}

		private SettingsBundle GenerateBundle()
		{
			SettingsBundle bundle = new SettingsBundle();
			bundle.PathToPlayer = (string) Properties.Settings.Default["PathToPlayer"];

			return bundle;
		}
	}
}
