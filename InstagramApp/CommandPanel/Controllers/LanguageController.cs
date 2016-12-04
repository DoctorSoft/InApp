using System.Web.Mvc;
using CommandPanel.Models.LanguageModels;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class LanguageController : Controller
    {
        private readonly LanguageService languageService;

        public LanguageController()
        {
            this.languageService = new LanguageService();
        }

        // GET: Language
        public ActionResult Index(AccountName accountId)
        {
            var models = languageService.GetLanguages(accountId);
            var result = new LanguageListViewModel
            {
                Languages = models,
                AccountId = accountId
            };
            return View(result);
        }

        public ActionResult RemoveLanguage(AccountName accountId, string language)
        {
            languageService.RemoveLanguage(accountId, language);
            return RedirectToAction("Index", new { accountId });
        }

        [HttpPost]
        public ActionResult AddLanguage(AccountName accountId, string language)
        {
            languageService.AddLanguage(accountId, language);
            return RedirectToAction("Index", new { accountId });
        }
    }
}