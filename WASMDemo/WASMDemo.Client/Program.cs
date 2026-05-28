using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WASMDemo.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// In WASM, if pre-rendering turned on, it rendered in server side first than in Browser side.
builder.Services.AddSingleton<ContainerStorage>();

await builder.Build().RunAsync();
