using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeEF
{
    public interface IOutOfOfficeContextFactory
    {
        OutOfOfficeDbContext CreateDbContext();
    }
}
