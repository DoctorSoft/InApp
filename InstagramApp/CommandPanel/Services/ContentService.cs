using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.ContentModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Queries.Content;

namespace CommandPanel.Services
{
    public class ContentService
    {
        public List<ContentViewModel> GetAddedContent(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);
            
            var content = new GetContentQueryHandler(context).Handle(new GetContentQuery());

            return content.Select(data => new ContentViewModel
            {
                Link = data.Link,
                LikeCount = 0
            }).ToList();
        }
    }
}