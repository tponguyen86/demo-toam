using web_client.Models.Data.Contexts.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class Page : BaseSeo
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
    public bool Configuration { get; set; }
}
