using OutOfOfficeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestItemViewModel: ViewModelBase
    {
        private readonly ApprovalRequest _request;

        public Guid Id => this._request.Id;
        public DateOnly StartDate => this._request.LeaveRequest.StartDate;
        public DateOnly EndDate => this._request.LeaveRequest.EndDate;
        public ApprovalRequestStatus Status => this._request.Status;
        public ApprovalRequestItemViewModel(ApprovalRequest request) {
            this._request = request;
        }

        public override string ToString()
        {
            return $"Approval request";
        }
    }
}
