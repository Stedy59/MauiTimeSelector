using System;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace StedySoft.Maui.Framework {

	[ContentProperty(nameof(Path))]
	public class FamilyExtension : IMarkupExtension<BindingBase> {

		public string Path { get; set; } = string.Empty;

		public object FontName { get; set; }

		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
			this.ProvideValue(serviceProvider);

		public BindingBase ProvideValue(IServiceProvider serviceProvider) =>
			new Binding {
				Mode = BindingMode.OneWay,
				Path = this.Path,
				Source = FontManager.Current,
				Converter = this.FontName != null ? new EnumToStringConverter() : null,
				ConverterParameter = this.FontName
			};

	}

}
