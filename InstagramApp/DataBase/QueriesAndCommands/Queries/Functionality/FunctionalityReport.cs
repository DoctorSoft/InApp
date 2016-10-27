using System;
using System.Collections.Generic;
using DataBase.QueriesAndCommands.Commands.Functionality;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class FunctionalityReport
    {
        public List<FunctionalityReportRecord> Records { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
