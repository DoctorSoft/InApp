using System;
using System.Collections.Generic;

namespace CommandPanel.Models.AccountModels
{
    public class ReportData
    {
        public DateTime StartDateTime { get; set; }
        
        public DateTime EndDateTime { get; set; }

        public List<Report> Reports { get; set; } 
    }
}