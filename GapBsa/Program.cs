using Gap.Plugins.DataStore.InMemory;
using Gap.UseCases.CountriesUseCases;
using Gap.UseCases.DataStorePluginInterfaces;
using GapBsa.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Gap.UseCases.UseCaseInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Dependency Injection for In-Memory Data Story
builder.Services.AddScoped<ICountryRepository, CountryInMemoryRepository>();

// DI for Use Case and Repository
builder.Services.AddTransient<IViewCountriesUseCase, ViewCountriesUseCase>();

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
