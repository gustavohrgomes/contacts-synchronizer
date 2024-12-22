using Contacts.Adapters.SyncContacts;
using Contacts.Features.Sync;
using Contacts.Proxies;
using Contacts.Services;
using Microsoft.AspNetCore.Http.Json;
using Refit;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.Configure<JsonOptions>(opt =>
{
    opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddOutputCache(options => options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(60))));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddRefitClient<IContactsGetService>()
    .ConfigureHttpClient(config => config.BaseAddress = new Uri("https://challenge.trio.dev"));

builder.Services
    .AddHttpClient<MailchimpClient>(config =>
    {
        config.BaseAddress = new Uri("https://us14.api.mailchimp.com/3.0/");
        config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "a2V5OjI5N2U0MDVmM2FjZmZkZGVkMjMwNzA1YzcyOGZlMjExLXVzMTQ=");
    })
    .AddStandardResilienceHandler();

builder.Services
    .AddScoped<IContactsSyncService, ContactsSyncService>()
    .AddScoped<IContactsSynchronizer, MailchimpContactsSynchronizer>();

builder.Services.AddServiceLogEnricher();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();

app.UseHttpsRedirection();

app.MapContactsSyncEndpoint();

app.UseOutputCache();

app.Run();
