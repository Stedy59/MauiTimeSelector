using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using Microsoft.Maui.Controls;

using StedySoft.Maui.Framework;

namespace StedySoft.TimeSelector.Views {
	public partial class MainPage : ContentPage {

		public readonly ObservableCollection<FontItem> FontCollection = new();

		public MainPage() {
			this.InitializeComponent();
			static string GetEnumDescriptionFunc(object value) {
				object[] attributeArray = value.GetType().GetField(value.ToString()).GetCustomAttributes(false);
				return attributeArray.Length == 0
					? value.ToString()
					: attributeArray[0].As<DescriptionAttribute>().Description;
			}
			foreach (FontFamilyNames ffn in Enum.GetValues(typeof(FontFamilyNames))) {
				this.FontCollection.Add(new FontItem {
					Name = GetEnumDescriptionFunc(ffn),
					FontFamily = ffn.ToString(),
					Value = ffn
				});
			}
			this.fontsCollectionView.ItemsSource = this.FontCollection;
			this.fontsCollectionView.SelectedItem = this.FontCollection[0];
		}

		public static readonly BindableProperty CurrentTimeProperty =
			BindableProperty.Create(
				nameof(MainPage.CurrentTime),
				typeof(TimeOnly),
				typeof(MainPage),
				new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute));

		public TimeOnly CurrentTime {
			get => (TimeOnly)this.GetValue(MainPage.CurrentTimeProperty);
			set => this.SetValue(MainPage.CurrentTimeProperty, value);
		}

		public static readonly BindableProperty CurrentTimeSpanProperty =
			BindableProperty.Create(
				nameof(MainPage.CurrentTimeSpan),
				typeof(TimeSpan),
				typeof(MainPage),
				DateTime.Now.TimeOfDay);

		public TimeSpan CurrentTimeSpan {
			get => (TimeSpan)this.GetValue(MainPage.CurrentTimeSpanProperty);
			set => this.SetValue(MainPage.CurrentTimeSpanProperty, value);
		}

		private void FontSelectionChanged(object sender, SelectionChangedEventArgs e) =>
			FontManager.Current.FontFamily = this.fontsCollectionView.SelectedItem.As<FontItem>().Value;

	}

}
