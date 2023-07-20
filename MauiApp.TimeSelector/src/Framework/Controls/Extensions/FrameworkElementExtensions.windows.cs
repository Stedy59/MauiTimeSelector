using System;
using System.Collections.Generic;
using System.Numerics;

using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Platform;

using Microsoft.UI.Composition;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;

using MShadow = Microsoft.Maui.Controls.Shadow;
using MSolidColorBrush = Microsoft.Maui.Controls.SolidColorBrush;
using MScrollBarVisibility = Microsoft.Maui.ScrollBarVisibility;
using MScrollToPosition = Microsoft.Maui.Controls.ScrollToPosition;
using MSnapPointsType = Microsoft.Maui.Controls.SnapPointsType;
using MSnapPointsAlignment = Microsoft.Maui.Controls.SnapPointsAlignment;

using WScrollBarVisibility = Microsoft.UI.Xaml.Controls.ScrollBarVisibility;
using WSnapPointsType = Microsoft.UI.Xaml.Controls.SnapPointsType;
using WSnapPointsAlignment = Microsoft.UI.Xaml.Controls.Primitives.SnapPointsAlignment;

namespace StedySoft.Maui.Framework.Controls {

	#region Class FrameworkElementExtensions
	internal static class FrameworkElementExtensions {

		internal static WScrollBarVisibility ToPlatform(this MScrollBarVisibility scrollBarVisibility) =>
			scrollBarVisibility switch {
				MScrollBarVisibility.Always => WScrollBarVisibility.Visible,
				MScrollBarVisibility.Never => WScrollBarVisibility.Hidden,
				MScrollBarVisibility.Default => WScrollBarVisibility.Auto,
				_ => WScrollBarVisibility.Disabled
			};

		internal static WSnapPointsType ToPlatform(this MSnapPointsType snapPointsType) =>
			snapPointsType switch {
				MSnapPointsType.Mandatory => WSnapPointsType.Mandatory,
				MSnapPointsType.MandatorySingle => WSnapPointsType.MandatorySingle,
				MSnapPointsType.None => WSnapPointsType.None,
				_ => WSnapPointsType.None
			};

		internal static WSnapPointsAlignment ToPlatform(this MSnapPointsAlignment snapPointsAlignment) =>
			snapPointsAlignment switch {
				MSnapPointsAlignment.Center => WSnapPointsAlignment.Center,
				MSnapPointsAlignment.End => WSnapPointsAlignment.Far,
				MSnapPointsAlignment.Start => WSnapPointsAlignment.Near,
				_ => WSnapPointsAlignment.Center
			};

		internal static MScrollToPosition ToScrollToPosition(this MSnapPointsAlignment snapPointsAlignment) =>
			snapPointsAlignment switch {
				MSnapPointsAlignment.Center => MScrollToPosition.Center,
				MSnapPointsAlignment.End => MScrollToPosition.End,
				MSnapPointsAlignment.Start => MScrollToPosition.Start,
				_ => MScrollToPosition.Center
			};

		internal static IEnumerable<T?> GetChildren<T>(this DependencyObject parent) where T : DependencyObject {
			int myChildrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < myChildrenCount; i++) {
				DependencyObject child = VisualTreeHelper.GetChild(parent, i);
				if (child is T t) {
					yield return t;
				}
				else {
					foreach (T subChild in child.GetChildren<T>()) {
						yield return subChild;
					}
				}
			}
		}

		internal static T? GetFirstDescendant<T>(this DependencyObject element) where T : FrameworkElement {
			int count = VisualTreeHelper.GetChildrenCount(element);
			for (int i = 0; i < count; i++) {
				DependencyObject child = VisualTreeHelper.GetChild(element, i);
				if ((child as T ?? GetFirstDescendant<T>(child)) is T target) {
					return target;
				}
			}
			return null;
		}

		internal static void TryUpdateResources(this FrameworkElement element, string[] keys, object newValue) {
			ResourceDictionary rd = element?.Resources;
			foreach (string key in keys) { rd[key] = newValue; }
			element.RefreshThemeResources();
		}

		internal static void RefreshThemeResources(this FrameworkElement nativeView) {
			try {
				nativeView.RequestedTheme =
					SharedSettings.Current.DarkMode
						? ElementTheme.Dark
						: ElementTheme.Light;
				ElementTheme previous = nativeView.RequestedTheme;
				nativeView.RequestedTheme =
					nativeView.ActualTheme switch {
						ElementTheme.Dark => ElementTheme.Light,
						_ => ElementTheme.Dark
					};
				nativeView.RequestedTheme = previous;
			}
			catch { }
		}

		internal static void ApplyDropShadow(this Grid grid, MShadow shadow) {
			if (grid.Children[0] is not Canvas canvas || grid.Children[1] is not TextBlock textBlock) { return; }

			Compositor compositor = ElementCompositionPreview.GetElementVisual(canvas).Compositor;

			SpriteVisual spriteVisual = compositor.CreateSpriteVisual();
			spriteVisual.Size = canvas.RenderSize.ToVector2();

			DropShadow dropShadow = compositor.CreateDropShadow();
			dropShadow.Mask = textBlock.GetAlphaMask();
			dropShadow.BlurRadius = shadow.Radius;
			dropShadow.Offset = new Vector3((float)shadow.Offset.X, (float)shadow.Offset.Y, 0);
			dropShadow.Color = shadow.Brush.As<MSolidColorBrush>().Color.ToWindowsColor();
			dropShadow.Opacity = shadow.Opacity;

			spriteVisual.Shadow = dropShadow;

			ElementCompositionPreview.SetElementChildVisual(canvas, spriteVisual);
		}

		internal static bool IsLoaded(this FrameworkElement frameworkElement) =>
			frameworkElement?.IsLoaded == true;

		internal static IDisposable OnLoaded(this FrameworkElement frameworkElement, Action action) {
			if (frameworkElement.IsLoaded()) {
				action();
				return new ActionDisposable(() => { });
			}

			RoutedEventHandler? routedEventHandler = null;
			ActionDisposable disposable = new(() => {
				if (routedEventHandler != null) {
					frameworkElement.Loaded -= routedEventHandler;
				}
			});

			routedEventHandler = (_, __) => {
				disposable.Dispose();
				action();
			};

			frameworkElement.Loaded += routedEventHandler;
			return disposable;
		}

		internal static IDisposable OnUnloaded(this FrameworkElement frameworkElement, Action action) {
			if (!frameworkElement.IsLoaded()) {
				action();
				return new ActionDisposable(() => { });
			}

			RoutedEventHandler? routedEventHandler = null;
			ActionDisposable disposable = new(() => {
				if (routedEventHandler != null) {
					frameworkElement.Unloaded -= routedEventHandler;
				}
			});

			routedEventHandler = (_, __) => {
				disposable.Dispose();
				action();
			};

			frameworkElement.Unloaded += routedEventHandler;
			return disposable;
		}

		internal static void Arrange(this IView view, FrameworkElement frameworkElement) {
			Rect rect = new(0, 0, frameworkElement.ActualWidth, frameworkElement.ActualHeight);
			if (!view.Frame.Equals(rect)) { _ = view.Arrange(rect); }
		}

	}
	#endregion

}
