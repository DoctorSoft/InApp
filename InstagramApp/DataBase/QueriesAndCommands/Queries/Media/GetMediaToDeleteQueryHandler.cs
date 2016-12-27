using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
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
            DateTime curDate = DateTime.Now;
            curDate = curDate.AddDays(-2);

            var mediaToDeleteList = context.Medias
                .Where(model => model.LikeDate < curDate)
                .Select(model => model.Link)
                .ToList();
            return mediaToDeleteList;
        }
    }
}
