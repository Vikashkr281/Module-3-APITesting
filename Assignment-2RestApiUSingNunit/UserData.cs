using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2RestApiUSingNunit
{
    public class UserData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("user_name")]
        public string? UserName { get; set; }
       
       
       

    }

}
