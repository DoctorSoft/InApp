﻿using System.Collections.Generic;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class GetFollowingUsersQuery : IQuery<List<string>>
    {
        public int MaxCount { get; set; }
    }
}
