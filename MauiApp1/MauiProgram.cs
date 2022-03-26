using Android.Content.Res;

using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Platform;

using Syncfusion.Maui.Core.Hosting;
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

		// SfBadgeView, SfEffectsView
		builder.ConfigureSyncfusionCore();

#if ANDROID
		// 전체 배경 색 변경 - 적용가능하나 디자인을 해침
		//Microsoft.Maui.Handlers.ViewHandler.ViewMapper.AppendToMapping(nameof(IView.Background), (h, v) =>
		//{
		//	(h.NativeView as Android.Views.View).SetBackgroundColor(Microsoft.Maui.Graphics.Colors.White.ToNative());
		//});

		// Entry 에서 언더라인 제거
		Microsoft.Maui.Handlers.EntryHandler.EntryMapper.AppendToMapping("NoUnderline", (h, v) =>
		{
			h.NativeView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
		});
#endif

		// 기기에 따른 색상 변경
		Microsoft.Maui.Handlers.EntryHandler.EntryMapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
		{
			if (view is Entry)
			{
#if ANDROID
				handler.NativeView.SetTextColor(Colors.Red.ToNative());
#elif IOS
                  handler.NativeView.TextColor = Colors.Yellow.ToNative();
#elif WINDOWS
                  handler.NativeView.Foreground = Colors.Green.ToNative();
#endif
			}

			if (view is Label)
			{
#if ANDROID
				handler.NativeView.SetTextColor(Colors.Blue.ToNative());
#elif IOS
                  handler.NativeView.TextColor = Colors.Black.ToNative();
#elif WINDOWS
                  handler.NativeView.Foreground = Colors.Gray.ToNative();
#endif
			}
		});

		return builder.Build();
	}
}
