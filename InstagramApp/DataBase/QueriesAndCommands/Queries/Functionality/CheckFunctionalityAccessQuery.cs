using System;
using Constants;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class CheckFunctionalityAccessQuery : IQuery<bool>
    {
        public FunctionalityName FunctionalityName { get; set; }

        public Guid Token { get; set; }

    }
}
