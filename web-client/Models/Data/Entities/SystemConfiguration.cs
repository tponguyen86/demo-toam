using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class SystemConfiguration : BaseEntity
{
    public string Name { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string Type { get; set; }
}
