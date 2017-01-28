using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Media
{
    public class GetMediaToDeleteQueryHandler : IQueryHandler<GetMediaToDeleteQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetMediaToDeleteQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetMediaToDeleteQuery query)
        {
            var mediaToDeleteList = context.Medias
                .Select(model => model.Link)
                .ToList();
            return mediaToDeleteList;
        }
    }
}
