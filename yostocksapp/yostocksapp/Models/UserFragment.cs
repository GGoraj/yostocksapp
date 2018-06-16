using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using yostocksapp.Models;
//
//    var userFragment = UserFragment.FromJson(jsonString);

namespace yostocksapp.Models
{
    

    public partial class UserFragment
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("StockId")]
        public long StockId { get; set; }

        [JsonProperty("PercentValue")]
        public double PercentValue { get; set; }
    }

    public partial class UserFragment
    {
        public static List<UserFragment> FromJson(string json) => JsonConvert.DeserializeObject<List<UserFragment>>(json, yostocksapp.Models.Converter.Settings);
    }

    /*
    public static class Serialize
    {
        public static string ToJson(this List<UserFragment> self) => JsonConvert.SerializeObject(self, yostocksapp.Models.Converter.Settings);
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
    */
}

