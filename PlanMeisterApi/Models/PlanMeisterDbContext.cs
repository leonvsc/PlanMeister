using Microsoft.EntityFrameworkCore;

namespace PlanMeisterApi.Models;

public class PlanMeisterDbContext : DbContext
{
    public PlanMeisterDbContext(DbContextOptions<PlanMeisterDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasData(SeedHelper.GetEmployeeSeeds());
    }
}