using System.ServiceModel;

namespace HostTool.OnlineServices
{
	[ServiceContract]
	public interface IManagementService
	{
		[OperationContract]
		string Test(string param);
	}
}
