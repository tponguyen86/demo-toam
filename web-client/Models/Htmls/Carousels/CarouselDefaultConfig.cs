using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Carousels
{
    public class CarouselDefaultConfig : BaseDefaultConfig
    {
        public new Dictionary<string, CarouselSettingOptionModel> Setting { get; set; } = new();
    }
}
