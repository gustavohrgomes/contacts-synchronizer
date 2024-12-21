namespace Contacts.Models;

public record Contact(DateTime CreatedAt, string FirstName, string LastName, string Email, Uri Avatar, string Id);