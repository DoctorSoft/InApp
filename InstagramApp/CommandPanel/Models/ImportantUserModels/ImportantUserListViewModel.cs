using System.Collections.Generic;
using Constants;

namespace CommandPanel.Models.ImportantUserModels
{
    public class ImportantUserListViewModel
    {
        public List<ImportantUserViewModel> Users { get; set; }

        public AccountName AccountId { get; set; }
    }
}