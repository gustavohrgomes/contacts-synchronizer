using Contacts.DTOs;

namespace Contacts.Services;
public interface IContactsSyncService
{
    Task<SyncedContactsDTO> SyncContactsAsync(CancellationToken cancellationToken = default);
}
