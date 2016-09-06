using Constants;

namespace DataBase.Models
{
    public class FeaturesDbModel
    {
        public long Id { get; set; }

        public string FeatureIdentyName { get; set; }

        public bool IsBlocked { get; set; }

        public FeaturesName FeatureIdentity { get; set; }
    }
}
