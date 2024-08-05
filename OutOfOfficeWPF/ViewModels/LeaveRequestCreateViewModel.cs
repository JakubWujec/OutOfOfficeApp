using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
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
        public LeaveRequestCreateViewModel(INavigationService<LeaveRequestListViewModel> leaveRequestListNavigationService, LeaveRequestService leaveRequestService, IAuthStore authStore)
        {
            this.CancelCommand = new NavigateCommand<LeaveRequestListViewModel>(leaveRequestListNavigationService);
            this.SubmitCommand = new LeaveRequestCreateCommand(this, leaveRequestListNavigationService, leaveRequestService, authStore);
        }
    }
}
