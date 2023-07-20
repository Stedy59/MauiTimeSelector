using System;

using Microsoft.Maui.Controls;

namespace StedySoft.Maui.Framework {

	#region Class EnumToStringConverter
	public class EnumToStringConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) =>
			parameter?.ToString();

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) =>
			null;

	}
	#endregion

}
