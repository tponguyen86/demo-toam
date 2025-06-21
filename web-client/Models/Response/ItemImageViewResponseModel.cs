using web_client.Models.Base;

namespace web_client.Models.Response;

public class ItemImageViewResponseModel : BaseTitleModel
{
    public BaseFileModel? Image { get; set; }
}
