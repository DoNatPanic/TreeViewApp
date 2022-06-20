using System;
using System.Windows.Data;
using System.Windows.Media;
using TreeViewApp.ViewModel;

namespace TreeViewApp.Core.Converters
{
	class StringToColorConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var noColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#808080");
			var green = (SolidColorBrush)new BrushConverter().ConvertFrom("#00FF00");
			var black = (SolidColorBrush)new BrushConverter().ConvertFrom("#000000");

			if (value == null || !(value is UnitColors))
				return UnitColors.noColor;

			var dValue = (UnitColors)value;
			if (dValue == UnitColors.black)
				return black;
			else if (dValue == UnitColors.green)
				return green;
			else 
				return noColor;
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
