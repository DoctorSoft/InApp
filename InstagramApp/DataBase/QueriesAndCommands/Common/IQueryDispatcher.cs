namespace DataBase.QueriesAndCommands.Common
{
    public interface IQueryDispatcher
    {
        TQueryResponse Dispatch<TQuery, TQueryResponse>(TQuery query) where TQuery : IQuery<TQueryResponse>;
    }
}
