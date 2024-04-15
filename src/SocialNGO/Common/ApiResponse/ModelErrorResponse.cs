using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace SocialNGO.Helper.ApiResponse;

/// <summary> </summary>
public class ModelErrorResponse
{
    /// <summary> </summary>
    public int StatusCode { get; set; }

    /// <summary> </summary>
    public string? StatusPhrase { get; set; }

    /// <summary> </summary>
    public Guid CorrelationId { get; set; }

    /// <summary> </summary>
    public List<ErrorDetails>? Errors { get; set; }

    /// <summary> </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary></summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static IActionResult GenerateErrorResponse(ActionContext context)
    {
        var apiError = new ModelErrorResponse
        {
            StatusCode = (int)HttpStatusCode.BadRequest,
            StatusPhrase = "Error",
            CorrelationId = new Guid(),
            TimeStamp = DateTime.Now
        };
        var errors = context.ModelState;

        apiError.Errors = context.ModelState
                .Where(e => e.Value!.Errors.Count > 0)
                .Select(e => new ErrorDetails
                {
                    Number = GetRowNumber(e.Key),
                    Name = GetFieldName(e.Key),
                    Message = e.Value!.Errors.First().ErrorMessage
                }).ToList();

        return new BadRequestObjectResult(apiError);
    }

    private static int GetRowNumber(string key)
    {
        if(key.Contains('.'))
            return Convert.ToInt16(key?.Split('.')[0]?.Trim('[', ']')) + 1;

        return 0;
    }
    private static string? GetFieldName(string key)
    {
        if (key.Contains('.'))
            return key?.Split('.')[1];
        
        return key;
    }
}

/// <summary>
/// Error Details To Show Key and Message
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Which Property has issue
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// What is message
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Row Number
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Number { get; set; }
}
