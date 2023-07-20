using System;
using System.Globalization;

using Microsoft.Maui.Controls;

namespace StedySoft.Maui.Framework {

	#region Class BoolToStringConverter
	public class BoolToStringConverter : IValueConverter {

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
			value == null ? "Off" : (bool)value ? "On" : "Off";

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
			false;

	}
	#endregion

}
