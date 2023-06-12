using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using PlanMeisterShared.Service;

namespace PlanMeisterMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services
            .AddBlazorise(options => { options.Immediate = true; })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

        builder.Services.AddOidcAuthentication(options =>
        {
            options.ProviderOptions.ClientId = "hORwC8fz0E4Amg8ldcSwkooZIb6Zrbv8";
            options.ProviderOptions.Authority = "https://dev-f2rejb34yzs7isxp.eu.auth0.com";
            options.ProviderOptions.ResponseType = "code";
        });

        builder.Services.AddScoped(sp => new HttpClient
            { BaseAddress = new Uri("https://5cb2-84-83-28-195.ngrok-free.app/") });
        builder.Services.AddScoped<EmployeeService>();
        builder.Services.AddScoped<AppointmentService>();
        builder.Services.AddScoped<DayScheduleService>();
        builder.Services.AddScoped<WeekScheduleService>();
        builder.Services.AddScoped<RequestService>();
        builder.Services.AddScoped<HourPreferenceService>();

        return builder.Build();
    }
}