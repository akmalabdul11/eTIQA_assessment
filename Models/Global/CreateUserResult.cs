using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EFreelancer.Models.Global
{
    public class CreateUserResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}