using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.HashTag
{
    public class RemoveHashTagCommandHandler : ICommandHandler<RemoveHashTagCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public RemoveHashTagCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveHashTagCommand command)
        {
            var hashTag = context.HashTags.FirstOrDefault(model => model.Name.ToUpper() == command.HashTag.ToUpper());

            context.HashTags.Remove(hashTag);

            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
