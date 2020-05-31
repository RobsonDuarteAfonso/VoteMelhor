using System.Collections.Generic;
using Newtonsoft.Json;

namespace VoteMelhor.WebApi.Raws
{

        public class Gabinete
        {

            [JsonProperty("andar")]
            public string andar { get; set; }

            [JsonProperty("email")]
            public string email { get; set; }

            [JsonProperty("nome")]
            public string nome { get; set; }

            [JsonProperty("predio")]
            public string predio { get; set; }

            [JsonProperty("sala")]
            public string sala { get; set; }

            [JsonProperty("telefone")]
            public string telefone { get; set; }
        }

        public class UltimoStatus
        {

            [JsonProperty("condicaoEleitoral")]
            public string condicaoEleitoral { get; set; }

            [JsonProperty("data")]
            public string data { get; set; }

            [JsonProperty("descricaoStatus")]
            public string descricaoStatus { get; set; }

            [JsonProperty("email")]
            public string email { get; set; }

            [JsonProperty("gabinete")]
            public Gabinete gabinete { get; set; }

            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("idLegislatura")]
            public int idLegislatura { get; set; }

            [JsonProperty("nome")]
            public string nome { get; set; }

            [JsonProperty("nomeEleitoral")]
            public string nomeEleitoral { get; set; }

            [JsonProperty("siglaPartido")]
            public string siglaPartido { get; set; }

            [JsonProperty("siglaUf")]
            public string siglaUf { get; set; }

            [JsonProperty("situacao")]
            public string situacao { get; set; }

            [JsonProperty("uri")]
            public string uri { get; set; }

            [JsonProperty("uriPartido")]
            public string uriPartido { get; set; }

            [JsonProperty("urlFoto")]
            public string urlFoto { get; set; }
        }

        public class Dados
        {

            [JsonProperty("cpf")]
            public string cpf { get; set; }

            [JsonProperty("dataFalecimento")]
            public string dataFalecimento { get; set; }

            [JsonProperty("dataNascimento")]
            public string dataNascimento { get; set; }

            [JsonProperty("escolaridade")]
            public string escolaridade { get; set; }

            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("municipioNascimento")]
            public string municipioNascimento { get; set; }

            [JsonProperty("nomeCivil")]
            public string nomeCivil { get; set; }

            [JsonProperty("redeSocial")]
            public IList<string> redeSocial { get; set; }

            [JsonProperty("sexo")]
            public string sexo { get; set; }

            [JsonProperty("ufNascimento")]
            public string ufNascimento { get; set; }

            [JsonProperty("ultimoStatus")]
            public UltimoStatus ultimoStatus { get; set; }

            [JsonProperty("uri")]
            public string uri { get; set; }

            [JsonProperty("urlWebsite")]
            public string urlWebsite { get; set; }
        }

        public class CongressmanDetails_Raw
        {

            [JsonProperty("dados")]
            public Dados dados { get; set; }

            [JsonProperty("links")]
            public IList<Link> links { get; set; }
        }

}
