using System;

using Android.App;
using Android.Content;
using Android.Runtime;

namespace StedySoft.Maui.Framework.Controls {

	#region Class MauiTimePickerDialog
	public class MauiTimePickerDialog : TimePickerDialog {

		#region Constructor
		public MauiTimePickerDialog(Context context, EventHandler<TimeSetEventArgs> callBack, int hourOfDay, int minute, bool is24HourView) :
			base(context, (sender, e) => callBack(sender, new TimeSetEventArgs(e.HourOfDay, e.Minute)), hourOfDay, minute, is24HourView) {
		}

		protected MauiTimePickerDialog(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }
		#endregion

		#region Protected Overrides
		protected override void OnCreate(Android.OS.Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			this.SetCanceledOnTouchOutside(false);
		}
		#endregion

	}
	#endregion

}
