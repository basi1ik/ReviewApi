using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Parser2Gis.Models;

namespace Parser2Gis
{
    class Program
    {
        public static IConfiguration AppConfiguration { get; set; }

        static void Main(string[] args)
        {
            string result = RunAsync().GetAwaiter().GetResult();
            string json = GetJson(result);

            var reviews = GetReviews(json);

            foreach (var item in reviews)
            {
                Console.WriteLine(item.Text);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Get reviews items from json 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private static List<Review> GetReviews(string json)
        {
            string response = JsonConvert.DeserializeObject<Request>(json).Data.ToString();
            var reviewsRaw = JsonConvert.DeserializeObject<Data>(response).Review;
            var reviewItems = ConvertObjectToArray(reviewsRaw);
            
            return reviewItems; 
        }

        /// <summary>
        /// Convert object ot array
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static List<Review> ConvertObjectToArray(JObject obj)
        {
            List<Review> reviews = new List<Review>();

            foreach (KeyValuePair<string, JToken> property in obj)
            {                
                var dataRaw = JsonConvert.DeserializeObject<Data>(property.Value.ToString()).DataRaw.ToString();
                var review = JsonConvert.DeserializeObject<Review>(dataRaw);                
                reviews.Add(review);
            }          

            return reviews;
        }

        /// <summary>
        /// Get json from html 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private static string GetJson(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            string json = doc.DocumentNode.Descendants("script")
                                        .ToList()
                                        .Where(n => n.InnerText.Contains("__customcfg"))
                                        .First().InnerText
                                        .Split("var ")[2]
                                        .Trim();

            int first = json.IndexOf('{');
            int last = json.LastIndexOf('}');
            int count = last - first + 1;

            json = json.Substring(first, count);
            
            return json;
        }

        /// <summary>
        /// Do request on the site 2gis.ru
        /// </summary>
        /// <returns></returns>
        private static async Task<string> RunAsync()
        {
            AuthConfig config = AuthConfig.ReadFromJsonFile("appsettings.json");
            var httpClient = new HttpClient();               
            
            httpClient.DefaultRequestHeaders.Accept.Add(new 
                    MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(config.UserAgent);            
            httpClient.DefaultRequestHeaders.Referrer = new Uri(config.Referer);
            httpClient.DefaultRequestHeaders.Accept.ParseAdd(config.Accept);

            string content = String.Empty;

            HttpResponseMessage response = await httpClient.GetAsync(config.Url);
            if (response.IsSuccessStatusCode)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                content = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed to call the site: {response.StatusCode}");
                content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Content: {content}");
            }            
            Console.ResetColor();
            return content;
        }
    }
}
