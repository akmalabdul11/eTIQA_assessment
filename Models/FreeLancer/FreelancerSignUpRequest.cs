using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EFreelancer.Models.FreeLancer
{
    public class FreelancerSignUpRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("skillsets")]
        public string Skillsets { get; set; }

        [JsonProperty("Hobby")]
        public string Hobby { get; set; }

        [JsonProperty("dateJoined")]
        public DateTime DateJoined { get; set; }
    }
}