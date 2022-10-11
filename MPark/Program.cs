using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MPark;
using MPark.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IMParkMachinesService, MParkMachinesService>(client => client.BaseAddress = new Uri(APIClientSettings.BaseAddressURI));

await builder.Build().RunAsync();
