using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.HashTag
{
    public class GetHashTagsQueryHandler : IQueryHandler<GetHashTagsQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetHashTagsQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetHashTagsQuery query)
        {
            var hashTags = context.HashTags.Select(model => model.Name).ToList();

            return hashTags;
        }
    }
}
