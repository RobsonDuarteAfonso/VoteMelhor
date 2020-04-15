using Newtonsoft.Json;
using System.Collections.Generic;

namespace VoteMelhor.WebApi.Raws
{
    public class Xml
    {

        [JsonProperty("@version")]
        public string @version { get; set; }

        [JsonProperty("@encoding")]
        public string @encoding { get; set; }
    }

    public class Metadados
    {

        [JsonProperty("Versao")]
        public string Versao { get; set; }

        [JsonProperty("VersaoServico")]
        public string VersaoServico { get; set; }

        [JsonProperty("DescricaoDataSet")]
        public string DescricaoDataSet { get; set; }
    }

    public class Telefones
    {

        [JsonProperty("Telefone")]
        public object Telefone { get; set; }
    }

    public class IdentificacaoParlamentar
    {

        [JsonProperty("CodigoParlamentar")]
        public string CodigoParlamentar { get; set; }

        [JsonProperty("CodigoPublicoNaLegAtual")]
        public string CodigoPublicoNaLegAtual { get; set; }

        [JsonProperty("NomeParlamentar")]
        public string NomeParlamentar { get; set; }

        [JsonProperty("NomeCompletoParlamentar")]
        public string NomeCompletoParlamentar { get; set; }

        [JsonProperty("SexoParlamentar")]
        public string SexoParlamentar { get; set; }

        [JsonProperty("FormaTratamento")]
        public string FormaTratamento { get; set; }

        [JsonProperty("UrlFotoParlamentar")]
        public string UrlFotoParlamentar { get; set; }

        [JsonProperty("UrlPaginaParlamentar")]
        public string UrlPaginaParlamentar { get; set; }

        [JsonProperty("EmailParlamentar")]
        public string EmailParlamentar { get; set; }

        [JsonProperty("Telefones")]
        public Telefones Telefones { get; set; }

        [JsonProperty("SiglaPartidoParlamentar")]
        public string SiglaPartidoParlamentar { get; set; }

        [JsonProperty("UfParlamentar")]
        public string UfParlamentar { get; set; }
    }

    public class PrimeiraLegislaturaDoMandato
    {

        [JsonProperty("NumeroLegislatura")]
        public string NumeroLegislatura { get; set; }

        [JsonProperty("DataInicio")]
        public string DataInicio { get; set; }

        [JsonProperty("DataFim")]
        public string DataFim { get; set; }
    }

    public class SegundaLegislaturaDoMandato
    {

        [JsonProperty("NumeroLegislatura")]
        public string NumeroLegislatura { get; set; }

        [JsonProperty("DataInicio")]
        public string DataInicio { get; set; }

        [JsonProperty("DataFim")]
        public string DataFim { get; set; }
    }

    public class Suplentes
    {

        [JsonProperty("Suplente")]
        public object Suplente { get; set; }
    }

    public class Exercicios
    {

        [JsonProperty("Exercicio")]
        public object Exercicio { get; set; }
    }

    public class Titular
    {

        [JsonProperty("DescricaoParticipacao")]
        public string DescricaoParticipacao { get; set; }

        [JsonProperty("CodigoParlamentar")]
        public string CodigoParlamentar { get; set; }

        [JsonProperty("NomeParlamentar")]
        public string NomeParlamentar { get; set; }
    }

    public class Mandato
    {

        [JsonProperty("CodigoMandato")]
        public string CodigoMandato { get; set; }

        [JsonProperty("UfParlamentar")]
        public string UfParlamentar { get; set; }

        [JsonProperty("PrimeiraLegislaturaDoMandato")]
        public PrimeiraLegislaturaDoMandato PrimeiraLegislaturaDoMandato { get; set; }

        [JsonProperty("SegundaLegislaturaDoMandato")]
        public SegundaLegislaturaDoMandato SegundaLegislaturaDoMandato { get; set; }

        [JsonProperty("DescricaoParticipacao")]
        public string DescricaoParticipacao { get; set; }

        [JsonProperty("Suplentes")]
        public Suplentes Suplentes { get; set; }

        [JsonProperty("Exercicios")]
        public Exercicios Exercicios { get; set; }

        [JsonProperty("Titular")]
        public Titular Titular { get; set; }
    }

    public class Parlamentar
    {

        [JsonProperty("IdentificacaoParlamentar")]
        public IdentificacaoParlamentar IdentificacaoParlamentar { get; set; }

        [JsonProperty("Mandato")]
        public Mandato Mandato { get; set; }

        [JsonProperty("UrlGlossario")]
        public string UrlGlossario { get; set; }
    }

    public class Parlamentares
    {

        [JsonProperty("Parlamentar")]
        public IList<Parlamentar> Parlamentar { get; set; }
    }

    public class ListaParlamentarEmExercicio
    {

        [JsonProperty("@xmlns:xsi")]
        public string Xmlns { get; set; }

        [JsonProperty("@xsi:noNamespaceSchemaLocation")]
        public string NoNamespaceSchemaLocation { get; set; }

        [JsonProperty("Metadados")]
        public Metadados Metadados { get; set; }

        [JsonProperty("Parlamentares")]
        public Parlamentares Parlamentares { get; set; }
    }

    public class PoliticosSenadores_Raw
    {

        [JsonProperty("?xml")]
        public Xml Xml { get; set; }

        [JsonProperty("ListaParlamentarEmExercicio")]
        public ListaParlamentarEmExercicio ListaParlamentarEmExercicio { get; set; }
    }


}
