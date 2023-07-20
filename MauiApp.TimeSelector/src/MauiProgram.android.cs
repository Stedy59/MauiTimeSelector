using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;

using AActivity = Android.App.Activity;
using AProcess = Android.OS.Process;

using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;

using MApplication = Microsoft.Maui.Controls.Application;

using StedySoft.Maui.Framework.Controls;

using StedySoft.Maui.Framework;

namespace StedySoft.TimeSelector {

	#region Class MauiProgram
	public static partial class MauiProgram {

		public static MauiAppBuilder ConfigurePlatform(this MauiAppBuilder builder) {
			_ = builder
				.ConfigureLifecycleEvents(AppLifecycle => {
					_ = AppLifecycle.AddAndroid(android => android.OnCreate((activity, bundle) => Create(activity, bundle)));
					_ = AppLifecycle.AddAndroid(android => android.OnActivityResult((activity, requestCode, resultCode, data) => ActivityResult(activity, requestCode, resultCode, data)));
					_ = AppLifecycle.AddAndroid(android => android.OnBackPressed((activity) => BackPressed()));
					_ = AppLifecycle.AddAndroid(android => android.OnDestroy((activity) => Destroy()));
				});

			return builder;
		}

		private static void Create(AActivity activity, Bundle? savedInstanceState) { }

		private static void Destroy() =>
			FontManagerPlatform.Dispose();

		private static void ActivityResult(AActivity activity, int requestCode, Result resultCode, Intent? data) { }

		public static bool BackPressed() =>
			true;

	}
	#endregion

}
