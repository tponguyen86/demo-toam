using web_client.Models.Htmls.Base;
using web_client.Models.Htmls.Carousels;

namespace web_client.Models.Htmls.TitleLinks;

public class TitleLinksSettingModel
{
    public bool? TitleDisplay { get; set; } = true;
    public void Merge(TitleLinksSettingModel other)
    {
        if (other == null) return;
        TitleDisplay = other.TitleDisplay ?? TitleDisplay;
    }
}
//For viewcomponent
public class TitleLinksDefaultConfig : BaseDefaultConfig<TitleLinksSettingModel>
{
}
