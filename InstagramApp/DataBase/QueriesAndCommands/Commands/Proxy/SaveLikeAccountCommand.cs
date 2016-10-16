using DataBase.QueriesAndCommands.Common;

namespace DataBase.QueriesAndCommands.Commands.Proxy
{
    public class SaveLikeAccountCommand : IVoidCommand
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
