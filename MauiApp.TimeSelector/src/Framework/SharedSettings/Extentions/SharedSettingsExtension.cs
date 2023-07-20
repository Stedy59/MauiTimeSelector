using System;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace StedySoft.Maui.Framework {

	[ContentProperty(nameof(Path))]
	public class SharedSettingsExtension : IMarkupExtension<BindingBase> {

		public string Path { get; set; } = string.Empty;

		public IValueConverter Converter { get; set; }

		public object ConverterParameter { get; set; }

		public BindingMode Mode { get; set; } = BindingMode.OneWay;

		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
			this.ProvideValue(serviceProvider);

		public BindingBase ProvideValue(IServiceProvider serviceProvider) =>
			new Binding {
				Mode = this.Mode,
				Path = this.Path,
				Source = SharedSettings.Current,
				Converter = this.Converter,
				ConverterParameter = this.ConverterParameter
			};

	}

}
