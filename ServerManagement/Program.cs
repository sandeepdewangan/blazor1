using ServerManagement;
using ServerManagement.Components;
using ServerManagement.ObserverState;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Inject the SessionStorage
builder.Services.AddTransient<SessionStorage>();
builder.Services.AddScoped<ContainerStorage>();
builder.Services.AddScoped<RaipurOnlineServerStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Middlware through when something not found by the server, Static Routing
// This will not called NotFound page returned by the router. 
// Comment it out, to display Not Found Page, as defined by us in NotFound.razor page.
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
// Enable server side interaction along with dependencies.
// builder.Services.AddRazorComponents().AddInteractiveServerComponents();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
