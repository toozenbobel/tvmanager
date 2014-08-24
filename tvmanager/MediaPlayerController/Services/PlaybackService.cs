using System;
using CommonContracts.Services;
using Interactivity;

namespace MediaPlayerController.Services
{
	public class PlaybackService : IPlaybackService
	{
		private readonly ICommunicationService _communicationService;

		public PlaybackService(ICommunicationService communicationService)
		{
			_communicationService = communicationService;
		}

		public void Play()
		{
			_communicationService.PostCommand(Api.COMMAND_ID_PLAY);
		}

		public void Pause()
		{
			throw new NotImplementedException();
		}

		public void PlayPause()
		{
			throw new NotImplementedException();
		}

		public void Stop()
		{
			throw new NotImplementedException();
		}
	}
}
