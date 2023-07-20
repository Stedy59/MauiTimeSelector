using Newtonsoft.Json;

namespace StedySoft.Maui.Framework {

	#region Class JsonExtension
	public static class JsonExtension {

		public static string ToJson(this object o) =>
			JsonConvert.SerializeObject(o);
		public static T JsonToObject<T>(this string json) =>
			JsonConvert.DeserializeObject<T>(json);

	}
	#endregion

}
