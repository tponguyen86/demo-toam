namespace web_client.Models.Base;
public class BaseSelectCustomModel : BaseSelectModel
{
    public BaseSelectCustomModel() : base() { }

    public BaseSelectCustomModel(string value) : base(value) { }

    public BaseSelectCustomModel(Guid value) : base(value) { }
    public BaseSelectCustomModel(string value, string label) : base(value, label) { }

    public BaseSelectCustomModel(string value, string label, string key) : base(value, label, key) { }
}
