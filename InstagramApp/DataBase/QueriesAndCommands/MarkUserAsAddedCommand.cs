﻿using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class MarkUserAsAddedCommand : IVoidCommand
    {
        public string UserLink { get; set; }
    }
}
