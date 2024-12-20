using Microsoft.Extensions.Logging;

namespace SaintMichel
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<PetitesAnnonces_API>();
            builder.Services.AddTransient<AnnoncePageViewModel>();
            builder.Services.AddTransient<AnnoncePage>();
            builder.Services.AddTransient<AnnonceDetailPage>();
            builder.Services.AddTransient<AnnonceDetailPageViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
