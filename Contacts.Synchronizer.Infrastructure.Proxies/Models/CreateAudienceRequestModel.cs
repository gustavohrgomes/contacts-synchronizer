using System.Text.Json.Serialization;

namespace Contacts.Models;

public class CreateAudienceRequestModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("contact")]
    public ContactModel Contact { get; set; } = default!;

    [JsonPropertyName("permission_reminder")]
    public string PermissionReminder { get; set; } = default!;

    [JsonPropertyName("email_type_option")]
    public bool EmailTypeOptions { get; set; }

    [JsonPropertyName("campaign_defaults")]
    public CampaignDefaultsModel CampaignDefaults { get; set; } = default!;
}
