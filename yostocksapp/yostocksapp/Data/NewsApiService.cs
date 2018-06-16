using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using yostocksapp.Models;

namespace yostocksapp.Data
{
    public class NewsApiService : INewsApiService
    {
        public List<Article> Articles { get; private set; }
        private string URL = "https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=606b359d17734ef0a2c5a5f7dc922e00";
        HttpClient client;


        //Constructor
        public NewsApiService()
        {
            client = new HttpClient();
        }


        public async Task<List<Article>> GetArticlesAsync()
        {
            var URI = new Uri(string.Format(URL, string.Empty));
            Articles = new List<Article>();
            try
            {
                //send async GET request to specified uri
                var response = await client.GetAsync(URI);

                //if API is active (http 200 ok)
                if (response.IsSuccessStatusCode)
                {
                    //wait incomming response (JSON file)
                    var content = await response.Content.ReadAsStringAsync();
                    var list = Welcome.FromJson(content);

                    Articles = list.Articles;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            //null or full
            return Articles;
        }

    }
}
