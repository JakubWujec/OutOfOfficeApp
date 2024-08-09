﻿using Microsoft.Extensions.DependencyInjection;
using OutOfOfficeDomain;
using OutOfOfficeDomain.CommandServices;
using OutOfOfficeDomain.EventHandlers;
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
        private OutOfOfficeContext outOfOfficeContext;

        private NavigationStore navigationStore;
        private ModalNavigationStore modalNavigationStore;

        private LeaveRequestService leaveRequestService;
        private ApprovalRequestService approvalRequestService;
        private EmployeeService employeeService;

        private SubmitLeaveRequestService submitLeaveRequestService;

        private SqlLeaveRequestRepository leaveRequestRepository;
        private SqlApprovalRequestRepository approvalRequestRepository;
        private SqlEmployeeRepository employeeRepository;

        private HRRequestEventHandler hrRequestEventHandler;

        private IAuthenticator authenticator;
        private IAuthStore authStore;
        
        public App()
        {
            navigationStore = new NavigationStore();
            modalNavigationStore = new ModalNavigationStore();
            outOfOfficeContext = new OutOfOfficeContext();
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
        private HomeViewModel MakeHomeViewModel() {
            return new HomeViewModel(authStore);
        }
        private LoginViewModel MakeLoginViewModel() {
            return new LoginViewModel(MakeHomeNavigationService(), authenticator, employeeService);
        }

        private ApprovalRequestListViewModel MakeApprovalRequestListViewModel()
        {
            return new ApprovalRequestListViewModel(
                approvalRequestService
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
 