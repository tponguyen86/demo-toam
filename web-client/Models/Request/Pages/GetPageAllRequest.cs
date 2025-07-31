namespace web_client.Models.Request.Pages;

public class GetPageAllRequest
{
    public bool? ShowHome { get; set; }
    public bool HasShowHome() => ShowHome.HasValue && ShowHome.Value;

    public bool? ShowMenu { get; set; }
    public bool HasShowMenu() => ShowMenu.HasValue && ShowMenu.Value;
}
