using System;
using System.Globalization;

namespace StedySoft.Maui.Framework {

	#region Class DateTimeExtension
	public static class DateTimeExtension {

		public static string ToAbbreviatedDayString(this DayOfWeek dow) {
			DateTime dt = DateTime.Now;
			for (int i = 0; i <= 7; i++) {
				if (dt.AddDays(i).DayOfWeek == dow) { return dt.AddDays(i).ToAbbreviatedDayString(); }
			}
			return "???";
		}

		public static string ToAbbreviatedDayString(this DateTime dt) =>
			dt.ToCurrentCultureString("ddd");

		public static string ToFullDayString(this DayOfWeek dow) {
			DateTime dt = DateTime.Now;
			for (int i = 0; i <= 7; i++) {
				if (dt.AddDays(i).DayOfWeek == dow) { return dt.AddDays(i).ToFullDayString(); }
			}
			return "???";
		}

		public static string ToFullDayString(this DateTime dt) =>
			dt.ToCurrentCultureString("dddd");

		public static string To12HourString(this TimeOnly timeOnly) =>
			timeOnly.ToCurrentCultureString("h:mm tt");

		public static string To24HrString(this TimeOnly timeOnly) =>
			timeOnly.ToCurrentCultureString("HH:mm");

		public static string To12HourString(this DateTime dt) =>
			dt.ToCurrentCultureString("h:mm tt");

		public static string To24HrString(this DateTime dt) =>
			dt.ToCurrentCultureString("HH:mm");

		public static string ToCurrentCultureString(this TimeOnly timeOnly, string format) =>
			timeOnly.ToString(format, CultureInfo.CurrentCulture.DateTimeFormat);

		public static string ToCurrentCultureString(this DateTime dt, string format) =>
			dt.ToString(format, CultureInfo.CurrentCulture.DateTimeFormat);

	}
	#endregion

}
