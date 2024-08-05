using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private Func<ViewModelBase> _createViewModel;
        private Func<NavigationBarViewModel> _createNavigationBarViewModel;
        public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel, Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            this._navigationStore = navigationStore;
            this._createViewModel = createViewModel;
            this._createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
        }
    }
}
