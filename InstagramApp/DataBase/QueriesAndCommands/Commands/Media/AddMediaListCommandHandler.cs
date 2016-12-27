using System;
using System.Linq;
using Constants;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Media
{
    public class AddMediaListCommandHandler : IVoidCommandHandler<AddMediaListCommand>
    {
        private readonly DataBaseContext context;

        public AddMediaListCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }
        public VoidCommandResponse Handle(AddMediaListCommand command)
        {
            var mediaList = command.MediaList
            .Except(context.Medias.Select(model => model.Link))
            .Select(s => new MediaDbModel()
            {
                LikeDate = DateTime.Now,
                MediaStatus = command.MediaStatus ?? MediaStatus.ToLike,
                Link = s
            });

            context.Medias.AddRange(mediaList);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
