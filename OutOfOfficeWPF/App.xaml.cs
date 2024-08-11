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
        private OutOfOfficeContext outOfOfficeContext;

        private NavigationStore navigationStore;
        private ModalNavigationStore modalNavigationStore;

        private LeaveRequestService leaveRequestService;
        private ApprovalRequestService approvalRequestService;
        private EmployeeService employeeService;

        private SubmitLeaveRequestService submitLeaveRequestService;
        private AcceptApprovalRequestService acceptApprovalRequestService;
        private RejectApprovalRequestService rejectApprovalRequestService;

        private SqlLeaveRequestRepository leaveRequestRepository;
        private SqlApprovalRequestRepository approvalRequestRepository;
        private SqlEmployeeRepository employeeRepository;

        private HRRequestEventHandler hrRequestEventHandler;

        private IAuthenticator authenticator;
        private IAuthStore authStore;

        public App()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "out_of_office_app.db");
            var connectionString = $"Data Source={DbPath}";

            OutOfOfficeDbContextFactory contextFactory = new OutOfOfficeDbContextFactory(connectionString);
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
            hrRequestEventHandler = new HRRequestEventHandler(approvalRequestService);
            submitLeaveRequestService = new SubmitLeaveRequestService(leaveRequestRepository, hrRequestEventHandler);
            acceptApprovalRequestService = new AcceptApprovalRequestService(approvalRequestRepository);
            rejectApprovalRequestService = new RejectApprovalRequestService(approvalRequestRepository);
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
                submitLeaveRequestService,
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

        private ApprovalRequestShowViewModel MakeApprovalRequestShowViewModel(ApprovalRequest approvalRequest)
        {
            CompositeNavigationService navigationService = new CompositeNavigationService(
               new CloseModalNavigationService(modalNavigationStore),
               MakeApprovalRequestListNavigationService()
            );
            return new ApprovalRequestShowViewModel(navigationService, acceptApprovalRequestService, rejectApprovalRequestService, approvalRequest);
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
            return new NavigationService(navigationStore, MakeLoginViewModel);
        }

        private NavigationBarViewModel MakeNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                MakeHomeNavigationService(),
                MakeCreateLeaveRequestNavigationService(),
                MakeLoginNavigationService(),
                MakeLeaveRequestListNavigationService(),
                MakeApprovalRequestListNavigationService(),
                authStore
            );
        }

    }

}
