namespace StedySoft.Maui.Framework {

	#region Class ObjectExtensions
	public static class ObjectExtensions {

		public static T As<T>(this object o) where T : class => o as T;

		public static T CastTo<T>(this object o) => (T)o;

	}
	#endregion

}
