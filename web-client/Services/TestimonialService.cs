using web_client.IServices;
using web_client.Models.Base;
using web_client.Models.Response;

namespace web_client.Services;

public class TestimonialService : ITestimonialService
{
    public async Task<List<TestimonialItemModel>?> GetTestimonialsAsync(CancellationToken cancellationToken)
    {
        var bannerModel = new List<TestimonialItemModel>()
            {
                new TestimonialItemModel()
                {
                    Title= "Top 10",
                    Image=new BaseFileModel(){Path="https://img.hoplongtech.com/hoplong/logo-hang/banner-1/top-10-noi-lam-viec.jpg",Alt="Top 10"}
                }, new TestimonialItemModel()
                {
                    Title= "Top 500",
                    Image=new BaseFileModel(){Path="https://img.hoplongtech.com/hoplong/logo-hang/banner-1/hanyoung-nux-1.jpg",Alt="Top 500"}
                }
            };
        await Task.CompletedTask;
        return bannerModel;
    }
}