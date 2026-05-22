namespace ServerManagement.Models
{
    public class ServerRepo
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server { ServerId = 1, Name = "NIC Raipur", City = "Raipur" },
            new Server { ServerId = 2, Name = "CG Data Hub", City = "Bilaspur" },
            new Server { ServerId = 3, Name = "Bastar NetCore", City = "Raipur" },
            new Server { ServerId = 4, Name = "Durg Digital Node", City = "Kanker" },
            new Server { ServerId = 5, Name = "Korba Cloud Center", City = "Bilaspur" },
            new Server { ServerId = 6, Name = "Raigarh Sync Server", City = "Bilaspur" },
            new Server { ServerId = 7, Name = "Ambikapur Tech Hub", City = "Kanker" },
            new Server { ServerId = 8, Name = "Rajnandgaon Grid", City = "Raipur" },
            new Server { ServerId = 9, Name = "Kanker Connect", City = "Kanker" },
            new Server { ServerId = 10, Name = "Dhamtari Infra", City = "Dhamtari" },
            new Server { ServerId = 11, Name = "Mahasamund Core", City = "Dhamtari" },
            new Server { ServerId = 12, Name = "Balod Compute", City = "Balod" },
            new Server { ServerId = 13, Name = "Janjgir DataPoint", City = "Surguja" },
            new Server { ServerId = 14, Name = "Kawardha HostNet", City = "Dhamtari" },
            new Server { ServerId = 15, Name = "Surguja ServerWorks", City = "Surguja" },
        };


        public void AddServer(Server server)
        {
            var maxServerId = servers.Max(x => x.ServerId);
            server.ServerId = maxServerId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string city)
        {
            return servers.Where(s => s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int Id)
        {
            Server? server = servers.FirstOrDefault(s => s.ServerId == Id);
            if (server != null)
            {
                return server;
            }
            return null;
        }

        public void UpdateServer(int serverId, Server server)
        {
            if (serverId == server.ServerId) return;
            var serverToUpdate = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }
        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}