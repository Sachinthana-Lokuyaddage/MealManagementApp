using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using MealManagementApp.Client.Services;
using Microsoft.EntityFrameworkCore;
using MealManagementApp.Components;
using MealManagementApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClientFactory (Blazor Server requires it)
builder.Services.AddHttpClient<EmployeeMealService>();

// Register EmployeeMealService
builder.Services.AddScoped<EmployeeMealService>();

// Register DbContext
builder.Services.AddDbContext<MealDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MealDbContext"));
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MealManagementApp.Client._Imports).Assembly);

app.Run();
