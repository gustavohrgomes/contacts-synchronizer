using Contacts.Adapters.SyncContacts;
using Contacts.DTOs;
using Contacts.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Contacts.Synchronizer.Tests.Unit;

public class ContactsSyncServiceTests
{
    private readonly IContactsGetService _contactsServiceMock;
    private readonly IContactsSynchronizer _contactsSynchronizerMock;
    private readonly ILogger<ContactsSyncService> _loggerMock;
    private readonly ContactsSyncService _contactsSyncService;

    public ContactsSyncServiceTests()
    {
        _contactsServiceMock = Substitute.For<IContactsGetService>();
        _contactsSynchronizerMock = Substitute.For<IContactsSynchronizer>();
        _loggerMock = Substitute.For<ILogger<ContactsSyncService>>();
        _contactsSyncService = new ContactsSyncService(_contactsServiceMock, _contactsSynchronizerMock, _loggerMock);
    }

    [Fact]
    public async Task SyncContactsAsync_ShouldReturnEmptyResponse_WhenNoContactsToSync()
    {
        // Arrange
        _contactsServiceMock.GetContactsAsync(Arg.Any<CancellationToken>())
            .Returns(new List<ContactDTO>());

        // Act
        var result = await _contactsSyncService.SyncContactsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Contacts.Should().BeEmpty();
        result.SyncedContacts.Should().Be(0);
    }

    [Fact]
    public async Task SyncContactsAsync_ShouldSynchronizeContacts_WhenContactsAreAvailable()
    {
        // Arrange
        var contacts = new List<ContactDTO>
        {
            new() { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new() { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
        };

        _contactsServiceMock.GetContactsAsync(Arg.Any<CancellationToken>())
            .Returns(contacts);

        // Act
        var result = await _contactsSyncService.SyncContactsAsync();

        // Assert
        result.Should().NotBeNull();
        result.SyncedContacts.Should().Be(2);
        result.Contacts.Should().HaveCount(contacts.Count);
        //await _contactsSynchronizerMock.Received(1).SynchronizeAsync(Arg.Any<SyncContactsCommand>(), Arg.Any<CancellationToken>());
    }
}
