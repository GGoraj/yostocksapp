using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using yostocksapp.Models;

namespace yostocksapp.ViewModels
{
    public class BrandsViewModel
    {
        public ObservableCollection<BrandModel> Brands { get; set; }
        = new ObservableCollection<BrandModel>();
        public BrandsViewModel()
        {
            Brands.Add(new BrandModel { FileName = "google.png", BrandName = "google" });
            Brands.Add(new BrandModel { FileName = "apple.png", BrandName = "apple" });
            Brands.Add(new BrandModel { FileName = "disney.png", BrandName = "disnay" });
            Brands.Add(new BrandModel { FileName = "facebook.png", BrandName = "facebook" });
            Brands.Add(new BrandModel { FileName = "bing.png", BrandName = "bing" });
            Brands.Add(new BrandModel { FileName = "ford.png", BrandName = "ford" });
            Brands.Add(new BrandModel { FileName = "amazon.png", BrandName = "amazon" });
            Brands.Add(new BrandModel { FileName = "audi.png", BrandName = "audi" });
        }
    }
}
