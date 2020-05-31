using System.Collections.Generic;
using Newtonsoft.Json;

namespace VoteMelhor.WebApi.Raws
{
    public class Dado
    {

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("idLegislatura")]
        public int idLegislatura { get; set; }

        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("siglaPartido")]
        public string siglaPartido { get; set; }

        [JsonProperty("siglaUf")]
        public string siglaUf { get; set; }

        [JsonProperty("uri")]
        public string uri { get; set; }

        [JsonProperty("uriPartido")]
        public string uriPartido { get; set; }

        [JsonProperty("urlFoto")]
        public string urlFoto { get; set; }
    }

    public class Link
    {

        [JsonProperty("href")]
        public string href { get; set; }

        [JsonProperty("rel")]
        public string rel { get; set; }
    }

    public class Congressman_Raw
    {

        [JsonProperty("dados")]
        public IList<Dado> dados { get; set; }

        [JsonProperty("links")]
        public IList<Link> links { get; set; }
    }
}