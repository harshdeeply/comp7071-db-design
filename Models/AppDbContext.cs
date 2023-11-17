using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;

namespace hr_webapi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Employee
        modelBuilder
            .Entity<Employee>()
            .Ignore(e => e.PayHistory);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Employee> Employee { get; set; } = default!;
    public DbSet<hr_webapi.Models.Paycheque> Paycheque { get; set; } = default!;
    public DbSet<hr_webapi.Models.Shift> Shift { get; set; } = default!;
    public DbSet<hr_webapi.Models.PayDetail> PayDetail { get; set; } = default!;
    public DbSet<hr_webapi.Models.PayInfo> PayInfo { get; set; } = default!;
    public DbSet<hr_webapi.Models.EmploymentEvent> EmploymentEvent { get; set; } = default!;
    public DbSet<hr_webapi.Models.DayOff> DayOff { get; set; } = default!;
    public DbSet<hr_webapi.Models.DeductionDetail> DeductionDetail { get; set; } = default!;
}