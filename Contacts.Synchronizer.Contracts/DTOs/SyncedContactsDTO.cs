namespace Contacts.DTOs;

public record SyncedContactsDTO(int SyncedContacts, IReadOnlyCollection<ContactDTO> Contacts);
