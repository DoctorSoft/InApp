using System.Collections.Generic;
using System.Linq;
using CommandPanel.Models.LanguageModels;
using Constants;
using DataBase.Factories;
using DataBase.QueriesAndCommands.Commands.HashTag;
using DataBase.QueriesAndCommands.Commands.Languages;
using DataBase.QueriesAndCommands.Queries.Languages;

namespace CommandPanel.Services
{
    public class LanguageService
    {
        public List<LanguageViewModel> GetLanguages(AccountName accountId)
        {
            var context = new ContextFactory().GetContext(accountId);

            var languages = new GetLanguagesQueryHandler(context).Handle(new GetLanguagesQuery());

            return languages.Select(s => new LanguageViewModel
            {
                LanguageName = s
            }).ToList();
        }

        public void RemoveLanguage(AccountName accountId, string language)
        {
            var context = new ContextFactory().GetContext(accountId);

            new RemoveLanguageCommandHandler(context).Handle(new RemoveLanguageCommand
            {
                Language = language
            });
        }

        public void AddLanguage(AccountName accountId, string language)
        {
            var context = new ContextFactory().GetContext(accountId);

            new AddLanguageCommandHandler(context).Handle(new AddLanguageCommand
            {
                Language = language
            });
        }
    }
}