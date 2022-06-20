using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TreeViewApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			base.OnSourceInitialized(e);
			RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.SoftwareOnly;
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			var scaleY = e.NewSize.Height / 1080;
			MainGrid.LayoutTransform = new ScaleTransform(scaleY, scaleY);
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MainViewControl.Focus();
		}
	}
}
