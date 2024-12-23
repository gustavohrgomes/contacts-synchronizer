using Contacts.Proxies;
using Contacts.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Refit;

namespace Contacts.Synchronizer.Tests.Integration;
public class ContactsFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MockApiServer _mockApiServer = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(logging => logging.ClearProviders());

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IMailchimpClient));

            services.AddHttpClient<IMailchimpClient, MailchimpClient>(client =>
            {
                client.BaseAddress = new Uri(_mockApiServer.Url);
            });

            services.AddRefitClient<IContactsGetService>()
                .ConfigureHttpClient(config => config.BaseAddress = new Uri(_mockApiServer.Url));
        });
    }

    public Task InitializeAsync()
    {
        _mockApiServer.Start();
        _mockApiServer.GetContacts();
        _mockApiServer.CreateList();
        _mockApiServer.AddMembersToList();
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _mockApiServer.Dispose();
        return Task.CompletedTask;
    }
}
