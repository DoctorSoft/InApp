using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.ImportantUserModels;
using CommandPanel.Models.LanguageModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Commands.Users;
using DataBase.QueriesAndCommands.Queries.Languages;
using DataBase.QueriesAndCommands.Queries.Users;

namespace CommandPanel.Services
{
    public class ImportantUsersService
    {
        public List<ImportantUserViewModel> GetImportantUsers(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            var users = new GetUsersImpotantForOwnerQueryHandler(context).Handle(new GetUsersImpotantForOwnerQuery { MaxCount = int.MaxValue });

            return users.Select(s => new ImportantUserViewModel
            {
                UserLink = s
            }).ToList();
        }

        public void RemoveImportantUser(AccountName accountId, string user)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveUserCommandHandler(context).Handle(new RemoveUserCommand
            {
                UserLink = user
            });
        }

        public void AddImportantUser(AccountName accountId, string user)
        {
            var context = new ContextFactory().GetContext(accountId);

            new MarkUserAsImportantCommandHandler(context).Handle(new MarkUserAsImportantCommand
            {
                UserLink = user
            });
        }
    }
}