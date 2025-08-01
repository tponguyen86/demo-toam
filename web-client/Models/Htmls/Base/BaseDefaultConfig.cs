namespace web_client.Models.Htmls.Base;

public class BaseDefaultConfig: BaseDefaultConfig<object>
{
}
public class BaseDefaultConfig<TValue>
{
    public Dictionary<string, TValue> Setting { get; set; } = new();
}
