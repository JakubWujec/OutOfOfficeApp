using OutOfOfficeDomain;
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System.Windows.Input;


namespace OutOfOfficeWPF.ViewModels
{
    public class EmployeeCreateViewModel : ViewModelBase
    {
        private readonly EmployeeService employeeService;
        public EmployeeCreateViewModel(EmployeeService employeeService, INavigationService listNavigationService)
        {
            this.employeeService = employeeService;
            this.SubmitCommand = new EmployeeCreateCommand(this, employeeService, listNavigationService);
            this.CancelCommand = new NavigateCommand(listNavigationService);
        }

        public Array Positions => employeeService.GetPositions();

        private Position _selectedPosition;

        public Position SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private string firstName = string.Empty;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value; OnPropertyChanged(nameof(FirstName));
            }
        }
        private string lastName = string.Empty;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value; OnPropertyChanged(nameof(LastName));
            }
        }
        private bool isActive = true;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; OnPropertyChanged(nameof(IsActive)); }
        }


    }
}
