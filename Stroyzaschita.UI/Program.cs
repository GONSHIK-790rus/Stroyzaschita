using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Stroyzaschita.UI;
using Stroyzaschita.UI.Contexts;
using Stroyzaschita.UI.Interfaces;
using Stroyzaschita.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TokenStorage>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<AuthContext>();

builder.Services.AddScoped(serviceProvider => 
    new HttpClient { 
        BaseAddress = new Uri("http://localhost:5123") 
    }
);
builder.Services.AddMudServices();

await builder.Build().RunAsync();
