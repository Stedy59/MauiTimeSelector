using System;
using System.Threading;

namespace StedySoft.Maui.Framework {

	#region Class ActionDisposable
	internal class ActionDisposable(Action action) : IDisposable {

		volatile Action? _action = action;

		public void Dispose() =>
			Interlocked.Exchange(ref _action, null)?.Invoke();

	}
	#endregion

}
