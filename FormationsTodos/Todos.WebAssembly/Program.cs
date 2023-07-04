using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Todos.ApiClient.DI;
using Todos.WebAssembly;
using static System.Net.WebRequestMethods;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

var http = new HttpClient()
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};
builder.Services.AddScoped(sp => http);

using var response = await http.GetAsync("appsettings.json");
using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);
builder.RootComponents.Add<HeadOutlet>("head::after");
Console.WriteLine(builder.HostEnvironment.BaseAddress);
builder.Services.AddTodosApiClient(builder.Configuration["UrlApi"]);
await builder.Build().RunAsync();
