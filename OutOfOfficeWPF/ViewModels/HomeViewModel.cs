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
        private readonly NavigationBarViewModel _navigationBarViewModel;
        public HomeViewModel(IAuthStore authStore, NavigationBarViewModel _navigationBarViewModel) {
            this.authStore = authStore;
            this._navigationBarViewModel = _navigationBarViewModel;
        }

        public NavigationBarViewModel NavigationBarViewModel => _navigationBarViewModel;
        public string Name => authStore.CurrentEmployee.FirstName + " " + authStore.CurrentEmployee.LastName;
        public int Balance => authStore.CurrentEmployee.OutOfOfficeBalance;
        public bool IsLoggedIn => authStore.CurrentEmployee != null;
        public string WelcomeInfo => IsLoggedIn ? $"Welcome {authStore.CurrentEmployee.FirstName} {authStore.CurrentEmployee.LastName}" : "Welcome. You are not logged in";

    }
}
