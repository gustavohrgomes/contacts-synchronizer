using Contacts.Models;

namespace Contacts.Proxies;

public interface IMailchimpClient
{
    Task AddMembersToListAsync(string listId, AddMembersToListRequest request, CancellationToken cancellationToken);
    Task<string> CreateListAsync(CreateAudienceRequestModel request, CancellationToken cancellationToken);
}