using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Stroyzaschita.UI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(serviceProvider => 
    new HttpClient { 
        BaseAddress = new Uri("http://localhost:5123") 
    }
);
builder.Services.AddMudServices();

await builder.Build().RunAsync();
