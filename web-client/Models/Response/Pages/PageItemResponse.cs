using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.Pages;

namespace web_client.Models.Response.Pages;

public class PageItemResponse : BasePage
{
    public Guid Id { get; set; }
    public bool Configuration { get; set; }
    public PageItemResponse()
    {
    }
    public PageItemResponse(Page page)
    {
        Id = page.Id;
        MetaKeyword = page.MetaKeyword;
        MetaShortDescription = page.MetaShortDescription;
        MetaTitle = page.MetaTitle;
        PageKeyName = page.PageKeyName;
        Image = page.Image;
        Code = page.Code;
        Name = page.Name;
        Configuration = page.Configuration;
        Canonical = page.Canonical;
    }
}
