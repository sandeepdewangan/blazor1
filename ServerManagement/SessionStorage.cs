using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServerManagement.Models;

namespace ServerManagement
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage protectedSessionStorage;

        public SessionStorage(ProtectedSessionStorage protectedSessionStorage)
        {
            this.protectedSessionStorage = protectedSessionStorage;
        }

        public async Task<Server?> GetServerAsync()
        {
            var res = await this.protectedSessionStorage.GetAsync<Server>("server");
            if (res.Success)

                return res.Value;
            else
                return null;
        }

        public async Task SetServerAsync(Server? server)
        {
            await this.protectedSessionStorage.SetAsync("server", server);
        }
    }
}
