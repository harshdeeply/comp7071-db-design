using Microsoft.EntityFrameworkCore;
using hr_webapi.Models;

public interface IAppDbContext
{
    DbSet<Employee> Employee { get; set; }
    DbSet<Paycheque> Paycheque { get; set; }
    DbSet<Shift> Shift { get; set; }
    DbSet<PayDetail> PayDetail { get; set; }
    DbSet<PayInfo> PayInfo { get; set; }
    DbSet<EmploymentEvent> EmploymentEvent { get; set; }
    DbSet<DayOff> DayOff { get; set; }
    DbSet<DeductionDetail> DeductionDetail { get; set; }
    Task<int> SaveChangesAsync();
    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

}
