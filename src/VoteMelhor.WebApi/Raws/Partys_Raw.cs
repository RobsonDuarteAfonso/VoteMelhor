using Newtonsoft.Json;

namespace VoteMelhor.WebApi.Raws
{
    public class Partys_Raw
    {
        [JsonProperty("sigla")]
        public string Sigla { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("numero")]
        public int Numero { get; set; }
        [JsonProperty("imagem")]
        public string Imagem { get; set; }
    }
}
