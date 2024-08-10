namespace OutOfOfficeDomain.Tests.Fakes
{
    public class StubEventHandler<TEvent> : IEventHandler<TEvent>
    {
        public void Handle(TEvent e)
        {
        }
    }
}
