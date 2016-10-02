using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class GetFunctionalityStatisticQueryHandler : IQueryHandler<GetFunctionalityStatisticQuery, List<FunctionalityStatistic>>
    {
        private readonly DataBaseContext context;

        public GetFunctionalityStatisticQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<FunctionalityStatistic> Handle(GetFunctionalityStatisticQuery query)
        {
            var now = DateTime.Now;

            var functionalities = context
                .Functionalities
                .ToList()
                .OrderBy(model => model.LastApplied + model.ApplyInterval)
                .Select(model => new FunctionalityStatistic
                {
                    FunctionalityName = model.FunctionalityNumber,
                    LastActivity = model.LastApplied,
                    Token = model.Token
                })
                .ToList();

            return functionalities;
        }
    }
}
