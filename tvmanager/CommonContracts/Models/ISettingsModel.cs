using CommonContracts.Data;

namespace CommonContracts.Models
{
	public interface ISettingsModel	
	{
		SettingsBundle GetSettingsBundle();
		void SetPlayerPath(string path);
	}
}
