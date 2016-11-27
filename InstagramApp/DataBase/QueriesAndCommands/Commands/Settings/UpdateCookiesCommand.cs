using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Settings
{
    public class UpdateCookiesCommand : IVoidCommand
    {
        public string Cookies { get; set; }
    }
}
