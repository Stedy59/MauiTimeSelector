using Microsoft.Maui;

namespace StedySoft.Maui.Framework.Controls {

	#region Class MauiTimeSelectorHandler
	public partial class MauiTimeSelectorHandler : IViewHandler {

		#region Constructor
		public MauiTimeSelectorHandler() : base(Mapper) { }

		public MauiTimeSelectorHandler(IPropertyMapper mapper) : base(mapper ?? Mapper) { }

		public MauiTimeSelectorHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) : base(mapper, commandMapper) { }


		public static IPropertyMapper<MauiTimeSelector, MauiTimeSelectorHandler> Mapper =
			new PropertyMapper<MauiTimeSelector, MauiTimeSelectorHandler>(ViewMapper) {
				[nameof(MauiTimeSelector.BackgroundColor)] = MapBackgroundColor,
				[nameof(MauiTimeSelector.ArrowColor)] = MapArrowColor,
				[nameof(MauiTimeSelector.FontFamily)] = MapFontFamily,
				[nameof(MauiTimeSelector.FontSize)] = MapFontSize,
				[nameof(MauiTimeSelector.MouseOverColor)] = MapMouseOverColor,
				[nameof(MauiTimeSelector.RippleColor)] = MapRippleColor,
				[nameof(MauiTimeSelector.Shadow)] = MapShadow,
				[nameof(MauiTimeSelector.TextColor)] = MapTextColor,
				[nameof(MauiTimeSelector.TextShadow)] = MapTextShadow,
				[nameof(MauiTimeSelector.Time)] = MapTime
			};

		public static CommandMapper<MauiTimeSelector, MauiTimeSelectorHandler> CommandMapper = new(ViewCommandMapper);
		#endregion

	}
	#endregion

}
