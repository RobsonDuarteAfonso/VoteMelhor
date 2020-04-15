using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteMelhor.WebApi.Raws
{
    public class Partidos_Raw
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
