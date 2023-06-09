using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;
using PlanMeisterApi.Services;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PlanMeisterDbContext>((optionsBuilder) =>
{
    var connectionString = Environment.GetEnvironmentVariable("DB_Connection");
    optionsBuilder.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IDayScheduleRepository, DayScheduleRepository>();
builder.Services.AddScoped<IDayScheduleService, DayScheduleService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddScoped<IWeekScheduleRepository, WeekScheduleRepository>();
builder.Services.AddScoped<IWeekScheduleService, WeekScheduleService>();

builder.Services.AddScoped<IHourPreferenceRepository, HourPreferenceRepository>();
builder.Services.AddScoped<IHourPreferenceService, HourPreferenceService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
