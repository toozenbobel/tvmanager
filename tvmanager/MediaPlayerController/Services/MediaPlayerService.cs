
using CommonContracts.Models;
using CommonContracts.Services;
using Interactivity;

namespace MediaPlayerController.Services
{
	public class MediaPlayerService : IMediaPlayerService
	{
		private readonly IProcessModel _processModel;
		private readonly ICommunicationService _communicationService;

		public MediaPlayerService(IProcessModel processModel, ICommunicationService communicationService)
		{
			_processModel = processModel;
			_communicationService = communicationService;
		}

		public void StartPlayer()
		{
			_processModel.ActivatePlayer();
		}

		public void ClosePlayerWindow()
		{
			_processModel.ClosePlayer();
		}

		public void ToggleFullscreen()
		{
			throw new System.NotImplementedException();
		}

		public void PlayFile(string pathToFile)
		{
			_processModel.ActivatePlayer();

			_communicationService.PostFile(pathToFile);
		}
	}
}