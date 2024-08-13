using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeDomain.EventHandlers;
using OutOfOfficeEF;
using OutOfOfficeWPF.Services;
using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System.Windows;


namespace OutOfOfficeWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private OutOfOfficeDbContext outOfOfficeContext;

        private NavigationStore navigationStore;
        private ModalNavigationStore modalNavigationStore;

        private LeaveRequestService leaveRequestService;
        private ApprovalRequestService approvalRequestService;
        private EmployeeService employeeService;

        private SubmitLeaveRequestService submitLeaveRequestService;
        private AcceptApprovalRequestService acceptApprovalRequestService;
        private RejectApprovalRequestService rejectApprovalRequestService;
        private DeleteLeaveRequestService deleteLeaveRequestService;

        private SqlLeaveRequestRepository leaveRequestRepository;
        private SqlApprovalRequestRepository approvalRequestRepository;
        private SqlEmployeeRepository employeeRepository;

        private HRRequestEventHandler hrRequestEventHandler;

        private IAuthenticator authenticator;
        private IAuthStore authStore;

        public App()
        {
            OutOfOfficeDbContextFactory contextFactory = new OutOfOfficeDbContextFactory(GetConnectionString());
            outOfOfficeContext = contextFactory.CreateDbContext();
            navigationStore = new NavigationStore();
            modalNavigationStore = new ModalNavigationStore();
            leaveRequestRepository = new SqlLeaveRequestRepository(outOfOfficeContext);
            leaveRequestService = new LeaveRequestService(leaveRequestRepository);
            approvalRequestRepository = new SqlApprovalRequestRepository(outOfOfficeContext);
            approvalRequestService = new ApprovalRequestService(approvalRequestRepository);
            employeeRepository = new SqlEmployeeRepository(outOfOfficeContext);
            employeeService = new EmployeeService(employeeRepository);
            authStore = new AuthStore();
            authenticator = new Authenticator(authStore, employeeService);
            hrRequestEventHandler = new HRRequestEventHandler(approvalRequestService, leaveRequestService);

            submitLeaveRequestService = new SubmitLeaveRequestService(leaveRequestRepository, hrRequestEventHandler);
            acceptApprovalRequestService = new AcceptApprovalRequestService(approvalRequestRepository, hrRequestEventHandler);
            rejectApprovalRequestService = new RejectApprovalRequestService(approvalRequestRepository);
            deleteLeaveRequestService = new DeleteLeaveRequestService(leaveRequestRepository);
        }

        private string GetConnectionString()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "out_of_office_app.db");
            var connectionString = $"Data Source={DbPath}";
            return connectionString;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginNavigationService = MakeLoginNavigationService();
            loginNavigationService.Navigate();

            MainViewModel mainViewModel = new MainViewModel(navigationStore, modalNavigationStore);
            MainWindow mainWindow = new MainWindow();

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }

        private LeaveRequestListViewModel MakeLeaveRequestListViewModel()
        {
            return new LeaveRequestListViewModel(
                leaveRequestService,
                MakeCreateLeaveRequestNavigationService(),
                MakeLeaveRequestShowNavigationService()
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
        private HomeViewModel MakeHomeViewModel()
        {
            return new HomeViewModel(authStore);
        }
        private LoginViewModel MakeLoginViewModel()
        {
            return new LoginViewModel(MakeHomeNavigationService(), authenticator, employeeService);
        }

        private ParameterModalNavigationService<ApprovalRequest, ApprovalRequestShowViewModel> MakeApprovalRequestShowNavigationService()
        {

            return new ParameterModalNavigationService<ApprovalRequest, ApprovalRequestShowViewModel>(
                modalNavigationStore,
                MakeApprovalRequestShowViewModel
            );
        }

        private ParameterModalNavigationService<LeaveRequest, LeaveRequestShowViewModel> MakeLeaveRequestShowNavigationService()
        {

            return new ParameterModalNavigationService<LeaveRequest, LeaveRequestShowViewModel>(
                modalNavigationStore,
                MakeLeaveRequestShowViewModel
            );
        }

        private ModalNavigationService<EmployeeCreateViewModel> MakeCreateEmployeeNavigationService()
        {
            return new ModalNavigationService<EmployeeCreateViewModel>(modalNavigationStore, MakeEmployeeCreateViewModel);
        }

        private ParameterModalNavigationService<Employee, EmployeeShowViewModel> MakeEmployeeShowNavigationService()
        {
            return new ParameterModalNavigationService<Employee, EmployeeShowViewModel>(
                modalNavigationStore,
                MakeEmployeeShowViewModel
            );
        }

        public EmployeeShowViewModel MakeEmployeeShowViewModel(Employee employee)
        {
            return new EmployeeShowViewModel(employee);
        }

        private ApprovalRequestShowViewModel MakeApprovalRequestShowViewModel(ApprovalRequest approvalRequest)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
               new CloseModalNavigationService(modalNavigationStore),
               MakeApprovalRequestListNavigationService()
            );
            return new ApprovalRequestShowViewModel(navigationService, acceptApprovalRequestService, rejectApprovalRequestService, approvalRequest);
        }

        private LeaveRequestShowViewModel MakeLeaveRequestShowViewModel(LeaveRequest leaveRequest)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
               new CloseModalNavigationService(modalNavigationStore),
               MakeLeaveRequestListNavigationService()
            );
            return new LeaveRequestShowViewModel(navigationService, leaveRequest, submitLeaveRequestService, deleteLeaveRequestService);
        }

        private ApprovalRequestListViewModel MakeApprovalRequestListViewModel()
        {
            return new ApprovalRequestListViewModel(
                approvalRequestService,
                MakeApprovalRequestShowNavigationService()
            );
        }

        private EmployeeCreateViewModel MakeEmployeeCreateViewModel()
        {
            return new EmployeeCreateViewModel(employeeService, new NavigationService(navigationStore, MakeHomeViewModel));
        }

        private EmployeeListViewModel MakeEmployeeListViewModel()
        {
            return new EmployeeListViewModel(employeeService, MakeCreateEmployeeNavigationService());
        }

        private INavigationService MakeHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(navigationStore, MakeHomeViewModel, MakeNavigationBarViewModel);
        }

        private INavigationService MakeLeaveRequestListNavigationService()
        {
            return new LayoutNavigationService<LeaveRequestListViewModel>(
                navigationStore,
                MakeLeaveRequestListViewModel,
                MakeNavigationBarViewModel
            );
        }

        private INavigationService MakeApprovalRequestListNavigationService()
        {
            return new LayoutNavigationService<ApprovalRequestListViewModel>(
                navigationStore,
                MakeApprovalRequestListViewModel,
                MakeNavigationBarViewModel
            );
        }

        private INavigationService MakeLoginNavigationService()
        {
            return new LayoutNavigationService<LoginViewModel>(
                navigationStore,
                MakeLoginViewModel,
                MakeNavigationBarViewModel
            );
        }

        public INavigationService MakeEmployeeListNavigationService()
        {
            return new LayoutNavigationService<EmployeeListViewModel>(
                navigationStore,
                MakeEmployeeListViewModel,
                MakeNavigationBarViewModel
            );
        }

        private NavigationBarViewModel MakeNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                MakeHomeNavigationService(),
                MakeLoginNavigationService(),
                MakeLeaveRequestListNavigationService(),
                MakeApprovalRequestListNavigationService(),
                MakeEmployeeListNavigationService(),
                authStore
            );
        }

    }

}
