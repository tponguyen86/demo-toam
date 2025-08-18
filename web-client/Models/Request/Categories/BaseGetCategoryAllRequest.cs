using web_client.Helpers;

namespace web_client.Models.Request.Categories;

public class BaseGetCategoryAllRequest
{
    public Guid? ParentId { get; set; }
    public bool ParentIdValidate() => ParentId.HasValue && ParentId != Guid.Empty && !TopLevel;
    public void SetParentId(Guid parentId)
    {
        ParentId = parentId;
    }
    public Guid GetParentId() => ParentId ?? Guid.Empty;

    private bool TopLevel { get; set; }
    //when raise event => set pass where parentId
    public void SetTopLevel()
    {
        TopLevel = true;
    }
    public bool GetTopLevel() => TopLevel;

    //ProductCategory, Category,...
    private string? Discriminator { get; set; }
    public bool DiscriminatorHasValue() => Discriminator?.HasValueString() == true;
    public void SetDiscriminator(string discriminator)
    {
        Discriminator = discriminator;
    }

    public string GetDiscriminator() => Discriminator ?? string.Empty;
    public bool? ShowHome { get; set; }
    public bool HasShowHome() => ShowHome.HasValue && ShowHome.Value;

    public bool? ShowMenu { get; set; }
    public bool HasShowMenu() => ShowMenu.HasValue && ShowMenu.Value;
}
