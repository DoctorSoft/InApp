using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Engines.Engines.GetMediaByHashTagEngine
{
    public static class RequestsHelper
    {

        public static async Task<string> Get(string url)
        {

            var client = new WebClient
            {
                Headers =
                {
                    {HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.81 Safari/537.36"},
                    {HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8"},
                    {HttpRequestHeader.AcceptLanguage, "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4"}
                }
            };

            client.Headers.Add("Cache-Control: max-age=0");
            client.Headers.Add("X-Requested-With: XMLHttpRequest");


            var answer = await client.DownloadStringTaskAsync(url);

            var correctAnswer = ConvertToUtf8(answer);

            return correctAnswer;
        }

        private static string ConvertToUtf8(string source)
        {
            var utfBytes = Encoding.UTF8.GetBytes(source);
            var koi8RBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("windows-1251"), utfBytes);
            return Encoding.GetEncoding("utf-8").GetString(koi8RBytes);
        }
    }
}
