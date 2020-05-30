using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using VoteMelhor.WebApi.Raws;

namespace VoteMelhor.WebApi.Services
{
    public class HouseRepresentativesService
    {
        public async Task<Congressman_Raw> GetListCongressmen()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using var response = await httpClient.GetAsync("https://dadosabertos.camara.leg.br/api/v2/deputados");
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(apiResponse);

                    string jsonString = JsonConvert.SerializeXmlNode(doc);

                    // Site para gerar a class do objeto: jsonutils.com
                    Congressman_Raw jsonNet = JsonConvert.DeserializeObject<Congressman_Raw>(jsonString);

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
