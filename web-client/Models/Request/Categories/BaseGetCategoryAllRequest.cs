namespace web_client.Models.Request.Categories;

public class BaseGetCategoryAllRequest
{
    public Guid? ParentId { get; set; }
    public bool ParentIdHasValue() => ParentId.HasValue && ParentId != Guid.Empty;
    //ProductCategory
    public string? Discriminator { get; set; }
    public bool DiscriminatorHasValue() => !string.IsNullOrEmpty(Discriminator);
    public bool? ShowHome { get; set; }
    public bool HasShowHome() => ShowHome.HasValue && ShowHome.Value;

    public bool? ShowMenu { get; set; }
    public bool HasShowMenu() => ShowMenu.HasValue && ShowMenu.Value;
}
