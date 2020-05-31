using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
                    //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    using var response = await httpClient.GetAsync("https://dadosabertos.camara.leg.br/api/v2/deputados");

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    // Site para gerar a class do objeto: jsonutils.com
                    Congressman_Raw jsonNet = JsonConvert.DeserializeObject<Congressman_Raw>(apiResponse);

                    return jsonNet;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<string> GetDetailsCongressman(int id)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using var response = await httpClient.GetAsync($"https://dadosabertos.camara.leg.br/api/v2/deputados/{id}");

                    string apiResponse = await response.Content.ReadAsStringAsync();

                    // Site para gerar a class do objeto: jsonutils.com
                    CongressmanDetails_Raw jsonNet = JsonConvert.DeserializeObject<CongressmanDetails_Raw>(apiResponse);

                    return jsonNet.dados.nomeCivil;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }        
    }
}
