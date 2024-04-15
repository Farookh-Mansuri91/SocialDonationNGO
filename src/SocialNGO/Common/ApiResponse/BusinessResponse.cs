namespace SocialNGO.Helper.ApiResponse;

/// <summary> </summary>
public class BusinessResponse : ApiResponseModel
{
    /// <summary> </summary>
    public BusinessResponse()
    {
            
    }

    /// <summary></summary>
    /// <param name="statusCode"></param>
    /// <param name="response"></param>
    public BusinessResponse(int statusCode, bool response)
    {
        Response = response;
        StatusCode = statusCode;
    }

    /// <summary></summary>
    /// <param name="statusCode"></param>
    /// <param name="response"></param>
    /// <param name="data"></param>
    public BusinessResponse(int statusCode, bool response, Object data) : this (statusCode, response)
    {
        Data = data;
    }

    /// <summary></summary>
    /// <param name="statusCode"></param>
    /// <param name="response"></param>
    /// <param name="message"></param>
    /// <param name="data"></param>
    public BusinessResponse(int statusCode, bool response, Object data, string message) : this (statusCode, response, data)
    {
        Message = message;
    }
}
