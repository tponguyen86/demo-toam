using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.Categories;

namespace web_client.Models.Responses.Categories;
public class CategoryItemResponse : BaseCategory
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public CategoryProductSelectModel? ParentIdModel { get; set; }

    public bool ShowHome { get; set; }
    public string? ShowType { get; set; }
    public CategoryItemResponse() { }
    public CategoryItemResponse(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        ShortDescription = category.ShortDescription;
        Image = category.Image;
        MetaKeyword = category.MetaKeyword;
        MetaTitle = category.MetaTitle;
        MetaShortDescription = category.MetaShortDescription;
        ShowMenu = category.ShowMenu;
        PageKeyName = category.PageKeyName;
        Type = category.Type;
        Sort = category.Sort ?? 0;
        Status = category.Status;
        Banner = category.Banner;
        ShowHome = category.ShowHome;
        ShowType = category.ShowType;
        Canonical = category.Canonical;

        ParentId = category.ParentId;
        if (category.ParentId?.HasValueGuid()==true)
            ParentIdModel = new CategoryProductSelectModel(category.Id);
        
    }
}
