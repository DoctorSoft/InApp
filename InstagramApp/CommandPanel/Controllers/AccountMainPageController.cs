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

        public ActionResult ClearAllUsersToFollow(AccountName accountId)
        {
            accountService.RemoveAllUsersToFollow(accountId);

            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult ClearAllUsersToDelete(AccountName accountId)
        {
            accountService.RemoveAllUsersToDelete(accountId);

            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult ClearAllNormalUsers(AccountName accountId)
        {
            accountService.RemoveAllNormalUsers(accountId);

            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult SwitchFunctionalityAccess(AccountName accountId, FunctionalityName functionalityName)
        {
            accountService.SwitchSwitchFunctionalityAccess(accountId, functionalityName);

            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult SetFunctionalityAsAsap(AccountName accountId, FunctionalityName functionalityName)
        {
            accountService.SetFunctionalityAsAsap(accountId, functionalityName);

            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult ClearLogs(AccountName accountId)
        {
            accountService.ClearAccountLogs(accountId);

            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult ResetAllSearchFriendsMarks(AccountName accountId)
        {
            accountService.ResetAllSearchFriendsMarks(accountId);
            return RedirectToAction("Index", new { accountId = accountId });
        }

        public ActionResult ResetAllFunctionalityTokens(AccountName accountId)
        {
            accountService.ResetAllFunctionalityTokens(accountId);
            return RedirectToAction("Index", new { accountId = accountId });
        }
    }
}