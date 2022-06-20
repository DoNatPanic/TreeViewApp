using System.Windows;
using TreeViewApp.ViewModel;

namespace TreeViewApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow app = new();
			MainWindowViewModel context = new();
			app.DataContext = context;
			app.Show();
		}
	}
}
