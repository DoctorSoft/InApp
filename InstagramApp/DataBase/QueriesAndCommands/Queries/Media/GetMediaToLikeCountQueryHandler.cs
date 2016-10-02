using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Media
{
    public class GetMediaToLikeCountQueryHandler : IQueryHandler<GetMediaToLikeCountQuery, int>
    {
        private readonly DataBaseContext context;

        public GetMediaToLikeCountQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public int Handle(GetMediaToLikeCountQuery query)
        {
            var count = context.Medias.Count(model => model.MediaStatus == MediaStatus.ToLike);

            return count;
        }
    }
}
