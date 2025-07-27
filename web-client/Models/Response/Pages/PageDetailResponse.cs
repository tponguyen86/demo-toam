using web_client.Models.Base;

namespace web_client.Models.Response.Pages;

public class PageDetailResponse : PageItemResponse
{
    public BaseFileModel? Banner { get; set; }

    public bool Configuration { get; set; }
}
