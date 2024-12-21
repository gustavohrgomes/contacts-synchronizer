using System.Text.Json.Serialization;

namespace Contacts.Models;
public class LinkModel
{
    [JsonPropertyName("rel")]
    public string Rel { get; set; } = default!;

    [JsonPropertyName("href")]
    public string Href { get; set; } = default!;

    [JsonPropertyName("method")]
    public string Method { get; set; } = default!;

    [JsonPropertyName("targetSchema")]
    public string TargetSchema { get; set; } = default!;

    [JsonPropertyName("schema")]
    public string Schema { get; set; } = default!;
}
