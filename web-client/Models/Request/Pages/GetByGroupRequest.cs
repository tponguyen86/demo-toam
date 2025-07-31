using web_client.Helpers;

namespace web_client.Models.Request.Pages;

public class GetByGroupRequest
{
    //group menu
    public string? PageKey { get; set; }
    public bool HasPageKey() => PageKey?.HasValueString() == true;
}
