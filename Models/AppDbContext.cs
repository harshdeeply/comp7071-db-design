using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Entry(entity);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Employee
        modelBuilder
            .Entity<Employee>()
            .Ignore(e => e.PayHistory);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public DbSet<Employee> Employee { get; set; } = default!;
    public DbSet<Paycheque> Paycheque { get; set; } = default!;
    public DbSet<Shift> Shift { get; set; } = default!;
    public DbSet<PayDetail> PayDetail { get; set; } = default!;
    public DbSet<PayInfo> PayInfo { get; set; } = default!;
    public DbSet<EmploymentEvent> EmploymentEvent { get; set; } = default!;
    public DbSet<DayOff> DayOff { get; set; } = default!;
    public DbSet<DeductionDetail> DeductionDetail { get; set; } = default!;
}
