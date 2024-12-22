using Contacts.DTOs;

namespace Contacts.Services;
public interface IContactsSyncService
{
    Task<SyncedContactsResponse> SyncContactsAsync(CancellationToken cancellationToken = default);
}
