using Contacts.DTOs;

namespace Contacts.Adapters.SyncContacts;
public interface IContactsSynchronizer
{
    Task SynchronizeAsync(SyncContactsCommand command, CancellationToken cancellationToken);
}
