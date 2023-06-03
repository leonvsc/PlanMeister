using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebView.Maui;
using PlanMeisterShared.Service;

namespace PlanMeisterMAUI;

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
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		builder.Services
			.AddBlazorise( options =>
			{
				options.Immediate = true;
			} )
			.AddBootstrapProviders()
			.AddFontAwesomeIcons();

		// builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://7ddc-84-83-28-195.ngrok-free.app") });
		builder.Services.AddScoped<EmployeeService, EmployeeService>();
		builder.Services.AddScoped<AppointmentService, AppointmentService>();
		builder.Services.AddScoped<DayScheduleService, DayScheduleService>();
		builder.Services.AddScoped<WeekScheduleService, WeekScheduleService>();

		return builder.Build();
	}
}
