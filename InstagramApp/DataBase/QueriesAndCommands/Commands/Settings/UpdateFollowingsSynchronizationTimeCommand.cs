using System;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Settings
{
    public class UpdateFollowingsSynchronizationTimeCommand : IVoidCommand
    {
        public DateTime? NextTime { get; set; }
    }
}
