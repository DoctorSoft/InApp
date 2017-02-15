using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Script.Serialization;
using DataBase.Contexts.InnerTools;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class GetDaylyReportQueryHandler: IQueryHandler<GetDaylyReportQuery, FunctionalityReport>
    {
        private readonly DataBaseContext context;

        public GetDaylyReportQueryHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public FunctionalityReport Handle(GetDaylyReportQuery query)
        {
            var today = DateTime.Now.Date;
            var report = context.FunctionalityReports.Where(model => model.EndDateTime >= today).ToList();

            if (!report.Any())
            {
                today = today.AddDays(-1);
                report = context.FunctionalityReports.Where(model => model.EndDateTime >= today).ToList();
            }

            var javaScriptSerializer = new JavaScriptSerializer();
            var reportData = report
                .Select(model => javaScriptSerializer.Deserialize<List<FunctionalityReportRecord>>(model.JsonText));

            var dictionary = new Dictionary<string, FunctionalityReportRecord>();

            foreach (var reportItem in reportData)
            {
                foreach (var functionalityReportRecord in reportItem)
                {
                    if (dictionary.ContainsKey(functionalityReportRecord.FunctionalityName))
                    {
                        var data = dictionary[functionalityReportRecord.FunctionalityName];
                        data.Cancelled += functionalityReportRecord.Cancelled;
                        data.Exceptions += functionalityReportRecord.Exceptions;
                        data.Started += functionalityReportRecord.Started;
                        data.Successed += functionalityReportRecord.Successed;
                        dictionary[functionalityReportRecord.FunctionalityName] = data;
                    }
                    else
                    {
                        dictionary.Add(functionalityReportRecord.FunctionalityName, functionalityReportRecord);
                    }
                }
            }

            var records = dictionary.Values.ToList();

            return new FunctionalityReport
            {
                Records = records,
                EndDate = today.AddDays(1),
                StartDate = today
            };
        }
    }
}
