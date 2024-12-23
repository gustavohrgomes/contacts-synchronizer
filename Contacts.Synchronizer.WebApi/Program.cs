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
    .AddScoped<IContactsSyncService, ContactsSyncService>()
    .AddScoped<IContactsSynchronizer, MailchimpContactsSynchronizer>();

var mockApiAddress = builder.Configuration.GetValue<string>("ApplicationSettings:MockAPIAddress")!;
var mailMarketingAddress = builder.Configuration.GetValue<string>("ApplicationSettings:MailMarketingAddress")!;
var mailMarketingAuthType = builder.Configuration.GetValue<string>("ApplicationSettings:MailMarketingAuthType")!;
var mailMarketingAPIKey = builder.Configuration.GetValue<string>("ApplicationSettings:MailMarketingAPIKey")!;

builder.Services
    .AddRefitClient<IContactsGetService>()
    .ConfigureHttpClient(config => config.BaseAddress = new Uri(mockApiAddress));

builder.Services
    .AddHttpClient<MailchimpClient>(config =>
    {
        config.BaseAddress = new Uri(mailMarketingAddress);
        config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(mailMarketingAuthType, mailMarketingAPIKey);
    })
    .AddStandardResilienceHandler();

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
