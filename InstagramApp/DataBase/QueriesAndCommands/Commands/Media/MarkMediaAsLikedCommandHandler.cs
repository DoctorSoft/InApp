using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Media
{
    public class MarkMediaAsLikedCommandHandler : IVoidCommandHandler<MarkMediaAsLikedCommand>
    {
        private readonly DataBaseContext context;

        public MarkMediaAsLikedCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(MarkMediaAsLikedCommand command)
        {
            var media = context.Medias.FirstOrDefault(model => model.Link == command.Link);

            if (media == null)
            {
                return new VoidCommandResponse();
            }

            media.MediaStatus = MediaStatus.Liked;

            context.Medias.AddOrUpdate(media);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
