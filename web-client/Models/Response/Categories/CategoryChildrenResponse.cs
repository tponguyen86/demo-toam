using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.Categories;

namespace web_client.Models.Responses.Categories;

public class CategoryChildrenResponse : BaseCategoryChildrenModel
{
    public Guid Id { get; set; }
    public CategorySelectModel? ParentIdModel { get; set; }

    public PredefineDataSelectModel? StatusModel { get; set; }
    public Guid CreatedBy { get; set; }
    public ManagerSelectModel? CreatedByModel { get; set; }
    public Guid? UpdatedBy { get; set; }
    public ManagerSelectModel? UpdatedByModel { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public CategoryChildrenResponse() { }

    public CategoryChildrenResponse(CategoryDetail categoryDetail)
    {
        if (categoryDetail == null) return;
        Id = categoryDetail.Id;
        Name = categoryDetail.Name;
        ShortDescription = categoryDetail.ShortDescription;
        ParentId = categoryDetail.CategoryId;
        Image = categoryDetail.Image;
        MetaKeyword = categoryDetail.MetaKeyword;
        MetaTitle = categoryDetail.MetaTitle;
        MetaShortDescription = categoryDetail.MetaShortDescription;
        PageKeyName = categoryDetail.PageKeyName;
        Sort = categoryDetail.Sort;
        Status = categoryDetail.Status;
        Hot = categoryDetail.Hot;
        Canonical = categoryDetail.Canonical;

        if (categoryDetail.CategoryId.HasValueGuid() == true)
            ParentIdModel = new CategorySelectModel(categoryDetail.CategoryId);

        if (categoryDetail.Status?.HasValueString() == true)
            StatusModel = new PredefineDataSelectModel(PredefineDataConst.Status.Group, categoryDetail.Status);

        CreatedBy = categoryDetail.CreatedBy;
        CreatedAt = categoryDetail.CreatedAt;
        UpdatedBy = categoryDetail.UpdatedBy;
        UpdatedAt = categoryDetail.UpdatedAt;
        if (categoryDetail.CreatedBy.HasValueGuid() == true)
            CreatedByModel = new ManagerSelectModel(categoryDetail.CreatedBy);

        if (categoryDetail.UpdatedBy?.HasValueGuid() == true)
            UpdatedByModel = new ManagerSelectModel(categoryDetail.UpdatedBy.Value);

    }
}
