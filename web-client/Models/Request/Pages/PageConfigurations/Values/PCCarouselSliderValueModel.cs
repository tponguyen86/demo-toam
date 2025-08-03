using web_client.Models.Base;

namespace web_client.Models.Request.Pages.PageConfigurations.Values;

public class PCCarouselSliderValueModel
{
    public BaseFileModel? Image { get; set; }
    public string Title { get; set; }
    public string? ButtonLink { get; set; }
    public string? ButtonText { get; set; }
    public string? Description { get; set; }
}
