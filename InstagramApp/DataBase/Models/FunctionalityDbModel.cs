using System;
using Constants;

namespace DataBase.Models
{
    public class FunctionalityDbModel
    {
        public long Id { get; set; }

        public string FunctionalityName { get; set; }

        public FunctionalityName FunctionalityNumber { get; set; }

        public DateTime LastApplied { get; set; }

        public TimeSpan ApplyInterval { get; set; }

        public TimeSpan ExpectingTime { get; set; }

        public Guid? Token { get; set; }

        public bool Stopped { get; set; }
    }
}
