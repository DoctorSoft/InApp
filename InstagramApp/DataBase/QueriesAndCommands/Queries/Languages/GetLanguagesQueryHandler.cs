using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Languages
{
    public class GetLanguagesQueryHandler : IQueryHandler<GetLanguagesQuery, List<string>>
    {
        private readonly DataBaseContext context;

        public GetLanguagesQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<string> Handle(GetLanguagesQuery query)
        {
            var languages = context.Languages.Select(model => model.Name).ToList();

            return languages;
        }
    }
}
