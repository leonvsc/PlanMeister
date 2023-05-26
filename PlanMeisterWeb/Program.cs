using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlanMeisterWeb;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using PlanMeisterWeb.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5175") });
builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<AppointmentService, AppointmentService>();
builder.Services.AddScoped<DayScheduleService, DayScheduleService>();
builder.Services.AddScoped<WeekScheduleService, WeekScheduleService>();

await builder.Build().RunAsync();
