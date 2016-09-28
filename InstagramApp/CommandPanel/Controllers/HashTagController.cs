using System.Web.Mvc;
using CommandPanel.Models.HashTagModels;
using CommandPanel.Services;
using Constants;

namespace CommandPanel.Controllers
{
    public class HashTagController : Controller
    {
        private readonly HashTagService hashTagService;

        public HashTagController()
        {
            this.hashTagService = new HashTagService();
        }

        // GET: HashTag
        public ActionResult Index(AccountName accountId)
        {
            var models = hashTagService.GetHashTags(accountId);
            var result = new HashTagListViewModel
            {
                HashTags = models,
                AccountId = accountId
            };
            return View(result);
        }

        public ActionResult RemoveHashTage(AccountName accountId, string hashTag)
        {
            hashTagService.RemoveHashTag(accountId, hashTag);
            return RedirectToAction("Index", new {accountId});
        }

        [HttpPost]
        public ActionResult AddHashTag(AccountName accountId, string hashTag)
        {
            hashTagService.AddHashTag(accountId, hashTag);
            return RedirectToAction("Index", new {accountId});
        }
    }
}