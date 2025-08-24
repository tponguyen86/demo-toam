using web_client.Helpers;

namespace web_client.Models.Base.Properties;

//key of branch : hang-san-xuat
public class PropertySelectModel : BaseSelectCustomModel
{
    //omiron, nvidia
    public List<PropertyValueSelectModel>? ValueModel { get; set; }
    public PropertySelectModel(string propertyKey, string propertyValue) : base(propertyKey)
    {
        ValueModel = propertyValue?.Split(",").Where(x => x?.HasValueString() == true).Select(x => new PropertyValueSelectModel(x.Trim())).ToList();
    }
}
