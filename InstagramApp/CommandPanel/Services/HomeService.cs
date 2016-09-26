using System;
using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.HomeModels;
using Constants;

namespace CommandPanel.Services
{
    public class HomeService
    {
        public List<AccountViewModel> GetAccountList()
        {
            return Enum.GetValues(typeof (AccountName))
                .Cast<AccountName>()
                .Select(name => new AccountViewModel
                {
                    Name = name.ToString("G"),
                    AccountId = name

                })
                .ToList();
        } 
    }
}