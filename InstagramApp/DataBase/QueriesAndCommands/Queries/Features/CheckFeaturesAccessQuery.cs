using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Features
{
    public class CheckFeaturesAccessQuery: IQuery<bool>
    {
        public FeaturesName FeaturesName { get; set; }
    }
}
