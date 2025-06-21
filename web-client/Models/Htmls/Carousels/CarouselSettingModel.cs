namespace web_client.Models.Htmls.Carousels
{
    public class CarouselSettingModel
    {
        public int? AppearAnimationDelay { get; set; } = 500;
        public string? AppearAnimation { get; set; } = "fadeInDownShorter";
        public CarouselSettingOptionModel Option { get; set; } = new CarouselSettingOptionModel();
        public void Merge(CarouselSettingModel other)
        {
            if (other == null) return;

            AppearAnimation = other.AppearAnimation ?? AppearAnimation;
            AppearAnimationDelay = other.AppearAnimationDelay ?? AppearAnimationDelay;
            Option = other.Option ?? Option;
        }

    }
    
    public class CarouselSettingOptionModel
    {
        public int? Items { get; set; }
        public bool? Loop { get; set; }
        public bool? Nav { get; set; }
        public bool? Dots { get; set; }
        public bool? AutoHeight { get; set; }
        public string? AnimateOut { get; set; }

        // Merge another option model into this one
        public void Merge(CarouselSettingOptionModel other)
        {
            if (other == null) return;

            Items = other.Items ?? Items;
            Loop = other.Loop ?? Loop;
            Nav = other.Nav ?? Nav;
            Dots = other.Dots ?? Dots;
            AutoHeight = other.AutoHeight ?? AutoHeight;
            AnimateOut = other.AnimateOut ?? AnimateOut;
        }

    }

}
