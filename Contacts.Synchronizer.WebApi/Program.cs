using Contacts.Features.Sync;
using Contacts.Proxies;
using Contacts.Services;
using Refit;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContactsSyncService, ContactsSyncService>();

builder.Services
    .AddRefitClient<IMockApiClient>()
    .ConfigureHttpClient(config => config.BaseAddress = new Uri("https://challenge.trio.dev"));

builder.Services
    .AddHttpClient<MailchimpClient>(config =>
    {
        config.BaseAddress = new Uri("https://us14.api.mailchimp.com/3.0/");
        config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "a2V5OjI5N2U0MDVmM2FjZmZkZGVkMjMwNzA1YzcyOGZlMjExLXVzMTQ=");
    })
    .AddStandardResilienceHandler();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();

app.UseHttpsRedirection();

app.MapContactsSyncEndpoint();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
