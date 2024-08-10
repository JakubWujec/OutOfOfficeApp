using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class ParameterModalNavigateCommand<TParameter, TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private ParameterModalNavigationService<TParameter, TViewModel> navigationService;
        public ParameterModalNavigateCommand(ParameterModalNavigationService<TParameter, TViewModel> navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            if (parameter is TParameter _parameter)
            {
                navigationService.Navigate(_parameter);
            }
        }
    }
}
