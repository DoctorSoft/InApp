using System;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
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
            var now = DateTime.Now;

            var access = context.Functionalities.ToList()
                .Any(model =>
                        model.FunctionalityNumber == query.FunctionalityName &&
                        (model.Token == query.Token || model.Token == null || model.LastApplied + model.ExpectingTime < now));

            return access;
        }
    }
}
