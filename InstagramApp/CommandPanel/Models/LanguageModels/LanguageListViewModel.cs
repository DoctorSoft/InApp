using System.Collections.Generic;
using CommandPanel.Models.HashTagModels;
using Constants;

namespace CommandPanel.Models.LanguageModels
{
    public class LanguageListViewModel
    {
        public List<LanguageViewModel> Languages { get; set; }

        public AccountName AccountId { get; set; }
    }
}