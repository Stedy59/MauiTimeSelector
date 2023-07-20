using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

using StedySoft.Maui.Framework.Controls;

namespace StedySoft.Maui.Framework {

	#region Class AppBuilderExtensions
	public static class AppBuilderExtensions {

		#region Private Methods
		private static MauiAppBuilder ConfigureControls(this MauiAppBuilder builder) =>
			builder.ConfigureMauiHandlers(handlers =>
				handlers.AddHandler(typeof(MauiTimeSelector), typeof(MauiTimeSelectorHandler)));

		private static MauiAppBuilder ConfigureColorManager(this MauiAppBuilder builder) {
			_ = builder.Services.AddSingleton(ColorManager.Current);
			return builder;
		}

		private static MauiAppBuilder ConfigureFontManager(this MauiAppBuilder builder) {
			_ = builder.Services.AddSingleton(FontManager.Current);
			return builder.ConfigureFonts(fonts => {
				_ = fonts.AddFont("AsenineWide.ttf", "AsenineWide");
				_ = fonts.AddFont("ComicNeue.ttf", "ComicNeue");
				_ = fonts.AddFont("ComicNeueBold.ttf", "ComicNeueBold");
				_ = fonts.AddFont("ComicNeueThin.ttf", "ComicNeueThin");
				_ = fonts.AddFont("ComicNeueThin.ttf", "ComicNeueThinBold");
				_ = fonts.AddFont("HelveticaNeue.ttf", "HelveticaNeue");
				_ = fonts.AddFont("HelveticaNeueBold.ttf", "HelveticaNeueBold");
				_ = fonts.AddFont("HelveticaNeueThin.ttf", "HelveticaNeueThin");
				_ = fonts.AddFont("HelveticaNeueThinBold.ttf", "HelveticaNeueThinBold");
				_ = fonts.AddFont("MaterialIconsOutlined.ttf", "MaterialIconsOutlined");
				_ = fonts.AddFont("OpenSans.ttf", "OpenSans");
				_ = fonts.AddFont("OpenSansBold.ttf", "OpenSansBold");
				_ = fonts.AddFont("OpenSansThin.ttf", "OpenSansThin");
				_ = fonts.AddFont("OpenSansThinBold.ttf", "OpenSansThinBold");
				_ = fonts.AddFont("Roboto.ttf", "Roboto");
				_ = fonts.AddFont("RobotoBold.ttf", "RobotoBold");
				_ = fonts.AddFont("RobotoThin.ttf", "RobotoThin");
				_ = fonts.AddFont("RobotoThinBold.ttf", "RobotoThinBold");
				_ = fonts.AddFont("Urbanist.ttf", "Urbanist");
				_ = fonts.AddFont("UrbanistBold.ttf", "UrbanistBold");
				_ = fonts.AddFont("UrbanistThin.ttf", "UrbanistThin");
				_ = fonts.AddFont("UrbanistThinBold.ttf", "UrbanistThinBold");
				_ = fonts.AddFont("ScriptinaPro.ttf", "ScriptinaPro");
				FontManager.Current.FontCollection = fonts;
			});
		}

		private static MauiAppBuilder ConfigureSharedSettings(this MauiAppBuilder builder) {
			_ = builder.Services.AddSingleton(SharedSettings.Current);
			return builder;
		}
		#endregion

		#region Public Methods
		public static MauiAppBuilder ConfigureFramework(this MauiAppBuilder builder) =>
			builder
				.ConfigureSharedSettings()
				.ConfigureColorManager()
				.ConfigureFontManager()
				.ConfigureControls();
		#endregion

	}
	#endregion

}
