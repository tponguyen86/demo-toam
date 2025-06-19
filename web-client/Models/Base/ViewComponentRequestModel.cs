namespace web_client.Models.Base;

public class ViewComponentRequestModel<TRequest>
{
    //name of partical ex: if empty => default.cshtml
    public string? ViewName { get; set; }

    //Title ex: Đánh giá từ khách hàng
    public string? Title { get; set; }

    public TRequest ViewRequest { get; set; }
    public ViewComponentRequestModel()
    {
    }
    public ViewComponentRequestModel(TRequest viewRequest)
    {
        ViewRequest = viewRequest;
    }
    public ViewComponentRequestModel(TRequest viewRequest, string viewName) : this(viewRequest)
    {
        ViewName = viewName;
    }
}

public class ViewComponentRequestModel<TRequest, TItems> : ViewComponentRequestModel<TRequest>
{
    public TItems Items { get; set; }
}
