using System;
using System.ComponentModel;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

using MColors = Microsoft.Maui.Graphics.Colors;

namespace StedySoft.Maui.Framework.Controls {

	#region Class MauiTimeSelector
	public class MauiTimeSelector : View {

		#region Constructor
		public MauiTimeSelector() {
			this.BackgroundColor ??= MColors.Transparent;
			ColorManager.Current.PropertyChanged += (s, e) => {
				if (e.PropertyName == "TextShadowColor") {
					this.OnPropertyChanged(nameof(this.TextShadow));
				}
			};
			SharedSettings.Current.PropertyChanged += (s, e) => {
				if (e.PropertyName == "UseShadows") {
					this.OnPropertyChanged(nameof(this.TextShadow));
				}
			};
		}
		#endregion

		#region Bindable Properties
		public static readonly BindableProperty ArrowColorProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.ArrowColor),
				typeof(Color),
				typeof(MauiTimeSelector),
				MColors.Black);

		public Color ArrowColor {
			get => (Color)this.GetValue(MauiTimeSelector.ArrowColorProperty);
			set => this.SetValue(MauiTimeSelector.ArrowColorProperty, value);
		}

		public static readonly BindableProperty FontFamilyProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.FontFamily),
				typeof(string),
				typeof(MauiTimeSelector),
				null);

		public string FontFamily {
			get => (string)this.GetValue(MauiTimeSelector.FontFamilyProperty);
			set => this.SetValue(MauiTimeSelector.FontFamilyProperty, value);
		}

		public static BindableProperty FontSizeProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.FontSize),
				typeof(double),
				typeof(MauiTimeSelector),
				14.0d);

		[TypeConverter(typeof(FontSizeConverter))]
		public double FontSize {
			get => (double)this.GetValue(MauiTimeSelector.FontSizeProperty);
			set => this.SetValue(MauiTimeSelector.FontSizeProperty, value);
		}

		public static readonly BindableProperty RippleColorProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.RippleColor),
				typeof(Color),
				typeof(MauiTimeSelector),
				MColors.White);

		public static readonly BindableProperty MouseOverColorProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.MouseOverColor),
				typeof(Color),
				typeof(MauiTimeSelector),
				default);

		public Color MouseOverColor {
			get => (Color)this.GetValue(MauiTimeSelector.MouseOverColorProperty);
			set => this.SetValue(MauiTimeSelector.MouseOverColorProperty, value);
		}

		public Color RippleColor {
			get => (Color)this.GetValue(MauiTimeSelector.RippleColorProperty);
			set => this.SetValue(MauiTimeSelector.RippleColorProperty, value);
		}

		public static readonly BindableProperty TextColorProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.TextColor),
				typeof(Color),
				typeof(MauiTimeSelector),
				MColors.Black);

		public Color TextColor {
			get => (Color)this.GetValue(MauiTimeSelector.TextColorProperty);
			set => this.SetValue(MauiTimeSelector.TextColorProperty, value);
		}

		public static readonly BindableProperty TextShadowProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.TextShadow),
				typeof(Shadow),
				typeof(MauiTimeSelector),
				null);

		public Shadow TextShadow {
			get {
				Shadow shadow = (Shadow)this.GetValue(MauiTimeSelector.TextShadowProperty);
				if (shadow is not null) {
					shadow.Opacity = SharedSettings.Current.UseShadows ? 1 : 0;
				}
				return shadow;
			}
			set => this.SetValue(MauiTimeSelector.TextShadowProperty, value);
		}

		public static readonly BindableProperty TimeProperty =
			BindableProperty.Create(
				nameof(MauiTimeSelector.Time),
				typeof(TimeOnly),
				typeof(MauiTimeSelector),
				new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, 0),
				BindingMode.TwoWay
			);

		public TimeOnly Time {
			get => (TimeOnly)this.GetValue(MauiTimeSelector.TimeProperty);
			set => this.SetValue(MauiTimeSelector.TimeProperty, value);
		}
		#endregion

	}
	#endregion

}