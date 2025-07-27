using web_client.Models.Base;
using web_client.Models.Request.Pages;

namespace web_client.Models.Response.Pages;

public class PageItemResponse : BasePage
{
    public BaseFileModel? Banner { get; set; }

}
