using Contacts.DTOs;
using Contacts.Models;
using Contacts.Proxies;
using Contacts.Services;

namespace Contacts.Features.Sync;

public class ContactsSyncService(IMockApiClient mockApiClient, MailchimpClient mailchimpClient) : IContactsSyncService
{
    public async Task<SyncedContactsDTO> SyncContactsAsync(CancellationToken cancellationToken = default)
    {
        var contacts = await mockApiClient.GetContactsAsync();

        // Mailchimp logic goes here. I should Write an adapter for this.
        var audienceId = await mailchimpClient.CreateListAsync(CreateAudienceRequestModel("Backend Challenge"), cancellationToken);

        var contactsToSync = contacts.Select(c => new MemberModel
        {
            EmailType = EmailType.Html,
            EmailAddress = c.Email,
            Status = MemberStatus.Subscribed,
        });

        var request = new AddMembersToListRequest
        {
            Members = [.. contactsToSync]
        };

        await mailchimpClient.AddMembersToListAsync(audienceId, request, cancellationToken);

        return new SyncedContactsDTO(contacts.Count, [.. contacts.Select(c => new ContactDTO(c.FirstName, c.LastName, c.Email))]);
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