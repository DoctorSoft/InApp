using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Commands.Functionality;
using DataBase.QueriesAndCommands.Commands.Users;

namespace CommandPanel.Services
{
    public class BasesService
    {
        public void AddNewBase(string link, AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            new MarkUserAsRequiredCommandHandler(context).Handle(new MarkUserAsRequiredCommand
            {
                UserLink = link
            });

            new SetFunctionalityAsAsapCommandHandler(context).Handle(new SetFunctionalityAsAsapCommand
            {
                FunctionalityName = FunctionalityName.SearchNewUsers
            });
        }
    }
}