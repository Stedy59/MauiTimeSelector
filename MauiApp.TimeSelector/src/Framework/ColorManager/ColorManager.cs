using System;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace StedySoft.Maui.Framework {

	#region Class ColorManager
	public sealed class ColorManager : ObservableObject {

		#region Singleton Design Pattern
		private static readonly Lazy<ColorManager> _current =
			new(() => new ColorManager());

		public static ColorManager Current =>
			ColorManager._current.Value;
		#endregion

		#region Declarations
		private Color _accentColor = Color.FromHex(ColorManager._accentColorLight);
		private const string _accentColorLight = "#EE2196F3";
		private const string _accentColorDark = "#EEFF9E00";

		private Color _accentTextColor = Color.FromHex(ColorManager._accentTextColorLight);
		private const string _accentTextColorLight = "#FFFAFAFA";
		private const string _accentTextColorDark = "#FF3A3A3A";

		private Color _arrowColor = Color.FromHex(ColorManager._arrowColorLight);
		private const string _arrowColorLight = "#EE2196F3";
		private const string _arrowColorDark = "#EEFF9E00";

		private Color _backgroundColor = Color.FromHex(ColorManager._backgroundColorLight);
		private const string _backgroundColorLight = "#FFE6E6E6";
		private const string _backgroundColorDark = "#FF202020";

		private Color _borderColor = Color.FromHex(ColorManager._borderColorLight);
		private const string _borderColorLight = "#FFBABABA";
		private const string _borderColorDark = "#FF393939";

		private Color _buttonColor = Color.FromHex(ColorManager._buttonColorLight);
		private const string _buttonColorLight = "#FFE8E8E8";
		private const string _buttonColorDark = "#FF282828";

		private Color _dropdownColor = Color.FromHex(ColorManager._dropdownColorLight);
		private const string _dropdownColorLight = "#FFEDEDED";
		private const string _dropdownColorDark = "#FF2D2D2D";

		private Color _frameHighlightColor = Color.FromHex(ColorManager._frameHighlightColorLight);
		private const string _frameHighlightColorLight = "#FFFFFFFF";
		private const string _frameHighlightColorDark = "#FF323232";

		private Color _frameBackgroundColor = Color.FromHex(ColorManager._frameBackgroundColorLight);
		private const string _frameBackgroundColorLight = "#FFF1F1F1";
		private const string _frameBackgroundColorDark = "#FF242424";

		private Color _frameBorderColor = Color.FromHex(ColorManager._frameBorderColorLight);
		private const string _frameBorderColorLight = "#FFF3F3F3";
		private const string _frameBorderColorDark = "#FF262626";

		private Color _mouseOverColor = Color.FromHex(ColorManager._mouseOverColorLight);
		private const string _mouseOverColorLight = "#FFF1F1F1";
		private const string _mouseOverColorDark = "#FF424242";

		private Color _navBarColor = Color.FromHex(ColorManager._navBarColorLight);
		private const string _navBarColorLight = "#FFDADADA";
		private const string _navBarColorDark = "#FF181818";

		private Color _navPageColor = Color.FromHex(ColorManager._navPageColorLight);
		private const string _navPageColorLight = "#FF959595";
		private const string _navPageColorDark = "#FF707070";

		private Color _rippleColor = Color.FromHex(ColorManager._rippleColorLight);
		private const string _rippleColorLight = "#5C2196F3";
		private const string _rippleColorDark = "#5CFF9E00";

		private Color _switchOffColor = Color.FromHex(ColorManager._switchOffColorLight);
		private const string _switchOffColorLight = "#EE959595";
		private const string _switchOffColorDark = "#EE505050";

		private Color _switchOnColor = Color.FromHex(ColorManager._switchOnColorLight);
		private const string _switchOnColorLight = "#EE2196F3";
		private const string _switchOnColorDark = "#EEFF9E00";

		private Color _tabColor = Color.FromHex(ColorManager._tabColorLight);
		private const string _tabColorLight = "#FFDADADA";
		private const string _tabColorDark = "#FF181818";

		private Color _tabTextColor = Color.FromHex(ColorManager._tabTextColorLight);
		private const string _tabTextColorLight = "#FF6E6E6E";
		private const string _tabTextColorDark = "#FFCCCCCC";

		private Color _tabTextSelectedColor = Color.FromHex(ColorManager._tabTextSelectedColorLight);
		private const string _tabTextSelectedColorLight = "#EE2196F3";
		private const string _tabTextSelectedColorDark = "#EEFF9E00";

		private Color _textColor = Color.FromHex(ColorManager._textColorLight);
		private const string _textColorLight = "#FF3A3A3A";
		private const string _textColorDark = "#FFFAFAFA";

		private Color _textAltColor = Color.FromHex(ColorManager._textAltColorLight);
		private const string _textAltColorLight = "#FFAAAAAA";
		private const string _textAltColorDark = "#FFBEBEBE";

		private Color _textShadowColor = Color.FromHex(ColorManager._textShadowColorLight);
		private const string _textShadowColorLight = "#FF303030";
		private const string _textShadowColorDark = "#FF000000";

		private Color _translucentBackgroundColor = Color.FromHex(ColorManager._translucentBackgroundColorLight);
		private const string _translucentBackgroundColorLight = "#7CFFFFFF";
		private const string _translucentBackgroundColorDark = "#5C000000";

		private ResourceDictionary _colors;
		#endregion

		#region Constructor
		private ColorManager() { }
		#endregion

		#region Private Methods
		private Color _getColor(string resourceColorName, string defaultColor) =>
			this.Colors?.TryGetValue(resourceColorName, out object color) ?? false
				? color.As<Color>()
				: Color.FromHex(defaultColor);
		#endregion

		#region Internal Methods
		internal void _darkModeChange(bool isDarkMode) {
			this.AccentColor =
				isDarkMode
					? this._getColor("DarkAccentColor", ColorManager._accentColorDark)
					: this._getColor("LightAccentColor", ColorManager._accentColorLight);
			this.AccentTextColor =
				isDarkMode
					? this._getColor("DarkAccentTextColor", ColorManager._accentTextColorDark)
					: this._getColor("LightAccentTextColor", ColorManager._accentTextColorLight);
			this.ArrowColor =
				isDarkMode
					? this._getColor("DarkArrowColor", ColorManager._arrowColorDark)
					: this._getColor("LightArrowColor", ColorManager._arrowColorLight);
			this.BackgroundColor =
				isDarkMode
					? this._getColor("DarkBackgroundColor", ColorManager._backgroundColorDark)
					: this._getColor("LightBackgroundColor", ColorManager._backgroundColorLight);
			this.BorderColor =
				isDarkMode
					? this._getColor("DarkBorderColor", ColorManager._borderColorDark)
					: this._getColor("LightBorderColor", ColorManager._borderColorLight);
			this.ButtonColor =
				isDarkMode
					? this._getColor("DarkButtonColor", ColorManager._buttonColorDark)
					: this._getColor("LightButtonColor", ColorManager._buttonColorLight);
			this.DropdownColor =
				isDarkMode
					? this._getColor("DarkDropdownColor", ColorManager._dropdownColorDark)
					: this._getColor("LightDropdownColor", ColorManager._dropdownColorLight);
			this.FrameHighlightColor =
				isDarkMode
					? this._getColor("DarkFrameHighlightColor", ColorManager._frameHighlightColorDark)
					: this._getColor("LightFrameHighlightColor", ColorManager._frameHighlightColorLight);
			this.FrameBackgroundColor =
				isDarkMode
					? this._getColor("DarkFrameBackgroundColor", ColorManager._frameBackgroundColorDark)
					: this._getColor("LightFrameBackgroundColor", ColorManager._frameBackgroundColorLight);
			this.FrameBorderColor =
				isDarkMode
					? this._getColor("DarkFrameBorderColor", ColorManager._frameBorderColorDark)
					: this._getColor("LightFrameBorderColor", ColorManager._frameBorderColorLight);
			this.MouseOverColor =
				isDarkMode
					? this._getColor("DarkMouseOverColor", ColorManager._mouseOverColorDark)
					: this._getColor("LightMouseOverColor", ColorManager._mouseOverColorLight);
			this.NavigationBarColor =
				isDarkMode
					? this._getColor("DarkNavigationBarColor", ColorManager._navBarColorDark)
					: this._getColor("LightNavigationBarColor", ColorManager._navBarColorLight);
			this.NavigationPageColor =
				isDarkMode
					? this._getColor("DarkNavigationPageColor", ColorManager._navPageColorDark)
					: this._getColor("LightNavigationPageColor", ColorManager._navPageColorLight);
			this.RippleColor =
				isDarkMode
					? this._getColor("DarkRippleColor", ColorManager._rippleColorDark)
					: this._getColor("LightRippleColor", ColorManager._rippleColorLight);
			this.SwitchOffColor =
				isDarkMode
					? this._getColor("DarkSwitchOffColor", ColorManager._switchOffColorDark)
					: this._getColor("LightSwitchOffColor", ColorManager._switchOffColorLight);
			this.SwitchOnColor =
				isDarkMode
					? this._getColor("DarkSwitchOnColor", ColorManager._switchOnColorDark)
					: this._getColor("LightSwitchOnColor", ColorManager._switchOnColorLight);
			this.TabColor =
				isDarkMode
					? this._getColor("DarkTabColor", ColorManager._tabColorDark)
					: this._getColor("LightTabColor", ColorManager._tabColorLight);
			this.TabTextColor =
				isDarkMode
					? this._getColor("DarkTabTextColor", ColorManager._tabTextColorDark)
					: this._getColor("LightTabTextColor", ColorManager._tabTextColorLight);
			this.TabTextSelectedColor =
				isDarkMode
					? this._getColor("DarkTabTextSelectedColor", ColorManager._tabTextSelectedColorDark)
					: this._getColor("LightTabTextSelectedColor", ColorManager._tabTextSelectedColorLight);
			this.TextColor =
				isDarkMode
					? this._getColor("DarkTextColor", ColorManager._textColorDark)
					: this._getColor("LightTextColor", ColorManager._textColorLight);
			this.TextAltColor =
				isDarkMode
					? this._getColor("DarkTextAltColor", ColorManager._textAltColorDark)
					: this._getColor("LightTextAltColor", ColorManager._textAltColorLight);
			this.TextShadowColor =
				isDarkMode
					? this._getColor("DarkTextShadowColor", ColorManager._textShadowColorDark)
					: this._getColor("LightTextShadowColor", ColorManager._textShadowColorLight);
			this.TranslucentBackgroundColor =
				isDarkMode
					? this._getColor("DarkTranslucentBackgroundColor", ColorManager._translucentBackgroundColorDark)
					: this._getColor("LightTranslucentBackgroundColor", ColorManager._translucentBackgroundColorLight);
		}
		#endregion

		#region Properties
		public ResourceDictionary Colors {
			get => this._colors;
			set => this.SetProperty(
				ref this._colors,
				value,
				onChanged: () => this._darkModeChange(SharedSettings.Current.DarkMode));
		}

		public Color AccentColor {
			get => this._accentColor;
			set => this.SetProperty(ref this._accentColor, value);
		}

		public Color AccentTextColor {
			get => this._accentTextColor;
			set => this.SetProperty(ref this._accentTextColor, value);
		}

		public Color ArrowColor {
			get => this._arrowColor;
			set => this.SetProperty(ref this._arrowColor, value);
		}

		public Color BackgroundColor {
			get => this._backgroundColor;
			set => this.SetProperty(ref this._backgroundColor, value);
		}

		public Color BorderColor {
			get => this._borderColor;
			set => this.SetProperty(ref this._borderColor, value);
		}

		public Color ButtonColor {
			get => this._buttonColor;
			set => this.SetProperty(ref this._buttonColor, value);
		}

		public Color DropdownColor {
			get => this._dropdownColor;
			set => this.SetProperty(ref this._dropdownColor, value);
		}

		public Color FrameHighlightColor {
			get => this._frameHighlightColor;
			set => this.SetProperty(ref this._frameHighlightColor, value);
		}

		public Color FrameBackgroundColor {
			get => this._frameBackgroundColor;
			set => this.SetProperty(ref this._frameBackgroundColor, value);
		}

		public Color FrameBorderColor {
			get => this._frameBorderColor;
			set => this.SetProperty(ref this._frameBorderColor, value);
		}

		public Color MouseOverColor {
			get => this._mouseOverColor;
			set => this.SetProperty(ref this._mouseOverColor, value);
		}

		public Color NavigationBarColor {
			get => this._navBarColor;
			set => this.SetProperty(ref this._navBarColor, value);
		}

		public Color NavigationPageColor {
			get => this._navPageColor;
			set => this.SetProperty(ref this._navPageColor, value);
		}

		public Color RippleColor {
			get => this._rippleColor;
			set => this.SetProperty(ref this._rippleColor, value);
		}

		public Color SwitchOffColor {
			get => this._switchOffColor;
			set => this.SetProperty(ref this._switchOffColor, value);
		}

		public Color SwitchOnColor {
			get => this._switchOnColor;
			set => this.SetProperty(ref this._switchOnColor, value);
		}

		public Color TabColor {
			get => this._tabColor;
			set => this.SetProperty(ref this._tabColor, value);
		}

		public Color TabTextColor {
			get => this._tabTextColor;
			set => this.SetProperty(ref this._tabTextColor, value);
		}

		public Color TabTextSelectedColor {
			get => this._tabTextSelectedColor;
			set => this.SetProperty(ref this._tabTextSelectedColor, value);
		}

		public Color TextColor {
			get => this._textColor;
			set => this.SetProperty(ref this._textColor, value);
		}

		public Color TextAltColor {
			get => this._textAltColor;
			set => this.SetProperty(ref this._textAltColor, value);
		}

		public Color TextShadowColor {
			get => this._textShadowColor;
			set => this.SetProperty(ref this._textShadowColor, value);
		}

		public Color TranslucentBackgroundColor {
			get => this._translucentBackgroundColor;
			set => this.SetProperty(ref this._translucentBackgroundColor, value);
		}
		#endregion

	}
	#endregion

}
