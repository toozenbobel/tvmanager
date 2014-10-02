using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using LazyMovie.Models.Interfaces;

namespace LazyMovie.ViewModels
{
	public class ConnectionViewModel : Screen
	{
		private readonly IConnectionModel _connectionModel;

		public ConnectionViewModel(IConnectionModel connectionModel)
		{
			_connectionModel = connectionModel;
		}

		protected override async void OnActivate()
		{
			base.OnActivate();

			IsConnecting = true;

			var connected = await _connectionModel.TryConnectToSavedHost();

			IsConnecting = false;

			if (connected)
			{
				// todo: Navigate to main page
			}
			else
			{

			}
		}

		private string _hostName = "scylla";
		public string HostName
		{
			get { return _hostName; }
			set
			{
				_hostName = value;
				NotifyOfPropertyChange(() => HostName);
			}
		}

		public async void Connect()
		{
			if (!string.IsNullOrWhiteSpace(HostName))
			{
				var connected = await _connectionModel.Connect(HostName);

				MessageBox.Show(connected ? "Connected!" : "Failed");
			}
		}

		#region Animation

		private bool _isConnecting;
		public bool IsConnecting
		{
			get { return _isConnecting; }
			set
			{
				_isConnecting = value;
				NotifyOfPropertyChange(() => IsConnecting);
			}
		}

		#endregion

	}
}
