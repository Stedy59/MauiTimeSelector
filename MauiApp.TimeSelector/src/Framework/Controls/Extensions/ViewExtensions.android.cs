using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;

using AColor = Android.Graphics.Color;
using AView = Android.Views.View;

using AndroidX.Core.Content;

using Microsoft.Maui.Platform;

using AppResources = StedySoft.TimeSelector.Resource;

namespace StedySoft.Maui.Framework.Controls {

	#region Class ViewExtensions
	public static partial class ViewExtensions {

		#region Private Methods
		private static BitmapDrawable _getBitmapDrawable(Context context, AColor arrowColor) {
			using Drawable drawable = ContextCompat.GetDrawable(context, AppResources.Drawable.dropdown_ripple_arrow);
			BitmapDrawable bitmapDrawable = new(context.Resources, ((BitmapDrawable)drawable).Bitmap) {
				Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical
			};
			bitmapDrawable.SetColorFilter(new PorterDuffColorFilter(arrowColor, PorterDuff.Mode.SrcIn));
			return bitmapDrawable;
		}
		#endregion

		#region Public Methods
		public static void SetBackgroundDrawable(this AView view, AColor backgroundColor, int borderWidth = 0, AColor? borderColor = null, float cornerRadius = 0) {
			using GradientDrawable gDrawable = new();
			gDrawable.SetColor(backgroundColor);
			if (borderWidth > 0) { gDrawable.SetStroke(borderWidth, borderColor ?? AColor.Transparent); }
			if (cornerRadius > 0) { gDrawable.SetCornerRadius(cornerRadius); }
			view.Background = gDrawable;
		}

		public static void SetPickerStyleDrawable(this AView view, AColor arrowColor, AColor rippleColor, int rippleRadius) {
			using PaintDrawable mask = new();
			using BitmapDrawable bitmapDrawable = ViewExtensions._getBitmapDrawable(view.Context, arrowColor);
			using RippleDrawable rippleDrawable =
				new(ColorStateList.ValueOf(rippleColor), bitmapDrawable, mask) {
					Radius = rippleRadius
				};
			using LayerDrawable layerDrawable = new(new Drawable[] { rippleDrawable });
			layerDrawable.SetLayerInset(0, 0, 0, (int)view.Context.ToPixels(3), 0);
			layerDrawable.SetLayerGravity(0, GravityFlags.Right);
			view.Background = layerDrawable;
		}

		public static void SetRippleDrawable(this AView view, AColor rippleColor, float cornerRadius) {
			using PaintDrawable mask = new();
			mask.SetCornerRadius(cornerRadius);
			using GradientDrawable gDrawable = new();
			gDrawable.SetCornerRadius(cornerRadius);
			view.Background = (RippleDrawable)(new(ColorStateList.ValueOf(rippleColor), gDrawable, mask));
		}
		#endregion

	}
	#endregion

}
