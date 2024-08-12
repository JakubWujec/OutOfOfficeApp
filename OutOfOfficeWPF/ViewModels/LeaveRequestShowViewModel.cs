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
        public DateOnly StartDate => _leaveRequest.StartDate;
        public DateOnly EndDate => _leaveRequest.EndDate;
        public LeaveRequest SelectedRequest => _leaveRequest;
        public ICommand SubmitCommand { get; }
        public ICommand DeleteCommand { get; }
        public LeaveRequestShowViewModel(
            INavigationService cancelNavigationService,
            LeaveRequest leaveRequest,
            SubmitLeaveRequestService submitLeaveRequestService,
            DeleteLeaveRequestService deleteLeaveRequestService
            )
        {
            this.CancelCommand = new NavigateCommand(cancelNavigationService);
            this.SubmitCommand = new LeaveRequestSubmitCommand(this, submitLeaveRequestService);
            this.DeleteCommand = new LeaveRequestDeleteCommand(this, deleteLeaveRequestService);
            this._leaveRequest = leaveRequest;
        }
    }
}
