using web_client.Helpers;

namespace web_client.Models.Request.Categories.Details;

public class GetCategoryDetailRelativeRequest
{
    public Guid Id { get; set; }
    public int PageSize { get; set; } = 5;

    public List<Guid>? Category { get; set; }
    public bool CategoryHasValue() => Category?.Any() == true;
    public void SetCategory(List<Guid>? category)
    {
        if (category?.Any() != true) return;
        Category = category;
    }
    public void AddCategory(Guid category)
    {
        if (category.HasValueGuid() != true) return;
        if (CategoryHasValue() == false)
            Category = new List<Guid>();
        Category.Add(category);
    }
    public List<Guid> GetCategory() => Category ?? new List<Guid>();

    public bool Validate() => Id.HasValueGuid();
    public GetCategoryDetailRelativeRequest(Guid id)
    {
        Id = id;
    }
}
