using System.Text.Json.Serialization;
using web_client.Helpers.Shared;

namespace web_client.Models.Base;

public record Error(ReturnCode SysCode, string Message)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ReturnCode Code => SysCode;
};
