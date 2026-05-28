using Newtonsoft.Json;
using System.Text;

namespace ServerManagementWASM.Client.Models
{
    public class ServerAPIRepository : IServerAPIRepository
    {
        private const string apiName = "ServersAPI"; // as declared in Program.cs
        public readonly IHttpClientFactory httpClientFactory;
        public ServerAPIRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Server?> GetServersByIdAsync(int serverId)
        {
            var client = this.httpClientFactory.CreateClient(apiName);
            var response = await client.GetAsync($"servers/{serverId}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Server>(content);
        }

        public async Task<List<Server>> GetServersAsync()
        {
            var client = this.httpClientFactory.CreateClient(apiName);
            var response = await client.GetAsync("servers.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content) && content != null) // for firebase
            {
                // Newtonsoft.Json to serialize string to C# object.
                return JsonConvert.DeserializeObject<List<Server>>(content) ?? new List<Server>();
            }
            return new List<Server>();
        }

        public async Task AddServerAsync(Server server)
        {
            server.ServerId = await GetNextServerIdAsync();
            var client = this.httpClientFactory.CreateClient(apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");
            // We have used put bez of firestore, custom id.
            var response = await client.PutAsync($"servers/{server.ServerId}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServerAsync(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;
            var client = this.httpClientFactory.CreateClient(apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"servers/{server.ServerId}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServerAsync(int serverId)
        {
            var client = this.httpClientFactory.CreateClient(apiName);
            await client.DeleteAsync($"servers/{serverId}.json");
        }

        private async Task<int> GetNextServerIdAsync()
        {
            var servers = await GetServersAsync();
            if (servers is not null && servers.Any())
                return servers.Where(x => x is not null).Max(x => x.ServerId) + 1;
            return 1;
        }

    }
}
