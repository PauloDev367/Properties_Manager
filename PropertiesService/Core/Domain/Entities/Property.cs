using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Property
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public int TotalBath { get; set; }
    public int TotalKitchen { get; set; }
    public int TotalParkings { get; set; }
    public List<Image> Images { get; set; }
    public string MainPhoto { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
