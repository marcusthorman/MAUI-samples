using localization_demo.Pages;
using localization_demo.ViewModels;

namespace localization_demo;

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

		builder.Services.AddSingleton<ChooseLanguageViewModel>();
		builder.Services.AddTransient<ChooseLanguagePage>();

		return builder.Build();
	}
}
