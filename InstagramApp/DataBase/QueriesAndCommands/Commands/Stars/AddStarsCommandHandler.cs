using System.Linq;
using System.Linq.Dynamic;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.BulkInsert.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Stars
{
    public class AddStarsCommandHandler : ICommandHandler<AddStarsCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public AddStarsCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(AddStarsCommand command)
        {
            var addedStars = context.StarRecords.Select(model => model.Link).ToList();

            var newStars = command.StarsUrls.Except(addedStars);

            context.BulkInsert(newStars.Select(s => new StarRecordDbModel
            {
                Link = s,
                Followed = false,
                LastFollowing = null,
                LastUnfollowing = null
            }));

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
