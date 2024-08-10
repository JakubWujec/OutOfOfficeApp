using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;

namespace OutOfOfficeWPF.Services
{
    public class NavigationService : INavigationService
    {
        private NavigationStore navigationStore;
        private Func<ViewModelBase> createViewModel;
        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }
        public void Navigate()
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
