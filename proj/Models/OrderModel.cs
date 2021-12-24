using Newtonsoft.Json;
namespace proj.Models
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string? Name
        {
            get; set;
        }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("customer")]
        public string? Customer { get; set; }
        [JsonProperty("performer")]
        public string? Performer { get; set; }
        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
