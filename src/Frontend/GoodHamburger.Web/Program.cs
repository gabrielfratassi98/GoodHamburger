using GoodHamburger.Web;
using GoodHamburger.Web.Configurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.HttpExtensions();

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
