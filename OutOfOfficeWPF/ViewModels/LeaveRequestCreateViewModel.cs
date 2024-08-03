using OutOfOfficeDomain;
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
        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public LeaveRequestCreateViewModel(NavigationService navigationService, LeaveRequestService leaveRequestService)
        {
            this.CancelCommand = new NavigateCommand(navigationService);
            this.SubmitCommand = new LeaveRequestCreateCommand(this, navigationService, leaveRequestService);
        }
    }
}
