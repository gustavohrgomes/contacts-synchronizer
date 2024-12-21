using System.Text.Json.Serialization;

namespace Contacts.Models;
public class AddMembersToListRequest
{
    [JsonPropertyName("members")]
    public IEnumerable<MemberModel> Members { get; set; } = [];

    [JsonPropertyName("sync_tags")]
    public bool SyncTags { get; set; }

    [JsonPropertyName("update_existing")]
    public bool UpdateExisting { get; set; }
}
