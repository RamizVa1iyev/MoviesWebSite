using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient client,string url)
        {
            var response = await client.GetAsync(url);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
            return result;
        }

        public static async Task<TReponse> PutJsonAsync<TReponse, TRequest>(this HttpClient httpClient, string url,TRequest entity)
        {
            var uri = new Uri(url);
            var strinEntity = JsonConvert.SerializeObject(entity);
            var content = new StringContent(strinEntity, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = uri,
                Content=content
            };
            var response = await httpClient.SendAsync(request);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReponse>(resultString);
            return result;
        }
        public static async Task<TReponse> PostJsonAsync<TReponse, TRequest>(this HttpClient httpClient, string url, TRequest entity)
        {
            var uri = new Uri(url);
            var strinEntity = JsonConvert.SerializeObject(entity);
            var content = new StringContent(strinEntity, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Content = content
            };
            var response = await httpClient.SendAsync(request);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReponse>(resultString);
            return result;
        }
        public static async Task<T> DeleteJsonAsync<T>(this HttpClient client, string url)
        {
            var response = await client.DeleteAsync(url);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
            return result;
        }
    }
}
