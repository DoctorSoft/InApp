using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Constants;
using DataBase.Contexts;
using DataBase.Models;
using DataBase.QueriesAndCommands.Common;
using EntityFramework.Extensions;

namespace DataBase.QueriesAndCommands.Commands.Functionality
{
    public class MakeFunctionalityReportCommandHandler : ICommandHandler<MakeFunctionalityReportCommand, string>
    {
        private readonly DataBaseContext context;

        public MakeFunctionalityReportCommandHandler(DataBaseContext context)
        {
            this.context = context;
        }

        public string Handle(MakeFunctionalityReportCommand command)
        {
            var records = context.FunctionalityRecords.ToList();

            var startDate = records.Min(model => model.DateTime);
            var endDate = records.Max(model => model.DateTime);

            var reportList = new List<FunctionalityReportRecord>();

            var functionalities = Enum.GetValues(typeof (FunctionalityName)).Cast<FunctionalityName>().ToList();

            foreach (var functionalityName in functionalities)
            {
                var functionalityRecords = records.Where(model => model.Name == functionalityName).ToList();

                var reportRecord = new FunctionalityReportRecord
                {
                    FunctionalityName = functionalityName.ToString("G"),
                    Cancelled = functionalityRecords.Count(model => model.WorkStatus == WorkStatus.Calcelled),
                    Exceptions = functionalityRecords.Count(model => model.WorkStatus == WorkStatus.Exception),
                    Started = functionalityRecords.Count(model => model.WorkStatus == WorkStatus.Started),
                    Successed = functionalityRecords.Count(model => model.WorkStatus == WorkStatus.Success)
                };
                reportList.Add(reportRecord);
            }

            var content = new JavaScriptSerializer().Serialize(reportList);

            var functionalityReport = new FunctionalityReportDbModel
            {
                StartDateTime = startDate,
                EndDateTime = endDate,
                JsonText = content
            };

            context.FunctionalityReports.Add(functionalityReport);

            context.FunctionalityRecords.Delete();

            context.SaveChanges();

            return content;
        }
    }
}
