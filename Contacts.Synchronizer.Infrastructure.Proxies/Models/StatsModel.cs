using System.Text.Json.Serialization;

namespace Contacts.Models;
public class StatsModel
{
    [JsonPropertyName("member_count")]
    public int MemberCount { get; set; }

    [JsonPropertyName("unsubscribe_count")]
    public int UnsubscribeCount { get; set; }

    [JsonPropertyName("cleaned_count")]
    public int CleanedCount { get; set; }

    [JsonPropertyName("member_count_since_send")]
    public int MemberCountSinceSend { get; set; }

    [JsonPropertyName("unsubscribe_count_since_send")]
    public int UnsubscribeCountSinceSend { get; set; }

    [JsonPropertyName("cleaned_count_since_send")]
    public int CleanedCountSinceSend { get; set; }

    [JsonPropertyName("campaign_count")]
    public int CampaignCount { get; set; }

    [JsonPropertyName("campaign_last_sent")]
    public string CampaignLastSent { get; set; } = default!;

    [JsonPropertyName("merge_field_count")]
    public int MergeFieldCount { get; set; }

    [JsonPropertyName("avg_sub_rate")]
    public int AvgSubRate { get; set; } 

    [JsonPropertyName("avg_unsub_rate")]
    public int AvgUnsubRate { get; set; }

    [JsonPropertyName("target_sub_rate")]
    public int TargetSubRate { get; set; }

    [JsonPropertyName("open_rate")]
    public int OpenRate { get; set; }

    [JsonPropertyName("click_rate")]
    public int ClickRate { get; set; }

    [JsonPropertyName("last_sub_date")]
    public string LastSubDate { get; set; } = default!;

    [JsonPropertyName("last_unsub_date")]
    public string LastUnsubDate { get; set; } = default!;
}
