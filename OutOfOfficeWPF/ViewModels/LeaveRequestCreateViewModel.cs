using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestCreateViewModel: ViewModelBase
    {
        public DateOnly StartDate;
        public DateOnly EndDate;
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private readonly NavigationService navigationService;
        public LeaveRequestCreateViewModel(NavigationService navigationService)
        {
            this.StartDate = new DateOnly();
            this.EndDate = new DateOnly();
            this.navigationService = navigationService;
            this.CancelCommand = new NavigateCommand(navigationService);
            this.SubmitCommand = new LeaveRequestCreateCommand(this, navigationService);
        }
    }
}
