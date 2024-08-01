using OutOfOfficeDomain;
using OutOfOfficeEF;
using OutOfOfficeWPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace OutOfOfficeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            OutOfOfficeContext context = new OutOfOfficeContext();
            SqlLeaveRequestRepository repository = new SqlLeaveRequestRepository(context);
            LeaveRequestService service = new LeaveRequestService(repository);
            IEnumerable<LeaveRequest> requests = service.GetCurrentLeaveRequests();

            LeaveRequestListViewModel leaveRequestViewModel = new LeaveRequestListViewModel(
                from request in requests
                select new LeaveRequestItemViewModel(request.Comment, request.StartDate, request.EndDate, request.Id)
            );

            HelloWorldViewModel helloWorldViewModel = new HelloWorldViewModel();

            MainViewModel mainViewModel = new MainViewModel(leaveRequestViewModel);

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;
          
            mainWindow.Show();      
        }
    }

} 
