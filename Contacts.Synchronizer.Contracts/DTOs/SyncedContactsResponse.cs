namespace Contacts.DTOs;

public record SyncedContactsResponse(int SyncedContacts, IReadOnlyCollection<ContactResponse> Contacts);
