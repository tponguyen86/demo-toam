using web_client.Models.Response;

namespace web_client.IServices;

public interface ITestimonialService
{
    Task<List<TestimonialItemModel>?> GetTestimonialsAsync(CancellationToken cancellationToken);
}