using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
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

            media.MediaStatus = MediaStatus.ToLike;

            context.Medias.AddOrUpdate(media);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
