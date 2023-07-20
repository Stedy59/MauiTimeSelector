using System;

using Microsoft.Maui.Storage;

using Newtonsoft.Json;

namespace StedySoft.Maui.Framework {

	#region Class SharedSettings
	[JsonObject(MemberSerialization.OptIn)]
	public sealed class SharedSettings : ObservableObject {

		#region Singleton Design Pattern
		[JsonIgnore]
		private static readonly Lazy<SharedSettings> _current =
			new(() => {
				try {
					return Preferences.Get("SharedSettingsData", null).JsonToObject<SharedSettings>();
				}
				catch {
					return new SharedSettings();
				}
			});

		[JsonIgnore]
		public static SharedSettings Current =>
			SharedSettings._current.Value;
		#endregion

		#region Declarations
		private bool _showExceptionAsNotification;

		private bool _darkMode;
		private FontFamilyNames _fontFamily;
		private bool _shadows;
		#endregion

		#region Constructor
		private SharedSettings() { }
		#endregion

		#region Properties
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool ShowExceptionAsNotification {
			get => this._showExceptionAsNotification;
			set => this.SetProperty(ref this._showExceptionAsNotification, value);
		}

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool DarkMode {
			get => this._darkMode;
			set => this.SetProperty(
				ref this._darkMode,
				value,
				onChanged: () => ColorManager.Current._darkModeChange(value));
		}

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public FontFamilyNames FontFamily {
			get => this._fontFamily;
			set => this.SetProperty(
				ref this._fontFamily,
				value,
				onChanged: () => FontManager.Current.FontFamily = value);
		}

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool UseShadows {
			get => this._shadows;
			set => this.SetProperty(ref this._shadows, value);
		}
		#endregion

		#region Public Methods
		public void Update() {
			try {
				Preferences.Set("SharedSettingsData", SharedSettings.Current.ToJson());
			}
			catch (Exception ex) {
				Logger.LogException("SharedSettings", "Update", ex);
			}
		}
		#endregion

	}
	#endregion

}
