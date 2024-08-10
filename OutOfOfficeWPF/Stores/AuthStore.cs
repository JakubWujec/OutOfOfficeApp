using OutOfOfficeDomain;

namespace OutOfOfficeWPF.Stores
{
    public class AuthStore : IAuthStore
    {
        private Employee _currentEmployee;
        public Employee CurrentEmployee
        {
            get
            {
                return _currentEmployee;
            }
            set
            {
                this._currentEmployee = value;
                CurrentEmployeeChanged?.Invoke();
            }
        }
        public bool IsLoggedIn => CurrentEmployee != null;

        public event Action CurrentEmployeeChanged;
        public void Logout()
        {
            CurrentEmployee = null;
        }
    }
}
