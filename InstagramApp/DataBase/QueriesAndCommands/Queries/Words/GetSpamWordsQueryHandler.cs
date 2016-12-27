using System.Collections.Generic;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Words
{
    public class GetSpamWordsQueryHandler : IQueryHandler<GetSpamWordsQuery, List<SpamWordDbModel>>
    {
        private readonly DataBaseContext context;

        public GetSpamWordsQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public List<SpamWordDbModel> Handle(GetSpamWordsQuery query)
        {
            var words = context.SpamWords.ToList();

            return words;
        }
    }
}
