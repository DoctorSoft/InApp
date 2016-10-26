using System;

namespace DataBase.Models
{
    public class FunctionalityReportDbModel
    {
        public long Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string JsonText { get; set; }
    }
}
