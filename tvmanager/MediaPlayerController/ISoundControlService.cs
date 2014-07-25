namespace MediaPlayerController
{
	public interface ISoundControlService
	{
		void PlayerVolumeUp();
		void PlayerVolumeDown();
		void Mute();
		void SystemVolumeUp();
		void SystemVolumeDown();
	}
}