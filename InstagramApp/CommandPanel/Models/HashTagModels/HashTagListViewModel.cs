using System.Collections.Generic;
using Constants;

namespace CommandPanel.Models.HashTagModels
{
    public class HashTagListViewModel
    {
        public List<HashTagViewModel> HashTags { get; set; }

        public AccountName AccountId { get; set; }
    }
}