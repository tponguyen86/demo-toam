using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Base.Properties;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.Categories.Products;
using web_client.Models.Request.GroupProductSettings.Properties;
using web_client.Models.Response.GroupProductSettings.Properties;

namespace web_client.Models.Responses.Categories.Products;

public class ProductCategoryItemResponse : BaseProductCategory
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public CategoryProductSelectModel? ParentIdModel { get; set; }
    public bool ShowHome { get; set; }
    public string? ShowType { get; set; }
    public Guid GroupProductSetting { get; set; }
    public GroupProductSettingSelectModel GroupProductSettingModel { get; set; }
    public BaseAttribute? Attribute { get; set; }
    public BaseAttributeResponse? AttributeModel { get; set; }
    public ProductCategoryItemResponse() { }
    public ProductCategoryItemResponse(ProductCategory category)
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
        if (category.ParentId?.HasValueGuid() == true)
        {
            ParentIdModel = new CategoryProductSelectModel(category.ParentId.Value); ;
        }

        GroupProductSetting = category.GroupProductSetting;
        if (GroupProductSetting.HasValueGuid() == true)
        {
            GroupProductSettingModel = new GroupProductSettingSelectModel(GroupProductSetting); ;
        }

        if (category.Attribute != null)
        {
            Attribute = category.Attribute.DocumentToObject<BaseAttribute>();
            if (Attribute != null)
                AttributeModel = new BaseAttributeResponse(Attribute);
        }
    }
}