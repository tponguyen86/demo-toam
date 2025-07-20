namespace web_client.Models.Data.Entities.Base;

public interface IBaseEntity
{
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
    Guid CreatedBy { get; set; }
    Guid? UpdatedBy { get; set; }
}
