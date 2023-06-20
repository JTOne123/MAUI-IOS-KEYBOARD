using MAUI_IOS_KEYBOARD.Platforms.iOS.Renderers;
using Microsoft.Extensions.Logging;

namespace MAUI_IOS_KEYBOARD;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).ConfigureMauiHandlers((handlers) =>
            {
				#if IOS
					handlers.AddHandler(typeof(Page), typeof(KeyboardManagerRenderer));
				#endif
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
