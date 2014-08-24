using System.Runtime.Serialization;

namespace CommonContracts.Data
{
	[DataContract]
	public class SettingsBundle
	{
		public string PathToPlayer { get; set; }
	}
}
