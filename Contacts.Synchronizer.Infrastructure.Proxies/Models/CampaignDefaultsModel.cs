using System.Text.Json.Serialization;

namespace Contacts.Models;

public class CampaignDefaultsModel
{
    [JsonPropertyName("from_name")]
    public string FromName { get; set; } = default!;

    [JsonPropertyName("from_email")]
    public string FromEmail { get; set; } = default!;

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = default!;

    [JsonPropertyName("language")]
    public string Language { get; set; } = default!;
}
