

namespace ProyectRefit.Models
{
    using Newtonsoft.Json;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class User
    {
        [AliasAs("id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [AliasAs("email")]
        [JsonProperty("email")]
        public string Email { get; set; }
        [AliasAs("password")]
        [JsonProperty("password")]
        public string Passowrd { get; set; }
        [AliasAs("firstName")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [AliasAs("lastName")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [AliasAs("address")]
        [JsonProperty("address")]
        public string Address { get; set; }
        [AliasAs("tell")]
        [JsonProperty("tell")]
        public string Tell { get; set; }
    }
}
