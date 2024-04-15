using System.Text.Json.Serialization;

namespace SocialNGO.Helper.ApiResponse;

/// <summary> </summary>
public class ApiResponseModel
{
    /// <summary></summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int StatusCode { get; set; }

    /// <summary></summary>
    public bool Response { get; set; }

    /// <summary></summary>
    public Object? Data { get; set; }

    /// <summary></summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    /// <summary> </summary>
    public DateTime? TimeStamp { get; set; }

    /// <summary>
    /// Set Default Value of time
    /// </summary>
    public ApiResponseModel()
    {
        TimeStamp = DateTime.UtcNow;
    }
}

