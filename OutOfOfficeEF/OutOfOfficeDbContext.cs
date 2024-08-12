using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain;

namespace OutOfOfficeEF
{
    public class OutOfOfficeDbContext : DbContext
    {
        public OutOfOfficeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }

        public bool IsNew<TEntity>(TEntity entity) where TEntity : class
        {
            return !this.Set<TEntity>().Local.Any(e => e == entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles into the database
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "HR Manager" },
                new Role { Id = 3, Name = "Member" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = Guid.NewGuid(), FirstName = "Admin", LastName="Admin", IsActive=true, OutOfOfficeBalance = 26 }
            );

        }
    }
}
