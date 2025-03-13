using System.Text.Json.Serialization;

namespace Dotcentric.Infrastructure.Models
{
    public class Product
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("images")]
        public List<string>? Images { get; set; }
        [JsonPropertyName("price")]
        public int? Price { get; set; }

        public string Image
        {
            get => _image ?? Images?.FirstOrDefault() ?? string.Empty;
            set => _image = value;
        }

        private string? _image;
    }
}
