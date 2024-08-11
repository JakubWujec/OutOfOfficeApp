using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public class InMemoryReservoomDbContextFactory : IOutOfOfficeContextFactory
    {
        private readonly SqliteConnection _connection;

        public InMemoryReservoomDbContextFactory()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();
        }
        public OutOfOfficeDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connection).Options;

            return new OutOfOfficeDbContext(options);
        }
    }
}
