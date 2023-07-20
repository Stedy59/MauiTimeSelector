using Microsoft.Maui;
using MFont = Microsoft.Maui.Font;

using Microsoft.UI.Xaml.Media;

namespace StedySoft.Maui.Framework {

	#region Class FontManagerPlatform
	public static class FontManagerPlatform {

		#region Public Methods
		public static MFont ToPlatform(this FontNames fontName) =>
			FontManagerPlatform.GetFont(FontManager.Current.GetFontAssetName(fontName));

		public static MFont ToPlatform(this FontFamilyNames fontFamilyName) =>
			FontManagerPlatform.GetFont(FontManager.Current.GetFontFamilyAssetName(fontFamilyName));

		public static MFont GetFont(string fontFamily) =>
			fontFamily is not null ? MFont.OfSize(fontFamily, 0) : MFont.Default;

		public static FontFamily GetFontFamily(this MFont font, IFontManager fontManager) =>
			fontManager.GetFontFamily(font);
		#endregion

	}
	#endregion

}
