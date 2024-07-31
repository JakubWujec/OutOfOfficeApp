using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestItemViewModel
    {
        public string Comment { get; set; }
        public LeaveRequestItemViewModel(string comment) { 
            this.Comment = comment;
        }

        public override string ToString()
        {
            return $"{this.Comment}";
        }
    }
}
