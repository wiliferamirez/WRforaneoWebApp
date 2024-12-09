using Microsoft.Extensions.Logging;

namespace foraneoAppMaui
{
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
                });
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<AuthService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.UseMauiApp<App>();
            return builder.Build();
        }
    }
}
