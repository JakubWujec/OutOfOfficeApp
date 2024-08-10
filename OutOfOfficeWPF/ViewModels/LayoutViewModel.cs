namespace OutOfOfficeWPF.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        private NavigationBarViewModel navigationBarViewModel;
        private ViewModelBase contentViewModel;

        public NavigationBarViewModel NavigationBarViewModel => navigationBarViewModel;
        public ViewModelBase ContentViewModel => contentViewModel;

        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, ViewModelBase contentViewModel)
        {
            this.navigationBarViewModel = navigationBarViewModel;
            this.contentViewModel = contentViewModel;
        }
    }
}
