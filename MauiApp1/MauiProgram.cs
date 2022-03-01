using Syncfusion.Maui.ListView.Hosting;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("NotoSans-Regular.ttf", "NotoSansRegular");
				fonts.AddFont("NanumBrush.ttf", "NanumBrush");
			});

		builder.ConfigureSyncfusionListView();

		return builder.Build();
	}
}
