using web_client.Helpers;
using web_client.Models.Base;

namespace web_client.Models.Request.Categories;

public class GetCategoryAllIdRequest
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    private Guid? ParentId { get; set; }
    public bool ParentIdValidate() => ParentId.HasValue && ParentId != Guid.Empty && ParentId != Id;
    public void SetParentId(Guid parentId)
    {
        ParentId = parentId;
    }
    public Guid GetParentId() => ParentId ?? Guid.Empty;

    //ProductCategory, Category,...
    private string? Discriminator { get; set; }
    public bool DiscriminatorHasValue() => Discriminator?.HasValueString() == true;
    public void SetDiscriminator(string discriminator)
    {
        Discriminator = discriminator;
    }

    public string GetDiscriminator() => Discriminator ?? string.Empty;
    public GetCategoryAllIdRequest()
    {
    }
    public GetCategoryAllIdRequest(Guid id)
    {
        Id = id;
    }

    public GetCategoryAllIdRequest(string? code)
    {
        Code = code;
    }
    public GetCategoryAllIdRequest(BaseDetailRequestDto baseDetailRequest)
    {
        if (baseDetailRequest == null) return;
        Id = baseDetailRequest.Id;
        Code = baseDetailRequest.Code;
    }
}
