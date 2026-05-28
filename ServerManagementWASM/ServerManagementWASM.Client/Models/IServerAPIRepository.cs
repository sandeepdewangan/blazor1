namespace ServerManagementWASM.Client.Models
{
    public interface IServerAPIRepository
    {
        Task AddServerAsync(Server server);
        Task DeleteServerAsync(int serverId);
        Task<List<Server>> GetServersAsync();
        Task<Server?> GetServersByIdAsync(int serverId);
        Task UpdateServerAsync(int serverId, Server server);
    }
}