using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace yostocksapp.Models
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using NewsApiGreg1.Models;
    //
    //    var welcome = Welcome.FromJson(jsonString);
    //source: www.jsontoc#.com




    public partial class Welcome
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }

    public partial class Article
    {

        //This Event Is To Notify NewsSubTabPage of Changes in Articles
        //public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }


        //backing property for Title
        //private string _title;

        [JsonProperty("title")]
        public string Title
        {
            /* to be reviewed later
            get {
                return _title;
            }
            set {
                if(_title == value)
                {
                    return;
                }
                else
                {
                    _title = value;
                    if(PropertyChanged != null)
                    {
                        //rising the event
                        OnPropertyChanged();
                    }
                }
            }
            */
            get; set;
        }

        /*
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //if(PropertyChanged != null)
            
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
        */

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlToImage")]
        public string UrlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }


    }

    public partial class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
