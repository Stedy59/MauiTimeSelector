using System;

using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace StedySoft.Maui.Framework.Controls {

	#region Class MauiTimeSelectorHandler
	public partial class MauiTimeSelectorHandler : ViewHandler<MauiTimeSelector, PlatformTimePicker> {

		#region Protected Overrides
		protected override PlatformTimePicker CreatePlatformView() =>
			new();

		protected override void ConnectHandler(PlatformTimePicker platformView) {
			platformView.VirtualView = this.VirtualView;

			platformView.Loaded += this.OnPlatformViewLoaded;
			platformView.Unloaded += this.OnPlatformViewUnloaded;

			platformView.TimeChanged += this.OnPlatformViewTimeChanged;

			base.ConnectHandler(platformView);
		}

		protected override void DisconnectHandler(PlatformTimePicker platformView) {
			platformView.Loaded -= this.OnPlatformViewLoaded;
			platformView.Unloaded -= this.OnPlatformViewUnloaded;

			platformView.TimeChanged -= this.OnPlatformViewTimeChanged;

			base.DisconnectHandler(platformView);
		}
		#endregion

		#region Public Methods
		public static void MapArrowColor(MauiTimeSelectorHandler handler, MauiTimeSelector textView) { }

		public static void MapBackgroundColor(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) {
			handler.PlatformView.Background = timePicker.BackgroundColor.ToPlatform();
			handler.PlatformView.TryUpdateResources(
				new string[] {
					"TimePickerButtonBackground",
					"TimePickerButtonBackgroundDisabled",
					"TimePickerButtonBackgroundFocused" },
				timePicker.BackgroundColor.ToPlatform());
		}

		public static void MapFontFamily(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) {
			handler.PlatformView.FontFamily = handler.GetRequiredService<IFontManager>()
				.GetFontFamily(Font.OfSize(timePicker.FontFamily, timePicker.FontSize));
			handler.PlatformView?.Parent?.As<WrapperView>()?.UpdateLayout();
		}

		public static void MapFontSize(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) =>
			handler.PlatformView.FontSize = timePicker.FontSize;

		public static void MapMouseOverColor(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) =>
			handler.PlatformView.TryUpdateResources(
				new string[] { "TimePickerButtonBackgroundPointerOver" },
				timePicker.MouseOverColor.ToPlatform());

		public static void MapRippleColor(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) =>
			handler.PlatformView.TryUpdateResources(
				new string[] {
					"TimePickerButtonBackgroundPressed",
					"TimePickerFlyoutPresenterHighlightFill" },
				timePicker.RippleColor.ToPlatform());

		public static void MapShadow(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) =>
			handler.PlatformView.UpdateShadow(timePicker);

		public static void MapTextColor(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) {
			handler.PlatformView.Foreground = timePicker.TextColor.ToPlatform();
			handler.PlatformView.TryUpdateResources(
				new string[] {
					"TimePickerButtonForeground",
					"TimePickerButtonForegroundPointerOver",
					"TimePickerButtonForegroundPressed",
					"TimePickerButtonForegroundDisabled",
					"TimePickerButtonForegroundFocused" },
				timePicker.TextColor.ToPlatform());
		}

		public static void MapTextShadow(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) { }

		public static void MapTime(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) {
			handler.PlatformView.Time = timePicker.Time.ToTimeSpan();
			handler.PlatformView.ClockIdentifier = "12HourClock";
		}
		#endregion

		#region Events
		private void OnPlatformViewLoaded(object sender, RoutedEventArgs e) {
			if (this.PlatformView?.Parent is null) { return; }
			this.PlatformView.Parent.As<WrapperView>().SizeChanged += this.OnPlatformViewParentSizeChanged;
			this.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
			this.PlatformView.Height = this.PlatformView.Parent.As<WrapperView>().ActualHeight;
			this.PlatformView.Width = this.PlatformView.Parent.As<WrapperView>().ActualWidth;
		}

		private void OnPlatformViewUnloaded(object sender, RoutedEventArgs e) {
			if (this.PlatformView?.Parent is null) { return; }
			this.PlatformView.Parent.As<WrapperView>().SizeChanged -= this.OnPlatformViewParentSizeChanged;
		}

		private void OnPlatformViewParentSizeChanged(object sender, SizeChangedEventArgs e) {
			if (this.PlatformView?.Parent is null) { return; }
			this.PlatformView.Width = this.PlatformView.Parent.As<WrapperView>().ActualWidth;
			this.PlatformView.Height = this.PlatformView.Parent.As<WrapperView>().ActualHeight;
		}

		private void OnPlatformViewTimeChanged(object? sender, TimePickerValueChangedEventArgs e) =>
			this.VirtualView.As<MauiTimeSelector>().Time = new TimeOnly(e.NewTime.Hours, e.NewTime.Minutes, 0);
		#endregion

	}
	#endregion

}