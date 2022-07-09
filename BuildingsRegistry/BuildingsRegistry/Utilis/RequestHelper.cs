using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuildingsRegistry.Utilis
{
    public static class RequestHelper
    {
        public static async Task<T> GetRequest<T>(string url)
        {
            var response = await new HttpClient().GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var contentStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(contentStream);
        }

        public static async Task PostRequest(string url, dynamic data)
        {            
            var json = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync(url, stringContent);
        }
    }
}