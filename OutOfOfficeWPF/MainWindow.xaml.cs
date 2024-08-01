using OutOfOfficeDomain;
using OutOfOfficeEF;
using OutOfOfficeWPF.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OutOfOfficeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LeaveRequestListViewModel ViewModel { get; set; }
        public MainWindow()
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