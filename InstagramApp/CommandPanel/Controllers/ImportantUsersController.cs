using System.Web.Mvc;
using CommandPanel.Models.ImportantUserModels;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class ImportantUsersController : Controller
    {
        private readonly ImportantUsersService importantUsersService;

        public ImportantUsersController()
        {
            this.importantUsersService = new ImportantUsersService();
        }

        // GET: ImportantUsers
        public ActionResult Index(AccountName accountId)
        {
            var models = importantUsersService.GetImportantUsers(accountId);
            var result = new ImportantUserListViewModel
            {
                Users = models,
                AccountId = accountId
            };
            return View(result);
        }

        public ActionResult RemoveImportantUser(AccountName accountId, string user)
        {
            importantUsersService.RemoveImportantUser(accountId, user);
            return RedirectToAction("Index", new { accountId });
        }

        [HttpPost]
        public ActionResult AddImportantUser(AccountName accountId, string user)
        {
            importantUsersService.AddImportantUser(accountId, user);
            return RedirectToAction("Index", new { accountId });
        }
    }
}