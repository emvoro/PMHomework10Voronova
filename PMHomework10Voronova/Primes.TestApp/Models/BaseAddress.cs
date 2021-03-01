using System.Text.Json.Serialization;

namespace PrimesTestApp.Models
{
    public class BaseAddress
    {
        [JsonPropertyName("baseAddress")]
        public string Address { get; set; }
    }
}
