using Contacts.Adapters.SyncContacts;
using Contacts.DTOs;

namespace Contacts.Services;

public class ContactsSyncService(IContactsGetService contactsService, IContactsSynchronizer contactsSynchronizer) : IContactsSyncService
{
    public async Task<SyncedContactsResponse> SyncContactsAsync(CancellationToken cancellationToken = default)
    {
        var contacts = await contactsService.GetContactsAsync(cancellationToken);

        if (contacts is { Count: 0})
        {
            return new SyncedContactsResponse(0, Array.Empty<ContactResponse>());
        }

        await contactsSynchronizer.SynchronizeAsync(new SyncContactsCommand("Gustavo Gomes", contacts), cancellationToken).ConfigureAwait(false);

        return new SyncedContactsResponse(contacts.Count, [.. contacts.Select(c => new ContactResponse(c.FirstName, c.LastName, c.Email))]);
    }
}