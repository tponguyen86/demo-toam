using web_client.Helpers;

namespace web_client.Models.Base;

public class BaseFileModel
{
    public double? Weight { get; set; }
    public double? Height { get; set; }

    //"file.jpg"
    public string? FileName { get; set; }
    //"something/file.jpg"
    public string? Path { get; set; }

    //png, jpg, pdf, word , base64,...
    public string? Type { get; set; } = "jpg";
    public string? Alt { get; set; }

    public bool IsBase64() => Path != null && (Path?.Split(",")?.Length == 2 && Path.Split(",")[0].Contains("base64"));

    public string GetSourceBase64()
    {
        return Path?.Split(",")?[1] ?? string.Empty;
    }
}
//From Api return client ex: FullPath
public class FileModelResponse : BaseFileModel
{
    //ex: http://.../something/file.jpg,
    public string? FullPath { get; set; }
    public bool ValidForDisplay() => Path?.HasValueString() == true;

    public FileModelResponse(BaseFileModel? file)
    {

        if (file != null)
        {
            FileName = file.FileName;
            Path = file.Path;
            Type = file.Type;
            Alt = file.Alt;
        }
    }
}