namespace DataBase.QueriesAndCommands.Common
{
    public interface IQueryHandler<TQuery, TQueryResponse> where TQuery: IQuery<TQueryResponse>
    {
        TQueryResponse Handle(TQuery query);
    }
}
