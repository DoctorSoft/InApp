using System.Web.Mvc;
using CommandPanel.Models.ConfigurationsModels;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class ConfigurationsController : Controller
    {
        private readonly ConfigurationsService configurationsService;

        public ConfigurationsController()
        {
            this.configurationsService = new ConfigurationsService();
        }

        // GET: Configurations
        public ActionResult Index(AccountName accountId)
        {
            var settings = configurationsService.GetConfigurations(accountId);
            return View(settings);
        }

        public ActionResult UpdateSettings(AccountName accountId, ConfigurationsDraftModel model)
        {
            configurationsService.UpdateConfigurations(accountId, model);
            return RedirectToAction("Index", new { accountId = accountId });
        }
    }
}