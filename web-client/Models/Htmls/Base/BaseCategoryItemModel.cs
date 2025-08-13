using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Models.Htmls.Base;

public class BaseCategoryItemModel : BaseMediaLinkModel
{
    public Guid Id { get; set; }
    public List<BaseCategoryItemModel> Children { get; set; }
    public BaseCategoryItemModel() : base() { }
    public BaseCategoryItemModel(string title, string href) : base(title, href) { }
    public BaseCategoryItemModel(Guid id, string title, string href) : base(title, href) { Id = id; }
    public BaseCategoryItemModel(Guid id, string title, string href, List<BaseCategoryItemModel> children) : this(id, title, href) { Children = children; }

    public BaseCategoryItemModel(CategorySelectModel categorySelectModel)
    {
        if (categorySelectModel == null) return;

        Title = categorySelectModel.Label;

        var data = categorySelectModel.GetDataSelectModel();
        if (data != null)
        {
            Id = data.Id ?? Guid.Empty;
            Media = data.Image?.Path;
            Href = string.Format(RouteConst.GetRoute(RouteConst.ProductCategory), data.PageKeyName);
        }

        //Children = new List<BaseCategoryItemModel>();
    }
    public BaseCategoryItemModel(ProductCategoryItemResponse category)
    {
        if (category == null) return;

        Id = category.Id;
        Title = category.Name;
        Media = category.Image?.Path;
        Href = string.Format(RouteConst.GetRoute(RouteConst.CategoryOfProductDetail), category.PageKeyName);

        if (category?.ChildModel?.Child?.Any()==true)
            Children = category.ChildModel.Child.Select(c => new BaseCategoryItemModel(c)).ToList();
        
    }
}
