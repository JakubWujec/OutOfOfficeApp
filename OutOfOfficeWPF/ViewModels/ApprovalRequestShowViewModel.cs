
using OutOfOfficeWPF.Commands;
using OutOfOfficeWPF.Services;
using System.Windows.Input;

namespace OutOfOfficeWPF.ViewModels
{
    public class ApprovalRequestShowViewModel: ViewModelBase
    {
        public ICommand CancelCommand { get; }
        public ApprovalRequestShowViewModel(INavigationService cancelNavigationService)
        {
            this.CancelCommand = new NavigateCommand(cancelNavigationService);
        }

    }
}
