using web_client.Helpers;
using web_client.Models.Base.Properties;
using web_client.Models.Request.GroupProductSettings.Properties;

namespace web_client.Models.Response.GroupProductSettings.Properties;

public class AttributePropertyValueResponse : BaseAttributePropertyValue
{
    //"hang-san-xuat"
    //public string Key { get; set; }
    //branch : key of propeties Code= "hang-san-xuat" Label = "Hãng sản xuất"
    public PropertySelectModel PropertiesModelKey { get; set; }

    //value  of branch :  omron, nvidia
    public PropertyValueSelectModel? ValueModel { get; set; }

    public AttributePropertyValueResponse() { }
    public AttributePropertyValueResponse(string propertyKey, BaseAttributePropertyValue baseValue)
    {
        if (propertyKey.HasValueString() == true)
            PropertiesModelKey = new PropertySelectModel(propertyKey);

        if (baseValue != null)
        {
            if (baseValue?.Value?.HasValueString() == true)
            {
                Value = baseValue.Value;
                ValueModel = new PropertyValueSelectModel(baseValue.Value);
            }
            Type = baseValue?.Type;
        }
    }
}
