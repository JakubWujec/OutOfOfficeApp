using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeWPF.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public MainViewModel(ViewModelBase currentViewModel) {
            this.CurrentViewModel = currentViewModel;
        }
    }
}
