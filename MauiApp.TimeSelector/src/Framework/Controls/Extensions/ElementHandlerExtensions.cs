using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace StedySoft.Maui.Framework.Controls {

	#region Class ElementHandlerExtensions
	internal static class ElementHandlerExtensions {

		#region Public Methods
		public static IServiceProvider GetServiceProvider(this IElementHandler handler) {
			IMauiContext context = handler.MauiContext ??
				throw new InvalidOperationException($"Unable to find the context. The {nameof(ElementHandler.MauiContext)} property should have been set by the host.");
			return context?.Services ??
				throw new InvalidOperationException($"Unable to find the service provider. The {nameof(ElementHandler.MauiContext)} property should have been set by the host.");
		}

		public static T? GetService<T>(this IElementHandler handler, Type type) =>
			(T?)handler.GetServiceProvider().GetService(type);

		public static T? GetService<T>(this IElementHandler handler) =>
			handler.GetServiceProvider().GetService<T>();

		public static T GetRequiredService<T>(this IElementHandler handler, Type type) where T : notnull {
			IServiceProvider services = handler.GetServiceProvider();
			object service = services.GetRequiredService(type);
			return (T)service;
		}

		public static T GetRequiredService<T>(this IElementHandler handler) where T : notnull =>
			handler.GetServiceProvider().GetRequiredService<T>();

		public static Task<T> InvokeAsync<T>(this IElementHandler handler, string commandName, TaskCompletionSource<T> args) {
			handler?.Invoke(commandName, args);
			return args.Task;
		}

		public static T InvokeWithResult<T>(this IElementHandler handler, string commandName, RetrievePlatformValueRequest<T> args) {
			handler?.Invoke(commandName, args);
			return args.Result;
		}

		public static bool CanInvokeMappers(this IElementHandler viewHandler) =>
			true;
		#endregion

	}
	#endregion

}