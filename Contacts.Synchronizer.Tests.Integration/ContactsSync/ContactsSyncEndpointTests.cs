using Contacts.DTOs;
using FluentAssertions;
using System.Net;
using System.Text.Json;

namespace Contacts.Synchronizer.Tests.Integration.ContactsSync;
public class ContactsSyncEndpointTests : IClassFixture<ContactsFactory>
{
    private readonly ContactsFactory _factory;
    private HttpClient _client;

    public ContactsSyncEndpointTests(ContactsFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task SyncContactsAsync_WhenCalled_ReturnsSyncedContactsResponse()
    {
        var response = await _client.GetAsync("/contacts/sync");

        var result = JsonSerializer.Deserialize<SyncedContactsResponse>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Should().NotBeNull();
        result.SyncedContacts.Should().Be(24);
        result.Contacts.Should().NotBeEmpty();
    }
}
