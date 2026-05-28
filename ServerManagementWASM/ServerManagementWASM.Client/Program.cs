using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServerManagementWASM.Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


// We have to copy this below servcies to main project also,  bez of pre-rendering.
// Microsoft.Extensions.Http
builder.Services.AddHttpClient("ServersAPI", client =>
{
    client.BaseAddress = new Uri("https://wasm-demo-98f86-default-rtdb.asia-southeast1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddTransient<IServerAPIRepository, ServerAPIRepository>();

await builder.Build().RunAsync();
