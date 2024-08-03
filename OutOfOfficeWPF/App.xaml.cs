using OutOfOfficeDomain;
using OutOfOfficeEF;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
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
        private NavigationStore navigationStore;
        private LeaveRequestService leaveRequestService;
        private OutOfOfficeContext outOfOfficeContext;
        private SqlLeaveRequestRepository leaveRequestRepository;

        public App()
        {
            navigationStore = new NavigationStore();
            outOfOfficeContext = new OutOfOfficeContext();
            leaveRequestRepository = new SqlLeaveRequestRepository(outOfOfficeContext);
            leaveRequestService = new LeaveRequestService(leaveRequestRepository);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginViewModel viewModel = new LoginViewModel();

            MainViewModel mainViewModel = new MainViewModel(navigationStore);
            MainWindow mainWindow = new MainWindow();

            navigationStore.CurrentViewModel = viewModel;

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();      
        }

        private LeaveRequestListViewModel MakeLeaveRequestListViewModel()
        {
            IEnumerable<LeaveRequest> requests = leaveRequestService.GetCurrentLeaveRequests();
            return new LeaveRequestListViewModel(
                from request in requests
                select new LeaveRequestItemViewModel(request.Comment, request.StartDate, request.EndDate, request.Id),
                new NavigationService(navigationStore, MakeLeaveRequestCreateViewModel)
            );
        }
        private LeaveRequestCreateViewModel MakeLeaveRequestCreateViewModel()
        {
            return new LeaveRequestCreateViewModel(new NavigationService(navigationStore, MakeLeaveRequestListViewModel), leaveRequestService);
        }

        private LoginViewModel MakeLoginViewModel()
        {
            return new LoginViewModel();
        }
    }

} 
 