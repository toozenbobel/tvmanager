using Caliburn.Micro;
using MediaPlayerController.Contracts;

namespace Service.OnlineServices
{
	public class ManagementService : IManagementService
	{
		private readonly IMediaPlayerService _mediaPlayerService;
		private readonly IPlaybackService _playbackService;
		private readonly ISoundControlService _soundControlService;

		public ManagementService()
		{
			_mediaPlayerService = IoC.Get<IMediaPlayerService>();
			_playbackService = IoC.Get<IPlaybackService>();
			_soundControlService = IoC.Get<ISoundControlService>();
		}

		#region Playback

		public void Play()
		{
			_playbackService.Play();
		}

		public void Pause()
		{
			_playbackService.Pause();
		}

		public void PlayPause()
		{
			_playbackService.PlayPause();
		}

		public void Stop()
		{
			_playbackService.Stop();
		}

		#endregion

		public string Test(string param)
		{
			return param;
		}
	}
}