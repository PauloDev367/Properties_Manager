using Domain.ValueObjects;

namespace Application.DTO.Request.Property;

public class CreatePropertyRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public int TotalBath { get; set; }
    public int TotalKitchen { get; set; }
    public int TotalParkings { get; set; }
    public string MainPhoto { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
