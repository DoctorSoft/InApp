namespace DataBase.QueriesAndCommands.Common
{
    public interface IVoidCommandHandler<in TCommand> : ICommandHandler<TCommand, VoidCommandResponse> where TCommand : IVoidCommand
    {
    }
}
