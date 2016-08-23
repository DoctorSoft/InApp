namespace DataBase.Models
{
    public class SpamWordDbModel
    {
        public long Id { get; set; }

        public string WordRoot { get; set; }

        public double SpamFactor { get; set; }
    }
}
