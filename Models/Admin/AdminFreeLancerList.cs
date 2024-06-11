using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EFreelancer.Models.Admin
{

    public class AdminFreeLancerList
    {
        [JsonProperty("merchantsList")]
        public List<AdminFreeLancerDetails> FreelancerList { get; set; }

        [JsonProperty("itemsCount")]
        public int ItemsCount { get; set; }

    }
    public class AdminFreeLancerDetails
    {
        [JsonProperty("username")]
        public int FreeLancerId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("skillsets")]
        public string Skillsets { get; set; }

        [JsonProperty("hobby")]
        public string Hobby { get; set; }

        [JsonProperty("dateJoined")]
        public string DateJoined { get; set; }
    }
}