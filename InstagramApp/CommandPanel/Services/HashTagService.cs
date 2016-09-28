using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.HashTagModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Commands.HashTag;
using DataBase.QueriesAndCommands.Queries.HashTag;

namespace CommandPanel.Services
{
    public class HashTagService
    {
        public List<HashTagViewModel> GetHashTags(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            var hashTags = new GetHashTagsQueryHandler(context).Handle(new GetHashTagsQuery());

            return hashTags.Select(s => new HashTagViewModel
            {
                HashTagName = s
            }).ToList();
        }

        public void RemoveHashTag(AccountName accountId, string hashTag)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveHashTagCommandHandler(context).Handle(new RemoveHashTagCommand
            {
                HashTag = hashTag
            });
        }

        public void AddHashTag(AccountName accountId, string hashTag)
        {
            var context = new ContextFactory().GetContext(accountId);

            if (!hashTag.StartsWith("#"))
            {
                hashTag = "#" + hashTag;
            }

            new AddHashTagCommandHandler(context).Handle(new AddHashTagCommand
            {
                HashTag = hashTag
            });
        }
    }
}