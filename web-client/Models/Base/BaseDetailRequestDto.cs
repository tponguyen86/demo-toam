namespace web_client.Models.Base;


public class BaseDetailRequestDto
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public BaseDetailRequestDto()
    {
    }
    public BaseDetailRequestDto(Guid id)
    {
        Id = id;
    }

    public BaseDetailRequestDto(string? code)
    {
        Code = code;
    }

    public BaseDetailRequestDto(Guid id, string? code) : this(id)
    {
        Code = code;
    }

    public bool GetCode() => !string.IsNullOrEmpty(Code);

    public bool ValidateId()
    {
        return Id != Guid.Empty;
    }
    public bool ValidateCode()
    {
        return !string.IsNullOrEmpty(Code);
    }

    public bool Validate()
    {
        return ValidateId() && ValidateCode();
    }
}