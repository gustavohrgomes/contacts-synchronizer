using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Synchronizer.Tests.Integration.ContactsSync;
public class ContactsSyncEndpointTests(ContactsFactory contactsFactory) : IClassFixture<ContactsFactory>
{

    [Fact]
    public async Task SyncContactsAsync_WhenCalled_ReturnsSyncedContactsResponse()
    {

    }
}
