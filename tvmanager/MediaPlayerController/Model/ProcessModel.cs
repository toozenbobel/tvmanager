using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommonContracts.Models;

namespace MediaPlayerController.Model
{
	public class ProcessModel : IProcessModel
	{
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		private readonly ISettingsModel _settingsModel;

		public ProcessModel(ISettingsModel settingsModel)
		{
			_settingsModel = settingsModel;
		}

		private Process _playerProcess;

		public void ActivatePlayer()
		{
			if (_playerProcess == null || _playerProcess.HasExited)
			{
				_playerProcess = StartProcess();
			}

			if (_playerProcess == null)
			{
				throw new Exception("Failed to start Media Player process");
			}

			SetForegroundWindow(_playerProcess.MainWindowHandle);
		}

		public void ClosePlayer()
		{
			if (_playerProcess != null)
			{
				_playerProcess.CloseMainWindow();
			}
		}

		private Process StartProcess()
		{
			string pathToPlayer = _settingsModel.GetSettingsBundle().PathToPlayer;
			string pathToApplication = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			if (pathToApplication != null)
			{
				var path = Path.Combine(pathToApplication, pathToPlayer);
				
				_playerProcess = Process.Start(path);

				return _playerProcess;
			}

			return null;
		}
	}
}
