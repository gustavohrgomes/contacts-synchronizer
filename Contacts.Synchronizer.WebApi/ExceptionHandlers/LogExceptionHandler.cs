using Microsoft.AspNetCore.Diagnostics;

namespace Contacts.ExceptionHandlers;

public class LogExceptionHandler(ILogger<LogExceptionHandler> logger) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Message with TraceId: {TraceId} failed with error: {Message}", httpContext.TraceIdentifier, exception.Message);
        return ValueTask.FromResult(false);
    }
}
