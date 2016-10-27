using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using DataBase.Contexts;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class GetLastReportQueryHandler : IQueryHandler<GetLastReportQuery, FunctionalityReport>
    {
        private readonly DataBaseContext context;

        public GetLastReportQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public FunctionalityReport Handle(GetLastReportQuery query)
        {
            var report = context.FunctionalityReports.OrderByDescending(model => model.EndDateTime).FirstOrDefault();

            if (report == null)
            {
                return null;
            }

            return new FunctionalityReport
            {
                Records = new JavaScriptSerializer().Deserialize<List<FunctionalityReportRecord>>(report.JsonText),
                EndDate = report.EndDateTime,
                StartDate = report.StartDateTime
            };
        }
    }
}
