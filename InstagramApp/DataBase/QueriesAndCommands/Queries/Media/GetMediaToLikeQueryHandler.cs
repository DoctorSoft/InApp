using System.Collections.Generic;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Media
{
    public class GetMediaToLikeQueryHandler : IQueryHandler<GetMediaToLikeQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetMediaToLikeQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetMediaToLikeQuery query)
        {
            var medias = context
                .Medias
                .Where(model => model.MediaStatus == MediaStatus.ToLike)
                .Select(model => model.Link)
                .Take(query.MaxCount)
                .ToList();

            return medias;
        }
    }
}
