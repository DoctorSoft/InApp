using System;
using System.Collections.Generic;

namespace CommandPanel.Models.AccountModels
{
    public class InfoData
    {
        public DateTime FirstReportDate { get; set; }

        public long FirstReportFollowersCount { get; set; }

        public List<BaseData> Bases { get; set; }

    }
}