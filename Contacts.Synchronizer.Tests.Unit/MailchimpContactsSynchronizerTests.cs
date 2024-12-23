using System.Threading;
using System.Threading.Tasks;
using Contacts.Adapters.SyncContacts;
using Contacts.DTOs;
using Contacts.Models;
using Contacts.Proxies;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Contacts.Synchronizer.Tests.Unit;

public class MailchimpContactsSynchronizerTests
{
    private readonly IMailchimpClient _mailchimpClient;
    private readonly MailchimpContactsSynchronizer _synchronizer;

    public MailchimpContactsSynchronizerTests()
    {
        _mailchimpClient = Substitute.For<IMailchimpClient>();
        _synchronizer = new MailchimpContactsSynchronizer(_mailchimpClient);
    }

    [Fact]
    public async Task SynchronizeAsync_ShouldCreateListAndAddMembers()
    {
        // Arrange
        var command = new SyncContactsCommand
        (
            "Test Event",
            [
                new ContactDTO { Email = "test1@example.com" },
                new ContactDTO { Email = "test2@example.com" }
            ]
        );

        var cancellationToken = CancellationToken.None;
        var audienceId = "test-audience-id";

        _mailchimpClient.CreateListAsync(Arg.Any<CreateAudienceRequestModel>(), cancellationToken)
            .Returns(Task.FromResult(audienceId));

        // Act
        await _synchronizer.SynchronizeAsync(command, cancellationToken);

        // Assert
        await _mailchimpClient.Received(1).CreateListAsync(Arg.Is<CreateAudienceRequestModel>(x => x.Name == command.EventName), cancellationToken);
        await _mailchimpClient.Received(1).AddMembersToListAsync(audienceId, Arg.Is<AddMembersToListRequest>(x => x.Members.Count() == 2), cancellationToken);
    }
}
