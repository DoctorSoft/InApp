using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.HashTag
{
    public class AddHashTagCommandHandler : ICommandHandler<AddHashTagCommand, VoidCommandResponse>
    {
        private readonly DataBaseContext context;

        public AddHashTagCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(AddHashTagCommand command)
        {
            var therIsHashTag = context.HashTags.Any(model => model.Name.ToUpper() == command.HashTag.ToUpper());

            if (!therIsHashTag)
            {
                var hashTag = new HashTagDbModel
                {
                    Name = command.HashTag
                };

                context.HashTags.Add(hashTag);

                context.SaveChanges();
            }

            return new VoidCommandResponse();
        }
    }
}
