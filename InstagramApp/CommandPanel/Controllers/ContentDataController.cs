using System.Web.Mvc;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class ContentDataController : Controller
    {
        private readonly ContentService contentService;

        public ContentDataController()
        {
            this.contentService = new ContentService();
        }

        // GET: Content
        public ActionResult Index(AccountName accountId)
        {
            var list = contentService.GetAddedContent(accountId);
            return View(list);
        }
    }
}