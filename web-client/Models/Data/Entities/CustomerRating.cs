using System.ComponentModel.DataAnnotations.Schema;
using ToamManage.Infrastructure.Persistence.Models;
using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class CustomerRating : BaseStatusEntity
{
    public string Title { get; set; }
    public string CustomerName { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    [Column(TypeName = "jsonb")]
    public BaseFileModel Image { get; set; }

}
