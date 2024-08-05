using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OutOfOfficeWPF.Commands
{
    public class NavigateCommand: CommandBase 
    {
        private INavigationService navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            navigationService.Navigate();
        }
    }
}
