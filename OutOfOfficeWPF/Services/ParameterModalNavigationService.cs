using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Services
{
    public class ParameterModalNavigationService<TParameter, TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;
        public ParameterModalNavigationService(ModalNavigationStore modalNavigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            this._modalNavigationStore = modalNavigationStore;
            this._createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            this._modalNavigationStore.CurrentViewModel = this._createViewModel(parameter);
        }
    }
   
}
