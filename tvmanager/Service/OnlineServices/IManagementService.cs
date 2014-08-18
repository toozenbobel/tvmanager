using System.ServiceModel;

namespace Service.OnlineServices
{
	[ServiceContract]
	public interface IManagementService
	{
		[OperationContract]
		string Test(string param);

		[OperationContract]
		void Play();
	}
}
