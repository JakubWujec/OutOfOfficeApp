using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OutOfOfficeDomain;
using OutOfOfficeEF;

namespace OutOfOfficeWPF.Views
{
    /// <summary>
    /// Interaction logic for LeaveRequestListControl.xaml
    /// </summary>
    public partial class LeaveRequestListControl : UserControl
    {
        public LeaveRequestListViewModel ViewModel { get; set; }
        public LeaveRequestListControl()
        {
            InitializeComponent();

            SqlLeaveRequestRepository repository = new SqlLeaveRequestRepository();
            LeaveRequestService service = new LeaveRequestService(repository);
            IEnumerable<LeaveRequest> requests = service.GetCurrentLeaveRequests();

            ViewModel = new LeaveRequestListViewModel(
                from request in requests
                select new LeaveRequestItemViewModel(request.Comment)
            );

            DataContext = ViewModel;
        }
    }
}
