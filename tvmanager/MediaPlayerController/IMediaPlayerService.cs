﻿namespace MediaPlayerController
{
	public interface IMediaPlayerService
	{
		void StartPlayer(string pathToFile);
		void ClosePlayerWindow();
		void ToggleFullscreen();
	}
}