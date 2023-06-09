using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanMeisterApi.Enum;
using PlanMeisterShared.Enum;

namespace PlanMeisterApi.Models;

public class PlanMeisterDbContext : DbContext
{
    public PlanMeisterDbContext(DbContextOptions<PlanMeisterDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DaySchedule> DaySchedules { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<WeekSchedule> WeekSchedules { get; set; }
    public DbSet<HourPreference> HourPreferences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure the relationship between Appointment and DaySchedule
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.DaySchedule)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DayScheduleId);

        // Configure the relationship between Appointment and Employee
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Appointments)
            .HasForeignKey(a => a.EmployeeId);

        // Configure the relationship between Request and Employee
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Requests)
            .WithOne(r => r.Employee)
            .HasForeignKey(r => r.EmployeeId);
        
        // Configure the relationship between DaySchedule and WeekSchedule
        modelBuilder.Entity<DaySchedule>()
            .HasOne(w => w.WeekSchedule)
            .WithMany(d => d.DaySchedules)
            .HasForeignKey(d => d.WeekScheduleId);
        
        // Convert Request Enum to String
        modelBuilder.Entity<Request>()
            .Property(d => d.RequestType)
            .HasConversion(new EnumToStringConverter<RequestType>());
        
        // Convert DayOfWeek Enum to String
        modelBuilder.Entity<DaySchedule>()
            .Property(d => d.DayOfWeek)
            .HasConversion(new EnumToStringConverter<DayOfWeek>());
        
        // Convert AppointmentType Enum to String
        modelBuilder.Entity<Appointment>()
            .Property(d => d.Type)
            .HasConversion(new EnumToStringConverter<AppointmentType>());
        
        // Convert RequestStatus Enum to String
        modelBuilder.Entity<Request>()
            .Property(d => d.RequestStatus)
            .HasConversion(new EnumToStringConverter<RequestStatus>());
        
        // Convert HourPreferenceStatus Enum to String
        modelBuilder.Entity<HourPreference>()
            .Property(d => d.HourPreferenceStatus)
            .HasConversion(new EnumToStringConverter<HourPreferenceStatus>());
        
        modelBuilder.Entity<Appointment>().HasData(SeedHelper.GetAppointmentSeeds());
        modelBuilder.Entity<Employee>().HasData(SeedHelper.GetEmployeeSeeds());
        modelBuilder.Entity<DaySchedule>().HasData(SeedHelper.GetDaySeeds());
        modelBuilder.Entity<Request>().HasData(SeedHelper.GetRequestSeeds());
        modelBuilder.Entity<WeekSchedule>().HasData(SeedHelper.GetScheduleSeeds());
        modelBuilder.Entity<HourPreference>().HasData(SeedHelper.GetHourPreferenceSeeds());
    }
}