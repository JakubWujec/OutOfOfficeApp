using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Stores
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthStore authStore;
        public Authenticator(IAuthStore authStore)
        {
            this.authStore = authStore;
        }

        public Employee CurrentEmployee => authStore.CurrentEmployee;

        public void Login()
        {
            this.authStore.CurrentEmployee = new Employee()
            {
                FirstName = "TestName",
                LastName = "TestLastName",
                IsActive = true,
                OutOfOfficeBalance = 26
            };
        }
    }
}
