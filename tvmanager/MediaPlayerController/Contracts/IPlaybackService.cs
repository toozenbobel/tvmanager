﻿namespace MediaPlayerController.Contracts
{
	public interface IPlaybackService
	{
		void Play();
		void Pause();
		void PlayPause();
		void Stop();
	}
}
