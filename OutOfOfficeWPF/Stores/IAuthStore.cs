using OutOfOfficeDomain;

namespace OutOfOfficeWPF.Stores
{
    public interface IAuthStore
    {
        Employee CurrentEmployee { get; set; }

        public event Action CurrentEmployeeChanged;
        public void Logout();

        public bool IsLoggedIn { get; }

        public bool IsInPosition(Position position);
    }
}
