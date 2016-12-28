using System.Web.Mvc;
using CommandPanel.Services;

namespace CommandPanel.Controllers
{
    public class BotController : Controller
    {
        private readonly BotService botService;

        public BotController()
        {
            this.botService = new BotService();
        }

        // GET: Bot
        public ActionResult Index()
        {
            var bots = botService.GetConfigurations();
            return View();
        }
    }
}