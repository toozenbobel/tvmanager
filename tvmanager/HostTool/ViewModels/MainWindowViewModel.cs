using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using MvvmTools;

namespace HostTool.ViewModels
{
	public class MainWindowViewModel : Screen, IShell
	{
		private readonly IWindowManager _windowManager;

		public MainWindowViewModel(IWindowManager windowManager)
		{
			_windowManager = windowManager;
		}

		public ICommand TrayIconLeftClickCommand
		{
			get
			{
				return new RelayCommand(() => _windowManager.ShowWindow(IoC.Get<IShell>()));
			}
		}
	}
}
