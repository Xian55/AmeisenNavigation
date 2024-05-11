using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AmeisenNavigation.Tester
{
    internal sealed class RemotePathingAPI : IDisposable
    {
        private readonly string host = "127.0.0.1";
        private readonly int port = 5001;

        public readonly JsonSerializerOptions options;

        public readonly HttpClient client;

        public RemotePathingAPI()
        {
            options = new()
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new Vector3Converter());

            string url = $"http://{host}:{port}/api/PPather/";

            client = new()
            {
                BaseAddress = new Uri(url)
            };
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task DrawWorldPath(DrawWorldPathRequest request)
        {
            StringContent content =
                new(JsonSerializer.Serialize(request, options),
                Encoding.UTF8, "application/json");

            await client.PostAsync(RemotePathing.EndpointPath, content);
        }
    }
}
