using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace LanguageDetector
{
    public class LanguageDetector
    {
        public Detection Detect(string text, string key)
        {
            var client = new RestClient("http://ws.detectlanguage.com");
            var request = new RestRequest("/0.2/detect", Method.POST);

            request.AddParameter("key", key); 
            request.AddParameter("q", text);

            IRestResponse response = client.Execute(request);

            RestSharp.Deserializers.JsonDeserializer deserializer = new RestSharp.Deserializers.JsonDeserializer();

            try
            {
                var result = deserializer.Deserialize<Result>(response);
                
                var detection = result.data.detections.FirstOrDefault();

                return detection;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
