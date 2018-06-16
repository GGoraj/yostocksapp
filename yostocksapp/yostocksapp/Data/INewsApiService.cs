using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using yostocksapp.Models;

namespace yostocksapp.Data
{
    public interface INewsApiService
    {
        Task<List<Article>> GetArticlesAsync();
    }
}
