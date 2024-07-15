namespace Application.DTO.Response.Property;

public class PropertyPaginationResponseDto
{
    public int PerPage { get; set; }
    public int Page { get; set; }
    public int TotalItems { get; set; }
    public List<PropertyListResponse> Properties { get; set; }
}
