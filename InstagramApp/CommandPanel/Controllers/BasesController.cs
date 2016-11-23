using System.Web.Mvc;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class BasesController : Controller
    {
        private readonly BasesService basesService;

        public BasesController()
        {
            this.basesService = new BasesService();
        }

        // GET: Bases
        public ActionResult Index(AccountName accountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBase(AccountName accountId, string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return RedirectToAction("Index", "Bases", new {accountId = accountId});
            }

            basesService.AddNewBase(link, accountId);
            return RedirectToAction("Index", "AccountMainPage", new {accountId = accountId});
        }
    }
}