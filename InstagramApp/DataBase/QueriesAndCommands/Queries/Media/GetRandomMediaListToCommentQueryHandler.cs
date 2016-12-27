using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Media
{
    public class GetRandomMediaListToCommentQueryHandler: IQueryHandler<GetRandomMediaListToCommentQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetRandomMediaListToCommentQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetRandomMediaListToCommentQuery query)
        {
            var medias = context
                .Medias
                .Where(model => model.HasComment == false)
                .OrderBy(t => Guid.NewGuid())
                .Select(model => model.Link)
                .Take(query.CountMedia)
                .ToList();

            return medias;
        }
    }
}
