using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class HelloWorldViewModel: ViewModelBase
    {
        private NavigationStore navigationStore;
        private ViewModelBase destinationViewModel;
        public ICommand NavigateToCommand { get;  }
        public HelloWorldViewModel(NavigationStore navigationStore, ViewModelBase destinationViewModel)
        {
            this.navigationStore = navigationStore;
            this.destinationViewModel = destinationViewModel;
            this.NavigateToCommand = new NavigateCommand(navigationStore, destinationViewModel);
        }

     
    }
}
