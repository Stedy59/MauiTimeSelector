using Windows.Storage;

namespace StedySoft.Maui.Framework {

	#region Class Files
	public static partial class Files {

		#region Declarations
		private static string _rootDirectory { get; } = ApplicationData.Current.LocalFolder.Path;
		#endregion

	}
	#endregion

}
