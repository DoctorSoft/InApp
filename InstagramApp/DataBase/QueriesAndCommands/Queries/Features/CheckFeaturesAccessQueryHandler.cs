using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Features
{
    public class CheckFeaturesAccessQueryHandler: IQueryHandler<CheckFeaturesAccessQuery, bool>
    {
        private readonly DataBaseContext context;

        public CheckFeaturesAccessQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public bool Handle(CheckFeaturesAccessQuery query)
        {
            var access = context.Features
            .Any(model => model.FeatureIdentity == query.FeaturesName && model.IsBlocked == false);

            return access;
        }
    }
}
