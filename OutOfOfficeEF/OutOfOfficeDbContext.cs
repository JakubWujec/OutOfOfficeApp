using Microsoft.EntityFrameworkCore;
using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class OutOfOfficeDbContext: DbContext
    {
        public OutOfOfficeDbContext(DbContextOptions options) : base(options) { }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public bool IsNew<TEntity>(TEntity entity) where TEntity : class
        {
            return !this.Set<TEntity>().Local.Any(e => e == entity);
        }
    }
}
