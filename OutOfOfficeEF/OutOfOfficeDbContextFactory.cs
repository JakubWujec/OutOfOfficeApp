using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class OutOfOfficeDbContextFactory : IOutOfOfficeContextFactory
    {
        private readonly string _connectionString;
        public OutOfOfficeDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public OutOfOfficeDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new OutOfOfficeDbContext(options);
        }
    }
}
