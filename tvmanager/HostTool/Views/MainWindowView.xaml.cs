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

		private void OnTrayPopup(object sender, RoutedEventArgs e)
		{
			Show();
		}
	}
}
