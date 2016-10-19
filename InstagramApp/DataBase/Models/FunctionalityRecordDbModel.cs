using System;
using Constants;

namespace DataBase.Models
{
    public class FunctionalityRecordDbModel
    {
        public long Id { get; set; }

        public FunctionalityName Name { get; set; }

        public WorkStatus WorkStatus { get; set; }

        public string Note { get; set; }

        public DateTime DateTime { get; set; }
    }
}
