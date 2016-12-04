using Constants;
using DataBase.QueriesAndCommands.Commands.Users;
using Tools.Factories;

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
        }
    }
}