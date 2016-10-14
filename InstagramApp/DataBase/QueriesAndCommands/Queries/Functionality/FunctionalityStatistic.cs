﻿using System;
using Constants;

namespace DataBase.QueriesAndCommands.Queries.Functionality
{
    public class FunctionalityStatistic
    {
        public FunctionalityName FunctionalityName { get; set; }

        public DateTime LastActivity { get; set; }

        public Guid? Token { get; set; }

        public bool Stopped { get; set; }

        public bool Asap { get; set; }
    }
}
