using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private IAuthStore authStore;
        public HomeViewModel(IAuthStore authStore) {
            this.authStore = authStore;
        }
        public string Name => authStore.CurrentEmployee.FirstName + " " + authStore.CurrentEmployee.LastName;
        public int Balance => authStore.CurrentEmployee.OutOfOfficeBalance;

    }
}
