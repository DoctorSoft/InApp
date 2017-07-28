using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Engines.Engines.GetMediaByHashTagEngine
{
    public class GetMediaByHashTagEngine : AbstractEngine<GetMediaByHashTagModel, List<string>>
    {
        protected override List<string> ExecuteEngine(RemoteWebDriver driver, GetMediaByHashTagModel model)
        {
            try
            {
                var hashTag = TagsHalper.RemoveSharp(model.HashTag);

                var firstPage = RequestsHelper.Get(InstagramUrls.SeachByHashTag(hashTag)).Result;
                var jsonPage = JsonHalper.GetJson(firstPage);
                var endCursor = JsonHalper.GetEndCursor(jsonPage);

                var topUsers = JsonHalper.GetSrcTopImages(jsonPage);
                var newUsers = JsonHalper.GetSrcNewImages(jsonPage);

                var apiUrl = InstagramUrls.SeachByHashTagApi(hashTag, model.CountMedia, endCursor);

                var apiPage = RequestsHelper.Get(apiUrl).Result;
                var jsonApiPage = JsonHalper.GetJson(apiPage);
                var newUsersApi = JsonHalper.GetSrcNewImagesForApi(jsonApiPage);

                var result = new List<string>();

                result.AddRange(topUsers);
                result.AddRange(newUsers);
                result.AddRange(newUsersApi);

                return result;
            }
            catch (Exception exception)
            {
                return new List<string>();
                //throw new TopImagesByHashtagNotReceivedException(exception.Message);
            }
        }
    }
}
