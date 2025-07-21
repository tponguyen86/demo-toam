namespace web_client.Models.Request.GroupProductSettings.Children;

public class BasePropertySelectModel
{
    public Guid? Id { get; set; } = Guid.NewGuid();
    public double? NumberValue { get; set; }
    public string? Value { get; set; }
    public string Name { get; set; } = null!;
    public bool? Number { get; set; } = false;
}
