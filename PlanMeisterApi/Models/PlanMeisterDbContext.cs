using Microsoft.EntityFrameworkCore;

namespace PlanMeisterApi.Models;

public class PlanMeisterDbContext : DbContext
{
    public PlanMeisterDbContext(DbContextOptions<PlanMeisterDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}