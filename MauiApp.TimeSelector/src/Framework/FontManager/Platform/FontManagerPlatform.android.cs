using System.Collections.Generic;
using System.Linq;

using Android.Graphics;

using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;

namespace StedySoft.Maui.Framework {

	#region Class FontManagerPlatform
	public static class FontManagerPlatform {

		#region Declarations
		private static List<FontManagerPlatform.TypeFaceHolder> _typefaces { get; } = new List<FontManagerPlatform.TypeFaceHolder>();
		#endregion

		#region Class TypeFaceHolder
		private class TypeFaceHolder {

			#region Public Properties
			public string FontFamily { get; set; }
			public Typeface Typeface { get; set; }
			#endregion

		}
		#endregion

		#region Public Methods
		public static void Dispose() {
			foreach (TypeFaceHolder typeface in FontManagerPlatform._typefaces) { typeface.Typeface.Dispose(); }
			FontManagerPlatform._typefaces.Clear();
		}

		public static Typeface GetTypeFace(string fontFamily) {
			if (string.IsNullOrWhiteSpace(fontFamily) || fontFamily.Equals("Default", System.StringComparison.OrdinalIgnoreCase)) { return Typeface.Default; }
			foreach (TypeFaceHolder typeface in
				from TypeFaceHolder typeface in FontManagerPlatform._typefaces
				where typeface.FontFamily == fontFamily
				select typeface) {
					return typeface.Typeface;
				}
			TypeFaceHolder typeFaceHolder = new() {
				FontFamily = fontFamily,
				Typeface = new Font(fontFamily).ToTypeface()
			};
			FontManagerPlatform._typefaces.Add(typeFaceHolder);
			return typeFaceHolder.Typeface;
		}

		public static Typeface ToPlatform(this FontNames fontName) =>
			GetTypeFace(FontManager.Current.GetFontAssetName(fontName));

		public static Typeface ToPlatform(this FontFamilyNames fontFamilyName) =>
			GetTypeFace(FontManager.Current.GetFontFamilyAssetName(fontFamilyName));
		#endregion

	}
	#endregion

}
