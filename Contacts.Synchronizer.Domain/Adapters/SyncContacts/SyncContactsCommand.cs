using Contacts.DTOs;

namespace Contacts.Adapters.SyncContacts;
public record SyncContactsCommand(string EventName, IReadOnlyCollection<ContactDTO> Contacts);
