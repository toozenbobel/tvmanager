using System.Diagnostics;
using System.Windows;
using CommonContracts.Models;
using CommonContracts.Services;
using HostTool.Init;
using HostTool.Tools;
using HostTool.ViewModels;
using Interactivity;
using MediaPlayerController.Model;
using MediaPlayerController.Services;
using Settings;

namespace HostTool
{
	using System;
	using System.Collections.Generic;
	using Caliburn.Micro;

	public sealed class AppBootstrapper : BootstrapperBase
	{
		SimpleContainer _container;
		Window _mainWindow;

		public AppBootstrapper()
		{
			StartRuntime();
		}

		protected override void Configure()
		{
			_container = new SimpleContainer();
			_container.Singleton<IWindowManager, TrayIconWindowManager>();
			_container.Singleton<IEventAggregator, EventAggregator>();
			_container.Singleton<ServicesHostingManager>();

			_container.Singleton<ISettingsModel, SettingsModel>();
			_container.Singleton<IProcessModel, ProcessModel>();

			_container.Singleton<ICommunicationService, CommunicationService>();
			_container.Singleton<IMediaPlayerService, MediaPlayerService>();
			_container.Singleton<IPlaybackService, PlaybackService>();
			_container.Singleton<ISoundControlService, SoundControlService>();

			_container.PerRequest<IShell, MainWindowViewModel>();
		}

		protected override object GetInstance(Type service, string key)
		{
			var instance = _container.GetInstance(service, key);
			if (instance != null)
				return instance;

			throw new InvalidOperationException("Could not locate any instances.");
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}

		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
		{
			var viewModel = IoC.Get<IShell>();

			var windowManager = IoC.Get<IWindowManager>() as TrayIconWindowManager;

			Debug.Assert(windowManager != null, "windowManager != null");

			_mainWindow = windowManager.MainWindow(viewModel);
			_mainWindow.Hide();

			ServicesStartup.Init(); // Init and start all services
			ConfigureHost();
		}

		private void ConfigureHost()
		{
			// todo: make it configurable. keep settings in file or database
			var communicationService = IoC.Get<ICommunicationService>();
			communicationService.Initialize("localhost", 13579);
		}
	}
}