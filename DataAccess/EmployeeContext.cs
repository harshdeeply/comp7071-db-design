using hr_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace hr_webapi.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Paycheque> Paycheques { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<PayDetail> PayDetails { get; set; } 
        public DbSet<PayInfo> PayInfos { get; set; }
        public DbSet<EmploymentEvent> EmploymentEvents { get; set; }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<DeductionDetail> DeductionDetails { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
