using Microsoft.Extensions.Primitives;
using System.Text;
using web_client.Helpers;
using web_client.Models.Base;

namespace web_client.Models.Request.Products;
public class ProductPagingRequest : BaseSearchRequest
{
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
    public bool? Featured { get; set; }
    public bool FeaturedHasValue() => Featured.HasValue;

    private string CategoryKey { get; set; }
    public void SetCategoryKey(string categoryKey)
    {
        if (categoryKey.HasValueString() != true) return;
        CategoryKey = categoryKey;
    }
    public string GetCategoryKey()
    {
        return CategoryKey;
    }

    public IEnumerable<KeyValuePair<string,StringValues>> Attributes { get; set; }
  
    public void SetAttributes(IEnumerable<KeyValuePair<string, StringValues>> attributes)
    {
        if (attributes == null || !attributes.Any()) return;
        Attributes = attributes;
    }
    public IEnumerable<KeyValuePair<string, string>>? GetAttributes()
    {
        if (Attributes == null || !Attributes.Any()) return null;
        var result = new List<KeyValuePair<string, string>>();
        foreach (var attributes in Attributes?.Where(x => !string.IsNullOrEmpty(x.Value)))
        {
            var key = attributes.Key.Replace("p-", "");
            var value = attributes.Value.ToString().Split(",");
            foreach (var item in value)
            {
                result.Add(new KeyValuePair<string, string>(key, item));
            }
        }
        return result;
    }

}
