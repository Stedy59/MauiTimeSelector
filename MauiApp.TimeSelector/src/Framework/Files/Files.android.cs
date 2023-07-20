using MPlatform = Microsoft.Maui.ApplicationModel.Platform;

namespace StedySoft.Maui.Framework {

	#region Class Files
	public static partial class Files {

		#region Declarations
		private static string _rootDirectory { get; } = MPlatform.AppContext.ApplicationContext.GetExternalFilesDir("").Path;
		#endregion

	}
	#endregion

}
