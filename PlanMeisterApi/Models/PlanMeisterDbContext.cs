using Microsoft.EntityFrameworkCore;

namespace PlanMeisterApi.Models;

public class PlanMeisterDbContext : DbContext
{
    public PlanMeisterDbContext(DbContextOptions<PlanMeisterDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Day> Days { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure the relationship between Appointment and Day
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Day)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DayId);

        // Configure the relationship between Appointment and Employee
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Appointments)
            .HasForeignKey(a => a.EmployeeId);

        // Seed data for the Appointment model
        modelBuilder.Entity<Appointment>().HasData(SeedHelper.GetAppointmentSeeds());
        
        // Configure the relationship between Request and Employee
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Requests)
            .WithOne(r => r.Employee)
            .HasForeignKey(r => r.EmployeeId);
        
        // Configure the relationship between Schedule and Day
        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Day)
            .WithMany(d => d.Schedules)
            .HasForeignKey(s => s.DayId);

        modelBuilder.Entity<Employee>().HasData(SeedHelper.GetEmployeeSeeds());
        modelBuilder.Entity<Day>().HasData(SeedHelper.GetDaySeeds());
        modelBuilder.Entity<Request>().HasData(SeedHelper.GetRequestSeeds());
        modelBuilder.Entity<Schedule>().HasData(SeedHelper.GetScheduleSeeds());
    }
}