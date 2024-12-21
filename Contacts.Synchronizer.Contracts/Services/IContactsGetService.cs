using Contacts.DTOs;
using Refit;

namespace Contacts.Services;

public interface IContactsGetService
{
    [Get("/api/v1/contacts")]
    Task<IReadOnlyCollection<ContactDTO>> GetContactsAsync(CancellationToken cancellationToken = default!);
}
