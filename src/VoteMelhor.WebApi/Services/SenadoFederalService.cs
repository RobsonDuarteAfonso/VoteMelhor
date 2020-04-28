using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using VoteMelhor.WebApi.Raws;

namespace VoteMelhor.WebApi.Services
{
    public class SenadoFederalService
    {
        public async Task<PoliticosSenadores_Raw> GetListaSenadores()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using var response = await httpClient.GetAsync("http://legis.senado.leg.br/dadosabertos/senador/lista/atual");
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(apiResponse);

                    string jsonString = JsonConvert.SerializeXmlNode(doc);

                    // Site para gerar a class do objeto: jsonutils.com
                    PoliticosSenadores_Raw jsonNet = JsonConvert.DeserializeObject<PoliticosSenadores_Raw>(jsonString);

                    return jsonNet;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
