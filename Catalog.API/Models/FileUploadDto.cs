using Microsoft.AspNetCore.Http;

namespace Catalog.API.Models;

public class FileUploadDto
{
    public IFormFile File { get; set; }
}
