using System.ServiceModel;

namespace Service.OnlineServices
{
	[ServiceContract]
	public interface IManagementService
	{
		[OperationContract]
		string Ping();

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
