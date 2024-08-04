using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class LayoutViewModel: ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel;
        public ViewModelBase CurrentViewModel;

        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, ViewModelBase currentViewModel)
        {
            this.NavigationBarViewModel = navigationBarViewModel;
            this.CurrentViewModel = currentViewModel;
        }
    }
}
