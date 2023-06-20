
using Newtonsoft.Json;

namespace primeiroservico.Model
{
    public class Usuario
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string? Nome { get; set; }

        public string? status { get; set; }
    }
}