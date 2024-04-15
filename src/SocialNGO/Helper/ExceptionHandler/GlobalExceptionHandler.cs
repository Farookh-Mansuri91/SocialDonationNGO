using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace SocialNGO.Helper.ExceptionHandler;

/// <summary> </summary>
internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    /// <summary> </summary>
    /// <param name="logger"></param>
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) => _logger = logger;

    /// <summary></summary>
    /// <param name="httpContext"></param>
    /// <param name="exception"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        var problemDetails = new GenericErrorModel
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server error",
            CorrelationId = Guid.NewGuid(),
            TraceId = traceId,
            Message = exception.Message,
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
/// <summary> </summary>
internal class GenericErrorModel : ProblemDetails
{
    /// <summary> </summary>
    [JsonPropertyOrder(-6)]
    public Guid CorrelationId { get; set; }

    /// <summary></summary>
    public string? TraceId { get; set; }

    public required string? Message { get; set; }
}
