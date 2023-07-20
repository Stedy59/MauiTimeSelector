using System;
using System.Linq;

using Microsoft.Maui.Hosting;

namespace StedySoft.Maui.Framework {

	#region Class FontManager
	public sealed class FontManager : ObservableObject {

		#region Singleton Design Pattern
		private static readonly Lazy<FontManager> _current =
			new(() => new FontManager());

		public static FontManager Current =>
			FontManager._current.Value;
		#endregion

		#region Declarations
		private static readonly MaterialDesignIcons _materialIconValues = new();

		private IFontCollection _fontCollection;

		private FontFamilyNames _fontFamily = FontFamilyNames.Default;

		private string _normal;
		private string _bold;
		private string _thin;
		private string _thinBold;
		#endregion

		#region Constructor
		private FontManager() { }
		#endregion

		#region Private Methods
		private void _setFontFamily(FontFamilyNames fontFamilyName) {
			switch (fontFamilyName) {
				case FontFamilyNames.ComicNeue:
					this.Normal = this.GetFontAssetName(FontNames.ComicNeue);
					this.Bold = this.GetFontAssetName(FontNames.ComicNeueBold);
					this.Thin = this.GetFontAssetName(FontNames.ComicNeueThin);
					this.ThinBold = this.GetFontAssetName(FontNames.ComicNeueThinBold);
					break;
				case FontFamilyNames.HelveticaNeue:
					this.Normal = this.GetFontAssetName(FontNames.HelveticaNeue);
					this.Bold = this.GetFontAssetName(FontNames.HelveticaNeueBold);
					this.Thin = this.GetFontAssetName(FontNames.HelveticaNeueThin);
					this.ThinBold = this.GetFontAssetName(FontNames.HelveticaNeueThinBold);
					break;
				case FontFamilyNames.OpenSans:
					this.Normal = this.GetFontAssetName(FontNames.OpenSans);
					this.Bold = this.GetFontAssetName(FontNames.OpenSansBold);
					this.Thin = this.GetFontAssetName(FontNames.OpenSansThin);
					this.ThinBold = this.GetFontAssetName(FontNames.OpenSansThinBold);
					break;
				case FontFamilyNames.Roboto:
					this.Normal = this.GetFontAssetName(FontNames.Roboto);
					this.Bold = this.GetFontAssetName(FontNames.RobotoBold);
					this.Thin = this.GetFontAssetName(FontNames.RobotoThin);
					this.ThinBold = this.GetFontAssetName(FontNames.RobotoThinBold);
					break;
				case FontFamilyNames.Urbanist:
					this.Normal = this.GetFontAssetName(FontNames.Urbanist);
					this.Bold = this.GetFontAssetName(FontNames.UrbanistBold);
					this.Thin = this.GetFontAssetName(FontNames.UrbanistThin);
					this.ThinBold = this.GetFontAssetName(FontNames.UrbanistThinBold);
					break;
				default:
					this.Normal = null;
					this.Bold = null;
					this.Thin = null;
					this.ThinBold = null;
					break;
			}
		}
		#endregion

		#region Public Properties
		public IFontCollection FontCollection {
			get => this._fontCollection;
			set => this.SetProperty(ref this._fontCollection, value);
		}

		public FontFamilyNames FontFamily {
			get => this._fontFamily;
			internal set => this.SetProperty(
				ref this._fontFamily,
				value,
				onChanged: () => this._setFontFamily(value));
		}

		public string Normal {
			get => this._normal;
			internal set => this.SetProperty(ref this._normal, value);
		}

		public string Bold {
			get => this._bold;
			internal set => this.SetProperty(ref this._bold, value);
		}

		public string Thin {
			get => this._thin;
			internal set => this.SetProperty(ref this._thin, value);
		}

		public string ThinBold {
			get => this._thinBold;
			internal set => this.SetProperty(ref this._thinBold, value);
		}
		public string MaterialIcons =>
			this.GetFontAssetName(FontNames.MaterialIconsOutlined);

		public MaterialDesignIcons MaterialIconValues =>
			FontManager._materialIconValues;
		#endregion

		#region Public Methods
		public string GetFontAssetName(FontNames fontName) =>
			this.FontCollection.FirstOrDefault(font =>
				font.Alias.Equals(fontName.ToString()))?.Filename;

		public string GetFontFamilyAssetName(FontFamilyNames fontFamilyName) =>
			this.FontCollection.FirstOrDefault(font =>
				font.Alias.Equals($"{fontFamilyName}ThinBold"))?.Filename;
		#endregion

	}
	#endregion

}
