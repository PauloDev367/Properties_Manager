using Application.Image.Ports;
using DataEF;

namespace Application.Image;

public class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;

    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Image> CreateAsync(string path, Guid propertyId)
    {
        var image = new Domain.Entities.Image
        {
            PropertyId = propertyId,
            Path = path,
        };
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();

        return image;
    }
}
