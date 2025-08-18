using web_client.Helpers;

namespace web_client.Models.Base;

public class CategoryChildrenSelectModel : BaseSelectCustomModel
{
    public CategoryChildrenSelectModel(Guid id) : base(id) { }
    //for lookup
    public List<CategorySelectModel> Child { get; set; } = new List<CategorySelectModel>();

    public List<Guid> GetChildId()
    {
        return Child.Select(x => x.Value.GetGuid()).Where(x => x != Guid.Empty).ToList();
    }
    //has current id and child
    public List<Guid> GetAllId()
    {
        var ids = GetChildId();
        var idCurrent = Value.GetGuid();
        if (idCurrent.HasValueGuid() == true)
            ids.Add(idCurrent);
        return ids;
    }
}