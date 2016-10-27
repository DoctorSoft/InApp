namespace CommandPanel.Models.AccountModels
{
    public class Report
    {
        public string FunctionalityName { get; set; }

        public long Successed { get; set; }

        public long Cancelled { get; set; }

        public long Exceptions { get; set; }

        public long Started { get; set; }
    }
}