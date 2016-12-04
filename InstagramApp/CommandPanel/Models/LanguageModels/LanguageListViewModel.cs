using System.Collections.Generic;
using Constants;

namespace CommandPanel.Models.LanguageModels
{
    public class LanguageListViewModel
    {
        public List<LanguageViewModel> Languages { get; set; }

        public AccountName AccountId { get; set; }
    }
}