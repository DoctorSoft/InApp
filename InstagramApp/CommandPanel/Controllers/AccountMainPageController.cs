using System.Web.Mvc;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class AccountMainPageController : Controller
    {
        private readonly AccountService accountService;

        public AccountMainPageController()
        {
            this.accountService = new AccountService();
        }

        // GET: AccountMainPage
        public ActionResult Index(AccountName accountId)
        {
            var model = accountService.GetAccountMainStatistic(accountId);

            return View(model);
        }
    }
}