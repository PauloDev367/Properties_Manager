using Domain.ValueObjects;

namespace Application.DTO.Response.Property;

public class CreatedPropertyResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public int TotalBath { get; set; }
    public int TotalKitchen { get; set; }
    public int TotalParkings { get; set; }
    public string MainPhoto { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public CreatedPropertyResponseDto()
    {

    }
    public CreatedPropertyResponseDto(Domain.Entities.Property property)
    {
        CreatedAt = property.CreatedAt;
        Title = property.Title;
        Description = property.Description;
        Id = property.Id;
        MainPhoto = property.MainPhoto;
        Price = property.Price;
        TotalBath = property.TotalBath;
        TotalKitchen = property.TotalKitchen;
        TotalParkings = property.TotalParkings;
    }
}
