using Contacts.Models;
using Refit;

namespace Contacts.Proxies;

public interface IMockApiClient
{
    [Get("/api/v1/contacts")]
    Task<IReadOnlyCollection<Contact>> GetContactsAsync();
}
