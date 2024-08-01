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
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
