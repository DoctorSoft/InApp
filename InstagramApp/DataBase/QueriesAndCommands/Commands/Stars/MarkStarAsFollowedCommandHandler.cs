using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Stars
{
    public class MarkStarAsFollowedCommandHandler : ICommandHandler<MarkStarAsFollowedCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public MarkStarAsFollowedCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkStarAsFollowedCommand command)
        {
            var star = context.StarRecords.FirstOrDefault(model => model.Link.ToUpper() == command.Link.ToUpper());

            star.Followed = true;
            star.LastFollowing = DateTime.Now;
            
            context.StarRecords.AddOrUpdate(star);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
