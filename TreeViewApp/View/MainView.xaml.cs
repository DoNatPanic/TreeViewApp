using System.Windows.Controls;
using System.Windows.Input;

namespace TreeViewApp.View
{
	/// <summary>
	/// Логика взаимодействия для MainView.xaml
	/// </summary>
	public partial class MainView : UserControl
	{
		private readonly string defaultFilterText = "Filter";
		public MainView()
		{
			InitializeComponent();
		}

		private bool isFocused;

		private void Box_GotFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			isFocused = true;
			if ((sender as TextBox).Text == defaultFilterText)
				(sender as TextBox).Text = "";
		}


		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (isFocused)
			{
				Grid.Focus();
				isFocused = false;
			}

			if (Box.Text == "")
				Box.Text = defaultFilterText;
		}

		private void Box_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				Grid.Focus();
				isFocused = false;
				if ((sender as TextBox).Text == "")
					(sender as TextBox).Text = defaultFilterText;
			}
		}

		private void Box_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			isFocused = false;
			if ((sender as TextBox).Text == "")
				(sender as TextBox).Text = defaultFilterText;
		}
	}
}
