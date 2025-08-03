using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Pages;

public class PageDetailResponse : PageItemResponse
{
    public string Description { get; set; }

    public PageDetailResponse():base()
    {
    }
    public PageDetailResponse(Page item) : base(item)
    {
        if (item == null) return;
        Description = item.Description;
    }
}
