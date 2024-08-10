namespace OutOfOfficeDomain
{
    public interface ICommandService<TCommand>
    {
        void Execute(TCommand command);
    }
}
