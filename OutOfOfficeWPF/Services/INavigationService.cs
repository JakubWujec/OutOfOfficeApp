using OutOfOfficeWPF.Stores;
using OutOfOfficeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OutOfOfficeWPF.Services
{
    public interface INavigationService<TViewModel> 
        where TViewModel : ViewModelBase
    {
        public void Navigate();
    }
}
