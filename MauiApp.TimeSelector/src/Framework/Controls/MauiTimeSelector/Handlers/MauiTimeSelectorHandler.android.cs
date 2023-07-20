using System;

using Android.Graphics;
using Android.Util;

using AndroidX.AppCompat.Widget;

using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace StedySoft.Maui.Framework.Controls {

	#region Class MauiTimeSelectorHandler
	public partial class MauiTimeSelectorHandler : ViewHandler<MauiTimeSelector, AppCompatTextView> {

		#region Protected Overrides
		protected override AppCompatTextView CreatePlatformView() {
			AppCompatTextView textView = new(this.Context) {
				Clickable = true,
				Focusable = false,
				FocusableInTouchMode = false,
				LongClickable = false,
				SoundEffectsEnabled = true
			};
			textView.SetPadding(
				(int)this.Context.ToPixels(8),
				(int)this.Context.ToPixels(10),
				(int)this.Context.ToPixels(8),
				(int)this.Context.ToPixels(10));
			return textView;
		}

		protected override void ConnectHandler(AppCompatTextView platformView) {
			platformView.Text = this.VirtualView?.Time.ToCurrentCultureString("h:mm tt");
			platformView.Click += this.OnPlatformViewClick;

			platformView.LayoutChange += (s, e) =>
				this._setPickerStyleDrawable(this.PlatformView);

			base.ConnectHandler(platformView);
		}

		protected override void DisconnectHandler(AppCompatTextView platformView) {
			platformView.Click -= this.OnPlatformViewClick;
			base.DisconnectHandler(platformView);
		}
		#endregion

		#region Private Methods
		private void _setPickerStyleDrawable(AppCompatTextView textView) =>
			this.PlatformView
				.As<Android.Views.View>()
				.SetPickerStyleDrawable(
					this.VirtualView.ArrowColor.ToPlatform(),
					this.VirtualView.RippleColor.ToPlatform(),
					(int)this.Context.ToPixels((float)this.VirtualView.FontSize + 0.5f));
		#endregion

		#region Public Methods
		public static void MapArrowColor(MauiTimeSelectorHandler handler, MauiTimeSelector textView) =>
			handler._setPickerStyleDrawable(handler.PlatformView);

		public static void MapBackgroundColor(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) =>
			handler.PlatformView.SetBackgroundColor(timePicker.BackgroundColor.ToPlatform());

		public static void MapFontFamily(MauiTimeSelectorHandler handler, MauiTimeSelector textView) =>
			handler.PlatformView.SetTypeface(FontManagerPlatform.GetTypeFace(textView.FontFamily), TypefaceStyle.Normal);

		public static void MapFontSize(MauiTimeSelectorHandler handler, MauiTimeSelector textView) =>
			handler.PlatformView.SetTextSize(ComplexUnitType.Sp, (float)textView.FontSize);

		public static void MapMouseOverColor(MauiTimeSelectorHandler handler, MauiTimeSelector textView) { }

		public static void MapRippleColor(MauiTimeSelectorHandler handler, MauiTimeSelector textView) =>
			handler._setPickerStyleDrawable(handler.PlatformView);

		public static void MapShadow(MauiTimeSelectorHandler handler, MauiTimeSelector textView) { }

		public static void MapTextColor(MauiTimeSelectorHandler handler, MauiTimeSelector textView) =>
			handler.PlatformView.SetTextColor(textView.TextColor.ToPlatform());

		public static void MapTextShadow(MauiTimeSelectorHandler handler, MauiTimeSelector textView) =>
			handler.PlatformView.SetShadowLayer(
				textView.TextShadow?.Radius ?? 0,
				(float?)textView.TextShadow?.Offset.X ?? 0,
				(float?)textView.TextShadow?.Offset.Y ?? 0,
				(textView.TextShadow?.Opacity ?? 0) == 0f
					? Color.Transparent
					: textView.TextShadow.Brush.As<SolidColorBrush>().Color.ToPlatform());

		public static void MapTime(MauiTimeSelectorHandler handler, MauiTimeSelector timePicker) { }
			#endregion

		#region Events
			private void OnPlatformViewClick(object sender, System.EventArgs e) {
			MauiTimePickerDialog timePickerDlg =
				new(
					this.Context,
					(s, e) => {
						this.VirtualView.Time = new TimeOnly(e.HourOfDay, e.Minute, 0);
						this.PlatformView.Text = this.VirtualView.Time.ToCurrentCultureString("h:mm tt");
					},
					this.VirtualView.Time.Hour,
					this.VirtualView.Time.Minute,
					false);
			timePickerDlg.Show();
		}
		#endregion

	}
	#endregion

}