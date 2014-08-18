using System.ComponentModel;
using System.Windows;
using HostTool.Tools;

namespace HostTool.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindowView : Window
	{
		public MainWindowView()
		{
			InitializeComponent();
		}

		private void HostClick(object sender, RoutedEventArgs e)
		{
			ServicesHostingManager manager = new ServicesHostingManager();
			manager.StartServices();
		}

		private void ShowWindow(object sender, RoutedEventArgs e)
		{
			Show();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			Hide();
			
			base.OnClosing(e);
		}
	}
}
