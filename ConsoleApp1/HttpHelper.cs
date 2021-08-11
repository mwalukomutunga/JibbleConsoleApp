using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JibbleConsoleClient
{
    public static class HttpHelper       
    {
        private static readonly HttpClient client = new HttpClient();
        public async static Task<T> ProcessGetRequest<T>(string header, string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(header));
            var response = await client.GetAsync(url);            
            var newObject = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()):default;
            return newObject;
        }

    }
}
