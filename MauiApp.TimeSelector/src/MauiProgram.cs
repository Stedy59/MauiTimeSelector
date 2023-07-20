using Microsoft.Extensions.Logging;

using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

using StedySoft.Maui.Framework;

namespace StedySoft.TimeSelector {
	public static partial class MauiProgram {
		public static MauiApp CreateMauiApp() {
			MauiAppBuilder builder = MauiApp.CreateBuilder();
			builder.UseMauiApp<App>()
				.ConfigurePlatform()
				.ConfigureFramework();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}

	}

}
