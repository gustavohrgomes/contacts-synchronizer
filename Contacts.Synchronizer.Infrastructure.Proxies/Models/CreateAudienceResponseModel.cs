using System.Text.Json.Serialization;

namespace Contacts.Models;

public class CreateAudienceResponseModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("web_id")]
    public int WebId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("contact")]
    public Contact Contact { get; set; } = default!;

    [JsonPropertyName("permission_reminder")]
    public string PermissionReminder { get; set; } = default!;

    [JsonPropertyName("use_archive_bar")]
    public bool UseArchiveBar { get; set; }

    [JsonPropertyName("campaign_defaults")]
    public CampaignDefaultsModel CampaignDefaults { get; set; } = default!;

    [JsonPropertyName("notify_on_subscribe")]
    public string NotifyOnSubscribe { get; set; } = default!;

    [JsonPropertyName("notify_on_unsubscribe")]
    public string NotifyOnUnsubscribe { get; set; } = default!;

    [JsonPropertyName("date_created")]
    public DateTime DateCreated { get; set; }

    [JsonPropertyName("list_rating")]
    public int ListRating { get; set; }

    [JsonPropertyName("email_type_option")]
    public bool EmailTypeOption { get; set; }

    [JsonPropertyName("subscribe_url_short")]
    public string SubscribeUrlShort { get; set; } = default!;

    [JsonPropertyName("subscribe_url_long")]
    public string SubscribeUrlLong { get; set; } = default!;

    [JsonPropertyName("beamer_address")]
    public string BeamerAddress { get; set; } = default!;

    [JsonPropertyName("visibility")]
    public string Visibility { get; set; } = default!;

    [JsonPropertyName("double_optin")]
    public bool DoubleOptin { get; set; }

    [JsonPropertyName("has_welcome")]
    public bool HasWelcome { get; set; }

    [JsonPropertyName("marketing_permissions")]
    public bool MarketingPermissions { get; set; }

    [JsonPropertyName("modules")]
    public List<object> Modules { get; } = [];

    [JsonPropertyName("stats")]
    public StatsModel Stats { get; set; }

    [JsonPropertyName("_links")]
    public List<LinkModel> Links { get; } = [];
}
