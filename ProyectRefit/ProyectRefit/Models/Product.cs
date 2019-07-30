

namespace ProyectRefit.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Refit;

    public partial class Product
    { 
        [AliasAs("image")]
        [JsonProperty("image")]
        public string Image { get; set; }
        [AliasAs("id")]
        [JsonProperty("id")]
        public long Id { get; set; }
        [AliasAs("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [AliasAs("Description")]
        [JsonProperty("description")]
        public string Description { get; set; }
        [AliasAs("IsAvalible")]
        [JsonProperty("isAvalible")]
        public bool IsAvalible { get; set; }
        [AliasAs("price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [AliasAs("user")]
        [JsonProperty("user")]
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public User user { get; set; }
    }
}
