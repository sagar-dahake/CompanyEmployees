using Entities.Models;
using Entities.Models.SpResults;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;


namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        // New DbSets for payroll / leave
        public DbSet<Salary>? Salaries { get; set; }
        public DbSet<Payslip>? Payslips { get; set; }
        public DbSet<LeaveRecord>? LeaveRecords { get; set; }

        // Error logging table
        public DbSet<ErrorLog>? ErrorLogs { get; set; }

        // Keyless entities for stored procedure results
        public DbSet<LeaveSummaryResult> LeaveSummaryResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // apply new configurations
            modelBuilder.ApplyConfiguration(new SalaryConfiguration());
            modelBuilder.ApplyConfiguration(new PayslipConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveRecordConfiguration());

            // error log configuration
            modelBuilder.ApplyConfiguration(new ErrorLogConfiguration());

            // Keyless entity — not mapped to any table, used only for SP results
            modelBuilder.Entity<LeaveSummaryResult>().HasNoKey().ToView(null);
        }
    }
}