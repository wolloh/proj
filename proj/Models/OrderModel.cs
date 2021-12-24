using Newtonsoft.Json;
namespace proj.Models
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("order")]
        public string? Order
        {
            get; set;
        }
    }
}
