using System.Web.Mvc;
using Constants;

namespace CommandPanel.Controllers
{
    public class ContentDataController : Controller
    {
        // GET: Content
        public ActionResult Index(AccountName accountId)
        {
            return View();
        }
    }
}