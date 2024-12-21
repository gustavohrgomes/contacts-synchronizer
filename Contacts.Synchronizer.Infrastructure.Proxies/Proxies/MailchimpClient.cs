using Contacts.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Contacts.Proxies;

public class MailchimpClient(HttpClient client)
{
    public async Task<string> CreateListAsync(CreateAudienceRequestModel request, CancellationToken cancellationToken)
    {
        var response = await client.PostAsJsonAsync("lists", request, cancellationToken);
        
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        var result = JsonSerializer.Deserialize<CreateAudienceResponseModel>(content);

        return result?.Id ?? string.Empty;
    }

    public async Task AddMembersToListAsync(string listId, AddMembersToListRequest request, CancellationToken cancellationToken)
    {
        var response = await client.PostAsJsonAsync($"lists/{listId}", request, cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}
