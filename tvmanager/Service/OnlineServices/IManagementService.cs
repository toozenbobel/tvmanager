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

		[OperationContract]
		void StartPlayer();

		[OperationContract]
		void ClosePlayerWindow();

		[OperationContract]
		void PlayFile(string pathToFile);
	}
}
