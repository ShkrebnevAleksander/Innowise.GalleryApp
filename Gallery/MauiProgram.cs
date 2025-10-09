using Gallery.Services;
using Gallery.ViewModels;
using Gallery.Views;
using Microsoft.Extensions.Logging;

namespace Gallery
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
            builder.Services.AddSingleton<IUnsplashService, UnsplashService>();
            builder.Services.AddSingleton<IFavoritesService, FavoritesService>();

            builder.Services.AddTransient<GalleryViewModel>();
            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<FavoritesViewModel>();

            builder.Services.AddTransient<GalleryPage>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<FavoritesPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
