using Contacts.DTOs;
using Contacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Features.Sync;

public static class ContactsSyncEndpoint
{
    public static WebApplication MapContactsSyncEndpoint(this WebApplication app)
    {
        app.MapGet("/contacts/sync", async ([FromServices] IContactsSyncService syncService) =>
        {
            var result = await syncService.SyncContactsAsync();
            return TypedResults.Ok(result);
        })
        .CacheOutput()
        .WithOpenApi()
        .WithTags("Contacts")
        .WithName("ContactsSync")
        .WithDisplayName("ContactsSync")
        .WithDescription("Used for sync contacts with mail marketing tool")
        .Produces(StatusCodes.Status200OK, typeof(SyncedContactsResponse));

        return app;
    }
}
