using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Stores
{
    public class AuthStore : IAuthStore
    {
        public Employee CurrentEmployee {get; set;}
    }
}
