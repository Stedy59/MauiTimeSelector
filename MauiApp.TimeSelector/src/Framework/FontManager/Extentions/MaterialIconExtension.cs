using System;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace StedySoft.Maui.Framework {

	[ContentProperty(nameof(Path))]
	public class MaterialIconExtension : IMarkupExtension<BindingBase> {

		public string Path { get; set; } = string.Empty;

		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
			this.ProvideValue(serviceProvider);

		public BindingBase ProvideValue(IServiceProvider serviceProvider) =>
			new Binding {
				Mode = BindingMode.OneWay,
				Path = this.Path,
				Source = FontManager.Current.MaterialIconValues
			};

	}

}
