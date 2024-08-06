using Microsoft.Extensions.DependencyInjection;
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
        private ModalNavigationStore modalNavigationStore;
        private LeaveRequestService leaveRequestService;
        private CloseModalNavigationService closeModalNavigationService;
        private EmployeeService employeeService;
        private OutOfOfficeContext outOfOfficeContext;
        private SqlLeaveRequestRepository leaveRequestRepository;
        private SqlEmployeeRepository employeeRepository;
        private IAuthenticator authenticator;
        private IAuthStore authStore;

        public App()
        {
            navigationStore = new NavigationStore();
            modalNavigationStore = new ModalNavigationStore();
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

            MainViewModel mainViewModel = new MainViewModel(navigationStore, modalNavigationStore);
            MainWindow mainWindow = new MainWindow();

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();      
        }

        private LeaveRequestListViewModel MakeLeaveRequestListViewModel()
        {
            return new LeaveRequestListViewModel(
                leaveRequestService,
                MakeCreateLeaveRequestNavigationService()
            );
        }

        private ModalNavigationService<LeaveRequestCreateViewModel> MakeCreateLeaveRequestNavigationService()
        {
            return new ModalNavigationService<LeaveRequestCreateViewModel>(modalNavigationStore, MakeLeaveRequestCreateViewModel);
        }
        private LeaveRequestCreateViewModel MakeLeaveRequestCreateViewModel()
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
                new CloseModalNavigationService(modalNavigationStore),
                MakeLeaveRequestListNavigationService()
            );
            return new LeaveRequestCreateViewModel(navigationService, leaveRequestService, authStore);
        }
        private HomeViewModel MakeHomeViewModel() {
            return new HomeViewModel(authStore);
        }
        private LoginViewModel MakeLoginViewModel() {
            return new LoginViewModel(MakeHomeNavigationService(), authenticator, employeeService);
        }

        private EmployeeCreateViewModel MakeEmployeeCreateViewModel()
        {
            return new EmployeeCreateViewModel(employeeService, new NavigationService(navigationStore, MakeHomeViewModel));
        }

        private INavigationService MakeHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(navigationStore, MakeHomeViewModel, MakeNavigationBarViewModel);
        }
        private INavigationService MakeLeaveRequestCreateNavigationService()
        {
            return new LayoutNavigationService<LeaveRequestCreateViewModel>(navigationStore, MakeLeaveRequestCreateViewModel, MakeNavigationBarViewModel);
        }

        private INavigationService MakeLeaveRequestListNavigationService()
        {
            return new LayoutNavigationService<LeaveRequestListViewModel>(
                navigationStore, 
                MakeLeaveRequestListViewModel, 
                MakeNavigationBarViewModel
            );
        }
        private INavigationService MakeLoginNavigationService()
        {
            return new NavigationService(navigationStore, MakeLoginViewModel);
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
 