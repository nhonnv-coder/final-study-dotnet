namespace FinalMvcNet.Services.File;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile file);
    bool DeleteImage(string filePath);
}
