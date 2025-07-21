using web_client.Models.Request.GroupProductSettings.Properties;

namespace web_client.Models.Response.GroupProductSettings.Properties;

public class BaseAttributeResponse<TValueModel> : BaseAttribute
{
    //public Dictionary<string, BaseAttributePropertyValue> Properties { get; set; }
    public Dictionary<string, TValueModel> PropertiesModel { get; set; }
    public BaseAttributeResponse()
    {
    }

    public BaseAttributeResponse(BaseAttribute baseAttribute, Func<BaseAttributePropertyValue, TValueModel> converter)
    {
        if (baseAttribute == null) return;
        if (baseAttribute.Properties == null) return;

        Properties = baseAttribute.Properties;
        PropertiesModel = new Dictionary<string, TValueModel>();

        foreach (var property in Properties)
        {
            PropertiesModel.Add(property.Key, converter(property.Value));
        }
    }
}
public class BaseAttributeResponse : BaseAttributeResponse<AttributePropertyValueResponse>
{
    public BaseAttributeResponse(BaseAttribute baseAttribute) : base(baseAttribute, x => new AttributePropertyValueResponse(x))
    {
    }
    //public BaseAttributeResponse(BaseAttribute baseAttribute)
    //{
    //    if (baseAttribute == null) return;
    //    Properties = baseAttribute.Properties;
    //    PropertiesModel = new Dictionary<PropertSelectModel, AttributePropertyValueResponse>();

    //    foreach (var property in Properties)
    //    {
    //        var propertyValueModel = new AttributePropertyValueResponse(property.Value);
    //        PropertiesModel.Add(new PropertSelectModel(property.Key), propertyValueModel);
    //    }
    //}
}
