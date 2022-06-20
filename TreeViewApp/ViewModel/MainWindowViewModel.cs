using TreeViewApp.Core;

namespace TreeViewApp.ViewModel
{
	public class MainWindowViewModel : ObservableObject
	{
		private MainViewModel mainViewPage;
		private ContentViewModel contentViewPage;

		public MainViewModel MainViewPage
		{
			get => mainViewPage;
			set
			{
				mainViewPage = value;
				OnPropertyChanged();
			}
		}
		public ContentViewModel ContentViewPage
		{
			get => contentViewPage;
			set
			{
				contentViewPage = value;
				OnPropertyChanged();
			}
		}

		public MainWindowViewModel()
		{
			MainViewPage = new();
			ContentViewPage = new();
		}
	}
}
