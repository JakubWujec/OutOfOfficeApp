using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Services
{
    public class ParameterNavigationService<TParameter, TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;
        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel) { 
            this._navigationStore = navigationStore;
            this._createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            this._navigationStore.CurrentViewModel = this._createViewModel(parameter); 
        }
    }
}
