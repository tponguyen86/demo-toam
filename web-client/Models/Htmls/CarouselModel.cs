namespace web_client.Models.Htmls
{
    public class CarouselModel
    {
        public CarouselOptionModel Option { get; set; } = new CarouselOptionModel();

    }
    public class CarouselOptionModel
    {
        public int? Items { get; set; }
        public bool? Loop { get; set; }
        public bool? Nav { get; set; }
        public bool? Dots { get; set; }
        public bool? AutoHeight { get; set; }

        // Merge another option model into this one
        public void Merge(CarouselOptionModel other)
        {
            if (other == null) return;

            Items = other.Items ?? Items;
            Loop = other.Loop ?? Loop;
            Nav = other.Nav ?? Nav;
            Dots = other.Dots ?? Dots;
            AutoHeight = other.AutoHeight ?? AutoHeight;
        }

    }
}
