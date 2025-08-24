namespace web_client.Models.Base.Properties;

//key of branch : hang-san-xuat
public class PropertySelectModel : BaseSelectCustomModel
{
    public PropertyValueSelectModel? ValueModel { get; set; }
    public PropertySelectModel(string propertyKey, string propertyValue) : base(propertyKey)
    {
        ValueModel = new PropertyValueSelectModel(propertyValue);
    }
    //public override string ToString()
    //{
    //    return $"[{{\"Code\":\"{Key}\"}}]";
    //}
}
