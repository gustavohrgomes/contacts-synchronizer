using System.Text.Json.Serialization;

namespace Contacts.Models;

public class MemberModel()
{
    [JsonPropertyName("email_address")]
    public string EmailAddress { get; set; } = default!;

    [JsonPropertyName("email_type")]
    public string EmailType { get; set; } = default!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;
}
