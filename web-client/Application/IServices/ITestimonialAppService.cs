using web_client.Models.Response;

namespace web_client.Application.IServices;

public interface ITestimonialAppService
{
    Task<List<TestimonialItemModel>?> GetTestimonialsAsync(CancellationToken cancellationToken);
}