namespace DataBase.QueriesAndCommands.Common
{
    public interface ICommandDispatcher
    {
        TCommandResponse Dispatch<TCommand, TCommandResponse>(TCommand command) where TCommand : ICommand<TCommandResponse>;
    }
}
