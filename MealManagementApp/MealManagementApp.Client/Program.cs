using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MealManagementApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//  Register HttpClient (WASM uses browser's HTTP client)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//  Register EmployeeMealService
builder.Services.AddScoped<EmployeeMealService>();

await builder.Build().RunAsync();
