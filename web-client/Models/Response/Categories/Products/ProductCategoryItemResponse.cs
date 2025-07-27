using web_client.Helpers;
using web_client.Models.Base.Properties;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.GroupProductSettings.Properties;
using web_client.Models.Response.Categories;
using web_client.Models.Response.GroupProductSettings.Properties;

namespace web_client.Models.Responses.Categories.Products;

public class ProductCategoryItemResponse : BaseCategoryResponse
{
    public Guid GroupProductSetting { get; set; }
    public GroupProductSettingSelectModel GroupProductSettingModel { get; set; }
    public BaseAttribute? Attribute { get; set; }
    public BaseAttributeResponse? AttributeModel { get; set; }
    public ProductCategoryItemResponse() { }
    public ProductCategoryItemResponse(ProductCategory category) : base(category)
    {
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