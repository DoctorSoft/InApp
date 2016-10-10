using System.Linq;
using DataBase.Contexts.LikeApplication;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.LikeApplication
{
    public class RemoveLikeMediaCommandHandler : ICommandHandler<RemoveLikeMediaCommand, VoidCommandResponse>
    {
        private readonly LikeApplicationContext context;

        public RemoveLikeMediaCommandHandler(LikeApplicationContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(RemoveLikeMediaCommand command)
        {
            var mediaToDelete = context.Medias.FirstOrDefault(model => model.Link.ToUpper() == command.Link.ToUpper());

            context.Medias.Remove(mediaToDelete);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
