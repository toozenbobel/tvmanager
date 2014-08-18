using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactivity;
using MediaPlayerController.Contracts;

namespace MediaPlayerController.Implementation
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
