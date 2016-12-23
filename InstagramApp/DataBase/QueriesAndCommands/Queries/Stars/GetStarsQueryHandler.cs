using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Stars
{
    public class GetStarsQueryHandler : IQueryHandler<GetStarsQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetStarsQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetStarsQuery query)
        {
            var limitDate = DateTime.Now.Date.AddHours(-3);

            if (query.ToFollow)
            {
                var accounts =
                    context.StarRecords
                        .Where(model => model.LastUnfollowing == null || model.LastUnfollowing.Value > limitDate)
                        .Where(model => !model.Followed)
                        .OrderBy(model => model.Id)
                        .Take(query.MaxCount)
                        .Select(model => model.Link)
                        .ToList();

                return accounts;
            }

            var accountsToUnfollow =
                    context.StarRecords
                        .Where(model => model.LastFollowing == null || model.LastUnfollowing.Value > limitDate)
                        .Where(model => model.Followed)
                        .OrderBy(model => model.Id)
                        .Take(query.MaxCount)
                        .Select(model => model.Link)
                        .ToList();

            return accountsToUnfollow;
        }
    }
}
