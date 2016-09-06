using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class CheckFunctionalityAccessQueryHandler : IQueryHandler<CheckFunctionalityAccessQuery, bool>
    {
        private readonly DataBaseContext context;

        public CheckFunctionalityAccessQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public bool Handle(CheckFunctionalityAccessQuery query)
        {
            var access = context.Functionalities
                .Any(model =>
                        model.FunctionalityNumber == query.FunctionalityName &&
                        (model.Token == query.Token || model.Token == null));

            return access;
        }
    }
}
