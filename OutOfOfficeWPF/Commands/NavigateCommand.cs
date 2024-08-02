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
        private ViewModelBase viewModel;

        public NavigateCommand(NavigationStore navigationStore, ViewModelBase viewModel)
        {
            this.navigationStore = navigationStore;
            this.viewModel = viewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = viewModel;
        }
    }
}
