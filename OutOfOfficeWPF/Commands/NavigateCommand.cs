using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OutOfOfficeWPF.Commands
{
    public class NavigateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private NavigationStore navigationStore;
        private Func<ViewModelBase> createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
