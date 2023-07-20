using System;
using System.Threading.Tasks;

using Microsoft.Maui.ApplicationModel;

namespace StedySoft.Maui.Framework {

	#region Class Logger
	public static class Logger {

		#region Private Methods
		private static string _getExceptionText(Exception ex) =>
			ex == null
				? "[No Error Message Provided]"
				: ex.InnerException != null
					? $"[{ex.InnerException.HResult}] {ex.InnerException.Message}\r\n[{ex.HResult}] {ex.Message}"
					: $"[{ex.HResult}] {ex.Message}";

		private static string _getDebugText(string className, string function, string msg) =>
			$"{DateTime.Now:dddd, MMMM dd, yyyy} {DateTime.Now:hh:mm:ss tt} | StedySoftInternals | --> {className} --> {function} --> {msg}";

		private static string _getMessageText(string className, string function, string msg) =>
			$"{DateTime.Now:dddd, MMMM dd, yyyy} {DateTime.Now:hh:mm:ss tt} -->\r\n{className} --> {function} -->\r\n{msg}";

		private static void _writeLogText(string className, string function, string msg) {
			string msgText = Logger._getMessageText(className, function, msg);
			new Task(
				async () => await Files.WriteTextFileAsync("logs", $"ErrorLog.{DateTime.Now.Year:####}.{DateTime.Now.Month:0#}.{DateTime.Now.Day:0#}.txt", msgText, true)
			).Start();
		}
		#endregion

		#region Public Properties
		public static bool ShowExceptionAsNotification {
			get => SharedSettings.Current.ShowExceptionAsNotification;
			set => SharedSettings.Current.ShowExceptionAsNotification = value;
		}
		#endregion

		#region Public Methods
		public static void LogInformation(string className, string function, string message) =>
			Logger._writeLogText(className, function, message);

		public static void LogException(string className, string function, Exception ex) =>
			Logger._writeLogText(className, function, Logger._getExceptionText(ex));

		public static void Debug(string className, string function, string message) =>
			System.Diagnostics.Debug.WriteLine(Logger._getDebugText(className, function, message));
		#endregion

	}
	#endregion

}
