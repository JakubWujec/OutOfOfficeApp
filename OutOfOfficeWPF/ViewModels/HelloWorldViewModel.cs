using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
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
        private NavigationService navigationService;
        public ICommand NavigateToCommand { get; }
        public HelloWorldViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.NavigateToCommand = new NavigateCommand(navigationService);
        }
    }
}
