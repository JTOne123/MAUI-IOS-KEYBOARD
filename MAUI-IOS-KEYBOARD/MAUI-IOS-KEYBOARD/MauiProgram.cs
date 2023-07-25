using MAUI_IOS_KEYBOARD.Platforms.iOS.Handlers;
using MAUI_IOS_KEYBOARD.Platforms.iOS.Managers;
using MAUI_IOS_KEYBOARD.Platforms.iOS.Renderers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

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
			})
			.UseMauiCompatibility()
			.ConfigureMauiHandlers((handlers) =>
            {
				#if IOS
					handlers.AddHandler(typeof(MainPage), typeof(KeyboardManagerHandler));
					//handlers.AddCompatibilityRenderer(typeof(MainPage), typeof(KeyboardManagerRenderer));
				#endif
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<KeyboardManager>();

        return builder.Build();
	}
}
