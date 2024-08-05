using OutOfOfficeDomain;
using OutOfOfficeEF;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace OutOfOfficeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationStore navigationStore;
        private LeaveRequestService leaveRequestService;
        private EmployeeService employeeService;
        private OutOfOfficeContext outOfOfficeContext;
        private SqlLeaveRequestRepository leaveRequestRepository;
        private SqlEmployeeRepository employeeRepository;
        private IAuthenticator authenticator;
        private IAuthStore authStore;

        public App()
        {
            navigationStore = new NavigationStore();
            outOfOfficeContext = new OutOfOfficeContext();
            leaveRequestRepository = new SqlLeaveRequestRepository(outOfOfficeContext);
            leaveRequestService = new LeaveRequestService(leaveRequestRepository);
            employeeRepository = new SqlEmployeeRepository(outOfOfficeContext);
            employeeService = new EmployeeService(employeeRepository);
            authStore = new AuthStore();
            authenticator = new Authenticator(authStore, employeeService);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            navigationStore.CurrentViewModel = MakeLoginViewModel();

            MainViewModel mainViewModel = new MainViewModel(navigationStore);
            MainWindow mainWindow = new MainWindow();

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();      
        }

        private LeaveRequestListViewModel MakeLeaveRequestListViewModel()
        {
            IEnumerable<LeaveRequest> requests = leaveRequestService.GetCurrentLeaveRequests();
            return new LeaveRequestListViewModel(
                from request in requests
                select new LeaveRequestItemViewModel(request.Comment, request.StartDate, request.EndDate, request.Id),
                new NavigationService<LeaveRequestCreateViewModel>(navigationStore, MakeLeaveRequestCreateViewModel)
            );
        }
        private LeaveRequestCreateViewModel MakeLeaveRequestCreateViewModel()
        {
            return new LeaveRequestCreateViewModel(MakeLeaveRequestListNavigationService(), leaveRequestService);
        }
        private HomeViewModel MakeHomeViewModel() {
            return new HomeViewModel(authStore);
        }
        private LoginViewModel MakeLoginViewModel() {
            return new LoginViewModel(MakeHomeNavigationService(), authenticator, employeeService);
        }

        private EmployeeCreateViewModel MakeEmployeeCreateViewModel()
        {
            return new EmployeeCreateViewModel(employeeService, new NavigationService<HomeViewModel>(navigationStore, MakeHomeViewModel));
        }

        private INavigationService<HomeViewModel> MakeHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(navigationStore, MakeHomeViewModel, MakeNavigationBarViewModel);
        }
        private INavigationService<LeaveRequestCreateViewModel> MakeLeaveRequestCreateNavigationService()
        {
            return new LayoutNavigationService<LeaveRequestCreateViewModel>(navigationStore, MakeLeaveRequestCreateViewModel, MakeNavigationBarViewModel);
        }

        private INavigationService<LeaveRequestListViewModel> MakeLeaveRequestListNavigationService()
        {
            return new LayoutNavigationService<LeaveRequestListViewModel>(
                navigationStore, 
                MakeLeaveRequestListViewModel, 
                MakeNavigationBarViewModel
            );
        }
        private INavigationService<LoginViewModel> MakeLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(navigationStore, MakeLoginViewModel);
        }

        private NavigationBarViewModel MakeNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                MakeHomeNavigationService(),
                MakeLeaveRequestCreateNavigationService(),
                MakeLoginNavigationService(),
                MakeLeaveRequestListNavigationService(),
                authStore
            );
        }

    }

} 
 