using DataEF;
using Microsoft.AspNetCore.Hosting;

namespace Api.Services;

public class SavePropertyFilesService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly AppDbContext _appDbContext;
    public SavePropertyFilesService(IWebHostEnvironment webHostEnvironment, AppDbContext appDbContext)
    {
        _webHostEnvironment = webHostEnvironment;
        _appDbContext = appDbContext;
    }

    public async Task<string> SaveAsync(IFormFile file) {
        string? filePath = null;
        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "property/pictures");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);
        
        filePath = Path.Combine("uploads/property/pictures", uniqueFileName);
        return filePath;
    }

}
