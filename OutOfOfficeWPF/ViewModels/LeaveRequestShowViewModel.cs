using OutOfOfficeDomain.CommandServices;
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
    public class LeaveRequestShowViewModel: ViewModelBase
    {
        public ICommand CancelCommand { get; }
        private readonly LeaveRequest _leaveRequest;
        public String FullName => _leaveRequest.Employee.FullName;
        public LeaveRequest SelectedRequest => _leaveRequest;
        public LeaveRequestShowViewModel(
            INavigationService cancelNavigationService,
            LeaveRequest leaveRequest
            )
        {
            this.CancelCommand = new NavigateCommand(cancelNavigationService);
            this._leaveRequest = leaveRequest;
        }
    }
}
