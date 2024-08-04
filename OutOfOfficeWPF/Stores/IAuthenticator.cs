using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Stores
{
    public interface IAuthenticator
    {
        Employee CurrentEmployee { get; }
        public void Login(Guid id);
    }
}
