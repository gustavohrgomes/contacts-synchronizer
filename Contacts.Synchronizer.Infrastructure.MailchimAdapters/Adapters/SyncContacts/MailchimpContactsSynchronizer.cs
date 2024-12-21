using Contacts.Models;
using Contacts.Proxies;

namespace Contacts.Adapters.SyncContacts;

public class MailchimpContactsSynchronizer(MailchimpClient mailchimpClient) : IContactsSynchronizer
{
    public async Task SynchronizeAsync(SyncContactsCommand command, CancellationToken cancellationToken)
    {
        var audienceId = await mailchimpClient.CreateListAsync(CreateAudienceRequestModel(command.EventName), cancellationToken);

        var contactsToSync = command.Contacts.Select(c => new MemberModel
        {
            EmailType = EmailType.Html,
            EmailAddress = c.Email,
            Status = MemberStatus.Subscribed,
        })
        .ToList();

        var request = new AddMembersToListRequest
        {
            Members = contactsToSync
        };

        await mailchimpClient.AddMembersToListAsync(audienceId, request, cancellationToken);
    }

    private static CreateAudienceRequestModel CreateAudienceRequestModel(string eventName)
    {
        return new CreateAudienceRequestModel
        {
            Name = eventName,
            PermissionReminder = "permission_reminder",
            CampaignDefaults = new CampaignDefaultsModel
            {
                FromName = "Trio",
                FromEmail = "trio-backendchallenge@gmail.com",
                Subject = "Backend Challenge",
                Language = "EN_US"
            },
            Contact = new ContactModel
            {
                Company = "Trio",
                Address1 = "1234 Trio St",
                City = "Trio",
                State = "Trio",
                Zip = "12345",
                Country = "US"
            },
            EmailTypeOptions = true
        };
    }
}
