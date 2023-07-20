using System.IO;
using System.Threading.Tasks;

namespace StedySoft.Maui.Framework {

	#region Class Files
	public static partial class Files {

		#region Private Methods
		private static string _getFolder(string folder) =>
			folder.Equals(".")
			? Files._rootDirectory
			: Path.Combine(Files._rootDirectory, folder);

		private static string _validateFolder(string folder) {
			string f = Files._getFolder(folder);
			if (!Directory.Exists(f)) { _ = Directory.CreateDirectory(f); }
			return f;
		}
		#endregion

		#region Public Methods
		public static bool DeleteFile(string folder, string fileName) {
			if (!Files.FileExists(folder, fileName)) { return true; }
			try {
				File.Delete(Path.Combine(Files._getFolder(folder), fileName));
				return true;
			}
			catch {
				return false;
			}
		}

		public static bool FileExists(string folder, string fileName) =>
			File.Exists(Path.Combine(Files._getFolder(folder), fileName));

		public static string[] FileList(string folder) =>
			Directory.GetFiles(Files._validateFolder(folder), "*");

		public static string GetFolderPath(string folder) =>
			Files._getFolder(folder);

		public static string GetRootDirectory() =>
			Files._rootDirectory;

		public static async Task<byte[]> ReadAllBytesAsync(string folder, string fileName) {
			string path = Path.Combine(Files._validateFolder(folder), fileName);
			return await File.ReadAllBytesAsync(path);
		}

		public static async Task<string> WriteAllBytesAsync(string folder, byte[] imageBytes, string fileName) {
			string path = Path.Combine(Files._validateFolder(folder), fileName);
			await File.WriteAllBytesAsync(path, imageBytes);
			return path;
		}

		public static async Task<string> ReadTextFileAsync(string folder, string fileName) {
			if (!Files.FileExists(folder, fileName)) { return null; }
			using StreamReader sr = new(Path.Combine(Files._getFolder(folder), fileName));
			return await sr.ReadToEndAsync();
		}

		public static async Task WriteTextFileAsync(string folder, string fileName, string stringToWrite, bool append = false) {
			using StreamWriter sw = new(Path.Combine(Files._validateFolder(folder), fileName), append);
			await sw.WriteLineAsync(stringToWrite);
		}
		#endregion

	}
	#endregion

}
