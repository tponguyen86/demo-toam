using System.Text.Json.Serialization;
using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.Categories;

namespace web_client.Models.Responses.Categories;

public class CategoryDetailResponse : BaseCategory
{
    public Guid Id { get; set; }
    public string Content { get; set; } = default!;
    public string Status { get; set; }
    public bool Hot { get; set; }
    public string ParentTitle { get; set; }

    [JsonIgnore]
    public List<Guid>? ProjectKeys { get; set; }
    public List<BaseSelectModel>? Projects { get; set; }
    [JsonIgnore]
    public List<Guid>? ProductKeys { get; set; }
    public List<BaseSelectModel>? Products { get; set; }

    public CategoryDetailResponse() { }

    public CategoryDetailResponse(CategoryDetail categoryDetail)
    {
        Id = categoryDetail.Id;
        Name = categoryDetail.Name;
        Content = categoryDetail.Content;
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
    }
}
