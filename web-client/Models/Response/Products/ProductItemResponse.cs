using System.Text.Json;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Base.Properties;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.GroupProductSettings.Properties;
using web_client.Models.Request.Products;
using web_client.Models.Response.GroupProductSettings.Properties;

namespace web_client.Models.Response.Products;

public class ProductItemResponse : BaseProduct
{
    public Guid Id { get; set; }
    public Guid GroupProductSetting { get; set; }
    public GroupProductSettingSelectModel? GroupProductSettingModel { get; set; }
    public CategorySelectModel? ProductCategoryModel { get; set; }
    public BaseAttribute? Attribute { get; set; }
    public BaseAttributeResponse? AttributeModel { get; set; }
    public ProductItemResponse() { }
    public ProductItemResponse(Product product)
    {
        if (product == null) return;

        Id = product.Id;
        Name = product.Name;
        ShortDescription = product.ShortDescription;
        Image = product.Image;
        MetaKeyword = product.MetaKeyword;
        MetaTitle = product.MetaTitle;
        MetaShortDescription = product.MetaShortDescription;
        PageKeyName = product.PageKeyName;

        Canonical = product.Canonical;
        Sku = product.Sku;
        Featured = product.Featured;
        Price = product.Price;
        PriceHidden = product.PriceHidden;

        ProductCategory = product.ProductCategory;
        ProductCategoryModel = new CategorySelectModel(ProductCategory);

        GroupProductSetting = product.GroupProductSetting;
        if (GroupProductSetting.HasValueGuid() == true)
            GroupProductSettingModel = new GroupProductSettingSelectModel(GroupProductSetting);

        if (product.Attribute != null)
        {
            //Attribute = product.Attribute.DocumentToObject<BaseAttribute>(new JsonSerializerOptions());
            Attribute = product.Attribute;
            if (Attribute != null)
                AttributeModel = new BaseAttributeResponse(Attribute);
        }

        Status = product.Status;
        if (product.Status?.HasValueString() == true)
            StatusModel = new PredefineDataSelectModel(PredefineDataConst.Status.Group, Status);

        CreatedAt = product.CreatedAt;
        CreatedBy = product.CreatedBy;
        if (product.CreatedBy.HasValueGuid() == true)
            CreatedByModel = new ManagerSelectModel(product.CreatedBy);

        UpdatedAt = product.UpdatedAt;
        UpdatedBy = product.UpdatedBy;
        if (product.UpdatedBy?.HasValueGuid() == true)
            UpdatedByModel = new ManagerSelectModel(product.UpdatedBy.Value);
    }

    public PredefineDataSelectModel? StatusModel { get; set; }
    public Guid CreatedBy { get; set; }
    public ManagerSelectModel? CreatedByModel { get; set; }
    public Guid? UpdatedBy { get; set; }
    public ManagerSelectModel? UpdatedByModel { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}