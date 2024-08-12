using OutOfOfficeWPF.Stores;

namespace OutOfOfficeWPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private IAuthStore authStore;

        public HomeViewModel(IAuthStore authStore)
        {
            this.authStore = authStore;
        }
        public string Name => authStore.CurrentEmployee?.FirstName + " " + authStore.CurrentEmployee?.LastName;
        public int Balance => authStore.CurrentEmployee?.OutOfOfficeBalance ?? 0;
        public bool IsLoggedIn => authStore.CurrentEmployee != null;
        public String Position => authStore.CurrentEmployee.Position.ToString();
        public String FullName => authStore.CurrentEmployee.FullName;
    }
}
