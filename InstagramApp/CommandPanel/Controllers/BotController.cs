using System.Web.Mvc;
using CommandPanel.Models.ConfigurationsModels;
using CommandPanel.Services;
using Constants;

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
            return View(bots);
        }

        public ActionResult UpdateSettings(AccountName accountId, ConfigurationsDraftModel model)
        {
            botService.UpdateConfigurations(accountId, model);
            return RedirectToAction("Index", new { accountId = accountId });
        }
    }
}