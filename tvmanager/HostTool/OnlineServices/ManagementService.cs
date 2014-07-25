namespace HostTool.OnlineServices
{
	public class ManagementService : IManagementService
	{
		public string Test(string param)
		{
			return "From server: " + param;
		}
	}
}