using System;
using System.Globalization;

using Microsoft.Maui.Controls;

namespace StedySoft.Maui.Framework {

	#region Class BoolToOpacityConverter
	public class BoolToOpacityConverter : IValueConverter {

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
			parameter switch {
				"BaseShadow" => (bool)value ? 1.0f : 0.0f,
				"BorderShadow" => (bool)value ? 0.5f : 0.05f,
				"FrameShadow" => (bool)value ? 0.5f : 0.15f,
				"DialogShadow" => (bool)value ? 1.0f : 0.05f,
				"ClockFaceShadow" => (bool)value ? 1.0f : 0.25f,
				_ => (object)0.5f,
			};

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
			false;

	}
	#endregion

}
