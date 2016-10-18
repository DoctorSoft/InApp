using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Content
{
    public class GetContentQueryHandler : IQueryHandler<GetContentQuery, List<ContentData>>
    {
        private readonly DataBaseContext context;

        public GetContentQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<ContentData> Handle(GetContentQuery query)
        {
            return context.Contents.Select(model => new ContentData
            {
                ContentType = model.ContentType.Name,
                Link = model.Link,
                IncludingDate = model.IncludingDateTime
            }).ToList();
        }
    }
}
