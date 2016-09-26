using System.Web.Mvc;
using CommandPanel.Services;

namespace CommandPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService homeService;

        public HomeController()
        {
            this.homeService = new HomeService();
        }

        public ActionResult Index()
        {
            var result = homeService.GetAccountList();
            return View(result);
        }
    }
}