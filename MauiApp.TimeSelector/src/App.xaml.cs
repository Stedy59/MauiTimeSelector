using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

using StedySoft.Maui.Framework;

using StedySoft.TimeSelector.Views;

namespace StedySoft.TimeSelector {

	public partial class App : Application {

		public App() {
			this.InitializeComponent();
			ColorManager.Current.Colors = new Colors();
			this.MainPage = new NavigationPage(new MainPage() {});
		}

		protected override Window CreateWindow(IActivationState? activationState) {
			Window window = base.CreateWindow(activationState);
			if (DeviceInfo.Current.Platform == DevicePlatform.WinUI) { window.Width = 500; }
			window.Title = AppInfo.Name;
			return window;
		}

	}

}
