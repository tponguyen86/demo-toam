using web_client.Helpers;

namespace web_client.Models.Base.Properties;

//key of branch : hang-san-xuat
public class PropertySelectModel : BaseSelectCustomModel
{
    //value  of branch :  omron, nvidia
    public List<PropertyValueSelectModel>? ValueModel { get; set; }
    public List<string>? Values { get; set; }
    public PropertySelectModel(string propertyKey, string propertyValue) : base(propertyKey)
    {
        Values = propertyValue?.Split(",").Select(x => x.Trim()).Where(x => x?.HasValueString() == true).Distinct().ToList();
        if (Values?.Count > 0)
            ValueModel = Values.Select(x => new PropertyValueSelectModel(x)).ToList();
    }
}
