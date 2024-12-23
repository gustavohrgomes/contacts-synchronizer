using Contacts.Adapters.SyncContacts;
using Contacts.ExceptionHandlers;
using Contacts.Features.Sync;
using Contacts.Proxies;
using Contacts.Services;
using Microsoft.AspNetCore.Http.Json;
using OpenTelemetry.Metrics;
using Refit;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

#region Json Options
builder.Services.Configure<JsonOptions>(opt =>
{
    opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
#endregion

// Add services to the container.
#region Global Error Handling
builder.Services
    .AddExceptionHandler<LogExceptionHandler>()
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddProblemDetails();
#endregion

#region Output Cache
builder.Services.AddOutputCache(options => options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(60))));
#endregion

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
#region OpenAPI/Swagger Config
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Register services
builder.Services
    .AddScoped<IContactsSyncService, ContactsSyncService>()
    .AddScoped<IContactsSynchronizer, MailchimpContactsSynchronizer>();
#endregion

#region HttpClient
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
#endregion

builder.Services.AddServiceLogEnricher();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapOpenApi();

app.UseHttpsRedirection();

app.MapContactsSyncEndpoint();

app.UseExceptionHandler();

app.UseOutputCache();

app.Run();
