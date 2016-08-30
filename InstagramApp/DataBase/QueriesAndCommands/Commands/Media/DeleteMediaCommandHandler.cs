using System.Linq;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Media
{
    public class DeleteMediaCommandHandler : IVoidCommandHandler<DeleteMediaCommand>
    {
        private readonly DataBaseContext context;

        public DeleteMediaCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(DeleteMediaCommand command)
        {
            foreach (var url in command.UrlList)
            {
                var media = context.Medias.Where(model => url != null && model.Link == url);

                context.Medias.RemoveRange(media);
                context.SaveChanges();

            }
            return new VoidCommandResponse();
        }
    }
}
