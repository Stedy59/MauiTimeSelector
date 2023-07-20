using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Microsoft.Maui;

namespace StedySoft.Maui.Framework {

	#region Class ObservableObject
	public class ObservableObject : INotifyPropertyChanged {

		#region Declaration
		private readonly WeakEventManager weakEventManager = new();
		#endregion

		#region Properties
		public event PropertyChangedEventHandler? PropertyChanged {
			add => this.weakEventManager.AddEventHandler(value);
			remove => this.weakEventManager.RemoveEventHandler(value);
		}
		#endregion

		#region Methods
		protected bool SetProperty<T>([NotNullIfNotNull(nameof(newValue))] ref T property, T newValue, [CallerMemberName] string? propertyName = null, Action? onChanged = null) {
			if (EqualityComparer<T>.Default.Equals(property, newValue)) { return false; }
			property = newValue;
			onChanged?.Invoke();
			this.OnPropertyChanged(propertyName);
			return true;
		}
		#endregion

		#region Events
		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
			this.weakEventManager.HandleEvent(this, new PropertyChangedEventArgs(propertyName), nameof(INotifyPropertyChanged.PropertyChanged));
		#endregion

	}
	#endregion

}
