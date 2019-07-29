

namespace ProyectRefit.service
{
    using Newtonsoft.Json;
    using ProyectRefit.Models;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpService
    {

        public async Task<Response>PostAsync<T>(string baseUrl, string modul, T model)
        {
            try
            {
                var requestString = JsonConvert.SerializeObject(model);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
                var response = await client.PostAsync(modul,content);
                var answer= await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer
                    };
                }
                var productResult = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    IsSuccess = true,
                    Result = productResult
                };
            }
            catch (Exception ex) {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
