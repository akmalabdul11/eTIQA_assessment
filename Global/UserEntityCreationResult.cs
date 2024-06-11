using Newtonsoft.Json;

namespace EFreelancer.Models.Global
{
    public class UserEntityCreationResult
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("entityId")]
        public int EntityId { get; set; }
    }
}
