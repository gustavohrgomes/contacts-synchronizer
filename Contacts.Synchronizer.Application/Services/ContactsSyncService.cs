using Contacts.Adapters.SyncContacts;
using Contacts.DTOs;

namespace Contacts.Services;

public class ContactsSyncService(IContactsGetService contactsService, IContactsSynchronizer contactsSynchronizer) : IContactsSyncService
{
    public async Task<SyncedContactsDTO> SyncContactsAsync(CancellationToken cancellationToken = default)
    {
        var contacts = await contactsService.GetContactsAsync(cancellationToken);

        await contactsSynchronizer.SynchronizeAsync(new SyncContactsCommand("Gustavo Gomes", contacts), cancellationToken).ConfigureAwait(false);

        return new SyncedContactsDTO(contacts.Count, [.. contacts.Select(c => new ContactDTO 
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email
        })]);
    }
}