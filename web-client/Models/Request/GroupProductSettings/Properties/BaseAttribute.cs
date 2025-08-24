namespace web_client.Models.Request.GroupProductSettings.Properties;

public class BaseAttribute<TValue>
{
    //key : id of propeties "Hãng sản xuất" , value : id of propeties value ex : Omron
    public Dictionary<string, TValue> Properties { get; set; }
}
public class BaseAttribute : BaseAttribute<BaseAttributePropertyValue>
{
}