namespace CommonContracts.Services
{
	public interface IMediaPlayerService
	{
		void StartPlayer();
		void ClosePlayerWindow();
		void ToggleFullscreen();
		void PlayFile(string pathToFile);
	}
}