using Contacts.Adapters.SyncContacts;
using Contacts.DTOs;
using Microsoft.Extensions.Logging;

namespace Contacts.Services;

public class ContactsSyncService(IContactsGetService contactsService, IContactsSynchronizer contactsSynchronizer, ILogger<ContactsSyncService> logger) : IContactsSyncService
{
    public async Task<SyncedContactsResponse> SyncContactsAsync(CancellationToken cancellationToken = default)
    {
        var contacts = await contactsService.GetContactsAsync(cancellationToken);

        if (contacts is { Count: 0})
        {
            return new SyncedContactsResponse(0, []);
        }

        await contactsSynchronizer.SynchronizeAsync(new SyncContactsCommand("Gustavo Gomes", contacts), cancellationToken).ConfigureAwait(false);

        return new SyncedContactsResponse(contacts.Count, [.. contacts.Select(c => new ContactResponse(c.FirstName, c.LastName, c.Email))]);
    }
}