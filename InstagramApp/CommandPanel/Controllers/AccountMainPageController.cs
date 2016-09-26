using System.Web.Mvc;
using Constants;

namespace CommandPanel.Controllers
{
    public class AccountMainPageController : Controller
    {
        // GET: AccountMainPage
        public ActionResult Index(AccountName accountId)
        {
            return View(accountId);
        }
    }
}