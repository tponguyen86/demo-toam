using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class PagingComponent
{
    public List<PagingItemComponent> Links { get; set; } = new List<PagingItemComponent>();
    public int CurrentPage { get; set; }

    public bool ShowFirst { get; set; } = true;
    public bool ShowLast { get; set; } = true;
    public bool ShowPrevious { get; set; } = true;
    public bool ShowNext { get; set; } = true;
    public bool ShowPageNumber { get; set; } = true;
    //more example: for first,previous button..., size Links display, etc.

    public int TotalPages { get; set; }
    public int Limit { get; set; } = 5; // Number of page links to show

    public string UrlFormat { get; set; } = "/page/{0}";
}

public class PagingItemComponent : BaseLinkModel
{
    public bool IsActive { get; set; } = false;
    public bool IsDisabled { get; set; } = false;
}

