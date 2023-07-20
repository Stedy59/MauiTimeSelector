using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace StedySoft.Maui.Framework.Controls {

	#region Class PlatformTimePicker
	public class PlatformTimePicker : TimePicker {

		#region Protected Overrides
		protected override void OnApplyTemplate() {
			base.OnApplyTemplate();

			Button flyoutButton = this.GetTemplateChild("FlyoutButton").As<Button>();
			if (flyoutButton != null) {
				this.SizeChanged += (s, e) => {
					if (flyoutButton != null) {
						flyoutButton.MinWidth = this.ActualWidth;
						flyoutButton.MaxWidth = this.ActualWidth;
					}
				};
				flyoutButton.VerticalAlignment = VerticalAlignment.Center;
				flyoutButton.VerticalContentAlignment = VerticalAlignment.Stretch;
				flyoutButton.MaxWidth = double.PositiveInfinity;
				flyoutButton.Padding = new Thickness(0);
				flyoutButton.Margin = new Thickness(0);
				Grid grid = flyoutButton?.Content.As<Grid>();
				grid.Padding = new Thickness(0);
				grid.SizeChanged += (s, e) => {
					double m = (35d - grid.ActualHeight) / 2;
					grid.Margin = new Thickness(0, m, 0, m);
				};
			}
		}
		#endregion

		#region Public Properties
		public MauiTimeSelector VirtualView { get; set; }
		#endregion

	}
	#endregion

}
