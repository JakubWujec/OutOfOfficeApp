using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.Commands
{
    public class ParameterNavigateCommand<TParameter, TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private ParameterModalNavigationService<TParameter, TViewModel> navigationService;
        public ParameterNavigateCommand(ParameterModalNavigationService<TParameter, TViewModel> navigationService)
        {
            this.navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            if(parameter != null)
            {
                navigationService.Navigate((TParameter)parameter);
            }
    
        }
    }
}
