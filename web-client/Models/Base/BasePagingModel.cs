namespace web_client.Models.Base;

public class BasePagingModel<T>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }
    public int TotalPage => (int)Math.Ceiling((double)TotalCount / PageSize);
    public IEnumerable<T> Items { get; set; } = [];
}
public class BasePagingModel<T, TData> : BasePagingModel<T>
{
    //send orther data ex: Total Model,...
    public TData Data { get; set; }
    public void SetData(TData data)
    {
        Data = data;
    }
}
