namespace web_client.Models.Base;

public class PredefineDataSelectModel : BaseSelectModel
{
    private string Group { get; set; }
    public string GetGroup() => Group;
    public PredefineDataSelectModel(string group, string key) : base(key)
    { Group = group; }
    public override string GetKeyFilter() => $"{Group}{Key}";
    public PredefineDataSelectModel(Guid? id) : base(id) { }
}