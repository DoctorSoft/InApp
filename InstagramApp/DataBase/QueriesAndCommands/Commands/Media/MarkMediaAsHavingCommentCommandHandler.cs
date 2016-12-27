using System.Data.Entity.Migrations;
using System.Linq;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Media
{
    public class MarkMediaAsHavingCommentCommandHandler: IVoidCommandHandler<MarkMediaAsHavingCommentCommand>
    {
        private readonly DataBaseContext context;

        public MarkMediaAsHavingCommentCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkMediaAsHavingCommentCommand command)
        {
            var media = context.Medias.FirstOrDefault(model => model.Link == command.Link);

            if (media == null)
            {
                return new VoidCommandResponse();
            }

            media.HasComment = true;

            context.Medias.AddOrUpdate(media);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
