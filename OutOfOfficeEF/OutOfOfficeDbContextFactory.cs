using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class OutOfOfficeDbContextFactory : IOutOfOfficeContextFactory, IDesignTimeDbContextFactory<OutOfOfficeDbContext>
    {
        private readonly string _connectionString;
        public OutOfOfficeDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OutOfOfficeDbContextFactory()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "out_of_office_app.db");
            var connectionString = $"Data Source={DbPath}";
            _connectionString = connectionString;
        }
        public OutOfOfficeDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new OutOfOfficeDbContext(options);
        }

        public OutOfOfficeDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new OutOfOfficeDbContext(options);
        }
    }
}
