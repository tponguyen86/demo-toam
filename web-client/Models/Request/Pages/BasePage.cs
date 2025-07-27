using web_client.Helpers.Shared;
using web_client.Models.Base;

namespace web_client.Models.Request.Pages;

public class BasePage : BaseSeoModel
{
    public string Name { get; set; } = default!;
    public string ShortDescription { get; set; } = default!;
    public Guid? ParentId { get; set; }
    public bool ShowMenu { get; set; }
    public int Sort { get; set; }
}