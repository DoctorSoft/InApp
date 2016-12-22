using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Stars
{
    public class MarkStarAsUnfollowedCommandHandler : IVoidCommandHandler<MarkStarAsUnfollowedCommand>
    {
        private readonly DataBaseContext context;

        public MarkStarAsUnfollowedCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkStarAsUnfollowedCommand command)
        {
            var star = context.StarRecords.FirstOrDefault(model => model.Link.ToUpper() == command.Link.ToUpper());

            star.Followed = false;
            star.LastUnfollowing = DateTime.Now;

            context.StarRecords.AddOrUpdate(star);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
