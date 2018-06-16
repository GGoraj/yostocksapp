using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using yostocksapp.Models;

namespace yostocksapp.ViewModels
{
    public class NewsViewModel
    {
        //public ICommand ReadMoreSelectedCommand { get; private set } 
        public ObservableCollection<Article> Articles { get; private set; }

        public NewsViewModel()
        {
            GetArticlesAsync();
        }


        public async void GetArticlesAsync()
        {
            Articles = new ObservableCollection<Article>(await App.NewsApiManager.GetArticlesAsync());
        }
    }
}
