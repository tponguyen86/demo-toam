namespace web_client.Models.Base;

public class BaseSeoModel
{
    public string PageKeyName { get; set; } = default!;
    public string MetaKeyword { get; set; } = default!;
    public string MetaTitle { get; set; } = default!;
    public string? MetaShortDescription { get; set; }
    public BaseFileModel? Image { get; set; }
    public string? Canonical { get; set; }
}
