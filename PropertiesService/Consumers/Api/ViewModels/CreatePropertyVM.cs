using Domain.ValueObjects;

namespace Api.ViewModels;

public class CreatePropertyVM
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public int TotalBath { get; set; }
    public int TotalKitchen { get; set; }
    public int TotalParkings { get; set; }
    public IFormFile MainPhoto { get; set; }
    public List<IFormFile>? Files { get; set; }
}
