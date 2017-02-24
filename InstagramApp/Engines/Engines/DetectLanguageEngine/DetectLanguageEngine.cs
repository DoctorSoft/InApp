using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RestSharp;

namespace Engines.Engines.DetectLanguageEngine
{
    public class DetectLanguageEngine : AbstractEngine<DetectLanguageEngineModel, LanguageModel>
    {
        private static Random random = new Random();

        public class Detection
        {
            public string language { get; set; }
            public bool isReliable { get; set; }
            public float confidence { get; set; }
        }

        public class ResultData
        {
            public List<Detection> detections { get; set; }
        }

        public class Result
        {
            public ResultData data { get; set; }
        }

        protected override LanguageModel ExecuteEngine(RemoteWebDriver driver, DetectLanguageEngineModel model)
        {
            if (random.Next(2) == 0)
            {
                return ExecuteByDetector(model);
            }

            return ExecuteByGoogle(driver, model);
        }

        private LanguageModel ExecuteByDetector(DetectLanguageEngineModel model)
        {
            const string key = "06b11f1ec38eb723b903fc36c74f5fe7";

            var client = new RestClient("http://ws.detectlanguage.com");
            var request = new RestRequest("/0.2/detect", Method.POST);

            request.AddParameter("key", key); // replace "demo" with your API key
            request.AddParameter("q", model.Text);

            var response = client.Execute(request);

            RestSharp.Deserializers.JsonDeserializer deserializer = new RestSharp.Deserializers.JsonDeserializer();

            var result = deserializer.Deserialize<Result>(response);

            var detection = result.data.detections[0];

            var dictionary = new Dictionary<string, string>
            {
                {"en", "английский" },
                {"ru", "русский"}
            };

            if (dictionary.ContainsKey(detection.language))
            {
                return new LanguageModel
                {
                    Language = dictionary[detection.language]
                };
            }
            return new LanguageModel
            {
                Language = detection.language
            };
        }

        private LanguageModel ExecuteByGoogle(RemoteWebDriver driver, DetectLanguageEngineModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Text))
            {
                return null;
            }

            driver.Navigate().GoToUrl("https://translate.google.ru/#auto/ru/");

            Thread.Sleep(1500);

            var textArea = driver.FindElementByTagName("textarea");

            var textData = new string(model.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c)).ToArray());

            textArea.SendKeys(textData);

            Thread.Sleep(2000);

            //gt-sl-sugg

            var buttonsDiv = driver.FindElementById("gt-sl-sugg");
            var languageButton = buttonsDiv.FindElements(By.ClassName("jfk-button-checked")).FirstOrDefault();

            var text = languageButton.Text.Split(' ').First();

            if (text.ToLower().Contains("определить"))
            {
                driver.Navigate().Refresh();
                buttonsDiv = driver.FindElementById("gt-sl-sugg");
                languageButton = buttonsDiv.FindElements(By.ClassName("jfk-button-checked")).FirstOrDefault();

                text = languageButton.Text.Split(' ').First();
            }

            return new LanguageModel
            {
                Language = text
            };
        }
    }
}
