using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Net
{
    public class WebClient
    {
        private static HttpClient client = new HttpClient(); // you should reuse a HttpClient!

        public async Task<string> DownloadStringAsync(string url)
        {
            using (var response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                throw new WebException($"Error {response.StatusCode}", WebExceptionStatus.SendFailure);

            }
        }
    }
}
