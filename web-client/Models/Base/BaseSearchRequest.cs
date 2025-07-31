using web_client.Helpers;
using web_client.Helpers.Shared;

namespace web_client.Models.Base;

public abstract class BaseSearchRequest
{
    public BaseSearchRequest() { }

    public string? KeySearch { get; set; }
    public string? SortColumn { get; set; }
    public string? SortType { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    //default is active for frontend
    public string? Status { get; set; } = PredefineDataConst.Status.Key.Active;

    public int GetPage()
    {
        return Page > 0 ? Page : 1;
    }
    public int GetPageSize()
    {
        return PageSize > 0 ? PageSize : 10;
    }
    public virtual void ModifySort()
    {
        if (string.IsNullOrEmpty(SortColumn))
        {
            SortColumn = "Id";
        }
        if (string.IsNullOrEmpty(SortType))
        {
            SortType = "asc";
        }
    }
    public bool HasKeySearch()
    {
        return !string.IsNullOrEmpty(KeySearch);
    }
    public bool HasStatus()
    {
        return !string.IsNullOrEmpty(Status);
    }
    public string GetKeySearch()
    {
        return string.IsNullOrEmpty(KeySearch) ? "" : KeySearch.ToLower().ConvertToUnsign();
    }
}
