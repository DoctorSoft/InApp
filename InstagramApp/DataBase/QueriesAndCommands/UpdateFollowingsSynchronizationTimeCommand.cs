using System;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands
{
    public class UpdateFollowingsSynchronizationTimeCommand : IVoidCommand
    {
        public DateTime? NextTime { get; set; }
    }
}
