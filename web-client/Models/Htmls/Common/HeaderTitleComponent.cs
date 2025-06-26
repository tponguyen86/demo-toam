using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class HeaderTitleComponent : BaseTitleModel
{
    public string? Description { get; set; }
    public bool ShowDescription { get; set; }
    public HeaderTitleComponent() { }

    public HeaderTitleComponent(string title)
    {
        Title = title;
    }
    public HeaderTitleComponent(string title, string description, bool showDescription = true) : this(title)
    {
        Description = description;
        ShowDescription = showDescription;
    }
}
