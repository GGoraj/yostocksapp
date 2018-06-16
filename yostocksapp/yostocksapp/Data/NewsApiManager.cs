using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using yostocksapp.Models;

namespace yostocksapp.Data
{
   public class NewsApiManager
    {
        INewsApiService jsonNewsApiService;

        public NewsApiManager(INewsApiService jsonNewsApiService)
        {
            this.jsonNewsApiService = jsonNewsApiService;
        }

        public Task<List<Article>> GetArticlesAsync()
        {
            return jsonNewsApiService.GetArticlesAsync();
        }
    }
}
