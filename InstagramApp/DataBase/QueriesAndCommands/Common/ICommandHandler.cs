namespace DataBase.QueriesAndCommands.Common
{
    public interface ICommandHandler<in TCommand, out TCommandResponse> where TCommand: ICommand<TCommandResponse>
    {
        TCommandResponse Handle(TCommand command);
    }
}
