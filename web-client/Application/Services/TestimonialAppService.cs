using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Response;

namespace web_client.Application.Services;

public class TestimonialAppService : ITestimonialAppService
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialAppService(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    public Task<List<TestimonialItemModel>?> GetTestimonialsAsync(CancellationToken cancellationToken)
    => _testimonialService.GetTestimonialsAsync(cancellationToken);
}
