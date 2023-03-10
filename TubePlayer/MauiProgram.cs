namespace TubePlayer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("FiraSans-Light.ttf", "RegularFont");
                fonts.AddFont("FiraSans-Medium.ttf", "MediumFont");
            })
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                    activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                }
#endif
            });

        RegisterAppServices(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void RegisterAppServices(IServiceCollection services)
    {
        services.AddSingleton<IConnectivity>(Connectivity.Current);

        Barrel.ApplicationId = Constants.ApplicationId;
        services.AddSingleton<IBarrel>(Barrel.Current);

        services.AddSingleton<IApiService, YoutubeService>();

        services.AddSingleton<StartPageViewModel>();
    }
}
