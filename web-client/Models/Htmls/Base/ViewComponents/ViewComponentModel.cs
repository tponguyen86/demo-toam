namespace web_client.Models.Htmls.Base;

public class ViewComponentModel<TSetting, TData>
{
    public TData Data { get; set; }
    public TData GetData() => this.Data;
    // Name of the partial view. If empty or null, defaults to "default.cshtml"
    public string? ViewName { get; set; } = "default";

    // Request model passed to the view component
    public TSetting ViewSettingRequest { get; set; }

    public ViewComponentModel()
    {
    }

    public ViewComponentModel(TSetting viewSettingRequest)
    {
        ViewSettingRequest = viewSettingRequest ?? throw new ArgumentNullException(nameof(viewSettingRequest));
    }

    public ViewComponentModel(TSetting viewSettingRequest, string? viewName = "default") : this(viewSettingRequest)
    {
        ViewName = viewName;
    }
    public ViewComponentModel(TSetting viewSettingRequest, TData tData, string? viewName = "default") : this(viewSettingRequest, viewName)
    {
        Data = tData;
    }
}

public class ViewComponentModel<TSetting> : ViewComponentModel<TSetting, object>
{
}
