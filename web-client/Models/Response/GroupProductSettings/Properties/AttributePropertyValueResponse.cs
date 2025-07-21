using web_client.Models.Request.GroupProductSettings.Properties;

namespace web_client.Models.Response.GroupProductSettings.Properties;

public class AttributePropertyValueResponse : BaseAttributePropertyValue
{
    public AttributePropertyValueResponse() { }
    public AttributePropertyValueResponse(BaseAttributePropertyValue baseValue)
    {
        //PropertyValueId = baseValue.PropertyValueId;
        //PropertyValueIdModel = new PropertyValueSelectModel(PropertyValueId);
    }
}
