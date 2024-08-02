using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class MainViewModel: ViewModelBase
    {

        private NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore) {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModelChanged += NavigationStore_ViewModelChanged;
        }

        private void NavigationStore_ViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
