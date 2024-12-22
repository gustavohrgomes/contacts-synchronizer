using System.Text.Json.Serialization;

namespace Contacts.DTOs;

public record ContactDTO
{
    public DateTime? CreatedAt { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Uri? Avatar { get; set; }
    public string? Id { get; set; }
}
