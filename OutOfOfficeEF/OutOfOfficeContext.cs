using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeDomain;

namespace OutOfOfficeEF
{
    public class OutOfOfficeContext: DbContext
    {
        public string DbPath { get; }
        public OutOfOfficeContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "out_of_office_app.db");
            var x = 5;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public bool IsNew<TEntity>(TEntity entity) where TEntity : class
        {
            return !this.Set<TEntity>().Local.Any(e => e == entity);
        }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
    }
}
