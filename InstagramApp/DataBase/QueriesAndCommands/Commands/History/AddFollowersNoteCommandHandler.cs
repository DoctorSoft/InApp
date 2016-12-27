﻿using System;
using DataBase.Contexts;
using DataBase.Contexts.InnerTools;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.History
{
    public class AddFollowersNoteCommandHandler : IVoidCommandHandler<AddFollowersNoteCommand>
    {
        private readonly DataBaseContext context;

        public AddFollowersNoteCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public VoidCommandResponse Handle(AddFollowersNoteCommand command)
        {
            var activityHistory = new ActivityHistoryDbModel
            {
                FollowersCount = command.FollowersCount,
                FollowingsCount = command.FollowingsCount,
                MediaCount = command.MediaCount,
                MarkDate = DateTime.Now
            };

            context.ActivityHistories.Add(activityHistory);
            context.SaveChanges();

            return new VoidCommandResponse();
        }
    }
}
