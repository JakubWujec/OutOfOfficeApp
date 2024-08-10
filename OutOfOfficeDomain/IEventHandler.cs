namespace OutOfOfficeDomain
{
    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent e);
    }
}
