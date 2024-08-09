using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestItemViewModel: ViewModelBase
    {
        public Guid Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string Status { get; set; }
    
        public ApprovalRequestItemViewModel(DateOnly startDate, DateOnly endDate, Guid id, string status ) { 
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Id = id;
            this.Status = status;
        }

        public override string ToString()
        {
            return $"Approval request";
        }
    }
}
