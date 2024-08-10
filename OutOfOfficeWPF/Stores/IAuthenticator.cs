using OutOfOfficeDomain;

namespace OutOfOfficeWPF.Stores
{
    public interface IAuthenticator
    {
        Employee CurrentEmployee { get; }
        public void Login(Guid id);
    }
}
